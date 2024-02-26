using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using xeBuild_GUI.x360utils.NAND;

namespace xeBuild_GUI
{
    class prepare
    {
        string source = "";
        int errorlevel = 0;
        delegate void SetTextCallback(string text);
        public static Extract extract = new Extract();
        public int prepecc()
        {
            errorlevel = 0;
            outtab.rtb.AppendText("Copying nand to ecc directory, this may take a while... ");
            Thread copy = new Thread(new ThreadStart(copyecc));
            source = Main.statc.source.Text;
            copy.Start();
            while (copy.IsAlive)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            return errorlevel;
        }
        private void copyecc()
        {
            try
            {
                File.Copy(source, Main.dir + "\\files\\ecc\\nanddump.bin", true);
                SetText("Done!\n");
            }
            catch
            {
                SetText("FAILED!\n");
                errorlevel++;
            }
        }
        private void SetText(string text)
        {
            if (outtab.rtb.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                outtab.rtb.Invoke(d, new object[] { text });
            }
            else { outtab.rtb.AppendText(text); }
        }
        public int prepother(string[] config) 
        {
            errorlevel = 0;
            #region xell
            if (!config[7].Equals("customxell", StringComparison.CurrentCultureIgnoreCase))
            {
                #region non-xellreloaded
                if (config[7] != "xellreloaded")
                {
                    outtab.rtb.AppendText("Using: " + config[7] + "\n");
                    try { File.Copy(Main.dir + "\\files\\xell\\" + config[7] + ".bin", Main.dir + "\\files\\xell-2f.bin", true); }
                    catch
                    {
                        outtab.rtb.AppendText("ERROR Copying of: " + config[7] + " FAILED\n");
                        errorlevel++;
                    }
                }
                #endregion
                #region xellreloaded - glitch
                else if (config[2].StartsWith("glitch", StringComparison.CurrentCultureIgnoreCase))
                {
                    outtab.rtb.AppendText("Using xell-reloaded for Glitch hack\n");
                    try { File.Copy(Main.dir + "\\files\\xell\\Xellreloaded_glitch.bin", Main.dir + "\\files\\xell-gggggg.bin", true); }
                    catch
                    {
                        outtab.rtb.AppendText("ERROR: Copying of xell-reloaded FAILED\n");
                        errorlevel++;
                    }
                }
                #endregion
                #region xellreloaded JTAG
                else if (config[2].Equals("JTAG", StringComparison.CurrentCultureIgnoreCase))
                {
                    outtab.rtb.AppendText("Using xell-reloaded for JTAG/SMC hack\n");
                    try { File.Copy(Main.dir + "\\files\\xell\\Xellreloaded_jtag.bin", Main.dir + "\\files\\xell-2f.bin", true); }
                    catch
                    {
                        outtab.rtb.AppendText("ERROR: Copying of xell-reloaded FAILED\n");
                        errorlevel++;
                    }
                }
                #endregion
            }
            else if (config[7].Equals("customxell", StringComparison.CurrentCultureIgnoreCase))
            {
                outtab.rtb.AppendText("Using custom Xell\n");
                #region custom Xell - Glitch
                if (config[2].Equals("glitch", StringComparison.CurrentCultureIgnoreCase))
                {
                    try { File.Copy(Main.dir + "\\xell.bin", Main.dir + "\\files\\xell-gggggg.bin", true); }
                    catch
                    {
                        outtab.rtb.AppendText("ERROR: Cannot create a Glitch image without xell! defaulting to xell-reloaded!\n");
                        try { File.Copy(Main.dir + "\\files\\xell\\Xellreloaded_glitch.bin", Main.dir + "\\files\\xell-gggggg.bin", true); }
                        catch
                        {
                            outtab.rtb.AppendText("ERROR: Copying of xell-reloaded FAILED\n");
                            errorlevel++;
                        }
                    }
                }
                #endregion
                #region custom Xell - JTAG
                else if (config[2].Equals("JTAG", StringComparison.CurrentCultureIgnoreCase))
                {
                    try { File.Copy(Main.dir + "\\xell.bin", Main.dir + "\\files\\xell-2f.bin", true); }
                    catch
                    {
                        outtab.rtb.AppendText("ERROR: Cannot create a JTAG image without xell! defaulting to xell-reloaded!\n");
                        try { File.Copy(Main.dir + "\\files\\xell\\Xellreloaded_jtag.bin", Main.dir + "\\files\\xell-2f.bin", true); }
                        catch
                        {
                            outtab.rtb.AppendText("ERROR: Copying of xell-reloaded FAILED\n");
                            errorlevel++;
                        }
                    }
                }
                #endregion
            }
            #endregion
            #region SMC
            switch (config[8])
            {
                #region Aud_clamp SMC's
                case "aud_clamp":
                    outtab.rtb.AppendText("Copying Aud_clamp patched SMC... ");
                    try
                    {
                        File.Copy(Main.dir + "\\files\\smc\\jtag\\aud_clamp.bin", Main.dir + "\\files\\data\\smc.bin", true);
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\nERROR: Could not copy aud_clamp patched SMC! defaulting to current!\n"); }
                    break;
                case "aud_clamp2":
                    outtab.rtb.AppendText("Copying Aud_clamp + Eject patched SMC... ");
                    try
                    {
                        File.Copy(Main.dir + "\\files\\smc\\jtag\\aud_clamp2.bin", Main.dir + "\\files\\data\\smc.bin", true);
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\nERROR: Could not copy aud_clamp + eject patched SMC! defaulting to current!\n"); }
                    break;
                #endregion
                #region Cygnos v2
                case "cygnos":
                    outtab.rtb.AppendText("Copying Cygnos v2 patched SMC... ");
                    if (!config[3].StartsWith("jasper", StringComparison.CurrentCultureIgnoreCase))
                    {
                        try
                        {
                            File.Copy(Main.dir + "\\files\\smc\\cygnos\\" + config[3] + ".bin", Main.dir + "\\files\\data\\smc.bin", true);
                            outtab.rtb.AppendText("Done!\n");
                        }
                        catch { outtab.rtb.AppendText("FAILED!\nERROR: Could not copy Cygnos v2 SMC! defaulting to current!\n"); }
                    }
                    else
                    {
                        try
                        {
                            File.Copy(Main.dir + "\\files\\smc\\cygnos\\jasper.bin", Main.dir + "\\files\\data\\smc.bin", true);
                            outtab.rtb.AppendText("Done!\n");
                        }
                        catch { outtab.rtb.AppendText("FAILED!\nERROR: Could not copy Cygnos v2 SMC! defaulting to current!\n"); }
                    }
                    break;
                #endregion
                #region alternative Cygnos v2
                case "cygnos2":
                    outtab.rtb.AppendText("Copying alternative Cygnos v2 patched SMC... ");
                    try
                    {
                        File.Copy(Main.dir + "\\files\\smc\\cygnos\\" + config[3] + "2.bin", Main.dir + "\\files\\data\\smc.bin", true);
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\nERROR: Could not copy alternative Cygnos v2 SMC! defaulting to current!\n"); }
                    break;
                #endregion
                #region normal SMC Hack (OLD)
                case "normal":
                    outtab.rtb.AppendText("Copying Normal (Old) hack patched SMC... ");
                    try
                    {
                        if (config[3] == "xenon") { File.Copy(Main.dir + "\\files\\smc\\jtag\\xenon.bin", Main.dir + "\\files\\data\\smc.bin", true); }
                        else { File.Copy(Main.dir + "\\files\\smc\\jtag\\normal.bin", Main.dir + "\\files\\data\\smc.bin", true); }
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\nERROR: Could not copy Normal (Old) hack patched SMC! defaulting to current!\n"); }
                    break;
                #endregion
                #region custom/other SMC
                default:
                    #region Custom SMC
                    if ((File.Exists(Main.dir + "\\smc.bin") && (config[8].Equals("customsmc", StringComparison.CurrentCultureIgnoreCase))))
                    {
                        outtab.rtb.AppendText("Copying custom SMC.bin... ");
                        #region non-retail
                        if (!config[2].Equals("retail", StringComparison.CurrentCultureIgnoreCase))
                        {
                            try
                            {
                                File.Copy(Main.dir + "\\smc.bin", Main.dir + "\\files\\data\\smc.bin", true);
                                outtab.rtb.AppendText("Done!\n");
                            }
                            catch { outtab.rtb.AppendText("FAILED!\nERROR: Could not copy custom SMC! defaulting to current!\n"); }
                        }
                        #endregion
                        #region retail
                        else
                        {
                            try
                            {
                                File.Copy(Main.dir + "\\smc.bin", Main.dir + "\\files\\data\\smc.bin", true);
                                outtab.rtb.AppendText("Done!\n");
                            }
                            catch
                            {
                                outtab.rtb.AppendText("FAILED!\nERROR: Could not copy custom SMC! defaulting to included retail SMC!\n Copying Retail SMC for " + config[3] + "... ");
                                try
                                {
                                    if ((config[3] != "xenon") && (config[3] != "trinity")) { File.Copy(Main.dir + "\\files\\smc\\retail\\hdmi_multi.bin", Main.dir + "\\files\\data\\smc.bin", true); }
                                    else { File.Copy(Main.dir + "\\files\\smc\\retail\\" + config[3] + ".bin", Main.dir + "\\files\\data\\smc.bin", true); }
                                    outtab.rtb.AppendText("Done!\n");
                                }
                                catch { outtab.rtb.AppendText("FAILED!\nERROR: Could not copy included retail SMC! defaulting to current!\n"); }
                            }
                        }
                        #endregion
                    }
                    #endregion
                    #region Retail SMC
                    else if (config[2].Equals("retail", StringComparison.CurrentCultureIgnoreCase))
                    {
                        outtab.rtb.AppendText("Copying Retail SMC for " + config[3] + "... ");
                        try
                        {
                            if ((config[3] != "xenon") && (config[3] != "trinity") && (config[3] != "corona")) { File.Copy(Main.dir + "\\files\\smc\\retail\\hdmi_multi.bin", Main.dir + "\\files\\data\\smc.bin", true); }
                            else { File.Copy(Main.dir + "\\files\\smc\\retail\\" + config[3] + ".bin", Main.dir + "\\files\\data\\smc.bin", true); }
                            outtab.rtb.AppendText("Done!\n");
                        }
                        catch { outtab.rtb.AppendText("FAILED!\nERROR: Could not copy included retail SMC! defaulting to current!\n"); }
                    }
                    #endregion
                    #region Leftover removal
                    else
                    {
                        if (File.Exists(Main.dir + "\\files\\data\\smc.bin"))
                        {
                            outtab.rtb.AppendText("Deleting leftover SMC... ");
                            try { File.Delete(Main.dir + "\\files\\data\\smc.bin"); outtab.rtb.AppendText("Done!\n"); }
                            catch { outtab.rtb.AppendText("Failed!\n"); errorlevel++; }
                        }
                    }
                    #endregion
                    break;
                #endregion
            }
            #endregion
            #region Dashlaunch
            if ((config[2].Equals("retail", StringComparison.CurrentCultureIgnoreCase)) || (config[2].Equals("devkit", StringComparison.CurrentCultureIgnoreCase)))
            {
                config[9] = "false";
            }
            if (config[9].Equals("true", StringComparison.CurrentCultureIgnoreCase))
            {
                if (Main.mright.dlbeta.Checked)
                {
                    outtab.rtb.AppendText("Including BETA version of dashlaunch... ");
                    try
                    {
                        File.Copy(Main.dir + "\\files\\dlaunchbeta\\launch.xex", Main.dir + "\\files\\launch.xex", true);
                        File.Copy(Main.dir + "\\files\\dlaunchbeta\\lhelper.xex", Main.dir + "\\files\\lhelper.xex", true);
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\n"); }
                }
                else
                {
                    outtab.rtb.AppendText("Including dashlaunch... ");
                    try
                    {
                        File.Copy(Main.dir + "\\files\\dlaunch\\launch.xex", Main.dir + "\\files\\launch.xex", true);
                        File.Copy(Main.dir + "\\files\\dlaunch\\lhelper.xex", Main.dir + "\\files\\lhelper.xex", true);
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\n"); }
                }
            }
            else
            {
                outtab.rtb.AppendText("dashlaunch NOT included...\n");
                if (File.Exists(Main.dir + "\\files\\launch.xex"))
                {
                    try
                    {
                        outtab.rtb.AppendText("Removing previous launch.xex...");
                        File.Delete(Main.dir + "\\files\\launch.xex");
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\n"); }
                }
                if (File.Exists(Main.dir + "\\files\\lhelper.xex"))
                {
                    try
                    {
                        outtab.rtb.AppendText("Removing lhelper.xex... ");
                        File.Delete(Main.dir + "\\files\\lhelper.xex");
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\n"); }
                }
                if (File.Exists(Main.dir + "\\files\\launch.ini"))
                {
                    try
                    {
                        outtab.rtb.AppendText("Removing previous launch.ini...");
                        File.Delete(Main.dir + "\\files\\launch.ini");
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\n"); }
                }
            }
            if ((config[10].Equals("true", StringComparison.CurrentCultureIgnoreCase)) && (config[9].Equals("true", StringComparison.CurrentCultureIgnoreCase)))
            {
                outtab.rtb.AppendText("Including custom dashlaunch settings (launch.ini)... ");
                try
                {
                    File.Copy(Main.dir + "\\launch.ini", Main.dir + "\\files\\launch.ini", true);
                    outtab.rtb.AppendText("Done!\n");
                }
                catch { outtab.rtb.AppendText("FAILED!\nERROR: Failed to copy launch.ini! dashlaunch defaults will be used...\n"); }
            }
            else
            {
                if (config[9].Equals("true", StringComparison.CurrentCultureIgnoreCase))
                {
                outtab.rtb.AppendText("dashlaunch defaults will be used...\n");
                }
                if (File.Exists(Main.dir + "\\files\\launch.ini"))
                {
                    outtab.rtb.AppendText("Removing custom dashlaunch settings (launch.ini)... ");
                    try
                    {
                        File.Delete(Main.dir + "\\files\\launch.ini");
                        outtab.rtb.AppendText("Done!\n");
                    }
                    catch { outtab.rtb.AppendText("FAILED!\n"); }
                }
            }
            #endregion
            #region Nanddumpcopy
            if (!Main.mright.extvital.Checked)
            {
                outtab.rtb.AppendText("Copying nand to data directory, this may take a while... ");
                Thread copy = new Thread(new ThreadStart(copyxebuild));
                source = config[0];
                copy.Start();
                while (copy.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
            }
            else
            {
                FileInfo fi = new FileInfo(Main.statc.source.Text);
                if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                {
                    outtab.rtb.AppendText("Checking for already extracted vitals...\n");
                    #region Keyvault
                    outtab.rtb.AppendText("Looking for kv.bin in data folder...\n");
                    if (!File.Exists(Main.dir + "\\files\\data\\kv.bin"))
                    {
                        if (!File.Exists(Main.dir + "\\kv.bin"))
                        {
                            errorlevel++;
                            outtab.rtb.AppendText("ERROR: Unable to find previously extracted kv.bin!\nTrying to extract keyvault from current nand... ");
                            Main.nand.getkv_smc(config[0]);
                            Main.kv = Main.crypt.DecryptKV(Main.enckv, config[4]);
                            if (Main.crypt.kvcheck(Main.kv, config[4]))
                            {
                                try
                                {
                                    Main.nand.savekv(Main.dir + "\\files\\data", Main.kv);
                                    outtab.rtb.AppendText("Successfully extracted keyvault!\n");
                                    errorlevel--;
                                }
                                catch { outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract Decrypted KV, check key and/or keyvault block!\n"); }
                            }
                            else { outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract Decrypted KV, check key and/or keyvault block!\n"); }
                        }
                        else
                        {
                            outtab.rtb.AppendText("ERROR: Unable to find previously extracted kv.bin!\nCopying donor keyvault from main directory... ");
                            try
                            {
                                File.Copy(Main.dir + "\\kv.bin", Main.dir + "\\files\\data\\kv.bin");
                                outtab.rtb.AppendText("Done!\n");
                            }
                            catch
                            {
                                errorlevel++;
                                outtab.rtb.AppendText("FAILED!\nERROR: Unable to copy donor kv.bin!\nTrying to extract keyvault from current nand... ");
                                Main.nand.getkv_smc(config[0]);
                                Main.kv = Main.crypt.DecryptKV(Main.enckv, config[4]);
                                if (Main.crypt.kvcheck(Main.kv, config[4]))
                                {
                                    Main.nand.savekv(Main.dir + "\\files\\data", Main.kv);
                                    outtab.rtb.AppendText("Successfully extracted keyvault!\n");
                                    errorlevel--;
                                }
                                else { outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract Decrypted KV, check key and/or keyvault block!\n"); }
                            }
                        }
                    }
                    #endregion
                    #region SMC
                    outtab.rtb.AppendText("Looking for smc.bin in data folder...\n");
                    if (!File.Exists(Main.dir + "\\files\\data\\smc.bin"))
                    {
                        errorlevel++;
                        outtab.rtb.AppendText("ERROR: Unable to find previously extracted smc.bin!\nTrying to extract keyvault from current nand... ");
                        try
                        {
                            Main.nand.getkv_smc(config[0]);
                            Main.smc = Main.crypt.DecryptSMC(Main.encsmc);
                            if (Main.smc.Length > 1)
                            {
                                Main.nand.savesmc(Main.dir + "\\files\\data", Main.smc);
                                outtab.rtb.AppendText("Successfully extracted SMC!\n");
                                errorlevel--;
                            }
                            else { outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract Decrypted SMC!\n"); }
                        }
                        catch { outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract Decrypted SMC!\n"); }
                    }
                    else { outtab.rtb.AppendText("Found SMC.bin!\n"); }
                    #endregion
                    #region SMC_Config
                    outtab.rtb.AppendText("Looking for smc_config.bin in data folder...\n");
                    if (!File.Exists(Main.dir + "\\files\\data\\smc_config.bin"))
                    {
                        if (!File.Exists(Main.dir + "\\smc_config.bin"))
                        {
                            errorlevel++;
                            outtab.rtb.AppendText("ERROR: Unable to find previously extracted smc_config.bin!\nTrying to extract smc_config.bin from current nand... ");
                            try
                            {
                                byte[] conf = Main.nand.dump_conf(config[0]);
                                if (conf.Length > 1)
                                {
                                    Main.nand.saveconfig(Main.dir + "\\files\\data", conf);
                                    outtab.rtb.AppendText("Successfully extracted SMC_Config!\n");
                                    errorlevel--;
                                }
                                else { outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract SMC_Config!\n"); }
                            }
                            catch { outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract SMC_Config!\n"); }
                        }
                        else
                        {
                            outtab.rtb.AppendText("ERROR: Unable to find previously extracted smc_config.bin!\nCopying donor smc_config.bin from main directory... ");
                            try
                            {
                                File.Copy(Main.dir + "\\smc_config.bin", Main.dir + "\\files\\data\\smc_config.bin");
                                outtab.rtb.AppendText("Done!\n");
                            }
                            catch
                            {
                                outtab.rtb.AppendText("FAILED!\nTrying to extract smc_config.bin from current nand... ");
                                errorlevel++;
                                try
                                {
                                    byte[] conf = Main.nand.dump_conf(config[0]);
                                    if (conf != null)
                                    {
                                        Main.nand.saveconfig(Main.dir + "\\files\\data", conf);
                                        outtab.rtb.AppendText("Successfully extracted SMC_Config!\n");
                                        errorlevel--;
                                    }
                                }
                                catch { outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract SMC_Config!\n"); }
                            }
                        }
                    }
                    else { outtab.rtb.AppendText("Found smc_config.bin!\n"); }
                    #endregion
                    #region FCRT.bin
                    if ((!Main.mright.nofcrt.Checked) && ((config[3].Equals("trinity", StringComparison.CurrentCultureIgnoreCase)) || (config[3].Equals("corona", StringComparison.CurrentCultureIgnoreCase))))
                    {
                        outtab.rtb.AppendText("Looking for fcrt.bin in data folder...\n");
                        if (!File.Exists(Main.dir + "\\files\\data\\fcrt.bin"))
                        {
                            outtab.rtb.AppendText("ERROR: Unable to find previously extracted fcrt.bin!\nTrying to extract fcrt.bin from current nand... ");
                            try
                            {
                                byte[] data = Main.nand.get_fcrt(config[0]);
                                if (data.Length > 1)
                                {
                                    File.WriteAllBytes(Main.dir + "\\files\\data\\fcrt.bin", data);
                                    outtab.rtb.AppendText("Successfully extracted fcrt.bin!\n");
                                }
                                else
                                {
                                    outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract fcrt.bin!\n");
                                    outtab.rtb.AppendText("*** WARNING: Due to this error you MAY experience problems with playing game discs in your disc drive...");
                                }
                            }
                            catch
                            {
                                outtab.rtb.AppendText("FAILED!\nERROR: Unable to extract fcrt.bin!\n");
                                outtab.rtb.AppendText("*** WARNING: Due to this error you MAY experience problthatäems with playing game discs in your disc drive...");
                            }
                        }
                        else { outtab.rtb.AppendText("Found fcrt.bin!\n"); }
                    }
                    #endregion
                }
                else
                {
                    outtab.rtb.AppendText("Extracting Files...\n");
                    extract.extractFilesFromNand(Main.statc.source.Text, Main.statc.output.Text, Main.statc.cpukey.Text);
                    outtab.rtb.AppendText("Files Extracted :)\n");
                    outtab.rtb.AppendText("Copying nand to data directory, this may take a while... ");
                    Thread copy = new Thread(new ThreadStart(copyxebuild));
                    source = config[0];
                    copy.Start();
                    while (copy.IsAlive)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
            }
            #endregion
            return errorlevel;
        }
        public string addxebuildopt()
        {
            string ret = "";
            foreach (string s in Main.xeset.xebuildsettings.Lines)
            {
                string[] tmp = s.Split('=');
                if ((!string.IsNullOrEmpty(tmp[0])) && (!string.IsNullOrEmpty(tmp[1])))
                {
                    if ((!tmp[1].Trim().Equals("false", StringComparison.CurrentCultureIgnoreCase)) && (!tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase)))
                    {
                        ret += "-o " + tmp[0].Trim() + "=" + tmp[1].Trim() + " ";
                    }
                    else if (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase))
                    {
                        ret += "-o " + tmp[0].Trim() + " ";
                    }
                }
            }
            if (!string.IsNullOrEmpty(ret)) { ret = ret.Trim(); }
            return ret;
        }
        private void copyxebuild()
        {
            try
            {
                File.Copy(source, Main.dir + "\\files\\data\\nanddump.bin", true);
                SetText("Done!\n");
            }
            catch
            {
                SetText("FAILED!\n");
                errorlevel++;
            }
        }
        public bool glitchsmccheck()
        {
            outtab.rtb.AppendText("Checking if SMC is Glitch or Retail...\n");
            if (!File.Exists(Main.dir + "\\files\\data\\smc.bin"))
            {
                outtab.rtb.AppendText("Dumping current SMC... ");
                try
                {
                    Main.nand.getkv_smc(Main.statc.source.Text);
                    Main.smc = Main.crypt.DecryptSMC(Main.encsmc);
                    outtab.rtb.AppendText("Done!\n");
                }
                catch { outtab.rtb.AppendText("FAILED!\n"); }
            }
            else
            {
                outtab.rtb.AppendText("Reading " + Main.dir + "\\files\\data\\smc.bin into memory... ");
                try
                {
                    using (BinaryReader br = new BinaryReader(File.Open(Main.dir + "\\files\\data\\smc.bin", FileMode.Open, FileAccess.Read)))
                    {
                        Main.smc = new byte[br.BaseStream.Length];
                        for (int i = 0; i < br.BaseStream.Length; i++)
                        {
                            Main.smc[i] = br.ReadByte();
                        }
                    }
                    outtab.rtb.AppendText("Done!\n");
                }
                catch { outtab.rtb.AppendText("FAILED!\n"); }
            }
            outtab.rtb.AppendText("Checking SMC...\n");
            if (Main.test.smctype(Main.smc).Equals("retail", StringComparison.CurrentCultureIgnoreCase))
            {
                outtab.rtb.AppendText("SMC is Retail!\nAdding patchsmc to xebuild options!\n");
                return false;
            }
            else
            {
                outtab.rtb.AppendText("SMC is Glitch patched! it will be used the way it is...\n");
                return true;
            }
        }
        public string addspecialxebuild(string mobo)
        {
            string ret = "";
            if (Main.mright.nomu.Checked)
            {
                outtab.rtb.AppendText("Disabling onboard Memory Unit...\n");
                ret += " -a nomu ";
            }
            if (Main.mright.notrinmu.Checked)
            {
                outtab.rtb.AppendText("Disabling internal Memory Unit...\n");
                ret += " -a notrinmu ";
            }
            if (Main.mright.nohdd.Checked)
            {
                outtab.rtb.AppendText("Disabling Harddrives...\n");
                ret += " -a nohdd ";
            }
            if (Main.mright.nofcrt.Checked)
            {
                outtab.rtb.AppendText("Disabling FCRT.bin check...\n");
                ret += " -a nofcrt ";
            }
            if (Main.mright.nohdmiwait.Checked && !mobo.Equals("xenon", StringComparison.CurrentCultureIgnoreCase))
            {
                outtab.rtb.AppendText("Disabling HDMI Handshake blockage (no longer waiting for HDMI Handshake to finnish during boot)...\n");
                ret += " -a nohdmiwait ";
            }
            if (Main.xeset.verbose.Checked)
            {
                outtab.rtb.AppendText("Enabling Verbose mode output for xeBuild...\n");
                ret += " -v ";
            }
            return ret;
        }
    }
}