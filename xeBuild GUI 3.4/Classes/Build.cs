using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using xeBuild_GUI.x360utils.NAND;

namespace xeBuild_GUI
{
    class build
    {
        ArrayList errorstrings = new ArrayList();
        prepare prep = new prepare();
        delegate void SetTextCallback(string text);
        Process proc;
        int errorlevel = 0;
        public static bool runit = true, procrunning = false, xebuild = false, ecctype = false;
        public string param = "", cxebuild = "", gpatch = "", spec = "", cini = "", source = "", output = "";
        Thread movethread, outreader, errreader;
        private readonly X360NAND _x360NAND = new X360NAND();
        public void initbuild(string[] settings)
        {
            procrunning = true;
            #region Common declarations/settings
            errorlevel = 0;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            DateTime now = DateTime.Now;
            outtab.rtb.AppendText("==================================\n");
            outtab.rtb.AppendText(" Swizzy's xeBuild GUI version " + Main.version + "\n");
            outtab.rtb.AppendText(" Log Started: " + day.ToString() + " " + now.ToString() + "\n");
            outtab.rtb.AppendText("==================================\n");
            outtab.rtb.AppendText("\n");
            outtab.rtb.AppendText(" *** Some console information ***\n");
            FileInfo fi = new FileInfo(Main.statc.source.Text);
            if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
            {
                try { outtab.rtb.AppendText("CB Version: " + Main.nand.getcbversion(settings[0]) + "\n"); }
                catch { outtab.rtb.AppendText("ERROR: Unable to get CB version!"); }
            }
            else
            {
                try { outtab.rtb.AppendText("CB Version: " + Main.nand.getcbversioncorona4g(settings[0]) + "\n"); }
                catch { outtab.rtb.AppendText("ERROR: Unable to get CB version!"); }
            }
            proc = new Process();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            #endregion
            #region ECC
            if (settings[2].StartsWith("ecc", StringComparison.CurrentCultureIgnoreCase))
            {
                xebuild = false;
                if (File.Exists(Main.dir + "\\files\\ecc\\python.exe"))
                {
                    outtab.rtb.AppendText("\n");
                    outtab.rtb.AppendText("\n");
                    Directory.CreateDirectory(Main.dir + "\\files\\ecc\\output\\");
                    errorlevel = prep.prepecc();
                    proc.StartInfo.FileName = Main.dir + "\\files\\ecc\\python.exe";
                    proc.StartInfo.WorkingDirectory = Main.dir + "\\files\\ecc\\";
                    if (settings[2].Equals("ecc", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (File.Exists(Main.dir + "\\files\\ecc\\build.py"))
                        {
                            param = "build.py nanddump.bin ";
                            #region CB shit
                            if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                            {
                                int cbval = Main.nand.getcbversion(Main.dir + "\\files\\ecc\\nanddump.bin");
                                if (cbval == 6751) { param += "cb\\cb_6750.bin "; }
                                else if (cbval == 9230) { param += "cb\\cba_9188.bin cb\\cbb_9188.bin cb\\cbb_9230.bin "; }
                                else if ((cbval == 1940) || (cbval == 1923)) { if (MessageBox.Show("Do you want to use CB 7375 instead of your current one? (you have 1940), It MAY be faster to glitch using 7375 rather then " + cbval.ToString() + "...", "Use CB 7375 instead?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { param += "cb\\cba_7375.bin "; } }                                
                            }
                            else
                            {
                                int cbval = Main.nand.getcbversioncorona4g(Main.dir + "\\files\\ecc\\nanddump.bin");
                                if (cbval == 6751) { param += "cb\\cb_6750.bin "; }
                                else if (cbval == 9230) { param += "cb\\cba_9188.bin cb\\cbb_9188.bin cb\\cbb_9230.bin "; }
                                else if ((cbval == 1940) || (cbval == 1923)) { if (MessageBox.Show("Do you want to use CB 7375 instead of your current one? (you have 1940), It MAY be faster to glitch using 7375 rather then " + cbval.ToString() + "...", "Use CB 7375 instead?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { param += "cb\\cba_7375.bin "; } }
                            }
                            #endregion
                            if (!settings[3].Equals("trinity", StringComparison.CurrentCultureIgnoreCase)) { param += "cd\\CDjasper"; }
                            else { param += "cd\\CD"; }
                            param += " xell-gggggg.bin";
                        }
                        else { MessageBox.Show("ERROR: Unable to find RGH ECC Build script! (build.py)", "ERROR - No build.py found", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else 
                    {
                        if (File.Exists(Main.dir + "\\files\\ecc\\build2.py"))
                        {
                            param = "build2.py nanddump.bin";
                            if (!settings[5].Equals("DD88AD0C9ED669E7B56794FB68563EFA", StringComparison.CurrentCultureIgnoreCase))
                            {
                                SetText("Changing 1BLKey for build script...\n");
                                byte[] keybytes = Main.misc.cpukeytoarray(settings[5]);
                                File.WriteAllBytes(Main.dir + "\\files\\ecc\\1blkey.bin", keybytes);
                            }
                            if (!string.IsNullOrEmpty(settings[4]))
                            {
                                SetText("Adding CPUKey to build script...\n");
                                byte[] keybytes = Main.misc.cpukeytoarray(settings[4]);
                                File.WriteAllBytes(Main.dir + "\\files\\ecc\\cpukey.bin", keybytes);
                            }
                        }
                        else { MessageBox.Show("ERROR: Unable to find RGH 2.0 ECC Build script! (build2.py)", "ERROR - No build2.py found", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    if (errorlevel == 0)
                    {
                        paramedit();
                        outtab.rtb.AppendText("\nParameters sent to python:\n\n" + param + "\n\n");
                        outtab.rtb.AppendText("Building nand using build.py (this may take a while):\n\n");
                    }
                }
                else
                {
                    outtab.rtb.AppendText("ERROR: Can't find python! make sure you've unpacked all files!\n");
                    errorlevel++;
                }
            }
            #endregion
            #region xeBuild
            else
            {
                xebuild = true;
                param = "";
                cxebuild = "";
                if (File.Exists(Main.dir + "\\files\\xebuild.exe"))
                {
                    try
                    {
                        if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                        {
                            Main.nand.getkv_smc(Main.statc.source.Text);
                            Main.kv = Main.crypt.DecryptKV(Main.enckv, settings[4]);
                            if (Main.crypt.kvcheck(Main.kv, settings[4]))
                            {
                                string[] kvinf = Main.mright.getkvinfo();
                                SetText("Serial number: " + kvinf[0] + "\n");
                                SetText("Console region: " + kvinf[1] + "\n");
                                SetText("DVDKey: " + kvinf[2] + "\n");
                                SetText("Console ID: " + kvinf[3] + "\n");
                                SetText("MFR-Date: " + kvinf[4] + "\n");
                                SetText("OSIG String: " + kvinf[5] + "\n");
                                SetText("FCRT.bin Required: " + kvinf[6] + "\n\n");
                            }
                            else { SetText("ERROR: Unable to decrypt KV using specified CPUKey!\nThis means the log will NOT contain information from your keyvault, it can be caused by etheir badkey or badblock/corrupt keyvault"); }
                        }
                        else
                        {
                            using (var reader2 = new NANDReader(Main.statc.source.Text))
                            {
                                var kv = _x360NAND.GetKeyVault(reader2, Main.statc.cpukey.Text);
                                var kvinfo = new xeBuild_GUI.x360utils.NAND.Keyvault();

                                SetText("Serial number: " + kvinfo.GetConsoleSerial(ref kv) + "\n");
                                SetText("\nConsole region: " + kvinfo.GetGameRegion(ref kv, true));
                                SetText("DVDKey: " + kvinfo.GetDVDKey(ref kv) + "\n");
                                SetText("\nConsole ID: " + kvinfo.GetConsoleID(ref kv) + "\n");
                                SetText("\nMFR-Date: " + kvinfo.GetMfrDate(ref kv, Keyvault.DateFormats.DDMMYY));
                                SetText("OSIG String: " + kvinfo.GetOSIGData(ref kv) + "\n");

                                if (kvinfo.FCRTRequired(ref kv) == true)
                                {
                                    SetText("FCRT.bin Required: TRUE" + "\n\n");
                                }
                                else
                                {
                                    SetText("FCRT.bin Required: FALSE" + "\n\n");
                                }
                            }
                        }
                    }
                    catch { }
                    proc.StartInfo.FileName = Main.dir + "\\files\\xebuild.exe";
                    proc.StartInfo.WorkingDirectory = Main.dir + "\\files\\";
                    #region xeBuild Custom Settings
                    if (settings[12].Equals("true", StringComparison.CurrentCultureIgnoreCase))
                    {
                        outtab.rtb.AppendText("Adding custom xeBuild Settings... ");
                        if (Main.xeset.getxebuild())
                        {
                            foreach (KeyValuePair<string, string> pair in Main.xebuildsettings)
                            {
                                if ((!string.IsNullOrEmpty(pair.Value)) && (pair.Value != "none"))
                                {
                                    if (!pair.Value.Equals("false", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        if (pair.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            cxebuild += " -o " + pair.Key;
                                        }
                                        else
                                        {
                                            if (pair.Key != "cfldv")
                                            {
                                                cxebuild += " -o " + pair.Key + "=" + pair.Value;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            errorlevel++;
                            MessageBox.Show("ERROR: Check your custom xeBuild settings there seems to be a problem with them!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (errorlevel == 0) { outtab.rtb.AppendText("Done!\n"); }
                        else { outtab.rtb.AppendText("FAILED!\nPlease check your custom xebuild settings before starting build next time!\n"); }
                    }
                    #endregion
                    errorlevel = prep.prepother(settings);
                    #region glitch patchsmc
                    if (settings[2].StartsWith("glitch", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (!prep.glitchsmccheck())
                        {
                            gpatch = " -o patchsmc ";
                        }
                    }
                    else { gpatch = ""; }
                    #endregion
                    spec = prep.addspecialxebuild(settings[3]);
                    #region custom ini/patch
                    if (settings[13].Equals("true", StringComparison.CurrentCultureIgnoreCase))
                    {
                        outtab.rtb.AppendText("Adding custom ini/patch files switch...");
                        if (!String.IsNullOrEmpty(settings[14]))
                        {
                            cini += " -i " + settings[14];
                            outtab.rtb.AppendText("Done!\n");
                        }
                        else
                        {
                            outtab.rtb.AppendText("FAILED!\nERROR: You have to specify a name for your custom ini/patch files!\n");
                        }
                    }
                    #endregion
                    if (!String.IsNullOrEmpty(settings[15]))
                    {
                        cxebuild += " -o cfldv=" + settings[15] + " ";
                    }
                    param = "-noenter -t " + settings[2] + " -c " + settings[3] + " -d data -f " + settings[6] + " -b " + settings[5] + " -p " + settings[4] + " " + gpatch + " " + cxebuild + " " + spec + " " + cini + " output.bin";
                    param = System.Text.RegularExpressions.Regex.Replace(param, "  ", " ");
                    if (errorlevel == 0)
                    {
                        paramedit();
                        outtab.rtb.AppendText("\nParameters sent to xeBuild:\n\n" + param + "\n\n");
                        outtab.rtb.AppendText("Building nand using xeBuild (this may take a while):\n\n");
                    }
                }
                else
                {
                    outtab.rtb.AppendText("ERROR: Can't find xeBuild.exe! make sure you've unpacked ALL files!");
                    errorlevel++;
                }
            }
            #endregion
            #region Run it
            if (errorlevel == 0)
            {
                proc.StartInfo.Arguments = param;
                proc.Start();
                errorstrings.Clear();
                outreader = new Thread(new ThreadStart(readout));
                errreader = new Thread(new ThreadStart(readerr));
                outreader.Start();
                errreader.Start();
                while (!proc.HasExited)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
                if (outreader.IsAlive)
                {
                    while (outreader.IsAlive)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
                if (errreader.IsAlive)
                {
                    while (errreader.IsAlive)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
                int exit = proc.ExitCode;
                if (exit == 0)
                {
                    if (settings[2].StartsWith("ecc", StringComparison.CurrentCultureIgnoreCase)) 
                    {
                        moveoutput(Main.dir + "\\files\\ecc\\output\\image_00000000.ecc", settings[1]);
                        NandproSet.eccfile = settings[1];
                    }
                    else 
                    {
                        moveoutput(Main.dir + "\\files\\output.bin", settings[1]);
                        NandproSet.binfile = settings[1];
                    }
                    while (movethread.IsAlive)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                    if (errorlevel == 0) { outtab.rtb.AppendText("Done!\n"); }
                    else { outtab.rtb.AppendText("FAILED!\nERROR: Unable to move output file to your destination directory!\n"); }
                }
                else if ((exit == 1) && (xebuild))
                {
                    errorlevel++;
                    outtab.rtb.AppendText("xeBuild ERROR: usage/commandline error\n");
                    MessageBox.Show("ERROR: There seems to have been a bug, or input error from you, please send me the file \"debug.log\" to admin@swizzy.se so that i may fix the bug, if there is one...", "xeBuild ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if ((exit == 2) && (xebuild))
                {
                    errorlevel++;
                    outtab.rtb.AppendText("xeBuild ERROR: file write error\n");
                    MessageBox.Show("ERROR: There was a write error, so there is no output from xebuild! please check your disk that it has ennuf space (minimum 512mb)", "xeBuild ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if ((exit == 3) && (xebuild))
                {
                    errorlevel++;
                    outtab.rtb.AppendText("xeBuild ERROR: image build error\n");
                    MessageBox.Show("ERROR: There was an error with the build process, check the log at files\\output.bin.log for more information (if you didn't run verbose mode)", "xeBuild ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    errorlevel++;
                    if (xebuild) { outtab.rtb.AppendText("xeBuild ERROR: Unkown exitcode ("+ exit.ToString() +")!\n"); }
                    else { outtab.rtb.AppendText("ERROR: Unkown error! exitcode: " + exit.ToString() + "\n"); }
                    MessageBox.Show("ERROR: Unkown error, check the log!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (errorlevel != 0)
            {
                outtab.rtb.SelectionColor = Color.Red;
                outtab.rtb.SelectedText = "ERROR: There was one or more fatal errors: " + errorlevel.ToString() + " errors during the build process\n";
                outtab.rtb.SelectionColor = SystemColors.ControlText;
            }
            end(settings);
            if (errorlevel != 0)
            {
                Main.debug(settings);
            }
            procrunning = false;
            #endregion            
        }
        private void paramedit()
        {
            if ((!Main.ezmode) && (Main.mright.paramedit.Checked))
            {
                runit = false;
                ParamEdit paramform = new ParamEdit();
                paramform.Show();
                while (!runit)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
            }
        }
        private void SetText(string text)
        {
            if (outtab.rtb.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                outtab.rtb.Invoke(d, new object[] { text });
            }
            else
            {
                if (!text.EndsWith("\n")) { outtab.rtb.AppendText(text + "\n"); }
                else { outtab.rtb.AppendText(text); }
                outtab.rtb.SelectionStart = outtab.rtb.Text.Length;
                outtab.rtb.ScrollToCaret();
            }
        }
        private void SetText2(string text)
        {
            if (outtab.rtb.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText2);
                outtab.rtb.Invoke(d, new object[] { text });
            }
            else 
            {
                outtab.rtb.AppendText(text);
                outtab.rtb.SelectionStart = outtab.rtb.Text.Length;
                outtab.rtb.ScrollToCaret();
            }
        }
        private void setbold(string text)
        {
            if (outtab.rtb.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setbold);
                outtab.rtb.Invoke(d, new object[] { text });
            }
            else 
            {
                outtab.rtb.SelectionFont = new Font(outtab.rtb.Font, FontStyle.Bold);
                outtab.rtb.SelectedText = text;
            }
        }
        private void cleanecc()
        {
            try
            {
                if (File.Exists(Main.dir + "\\files\\ecc\\nanddump.bin")) { File.Delete(Main.dir + "\\files\\ecc\\nanddump.bin"); }
                if (File.Exists(Main.dir + "\\files\\ecc\\1blkey.bin")) { File.Delete(Main.dir + "\\files\\ecc\\1blkey.bin"); }
                if (File.Exists(Main.dir + "\\files\\ecc\\cpukey.bin")) { File.Delete(Main.dir + "\\files\\ecc\\cpukey.bin"); }
                if (Directory.Exists(Main.dir + "\\files\\temp\\")) { Directory.Delete(Main.dir + "\\files\\temp\\", true); }
                SetText2("Done!\n");
            }
            catch { SetText2("FAILED!\n"); }
        }
        private void cleanxebuild()
        {
            try
            {
                if (File.Exists(Main.dir + "\\files\\data\\nanddump.bin")) { File.Delete(Main.dir + "\\files\\data\\nanddump.bin"); }
                if (File.Exists(Main.dir + "\\files\\data\\kv.bin")) { File.Delete(Main.dir + "\\files\\data\\kv.bin"); }
                if (File.Exists(Main.dir + "\\files\\data\\smc_config.bin")) { File.Delete(Main.dir + "\\files\\data\\smc_config.bin"); }
                if (File.Exists(Main.dir + "\\files\\data\\smc.bin")) { File.Delete(Main.dir + "\\files\\data\\smc.bin"); }
                if (File.Exists(Main.dir + "\\files\\data\\fcrt.bin")) { File.Delete(Main.dir + "\\files\\data\\fcrt.bin"); }
                if (File.Exists(Main.dir + "\\files\\xell-2f.bin")) { File.Delete(Main.dir + "\\files\\xell-2f.bin"); }
                if (File.Exists(Main.dir + "\\files\\xell-gggggg.bin")) { File.Delete(Main.dir + "\\files\\xell-gggggg.bin"); }
                if (File.Exists(Main.dir + "\\files\\launch.ini")) { File.Delete(Main.dir + "\\files\\launch.ini"); }
                if (File.Exists(Main.dir + "\\files\\launch.xex")) { File.Delete(Main.dir + "\\files\\launch.xex"); }
                if (File.Exists(Main.dir + "\\files\\lhelper.xex")) { File.Delete(Main.dir + "\\files\\lhelper.xex"); }
                if (Directory.Exists(Main.dir + "\\files\\temp\\")) { Directory.Delete(Main.dir + "\\files\\temp\\", true); }
                SetText2("Done!\n");
            }
            catch { SetText2("FAILED!\n"); }
        }
        private void moveoutput(string input, string dest)
        {
            source = input;
            output = dest;
            movethread = new Thread(new ThreadStart(mover));
            movethread.Start();
            while (movethread.IsAlive)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
        }
        private void mover()
        {
            SetText2("\n\nMoving output to your destination directory... ");
            try 
            {
                if (File.Exists(output)) { File.Delete(output); }
                File.Move(source, output); 
            }
            catch { errorlevel++; }
        }
        private void end(string[] settings)
        {
            ecctype = settings[2].Equals("ecc", StringComparison.CurrentCultureIgnoreCase);
            Thread last = new Thread(new ThreadStart(endthread));
            last.Start();
            while (last.IsAlive)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            #region Auto Log
            if ((settings[16].Equals("true", StringComparison.CurrentCultureIgnoreCase)) && (!string.IsNullOrEmpty(settings[17])))
            {
                settings[17] = System.Text.RegularExpressions.Regex.Replace(settings[17], "\\\\+", "\\");
                if (!Directory.Exists(Path.GetDirectoryName(settings[17]))) { settings[17] = Path.GetDirectoryName(settings[1]) + "\\" + settings[17]; }
                settings[17] = System.Text.RegularExpressions.Regex.Replace(settings[17], "\\\\+", "\\");
                if (outtab.logsave(settings[17]))
                {
                    DialogResult result = MessageBox.Show("Do you want to Close the program (Yes), Clear the log (No) or leave it the way it is (Cancel)?", "What do you want to do now?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)  { Application.Exit(); }
                    else if (result == DialogResult.No) { outtab.rtb.Text = ""; }
                }
                else { MessageBox.Show("ERROR: Unable to autosave log!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (settings[16].Equals("true", StringComparison.CurrentCultureIgnoreCase))
            {
                if (outtab.logsave(Path.GetDirectoryName(settings[1]) + "\\xeBuild_GUI.log"))
                {
                    DialogResult result = MessageBox.Show("Do you want to Close the program (Yes), Clear the log (No) or leave it the way it is (Cancel)?", "What do you want to do now?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) { Application.Exit(); } 
                    else if (result == DialogResult.No) { outtab.rtb.Text = ""; }
                }
                else { MessageBox.Show("ERROR: Unable to autosave log!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            #endregion
        }
        private void endthread()
        {
            foreach (object obj in errorstrings) { if (obj != null) { SetText2(obj as string); } }
            SetText2("Cleaning data and temporary directories... ");
            if (ecctype) { cleanecc(); }
            else { cleanxebuild(); }
            setbold("\n\n       ****** The app has now finished! ******\n\n");
            System.Media.SystemSounds.Beep.Play();
        }
        private void readout()
        {
            string line = "";
            using (StreamReader sr = proc.StandardOutput)
            {
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        SetText(line);
                    }
                }
            }
        }
        private void readerr()
        {
            string line = "";
            using (StreamReader sr = proc.StandardError)
            {
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        errorstrings.Add(line + "\n");
                    }
                }
            }
        }
    }
}