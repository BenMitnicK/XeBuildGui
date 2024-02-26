using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net.NetworkInformation;


namespace xeBuild_GUI
{
    public partial class IPScan : Form
    {
        string cfgfile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Swizzy\\xeBuild\\ipscan.cfg";
        public static ProgressBarEx pbar;
        public static TextBox status;
        delegate void SetProgCallback(int progress);
        delegate void SetTextCallback(string[] text);
        delegate void SetStatCallback(string status);
        Thread testing;
        bool success = false, abort = false;
        string baseip = "", currentip = "";
        int startip = 0, limit = 0, prog = 0, i = 0, pinglimit = 200;
        public IPScan() 
        {
            InitializeComponent();
            pbar = progbar;
            status = statustxt;
        }
        private void setprog(int progress)
        {
            try
            {
                if (IPScan.pbar.InvokeRequired)
                {
                    SetProgCallback d = new SetProgCallback(setprog);
                    IPScan.pbar.Invoke(d, new object[] { progress });
                }
                else 
                {
                    IPScan.pbar.Value = progress;
                }
            }
            catch 
            {
                IPScan.pbar.Value = IPScan.pbar.Maximum;
                IPScan.pbar.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void settext(string[] text)
        {
            if (Main.statc.cpukey.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(settext);
                Main.statc.cpukey.Invoke(d, new object[] { text });
            }
            else if (Main.mright.cfldv.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(settext);
                Main.mright.cfldv.Invoke(d, new object[] { text });
            }
            else 
            {
                Main.statc.cpukey.Text = text[0];
                Main.mright.cfldv.Text = text[1];
            }
        }
        private void setstatus(string text)
        {
            if (IPScan.status.InvokeRequired)
            {
                SetStatCallback d = new SetStatCallback(setstatus);
                IPScan.status.Invoke(d, new object[] { text });
            }
            else { IPScan.status.Text = text; }
        }
        private void downloadfuse(string ip)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    setstatus("Trying to download fuse from: " + ip);
                    client.DownloadFile("http://" + ip + "/FUSE", Main.dir + "\\files\\temp\\FUSE.txt");
                    i = limit;
                    prog = limit - startip - 1;
                    success = true;
                    setstatus("Success! Found Xell on IP: " + ip);
                }
                catch { success = false; }
                if (File.Exists(Main.dir + "\\files\\temp\\FUSE.txt"))
                {
                    string[] ret = Static.Getkey.readfusefile(Main.dir + "\\files\\temp\\FUSE.txt");
                    settext(ret);
                    if (!string.IsNullOrEmpty(Main.statc.source.Text))
                    {
                        try { File.Copy(Main.dir + "\\files\\temp\\FUSE.txt", Path.GetDirectoryName(Main.statc.source.Text) + "\\FUSE.txt"); }
                        catch { MessageBox.Show("ERROR: Unable to backup FUSE.txt to your source directory!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }
        private void testiprange()
        {
            prog = 0;
            i = startip;
            for (i = startip; i < limit; i++)
            {
                if ((abort) || (success)) { i = limit; }
                string iptext = baseip + i.ToString();
                if (iptext != currentip)
                {
                    IPAddress ipcheck;
                    if (IPAddress.TryParse(iptext, out ipcheck))
                    {
                        if (ipcheck.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Ping pinger = new Ping();
                            setstatus("Pinging: " + ipcheck);
                            if (pinger.Send(ipcheck, pinglimit).Status == IPStatus.Success)
                            {
                                downloadfuse(ipcheck.ToString());
                                if (!string.IsNullOrEmpty(Main.statc.cpukey.Text))
                                {
                                    if (Main.statc.ecc.Checked) { Main.statc.glitch.Checked = true; }
                                    if (File.Exists(Main.statc.source.Text)) { Main.mright.kvcheck_Click(null, null); }
                                }
                            }
                        }
                    }
                }
                prog++;
                setprog(prog);
            }
            if (!success) { setstatus("Unable to find Xell! Check your settings!"); } 
        }
        private void setbaseip()
        {
            string host = Dns.GetHostName();
            IPAddress[] localIPs = Dns.GetHostAddresses(host);
            string ipfull = "";
            string[] ipsplit = new string[3];
            for (i = 0; i < localIPs.Length; i++)
            {
                if (Dns.GetHostEntry(host).AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ipfull = Dns.GetHostEntry(host).AddressList[i].ToString();
                    i = localIPs.Length;
                }
            }
            ipsplit = ipfull.Split(".".ToCharArray());
            baseipbox.Text = ipsplit[0] + "." + ipsplit[1] + "." + ipsplit[2] + ".";
            currentip = ipfull;
        }
        private void IPScan_Load(object sender, EventArgs e) 
        {
            setbaseip();
            if (File.Exists(cfgfile))
            {
                string[] cfg = File.ReadAllLines(cfgfile);
                foreach (string s in cfg)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Trim().StartsWith("rangestart", StringComparison.CurrentCultureIgnoreCase)) { fromip.Text = s.Substring(11).Trim(); }
                        else if (s.Trim().StartsWith("rangeend", StringComparison.CurrentCultureIgnoreCase)) { toip.Text = s.Substring(9).Trim(); }
                        else if (s.Trim().StartsWith("baseip", StringComparison.CurrentCultureIgnoreCase)) { baseipbox.Text = s.Substring(7).Trim(); }
                        else if (s.Trim().StartsWith("timeout", StringComparison.CurrentCultureIgnoreCase)) { timeout.Text = s.Substring(8).Trim(); }
                    }
                }
            }
        }
        private void getipbtn_Click(object sender, EventArgs e) { setbaseip(); }
        private void startscanbtn_Click(object sender, EventArgs e)
        {
            try
            {
                success = false;
                abort = false;
                startip = int.Parse(fromip.Text);
                limit = int.Parse(toip.Text);
                baseip = baseipbox.Text;
                int pingmax = int.Parse(timeout.Text);
                if (pingmax > 100) { pinglimit = pingmax; }
                else { pinglimit = 100; }
                if (startip < limit)
                {
                    if ((startip < 254) && (startip >= 0) && (limit > 1) && (limit <= 255))
                    {
                        IPAddress testip;
                        if (IPAddress.TryParse(baseip + "0", out testip))
                        {
                            pbar.Maximum = limit - startip;
                            prog = 0;
                            testing = new Thread(new ThreadStart(testiprange));
                            testing.Start();
                            while (testing.IsAlive)
                            {
                                Application.DoEvents();
                                Thread.Sleep(100);
                            }
                        }
                        else { MessageBox.Show("ERROR: Base IP is not a valid IP adress!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else { MessageBox.Show("ERROR: The IP Range you've specified is out of range! IP's must be within 0 - 255\nScan From cannot be higher then 254\nScan to cannot be lower then 1", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBox.Show("ERROR: This scanner can only scan forwards, not backwards! make sure that scan from is higher then scan to!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch { MessageBox.Show("ERROR: Please check your input! Something went horribly wrong here...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void IPScan_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (testing != null)
            {
                if (testing.IsAlive)
                {
                    abort = true;
                    while (testing.IsAlive)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
            }
            if (File.Exists(cfgfile)) { File.Delete(cfgfile); }
            Directory.CreateDirectory(Path.GetDirectoryName(cfgfile));
            using (StreamWriter sw = new StreamWriter(File.Open(cfgfile, FileMode.CreateNew)))
            {
                sw.WriteLine("rangestart=" + fromip.Text);
                sw.WriteLine("rangeend=" + toip.Text);
                sw.WriteLine("baseip=" + baseipbox.Text);
                sw.WriteLine("timeout=" + timeout.Text);
            }
            e.Cancel = false;
        }
        private void testempty(object sender, EventArgs e) { startscanbtn.Enabled = ((!string.IsNullOrEmpty(fromip.Text)) && (!string.IsNullOrEmpty(toip.Text)) && (!string.IsNullOrEmpty(timeout.Text))); }
        private void baseipbox_TextChanged(object sender, EventArgs e)
        {
            IPAddress testip;
            startscanbtn.Enabled = (IPAddress.TryParse(baseip + "0", out testip));
        }
        private void ipinput(object sender, KeyPressEventArgs e) { Main.test.ipinput(sender, e); }
        private void numeric(object sender, KeyPressEventArgs e) { Main.test.numinput(sender, e); }
    }
}