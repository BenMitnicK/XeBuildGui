using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace xeBuild_GUI
{
    public partial class dwltab : UserControl
    {
        public string dwlfile = "", version = "", latest = "";
        public static string usbdrive = "";
        Dictionary<string, string> ulinks = new Dictionary<string, string>();
        Dictionary<string, string> umd5vals = new Dictionary<string, string>();
        public Dictionary<string, string> dflinks = new Dictionary<string, string>();
        public Dictionary<string, string> dfmd5vals = new Dictionary<string, string>();
        public dwltab() { InitializeComponent(); }
        public void drivelist()
        {
            drive.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo Drive in drives)
            {
                if (Drive.IsReady)
                {
                    if (Drive.DriveType == DriveType.Removable) { drive.Items.Add(Drive.Name + " ( " + Drive.VolumeLabel + " ) [Removable]"); }
                    else if (Drive.DriveType == DriveType.Fixed)
                    {
                        if (inchdd.CheckState == CheckState.Checked) { drive.Items.Add(Drive.Name + " ( " + Drive.VolumeLabel + " ) [Non-Removable]"); }
                    }
                }
            }
        }
        private void formatworker_DoWork(object sender, DoWorkEventArgs e)
        {
            Process format = new Process();
            format.StartInfo.FileName = "CMD.exe";
            format.StartInfo.RedirectStandardInput = true;
            format.StartInfo.RedirectStandardOutput = true;
            format.StartInfo.RedirectStandardError = true;
            format.StartInfo.UseShellExecute = false;
            format.StartInfo.CreateNoWindow = true;
            format.StartInfo.Arguments = "/C \"format " + e.Argument.ToString().Substring(0, 2) +" /FS:FAT32 /X /Q\"";
            format.Start();
            StreamWriter enter = format.StandardInput;
            enter.WriteLine("");
            enter.WriteLine("");
            format.WaitForExit();
        }
        private void formatworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            formatbtn.Enabled = true;
            prepdrive.Enabled = true;
            updrivelistbtn.Enabled = true;
            inchdd.Enabled = true;
            MessageBox.Show("Format completed!");
        }
        private void unpackworker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Directory.Exists(dwltab.usbdrive + "\\$systemupdate\\")) { Directory.Delete(dwltab.usbdrive + "\\$systemupdate\\", true); }
            StreamWriter ini = new StreamWriter(dwltab.usbdrive + "\\launch.ini", false, Encoding.ASCII);
            ini.WriteLine("[Settings]");
            ini.WriteLine("noupdater = false");
            ini.Close();
            ProcessStartInfo unzip = new ProcessStartInfo();
            unzip.FileName = Main.dir + "\\files\\7za.exe";
            unzip.Arguments = "x $SystemUpdate_" + e.Argument.ToString() + ".zip -o" + dwltab.usbdrive.Substring(0, 2);
            unzip.WorkingDirectory = Main.dir + "\\";
            zipexists();
            Process uzip = Process.Start(unzip);
            uzip.WaitForExit();
            if (File.Exists(usbdrive + "\\LOGIC-SUNRISE.COM.txt")) { File.Delete(usbdrive + "\\LOGIC-SUNRISE.COM.txt"); }
        }
        private void upddrivelist(object sender, System.EventArgs e) { drivelist(); }
        public void dwlcancelbtn_Click(object sender, System.EventArgs e) 
        {
            Main.wc.CancelAsync();
            dwlstatus.Text = "Download Cancelled";
            dwlprogbar.Value = 100;
            dwlprogtxt.Text = "Download Cancelled";
            dwlcancelbtn.Enabled = false;
        }
        private void formatbtn_Click(object sender, System.EventArgs e)
        {
            formatbtn.Enabled = false;
            if (!string.IsNullOrEmpty(drive.Text))
            {
                if (MessageBox.Show("Are you sure you want to format " + drive.Text.Substring(0, 2) + "? (This WILL erase EVERYTHING from your usb drive!", "Format drive", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (MessageBox.Show("Are you REALLY sure about this?", "Really sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        formatworker.RunWorkerAsync(drive.Text);
                        formatbtn.Enabled = false;
                        prepdrive.Enabled = false;
                        updrivelistbtn.Enabled = false;
                        while (formatworker.IsBusy)
                        {
                            Application.DoEvents();
                            Thread.Sleep(100);
                        }
                    }
                    else
                    {
                        formatbtn.Enabled = true;
                        MessageBox.Show("Thats to bad! why did you click yes on the previous one then?!", "To bad!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    formatbtn.Enabled = true;
                    MessageBox.Show("Thats to bad, get a different drive, or select a different device then!", "To bad!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                formatbtn.Enabled = true;
                MessageBox.Show("ERROR: You must select a drive to format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void prep(string dashboard)
        {
            if (!String.IsNullOrEmpty(drive.Text))
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo Drive in drives)
                {
                    if (Drive.IsReady)
                    {
                        if (Drive.Name == drive.Text.Remove(3, drive.Text.Length - 3))
                        {
                            if (Drive.DriveFormat == "FAT32")
                            {
                                if (md5match.Text.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    usbdrive = drive.Text.Substring(0, 2);
                                    unpackworker.RunWorkerAsync(dashboard);
                                }
                                else
                                {
                                    MessageBox.Show("ERROR: Your file seems corrupt, please re-download it!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("ERROR: Drive is NOT FAT32, please format it first!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR: Please select a Drive first!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void prepdrive_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(avers.Text))
            {
                expected.Text = umd5vals[avers.Text];
                string dashver = avers.Text.Substring(4, avers.Text.Length - 6);
                if (File.Exists(Main.dir + "\\$SystemUpdate_" + dashver + ".zip"))
                {
                    actual.Text = Main.misc.getmd5(Main.dir + "\\$SystemUpdate_" + dashver + ".zip");
                    if (actual.Text == expected.Text)
                    {
                        prep(dashver);
                    }
                    else
                    {
                        MessageBox.Show("ERROR: MD5 does not match!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: Download the system update first!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ERROR: Select what update to use first!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fillversions(string avatarfile, string dashfile)
        {
            avers.Items.Clear();
            dfvers.Items.Clear();
            Main.statc.kernel.Items.Clear();
            Main.statc.kernel.Items.Add("Custom");
            ulinks.Clear();
            umd5vals.Clear();
            if (File.Exists(Main.appdir + "\\Swizzy\\xeBuild_GUI\\" + avatarfile))
            {
                readavatar(Main.appdir + "\\Swizzy\\xeBuild_GUI\\" + avatarfile);
            }
            else if (File.Exists(Main.dir + "\\files\\" + avatarfile))
            {
                readavatar(Main.dir + "\\files\\" + avatarfile);
            }
            if (File.Exists(Main.appdir + "\\Swizzy\\xeBuild_GUI\\" + dashfile))
            {
                readdashfiles(Main.appdir + "\\Swizzy\\xeBuild_GUI\\" + dashfile);
            }
            else if (File.Exists(Main.dir + "\\files\\" + dashfile))
            {
                readdashfiles(Main.dir + "\\files\\" + dashfile);
            }
            avers.Text = latest;
            dfvers.Text = latest;
            Main.statc.kernel.Text = latest;
        }
        private void downloadversionchanged(object sender, EventArgs e)
        {
            try
            {
                if (sender == avers)
                {
                    expected.Text = umd5vals[avers.Text];
                }
                else if (sender == dfvers)
                {
                    expected.Text = dfmd5vals[dfvers.Text];
                }
            }
            catch
            {
                MessageBox.Show("ERROR: Unable to set Expected MD5 value! this shouldn't ever occur unless the xml's are broken/modified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dwlavatarbtn_Click(object sender, EventArgs e)
        {
            twistbtnstate();
            if (!String.IsNullOrEmpty(avers.Text))
            {
                string dversion = avers.Text.Substring(4, avers.Text.Length - 6);
                expected.Text = umd5vals[avers.Text];
                if (!File.Exists(Main.dir + "\\$SystemUpdate_" + dversion + ".zip"))
                {
                    string[] args = new string[2];
                    args[0] = ulinks[avers.Text];
                    args[1] = Main.dir + "\\$SystemUpdate_" + dversion + ".zip";
                    dwlfile = args[1];
                    dwlstatus.Text = "Downloading $SystemUpdate_" + dversion + ".zip";
                    dwl(args);
                }
                else
                {
                    actual.Text = Main.misc.getmd5(Main.dir + "\\$SystemUpdate_" + dversion + ".zip");
                    if (expected.Text != actual.Text)
                    {
                        twistbtnstate();
                        DialogResult res = MessageBox.Show("ERROR: The checksums don't match, do you want to delete the current file?", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes)
                        {
                            if (File.Exists(Main.dir + "\\$SystemUpdate_" + dversion + ".zip")) { File.Delete(Main.dir + "\\$SystemUpdate_" + dversion + ".zip"); }
                            dwlavatarbtn_Click(sender, e);
                        }
                    }
                    else
                    {
                        dwlstatus.Text = "Done!";
                        twistbtnstate();
                    }
                }
            }
            else
            {
                twistbtnstate();
                MessageBox.Show("ERROR: Please specify what version to download!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
        public void dwl(string[] args)
        {
            try
            {
                dwlcancelbtn.Enabled = true;
                Main.wc = new WebClient();
                Main.wc.DownloadFileCompleted += new AsyncCompletedEventHandler(dwlcompleted);
                Main.wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(dwlprogress);
                Main.wc.DownloadFileAsync(new Uri(args[0]), args[1]);
            }
            catch
            {
                MessageBox.Show("ERROR: There was an eror when trying to initalize the download!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                twistbtnstate();
                dwlcancelbtn.Enabled = false;
            }
        }
        private void dwlprogress(object sender, DownloadProgressChangedEventArgs e)
        {
            dwlprogbar.Value = e.ProgressPercentage;
            dwlprogtxt.Text = (e.BytesReceived / 1024) + "KB of " + (e.TotalBytesToReceive / 1024) + "KB Downloaded ( " + e.ProgressPercentage + "% )";
        }
        private void dwlcompleted(object sender, AsyncCompletedEventArgs e)
        {
            twistbtnstate();
            dwlcancelbtn.Enabled = false;
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    dwlstatus.Text = "Getting MD5 value...";
                    actual.Text = Main.misc.getmd5(dwlfile);
                    dwlstatus.Text = "Done!";
                }
                else
                {
                    string errormessage = "";
                    if (e.Error.ToString().Contains("(404) Not Found."))
                    {
                        errormessage = "Unable to find file (error 404) Try again later!";
                    }
                    else
                    {
                        errormessage = e.Error.ToString();
                    }
                    dwlerrorlog.AppendText("There was an error during the download:\n\n" + errormessage);
                }
            }
            else
            {
                dwlprogtxt.Text = "";
                dwlprogbar.Value = 0;
                dwlstatus.Text = "Cancelled!";
            }
        }
        private void expected_TextChanged(object sender, EventArgs e) { actual.Text = ""; }
        private void actual_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(actual.Text))
            {
                md5match.Text = (actual.Text == expected.Text).ToString();
            }
            else
            {
                md5match.Text = "N/A";
            }
        }
        private void md5match_TextChanged(object sender, EventArgs e)
        {
            if (md5match.Text.Equals("true", StringComparison.CurrentCultureIgnoreCase))
            {
                md5match.ForeColor = Color.Green;
                md5match.Font = new Font(md5match.Font, FontStyle.Bold);
            }
            else if (md5match.Text.Equals("false", StringComparison.CurrentCultureIgnoreCase))
            {
                md5match.ForeColor = Color.Red;
                md5match.Font = new Font(md5match.Font, FontStyle.Bold);
            }
            else
            {
                md5match.ForeColor = Color.Black;
                md5match.Font = new Font(md5match.Font, FontStyle.Regular);
                md5match.Text = "N/A";
            }
        }
        private void dwldashbtn_Click(object sender, EventArgs e)
        {
            twistbtnstate();
            if (!String.IsNullOrEmpty(dfvers.Text))
            {
                string dversion = dfvers.Text.Substring(4, dfvers.Text.Length - 6);
                expected.Text = dfmd5vals[dfvers.Text];
                if (!File.Exists(Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs"))
                {
                    Directory.CreateDirectory(Main.dir + "\\files\\" + dversion + "\\");
                    string[] args = new string[2];
                    args[0] = dflinks[dfvers.Text];
                    args[1] = Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs";
                    dwlfile = args[1];
                    dwlstatus.Text = "Downloading " + dversion + ".pirs";
                    dwl(args);
                    while (Main.wc.IsBusy)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                    if (File.Exists(Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs")) 
                    {
                        actual.Text = Main.misc.getmd5(Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs");
                        if (expected.Text == actual.Text)
                        {
                            File.Copy(Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs", Main.dir + "\\files\\" + dversion + "\\su20076000_00000000", true);
                        }
                        else { MessageBox.Show("ERROR: The checksums don't match, try downloading again or edit the xml's!", "ERROR - MD5 Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                {
                    actual.Text = Main.misc.getmd5(Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs");
                    if (expected.Text != actual.Text)
                    {
                        DialogResult res = MessageBox.Show("ERROR: The checksums don't match, do you want to delete the current file?", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes)
                        {
                            if (File.Exists(Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs")) { File.Delete(Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs"); }
                            dwldashbtn_Click(sender, e);
                        }
                        twistbtnstate();
                    }
                    else
                    {
                        if (File.Exists(Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs")) { File.Copy(Main.dir + "\\files\\" + dversion + "\\" + dversion + ".pirs", Main.dir + "\\files\\" + dversion + "\\su20076000_00000000", true); }
                        dwlstatus.Text = "Done!";
                        twistbtnstate();
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR: Please specify what version to download!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        public void twistbtnstate()
        {
            dwlavatarbtn.Enabled = (!dwlavatarbtn.Enabled);
            dwldashbtn.Enabled = (!dwldashbtn.Enabled);
            prepdrive.Enabled = (!prepdrive.Enabled);
            formatbtn.Enabled = (!formatbtn.Enabled);
            dfvers.Enabled = (!dfvers.Enabled);
            avers.Enabled = (!avers.Enabled);            
        }
        private void zipexists()
        {
            if (!File.Exists(Main.dir + "\\files\\7za.exe"))
            {
                FileInfo exe = new FileInfo(Main.dir + "\\files\\7za.exe");
                FileStream toexe = exe.OpenWrite();
                Stream fromexe = Main.app.GetManifestResourceStream("xeBuild_GUI.Embedded.7za.exe");
                const int size = 4096;
                byte[] bytes = new byte[size];
                int numBytes;
                while ((numBytes = fromexe.Read(bytes, 0, size)) > 0)
                {
                    toexe.Write(bytes, 0, numBytes);
                }
                toexe.Close();
                fromexe.Close();
            }
        }
        private void readdashfiles(string dir)
        {
            using (XmlReader xml = XmlReader.Create(dir))
            {
                while (xml.Read())
                {
                    if (xml.IsStartElement())
                    {
                        switch (xml.Name.ToLower())
                        {
                            case "ver":
                                xml.Read();
                                version = xml.Value;
                                dfvers.Items.Add(version);
                                Main.statc.kernel.Items.Add(version);
                                break;
                            case "link":
                                xml.Read();
                                dflinks.Add(version, xml.Value.Replace(@"\", @"/"));
                                break;
                            case "md5":
                                xml.Read();
                                dfmd5vals.Add(version, xml.Value.ToUpper());
                                break;
                            case "latest":
                                xml.Read();
                                latest = xml.Value;
                                break;
                            case "type":
                                xml.Read();
                                Main.types.Add(version, xml.Value);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        private void readavatar(string dir)
        {
            using (XmlReader xml = XmlReader.Create(dir))
            {
                while (xml.Read())
                {
                    if (xml.IsStartElement())
                    {
                        switch (xml.Name.ToLower())
                        {
                            case "ver":
                                xml.Read();
                                version = xml.Value;
                                avers.Items.Add(version);
                                break;
                            case "link":
                                xml.Read();
                                ulinks.Add(version, xml.Value.Replace(@"\", @"/"));
                                break;
                            case "md5":
                                xml.Read();
                                umd5vals.Add(version, xml.Value.ToUpper());
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}