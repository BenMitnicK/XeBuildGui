using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace xeBuild_GUI
{
    public partial class Nandpro : Form
    {
        #region Declarations
        public static GroupBox dump;
        int error = 0, matchcount = 0;
        delegate void SetTextCallback(string text);
        public static string workdir = "", file = "", npversion = "", args = "", file1 = "", file2 = "";
        bool blockout = false, runit = true, skip = false;
        public static bool updskip = true;
        public static RichTextBox rtb;
        public static TextBox fbl, tbl, conf, wnand;
        public static ComboBox dmpt;
        public static Thread outreader;
        private string[] dumpnames;
        Color txtcolor = Color.Black;
        Process proc;
        string size;
        #endregion
        #region Static Functions
        public Nandpro() 
        {
            InitializeComponent();
            rtb = outbox;
            conf = flashconfig;
            dump = sizebox;
            fbl = fromblock;
            tbl = toblock;
            wnand = worknand;
            dmpt = dumptimes;
        }
        private void clrbtn_Click(object sender, EventArgs e) { outbox.Text = ""; }
        private void ctrlfix(object sender, KeyEventArgs e) { Main.test.ctrlfix(sender, e); }
        private void hexin(object sender, KeyPressEventArgs e) { Main.test.hexinput(sender, e); }
        private void outbox_TextChanged(object sender, EventArgs e) { logcontrols.Enabled = (outbox.Text.Length > 0); }
        private void SetText(string text)
        {
            try
            {
                if (Nandpro.rtb.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    Nandpro.rtb.Invoke(d, new object[] { text });
                }
                else
                {
                    if (!text.EndsWith("\n"))
                    {
                        Nandpro.rtb.AppendText(text + "\n");
                    }
                    else
                    {
                        Nandpro.rtb.AppendText(text);
                    }
                    Nandpro.rtb.SelectionStart = Nandpro.rtb.Text.Length;
                    Nandpro.rtb.ScrollToCaret();
                }
            }
            catch { }
        }
        private void SetColor(string text)
        {
            try
            {
                if (Nandpro.rtb.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetColor);
                    Nandpro.rtb.Invoke(d, new object[] { text });
                }
                else
                {
                    Nandpro.rtb.SelectionColor = txtcolor;
                    Nandpro.rtb.SelectedText = text;
                    Nandpro.rtb.SelectionStart = Nandpro.rtb.Text.Length;
                    Nandpro.rtb.ScrollToCaret();
                }
            }
            catch { }
        }
        private void SetFlash(string text)
        {
            try
            {
                if (Nandpro.conf.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetFlash);
                    Nandpro.conf.Invoke(d, new object[] { text });
                }
                else
                {
                    Nandpro.conf.Text = text.Substring(14, text.Length - 14);
                }
            }
            catch { }
        }
        private void selectbtn_Click(object sender, EventArgs e)
        {
            selectnand.Title = "Select NAND to work with";
            if (selectnand.ShowDialog() == DialogResult.OK)
            {
                worknand.Text = selectnand.FileName;
            }
            selectnand.FileName = "nand.bin";
        }
        private void worknand_TextChanged(object sender, EventArgs e)
        {
            ecctobinbtn.Enabled = (File.Exists(worknand.Text));
            remapbtn.Enabled = (File.Exists(worknand.Text));
        }
        private void runproc()
        {
            outreader = new Thread(new ThreadStart(outputhandler));
            nandop.Enabled = false;
            hwop.Enabled = false;
            sizebox.Enabled = false;
            proc = new Process();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            Directory.CreateDirectory(workdir);
            proc.StartInfo.WorkingDirectory = workdir;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.FileName = Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe";
            if (File.Exists(Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe"))
            {
                SetText("Using nandpro version: " + npversion + "\n");
                SetText("Nandpro commandline sent: " + args + "\n");
                proc.Start();
                outreader.Start();
                while (!proc.HasExited)
                {
                    nandproact.Active = true;
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
                while (outreader.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
                nandproact.Active = false;
            }
            else { MessageBox.Show("ERROR: Unable to find the nandpro version you've selected!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            nandop.Enabled = true;
            hwop.Enabled = true;
            sizebox.Enabled = true;
        }
        private void outputhandler()
        {
            string line = "";
            using (StreamReader sr = proc.StandardOutput)
            {
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        try { int.Parse(line, System.Globalization.NumberStyles.HexNumber); }
                        catch
                        {
                            if (!blockout)
                            {
                                SetText(line);
                                if (line.StartsWith("flash config:", StringComparison.CurrentCultureIgnoreCase)) { SetFlash(line); }
                            }
                        }
                    }
                }
            }
        }
        private bool FileCompare(string file1, string file2)
        {
            if ((File.Exists(file1)) && (File.Exists(file2)))
            {
                int file1byte, file2byte;
                FileStream fs1, fs2;
                if (file1 == file2)
                {
                    return true;
                }
                fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
                fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);
                if (fs1.Length != fs2.Length)
                {
                    fs1.Close();
                    fs2.Close();
                    return false;
                }
                do
                {
                    file1byte = fs1.ReadByte();
                    file2byte = fs2.ReadByte();
                }
                while ((file1byte == file2byte) && (file1byte != -1));
                fs1.Close();
                fs2.Close();
                return ((file1byte - file2byte) == 0);
            }
            else  { return false;  }
        }
        private void compare()
        {
            if (FileCompare(file1, file2)) { SetColor("Success!\n"); matchcount++; }
            else { SetColor("Failed!\n"); error++; }
        }
        private string getdumpname(int time)
        {
            savenand.FileName = "dump" + (time + 1).ToString() + ".bin";
            savenand.Title = "Select what name to give to dump number: " + (time + 1).ToString();
            if (savenand.ShowDialog() == DialogResult.OK) { return savenand.FileName; }
            else { return null; }
        }
        private void getsize()
        {
            foreach (Control c in sizebox.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked) { size = rb.Name.Substring(1); }
                }
            }
        }
        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] currset = new string[10];
            currset[0] = NandproSet.workdir;
            try
            {
                currset[1] = NandproSet.filenames[0];
                currset[2] = NandproSet.filenames[1];
                currset[3] = NandproSet.filenames[2];
                currset[4] = NandproSet.filenames[3];
            }
            catch { }
            currset[5] = NandproSet.device;
            currset[6] = NandproSet.npvers;
            currset[7] = NandproSet.size;
            currset[8] = NandproSet.dumptimes;
            currset[9] = NandproSet.workfile;
            bool isopen = false;
            foreach (Form a in Application.OpenForms)
            {
                if (a is NandproSettings)
                {
                    isopen = true;
                    a.Visible = true;
                    a.TopMost = true;
                    a.Focus();
                    a.BringToFront();
                    a.TopMost = false;
                    NandproSettings.settings = currset;
                }
            }
            if (isopen == false)
            {
                NandproSettings nandform = new NandproSettings(currset);
                nandform.Show();
            }
        }
        private void savelogbtn_Click(object sender, EventArgs e)
        {
            if (savelog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = new string[1];
                if (File.Exists(savelog.FileName)) { lines = File.ReadAllLines(savelog.FileName); }
                using (StreamWriter sw = new StreamWriter(savelog.FileName))
                {
                    if (lines.Length > 1) { foreach (string s in lines) { sw.WriteLine(s); } }
                    foreach (string s in outbox.Lines) { sw.WriteLine(s); }
                }
            }
            savelog.FileName = "nandpro.log";
        }
        #endregion
        private void ecctobinbtn_Click(object sender, EventArgs e)
        {
            blockout = true;
            getsize();
            NandproSet.workfile = worknand.Text;
            if (string.IsNullOrEmpty(NandproSet.eccfile))
            {
                openecc.Title = "Select ECC to write to NAND image";
                if (openecc.ShowDialog() == DialogResult.OK)
                {
                    NandproSet.eccfile = openecc.FileName;
                    runit = true;
                }
                openecc.FileName = "image_00000000.ecc";
            }
            else
            {
                DialogResult res = MessageBox.Show("Do you want to use pre-selected ECC file?\n\n(" + NandproSet.eccfile + ")", "Use pre-selected ECC?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) { runit = true; }
                else if (res == DialogResult.No)
                {
                    NandproSet.eccfile = "";
                    runit = false;
                    ecctobinbtn_Click(sender, e);
                }
                else { runit = false; }
            }
            if (runit)
            {
                npversion = "20b";
                status.Text = "Writing ECC to NAND image..."; 
                workdir = Path.GetDirectoryName(NandproSet.workfile) + "\\";
                file = Path.GetFileName(NandproSet.workfile);
                NandproSet.binfile = NandproSet.workfile;
                try
                {
                    if (NandproSet.eccfile != workdir + "image.ecc") { File.Copy(NandproSet.eccfile, workdir + "\\image.ecc", true); }
                    args = "\"" + file + "\": +w" + size + " image.ecc";
                    runproc();
                    if (File.Exists(Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe"))
                    {
                        while (!proc.HasExited)
                        {
                            Application.DoEvents();
                            Thread.Sleep(100);
                        }
                    }
                    status.Text = "Done! Waiting for further instructions...";
                    System.Media.SystemSounds.Beep.Play();
                }
                catch
                {
                    MessageBox.Show("There was an error with your request!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status.Text = "ERROR!";
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }
            blockout = false;
        }
        private void writeeccbtn_Click(object sender, EventArgs e)
        {
            getsize();
            if (string.IsNullOrEmpty(NandproSet.eccfile))
            {
                openecc.Title = "Select ECC to write to NAND";
                if (openecc.ShowDialog() == DialogResult.OK)
                {
                    NandproSet.eccfile = openecc.FileName;
                    runit = true;
                }
                else { runit = false; }
                openecc.FileName = "image_00000000.ecc";
            }
            else
            {
                DialogResult res = MessageBox.Show("Do you want to use pre-selected ECC file?\n\n(" + NandproSet.eccfile + ")", "Use pre-selected ECC?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) { runit = true; }
                else if (res == DialogResult.No)
                {
                    NandproSet.eccfile = "";
                    writeeccbtn_Click(sender, e);
                }
                else { runit = false; }
            }
            if (runit)
            {
                npversion = NandproSet.npvers;
                status.Text = "Writing ECC to NAND...";
                workdir = Path.GetDirectoryName(NandproSet.eccfile) + "\\";
                file = Path.GetFileName(NandproSet.eccfile);
                try
                {
                    args = NandproSet.device + ": +w" + size + " \"" + Path.GetFileName(NandproSet.eccfile) + "\"";
                    runproc();
                    if (File.Exists(Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe"))
                    {
                        while (!proc.HasExited)
                        {
                            Application.DoEvents();
                            Thread.Sleep(100);
                        }
                    }
                    status.Text = "Done! Waiting for further instructions...";
                    System.Media.SystemSounds.Beep.Play();
                }
                catch
                {
                    MessageBox.Show("There was an error with your request!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status.Text = "ERROR!";
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }
        }
        private void flashcpldbtn_Click(object sender, EventArgs e)
        {
            if (NandproSet.npvers != "custom") { npversion = "30a"; }
            else { npversion = NandproSet.npvers; }
            opencpld.Title = "Select which xsvf file to write to your CPLD";
            opencpld.InitialDirectory = Main.dir + "\\files\\nandpro\\cpldfiles\\";
            if (opencpld.ShowDialog() == DialogResult.OK)
            {
                status.Text = "Flashing your CPLD...";
                workdir = Path.GetDirectoryName(opencpld.FileName) + "\\";
                file = Path.GetFileName(opencpld.FileName);
                args = "xsvf: " + "\"" + file + "\"";
                runproc();
                if (File.Exists(Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe"))
                {
                    while (!proc.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
                status.Text = "Done! Waiting for further instructions...";
                System.Media.SystemSounds.Beep.Play();
            }
        }
        private void erasebtn_Click(object sender, EventArgs e)
        {
            getsize();
            npversion = NandproSet.npvers;
            if (MessageBox.Show("Are you sure you want to erase your nand? this WILL remove ANY data from your motherboard!! make sure you have a valid dump BEFORE you erase it!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Directory.CreateDirectory(Main.dir + "\\files\\temp\\");
                workdir = Main.dir + "\\files\\temp\\";
                status.Text = "Erasing nand!";
                args = NandproSet.device + ": -e" + size;
                runproc();
                if (File.Exists(Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe"))
                {
                    while (!proc.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
                status.Text = "Done! Waiting for further instructions...";
                System.Media.SystemSounds.Beep.Play();
            }
        }
        private void comparebtn_Click(object sender, EventArgs e)
        {
            getsize();
            error = 0;
            if (selectnand.ShowDialog() == DialogResult.OK)
            {
                file1 = selectnand.FileName;
                if (selectnand.ShowDialog() == DialogResult.OK)
                {
                    status.Text = "Checking dumps...";
                    file2 = selectnand.FileName;
                    rtb.AppendText("Checking the dumps against eachother! this may take a little while...\n");
                    rtb.AppendText("The check returned: ");
                    Thread test = new Thread(new ThreadStart(compare));
                    test.Start();
                    nandproact.Active = true;
                    while (test.IsAlive)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                    nandproact.Active = false;
                    status.Text = "Done! Waiting for further instructions...";
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            if (error != 0) { MessageBox.Show("ERROR: The dumps don't match!\ncheck your soldering and try to dump it again\nerrors like this are often caused by bad soldering\n you can also try using CMD command: \"FC /b dump1.bin dump2.bin\" to get information about where the differences are\nsometimes it could be something like moving a cable a little that is causing the problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void writenandbtn_Click(object sender, EventArgs e)
        {
            getsize();
            selectnand.Title = "Select NAND file to write...";
            if (string.IsNullOrEmpty(NandproSet.binfile))
            {
                if (selectnand.ShowDialog() == DialogResult.OK) 
                {
                    NandproSet.binfile = selectnand.FileName;
                    runit = true;
                }
                else { runit = false; }
            }
            else
            {
                DialogResult res = MessageBox.Show("Do you want to use pre-selected NAND file?\n\n(" + NandproSet.binfile + ")", "Use pre-selected NAND?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) { runit = true; }
                else if (res == DialogResult.No)
                {
                    NandproSet.binfile = "";
                    runit = false;
                    writenandbtn_Click(sender, e);
                }
                else { runit = false; }
            }
            selectnand.FileName = "nand.bin";
            if (runit)
            {
                npversion = NandproSet.npvers;
                workdir = Path.GetDirectoryName(NandproSet.binfile);
                if (size != "1")
                {
                    status.Text = "Erasing the first 50 blocks of the NAND...";
                    args = NandproSet.device + ": -e16 0 50";
                    runproc();
                    while (!proc.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
                status.Text = "Writing NAND...";
                args = NandproSet.device + ": -w" + size + " \"" + Path.GetFileName(NandproSet.binfile) + "\"";
                runproc();
                if (File.Exists(Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe"))
                {
                    while (!proc.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
                status.Text = "Done! Waiting for further instructions...";
                System.Media.SystemSounds.Beep.Play();
            }
        }
        private void remapbtn_Click(object sender, EventArgs e)
        {
            getsize();
            NandproSet.workfile = worknand.Text;
            if (!string.IsNullOrEmpty(NandproSet.workfile))
            {
                if (File.Exists(NandproSet.workfile))
                {
                    status.Text = "Remapping nand...";
                    workdir = Path.GetDirectoryName(NandproSet.workfile);
                    file = Path.GetFileName(NandproSet.workfile);
                    string[] blocks = new string[2];
                    blocks[0] = fromblock.Text;
                    blocks[1] = toblock.Text;
                    npversion = "20b";
                    args = "\"" + file + "\": -r" + size + " badblock.bin " + blocks[0] + " 1";
                    blockout = true;
                    runproc();
                    if (File.Exists(Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe"))
                    {
                        while (!proc.HasExited)
                        {
                            Application.DoEvents();
                            Thread.Sleep(100);
                        }
                    }
                    args = "\"" + file + "\": -w" + size + " badblock.bin " + blocks[1] + " 1";
                    runproc();
                    if (File.Exists(Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe"))
                    {
                        while (!proc.HasExited)
                        {
                            Application.DoEvents();
                            Thread.Sleep(100);
                        }
                    }
                    rtb.AppendText("Block " + blocks[0] + " remapped to " + blocks[1] + "\n");
                    status.Text = "Done! Waiting for further instructions...";
                    NandproSet.binfile = NandproSet.workfile;
                    blockout = false;
                }
                else { MessageBox.Show("ERROR: Can't find the selected nand, have you renamed the file?", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("ERROR: Please specify what nand to work with first!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dumpbtn_Click(object sender, EventArgs e)
        {
            matchcount = 0;
            getsize();
            error = 0;
            int times = int.Parse(dumptimes.Text);
            int emptycount = 0;
            if (NandproSet.filenames.Length > 1)
            {
                for (int i = 0; i < NandproSet.filenames.Length; i++)
                {
                    if (string.IsNullOrEmpty(NandproSet.filenames[i])) { emptycount++; }
                    else if (NandproSet.filenames[i].Equals("none", StringComparison.CurrentCultureIgnoreCase)) { NandproSet.filenames[i] = ""; emptycount++; }
                }
            }
            else { emptycount = 0; }
            DialogResult res = DialogResult.OK;
            skip = true;
            if (emptycount < times) { res = MessageBox.Show("Do you want to use pre-defined dumpname(s)?", "Use pre-defined dumpnames", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            else { skip = false; }
            if (skip)
            {
                if (res == DialogResult.Yes)
                {
                    if ((emptycount > 0) && (emptycount > times)) { skip = false; }
                    else 
                    {
                        skip = false;
                        string[] tmp = new string[NandproSet.filenames.Length];
                        for (int i = 0; i < tmp.Length; i++) { tmp[i] = NandproSet.filenames[i]; }
                        NandproSet.filenames = new string[times];
                        for (int i = 0; i < NandproSet.filenames.Length; i++)
                        {
                            if (i <= tmp.Length) { NandproSet.filenames[i] = tmp[i]; }
                        }
                    }
                }
                else { NandproSet.filenames = new string[times]; skip = false; }
            }
            else { NandproSet.filenames = new string[times]; }
            if (!skip)
            {
                for (int i = 0; i < times; i++) { if (string.IsNullOrEmpty(NandproSet.filenames[i])) { NandproSet.filenames[i] = getdumpname(i); } }
            }
            npversion = NandproSet.npvers;
            dumpnames = new string[times];
            for (int i = 0; i < times; i++)
            {
                if (!string.IsNullOrEmpty(NandproSet.filenames[i]))
                {
                    status.Text = "Dumping nand... Currently on dump: " + (i + 1) + " of " + times;
                    SetText("Dumping nand: " + (i + 1) + " of " + times + "\n");
                    string dumpname = Path.GetFileName(NandproSet.filenames[i]);
                    dumpname = Regex.Replace(dumpname, "{size}", size, RegexOptions.IgnoreCase);
                    args = NandproSet.device + ": -r" + size + " \"" + dumpname + "\"";
                    if (NandproSet.filenames[i].Substring(1).StartsWith(":\\")) { workdir = Path.GetDirectoryName(NandproSet.filenames[i]); }
                    else { workdir = NandproSet.workdir; }
                    dumpnames[i] = workdir + "\\" + dumpname;
                    runproc();
                    if (File.Exists(Main.dir + "\\files\\nandpro\\nandpro" + npversion + ".exe"))
                    {
                        while (!proc.HasExited)
                        {
                            Application.DoEvents();
                            Thread.Sleep(100);
                        }
                        if (proc.HasExited) { Thread.Sleep(400); }
                    }
                }
                else { SetText("ERROR: Missing filename!\n"); }
            }
            #region Comparing results...
            nandop.Enabled = false;
            hwop.Enabled = false;
            for (int i = 0; i < times; i++)
            {
                if (!string.IsNullOrEmpty(dumpnames[i]))
                {
                    if (i == 0) { file1 = dumpnames[i]; }
                    else if (i == 1)
                    {
                        if ((dumpnames[0] != null) && (dumpnames[1] != null))
                        {
                            status.Text = "Comparing the dumps...";
                            rtb.AppendText("Comparing the dumps against eachother! this may take a little while...\n");
                            if ((File.Exists(dumpnames[0])) && (File.Exists(dumpnames[1])))
                            {
                                rtb.AppendText("Dump1 vs. Dump2 Check result is: ");
                                file2 = dumpnames[1];
                                Thread test = new Thread(new ThreadStart(compare));
                                test.Start();
                                nandproact.Active = true;
                                while (test.IsAlive)
                                {
                                    Application.DoEvents();
                                    Thread.Sleep(100);
                                }
                                nandproact.Active = false;
                            }
                            else
                            {
                                if (!File.Exists(file1)) { rtb.AppendText("ERROR: Dump 1 don't exist!\n"); }
                                if (!File.Exists(file2)) { rtb.AppendText("ERROR: Dump 2 don't exist!\n"); }
                            }
                        }
                    }
                    else if (i > 1)
                    {
                        if ((dumpnames[0] != null) && (dumpnames[i] != null))
                        {
                            if (File.Exists(dumpnames[i]))
                            {
                                rtb.AppendText("Dump1 vs. Dump" + (i + 1).ToString() + " Check result is: ");
                                file2 = dumpnames[i];
                                Thread test = new Thread(new ThreadStart(compare));
                                test.Start();
                                nandproact.Active = true;
                                while (test.IsAlive)
                                {
                                    Application.DoEvents();
                                    Thread.Sleep(100);
                                }
                                nandproact.Active = false;
                            }
                            else { rtb.AppendText("ERROR: Dump " + (i + 1).ToString() + " don't exist!\n"); }
                        }
                    }
                }
            }
            if (error != 0) { MessageBox.Show("ERROR: The dumps don't match!\n check the log for more information... if there is a badblock with an errocode like\n\"ERROR 25C Reading block: ...\"\nit might be causing a problem (it could be a so called \"Ghost Block\"\nmeaning a block that will never be the same, no matter how many times you dump the nand\n no matter how good your soldering is...\n\n If this is not your problem then check your soldering and try to dump it again\nerrors like this are often caused by bad soldering\n you can also try using CMD command: \"FC /b dump1.bin dump2.bin\" to get information about where the differences are\nsometimes it could be something like moving a cable a little that is causing the problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            #endregion
            if ((matchcount > 1) && (int.Parse(size) >= 16) && (error == 0)) 
            {
                string dumpname = NandproSet.filenames[0];
                dumpname = Regex.Replace(dumpname, "{size}", size, RegexOptions.IgnoreCase);
                if (!dumpname.Substring(1).StartsWith(":\\")) { dumpname = NandproSet.workdir + "\\" + dumpname; }
                Main.statc.source.Text = dumpname;
                if (string.IsNullOrEmpty(Main.statc.output.Text))
                {
                    Main.statc.output.Text = Path.GetDirectoryName(Main.statc.source.Text) + "\\";
                }
                if (Main.mright.semiauto.Checked) { Main.mright.checkmobo(); }
            }
            nandop.Enabled = true;
            hwop.Enabled = true;
            status.Text = "Done! Waiting for further instructions...";
        }
        private void Nandpro_Load(object sender, EventArgs e)
        {
            if (File.Exists(Main.dir + "\\nandpro.xml"))
            {
                NandproSet.loadsettings(Main.dir + "\\nandpro.xml");
                updateset();
            }
            else
            {
                NandproSet.workdir = Main.dir + "\\dumps\\";
                NandproSet.npvers = "30a";
                NandproSet.device = "usb";
                NandproSet.filenames = new string[4];
                NandproSet.filenames[0] = "dump{size}-1.bin";
                NandproSet.filenames[1] = "dump{size}-2.bin";
                NandproSet.filenames[2] = "dump{size}-3.bin";
                NandproSet.filenames[3] = "dump{size}-4.bin";
            }
        }
        private void updateset()
        {
            dumptimes.Text = NandproSet.dumptimes;
            switch (NandproSet.size)
            {
                case "1":
                    s1.Checked = true;
                    break;
                case "2":
                    s2.Checked = true;
                    break;
                case "16":
                    s16.Checked = true;
                    break;
                case "64":
                    s64.Checked = true;
                    break;
                case "256":
                    s256.Checked = true;
                    break;
                case "512":
                    s512.Checked = true;
                    break;
                default:
                    s1.Checked = false;
                    s2.Checked = false;
                    s16.Checked = false;
                    s64.Checked = false;
                    s256.Checked = false;
                    s512.Checked = false;
                    break;
            }
        }
    }
}