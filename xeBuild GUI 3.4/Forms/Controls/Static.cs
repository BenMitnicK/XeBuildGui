using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using xeBuild_GUI.x360utils.NAND;

namespace xeBuild_GUI
{
    public partial class Static : UserControl
    {
        string _type = "";
        internal static readonly cpukey Getkey = new cpukey();
        internal readonly build Builder = new build();
        public Static() { InitializeComponent(); }
        private void StaticLoad(object sender, EventArgs e) { setbaseip(); }
        private void Ctrlfix(object sender, KeyEventArgs e) { Main.test.ctrlfix(sender, e); }
        private void Keycheck(object sender, KeyPressEventArgs e) { Main.test.hexinput(sender, e); }
        private void Numeric(object sender, KeyPressEventArgs e) { Main.test.numinput(sender, e); }
        private void Ipinput(object sender, KeyPressEventArgs e) { Main.test.ipinput(sender, e);  }
        private void GetkeyCpukeytxtbtnClick(object sender, EventArgs e)
        {
            var res = openkeystxt.ShowDialog();
            if (res == DialogResult.OK)
            {
                cpukey.Text = Getkey.readkeyfile(openkeystxt.FileName);
                if (ecc.Checked) { glitch.Checked = true; }
                else if (ecc2.Checked) { glitch2.Checked = true; }
                if (File.Exists(source.Text)) { Main.mright.kvcheck_Click(null, null); }
            }
            openkeystxt.FileName = "keys.txt";
            Main.mright.checkKvEnable();
        }
        private void getkey_fusestxtbtn_Click(object sender, System.EventArgs e)
        {
            cpukey.Text = "";
            DialogResult res = openfusetxt.ShowDialog();
            if (res == DialogResult.OK)
            {                
                string[] ret = Getkey.readfusefile(openfusetxt.FileName);
                cpukey.Text = ret[0];
                Main.mright.cfldv.Text = ret[1];
                if (ecc.Checked) { glitch.Checked = true; }
                else if (ecc2.Checked) { glitch2.Checked = true; }
                if (File.Exists(source.Text)) { Main.mright.kvcheck_Click(null, null); }
            }
            openfusetxt.FileName = "FUSE.txt";
        }
        private void setbaseip()
        {
            string host = Dns.GetHostName();
            IPAddress[] localIPs = Dns.GetHostAddresses(host);
            string ipfull = "";
            string[] ipsplit = new string[3];
            for (int i = 0; i < localIPs.Length; i++)
            {
                if (Dns.GetHostEntry(host).AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ipfull = Dns.GetHostEntry(host).AddressList[i].ToString();
                    i = localIPs.Length;
                }
            }
            ipsplit = ipfull.Split(".".ToCharArray());
            xellip.Text = ipsplit[0] + "." + ipsplit[1] + "." + ipsplit[2] + ".";
        }
        private void getipbtn_Click(object sender, System.EventArgs e) { setbaseip(); }
        private void getkey_networkbtn_Click(object sender, System.EventArgs e)
        {
            getkey_networkbtn.Enabled = false;
            cpukey.Text = "";
            IPAddress ipcheck;
            if (IPAddress.TryParse(xellip.Text, out ipcheck))
            {
                if (ipcheck.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Ping pinger = new Ping();
                    if (pinger.Send(ipcheck, 1000).Status == IPStatus.Success)
                    {
                        fusedownloader(ipcheck.ToString());
                        if (!string.IsNullOrEmpty(cpukey.Text.Trim()))
                        {
                            if (ecc.Checked) { glitch.Checked = true; }
                            else if (ecc2.Checked) { glitch2.Checked = true; }
                            if (File.Exists(source.Text)) { Main.mright.kvcheck_Click(null, null); }
                        }
                    }
                    else { MessageBox.Show("ERROR: IP not reachable!", "IP Connectivity ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBox.Show("ERROR: Invalid IP input!", "Input ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("ERROR: Invalid IP input!", "Input ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            getkey_networkbtn.Enabled = true;
        }
        private void fusedownloader(string ip)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile("http://" + ip + "/FUSE", Main.dir + "\\files\\temp\\FUSE.txt");
                }
                catch
                {
                    MessageBox.Show("ERROR: Unable to download fuses from xell!", "Download ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (File.Exists(Main.dir + "\\files\\temp\\FUSE.txt"))
                {
                    string[] ret = Getkey.readfusefile(Main.dir + "\\files\\temp\\FUSE.txt");
                    Main.statc.cpukey.Text = ret[0];
                    Main.mright.cfldv.Text = ret[1];
                    if (!string.IsNullOrEmpty(Main.statc.source.Text))
                    {
                        try 
                        {
                            bool copyfile = true;
                            if (File.Exists(Path.GetDirectoryName(Main.statc.source.Text) + "\\FUSE.txt"))
                            {
                                copyfile = false;
                                copyfile = (MessageBox.Show("FUSE.txt already exist in the dump directory, do you wish to overwrite this file?", "FUSE.txt already exists, overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes);
                            }
                            if (copyfile)
                            {
                                File.Copy(Main.dir + "\\files\\temp\\FUSE.txt", Path.GetDirectoryName(Main.statc.source.Text) + "\\FUSE.txt", true);
                            }
                            else
                            {
                                MessageBox.Show("If you change your mind you'll find FUSE.txt here:\n" + Main.dir + "\\files\\temp\\FUSE.txt", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch 
                        {
                            MessageBox.Show("ERROR: Unable to backup FUSE.txt to your source directory! you can find the fuses in \\files\\temp\\", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        }
                    }
                }
            }
        }
        private void aud_enable(object sender, System.EventArgs e)
        {
            aud_clamp.Enabled = ((!xenon.Checked) && (!trinity.Checked) && (!retail.Checked));
            aud_clamp2.Enabled = ((!xenon.Checked) && (!trinity.Checked) && (!retail.Checked));
            cygnos2.Enabled = (zephyr.Checked);
            Main.mright.nomu.Enabled = ((jasperbb.Checked) || (jasperbigffs.Checked));
            if ((devkit.Checked) || (retail.Checked)) { Main.mright.nomu.Enabled = false; }
            Main.statusupdate();
            try { _type = Main.types[kernel.Text]; }
            catch { _type = ""; }
            activatenohdmi(_type);
        }
        private void xenon_CheckedChanged(object sender, EventArgs e)
        {
            if (xenon.Checked)
            {
                ecc2.Checked = false;
                glitch2.Checked = false;
            }
            aud_enable(sender, e);
            Main.statusupdate();
        }
        private void trinity_CheckedChanged(object sender, System.EventArgs e) 
        {
            if (trinity.Checked)
                jtag.Checked = false;
            else if (corona.Checked || corona4g.Checked)
            {
                ecc.Checked = false;
                glitch.Checked = false;
                jtag.Checked = false;
            }
            Main.mright.nofcrt.Enabled = ((trinity.Checked) || (corona.Checked));
            Main.mright.notrinmu.Enabled = ((trinity.Checked) || (corona.Checked));
            if ((devkit.Checked) || (retail.Checked)) { Main.mright.nofcrt.Enabled = false; }
            Main.statusupdate();
            try { _type = Main.types[kernel.Text]; }
            catch { _type = ""; }
            activatenohdmi(_type);
        }
        private void type_changed(object sender, System.EventArgs e)
        {
            smc.Enabled = ((jtag.Checked) || (retail.Checked) || (devkit.Checked));
            normal.Enabled = (jtag.Checked);
            cygnos.Enabled = (jtag.Checked);
            xell.Enabled = (jtag.Checked);
            xellous.Enabled = (jtag.Checked);
            xellver.Enabled = ((jtag.Checked) || (glitch.Checked) || (glitch2.Checked));
            kernelver.Enabled = ((!ecc.Checked) && (!ecc2.Checked));
            Main.mright.includedl.Enabled = ((!ecc.Checked) && (!ecc2.Checked) && (!retail.Checked) && (!devkit.Checked));
            Main.mright.customdl.Enabled = ((!ecc.Checked) && (!ecc2.Checked) && (!retail.Checked) && (!devkit.Checked));
            Main.mright.customxebuild.Enabled = ((!ecc.Checked) && (!ecc2.Checked) && (!retail.Checked) && (!devkit.Checked));
            Main.mright.cfldv.Enabled = ((!ecc.Checked) && (!ecc2.Checked));
            Main.mright.cfldvlabel.Enabled = ((!ecc.Checked) && (!ecc2.Checked));
            Main.mright.specialp.Enabled = ((!ecc.Checked) && (!ecc2.Checked) && (!retail.Checked) && (!devkit.Checked));
            Main.xeset.xebuildjtag.Enabled = (jtag.Checked);
            if (jtag.Checked) 
                trinity.Checked = false;
            else if ((devkit.Checked) || (retail.Checked))
            {
                Main.mright.nofcrt.Enabled = false;
                Main.mright.nomu.Enabled = false;
            }
            if ((ecc2.Checked) || (glitch2.Checked)) { xenon.Checked = false; }
            aud_enable(sender, e);
            Main.statusupdate();
        }
        private void OpenbtnClick(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(source.Text)) { opennand.InitialDirectory = Path.GetDirectoryName(source.Text); }
            var res = opennand.ShowDialog();
            if (res == DialogResult.OK)
            {
                source.Text = opennand.FileName;
                if (string.IsNullOrEmpty(output.Text))
                {
                    output.Text = Path.GetDirectoryName(source.Text) + "\\";
                    output.Text = System.Text.RegularExpressions.Regex.Replace(output.Text, "\\\\+", "\\");
                }
                if (Main.mright.semiauto.Checked) {
                    //Main.mright.checkmobo();
                    FileInfo fi = new FileInfo(source.Text);
                    if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                    {
                        Main.mright.checkmobo();
                    }else{
                            Main.mright.checkcorona4gmobo();
                        }
                        /*var reader = new NANDReader(source.Text);
                        if (!reader.HasSpare)
                        {
                            Main.mright.checkcorona4gmobo();
                        }
                        else
                        {
                            Main.mright.checkmobo();
                        }*/
                }
            }
            opennand.FileName = "flashdmp.bin";
            Main.mright.checkKvEnable();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if ((ecc.Checked) || (ecc2.Checked))
            {
                DialogResult res = saveecc.ShowDialog();
                if (res == DialogResult.OK)
                {
                    output.Text = Path.GetDirectoryName(saveecc.FileName);
                    eccname.Text = Path.GetFileName(saveecc.FileName);
                    savebin.InitialDirectory = Path.GetDirectoryName(saveecc.FileName);
                }
            }
            else
            {
                DialogResult res = savebin.ShowDialog();
                if (res == DialogResult.OK)
                {
                    output.Text = Path.GetDirectoryName(savebin.FileName);
                    binname.Text = Path.GetFileName(savebin.FileName);
                    saveecc.InitialDirectory = Path.GetDirectoryName(savebin.FileName);
                }
            }
            saveecc.FileName = "image_00000000.ecc";
            savebin.FileName = "updflash.bin";
        }
        private void enablekvinfo() { Main.mright.kvinfo.Enabled = ((Main.test.keycheck(cpukey.Text)) && (File.Exists(source.Text))); }
        private void source_TextChanged(object sender, EventArgs e) 
        {
            if (cpukey.Text.Length == 32) { enablekvinfo(); }
            Main.mright.moboinfo.Enabled = (source.Text.Length > 0);
            output.Text = Path.GetDirectoryName(source.Text);
            cpukey.Clear();
            Main.statusupdate();
        }
        private void cpukey_TextChanged(object sender, EventArgs e) 
        {
            if (cpukey.Text.Length == 32) { enablekvinfo(); Main.statusupdate(); }
            else { genbtn.Enabled = false; Main.mright.kvinfo.Enabled = false; }
        }
        private void key_leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(blkey.Text)) { blkey.Text = "DD88AD0C9ED669E7B56794FB68563EFA"; }
            TextBox tb = sender as TextBox;
            if (tb.Text.Length > 0) { Main.test.keycheck(tb.Text); }
            updstat(sender, e);
        }
        private void updstat(object sender, EventArgs e) { Main.statusupdate(); }
        private void ckernel_TextChanged(object sender, EventArgs e)
        {
            if (ckernel.Text.Length > 0) { kernel.Text = "Custom"; }
            Main.statusupdate();
        }
        private void genbtn_Click(object sender, EventArgs e)
        {
            genbtn.Enabled = false;
            Main.download.dfvers.Text = kernel.Text;
            Main.download.avers.Text = kernel.Text;
            bool start = true;
            if (outtab.rtb.Text.Length != 0)
            {
                if (MessageBox.Show("WARNING: You are about to clear the log!\nMake sure you've saved any previous log data before building a new one!\n\nPress OK if you want to clear log, otherwise click cancel/close the dialog!", "WARNING Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    start = true;
                    outtab.rtb.Text = "";
                }
                else { start = false; }
            }
            if (start)
            {
                string[] settings = getsettings();
                if (!settings[2].StartsWith("ecc", StringComparison.CurrentCultureIgnoreCase))
                {
                    if ((!File.Exists(Main.dir + "\\files\\" + settings[6] + "\\cf_" + settings[6] + ".bin")) && (!File.Exists(Main.dir + "\\files\\common\\cf_" + settings[6] + ".bin")) && (!File.Exists(Main.dir + "\\files\\" + settings[6] + "\\se_" + settings[6] + ".bin")) && (!File.Exists(Main.dir + "\\files\\common\\se_" + settings[6] + ".bin")) && (!File.Exists(Main.dir + "\\files\\" + settings[6] + "\\su20076000_00000000")))
                    {
                        Main.tabc.SelectedTab = Main.r.dwl;
                        start = false;
                    }
                    else if (File.Exists(Main.dir + "\\files\\" + settings[6] + "\\su20076000_00000000"))
                    {
                        string pirs = Main.test.getpirsversion(Main.dir + "\\files\\" + settings[6] + "\\su20076000_00000000");
                        if (settings[6].Trim() != pirs) { start = (MessageBox.Show("Warning: Your selected build version don't match the version found in the PIRS file of the folder\n, this is an indicator that you've placed the system update PIRS in the wrong folder manually\nDo you want to continue with this build? you'll probably get an error from xeBuild... the detected version is: " + pirs, "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes); }
                    }
                }
                if (start)
                {
                    try
                    {
                        if (!Main.mright.extvital.Checked && !Main.disfailsafe)
                        {
                            #region Mobo Failsafe
                            string suggestion;
                            int cb;
                            FileInfo fi = new FileInfo(Main.statc.source.Text);
                            if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                            {
                                cb = Main.nand.getcbversion(Main.statc.source.Text);
                                suggestion = Main.test.cbtranslate(cb, settings[0]);
                            }
                            else
                            {
                                cb = Main.nand.getcbversioncorona4g(Main.statc.source.Text);
                                suggestion = Main.test.cbtranslate(cb, settings[0]);
                            }
                            if (suggestion.StartsWith("falcon", StringComparison.CurrentCultureIgnoreCase)) { suggestion = "falcon"; }
                            else if (suggestion.Equals("unkown", StringComparison.CurrentCultureIgnoreCase)) { suggestion = settings[3]; }
                            else if (suggestion.ToLower().Contains("jasper")) { suggestion = "jasper"; }
                            if (!settings[3].StartsWith(suggestion.ToLower()))
                            {
                                if (MessageBox.Show("WARNING: You are about to create a NAND that MAY cause your console NOT to work!\nAre you sure that " + settings[3] + " is your motherboard revision?\nThe app suggests using: " + suggestion + " (CB value: " + cb.ToString() + ")\nDo you want to use the suggested motherboard revision or select another one?", "WARNING Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    suggestion = Main.test.cbtranslate(cb, settings[0]);
                                    switch (suggestion.ToLower())
                                    {
                                        case "xenon":
                                            settings[3] = "xenon";
                                            start = true;
                                            break;
                                        case "zephyr":
                                            settings[3] = "zephyr";
                                            start = true;
                                            break;
                                        case "falcon":
                                            settings[3] = "falcon";
                                            start = true;
                                            break;
                                        case "jasper 16mb":
                                            settings[3] = "jasper";
                                            start = true;
                                            break;
                                        case "jasper bb (256mb)":
                                            settings[3] = "jasperbb";
                                            start = true;
                                            break;
                                        case "jasper bb (512mb)":
                                            settings[3] = "jasperbb";
                                            start = true;
                                            break;
                                        case "jasper bb":
                                            settings[3] = "jasperbb";
                                            start = true;
                                            break;
                                        case "trinity":
                                            settings[3] = "trinity";
                                            start = true;
                                            break;
                                        case "corona":
                                            settings[3] = "corona";
                                            start = true;
                                            break;
                                        case "corona4g":
                                            settings[3] = "corona4g";
                                            start = true;
                                            break;
                                        default:
                                            start = false;
                                            break;
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("Are you sure you want to use the motherboard you've selected?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { start = true; }
                                    else { start = false; }
                                }
                            }
                            #endregion
                            if (start)
                            {
                                #region Type Failsafe
                                var type = "";
                                switch (cb)
                                {
                                    case 1923:
                                    case 1940:
                                    case 4578:
                                    case 4579:
                                    case 5771:
                                    case 6750:
                                    case 6751:
                                    case 7375:
                                    case 9188:
                                    case 9230:
                                    case 9231:
                                    case 4572:
                                        start = ((settings[2].Equals("ecc", StringComparison.CurrentCultureIgnoreCase)) || (settings[2].Equals("glitch", StringComparison.CurrentCultureIgnoreCase)) || (settings[2].Equals("retail", StringComparison.CurrentCultureIgnoreCase) || settings[2].Equals("devkit", StringComparison.CurrentCultureIgnoreCase)));
                                        type = "glitch";
                                        break;
                                    case 1888:
                                    case 1902:
                                    case 1903:
                                    case 1920:
                                    case 1921:
                                    case 4558:
                                    case 4571:
                                    case 4580:
                                    case 5761:
                                    case 5766:
                                    case 5770:
                                    case 6712:
                                    case 6723:
                                    case 4570:
                                        start = ((settings[2].Equals("jtag", StringComparison.CurrentCultureIgnoreCase)) || (settings[2].Equals("retail", StringComparison.CurrentCultureIgnoreCase)) || (settings[2].Equals("devkit", StringComparison.CurrentCultureIgnoreCase)));
                                        type = "jtag";
                                        break;
                                    case 4575:
                                    case 4577:
                                    case 5772:
                                    case 5773:
                                    case 5774:
                                    case 6752:
                                    case 6753:
                                    case 6754:
                                    case 13121:
                                    case 13180:
                                    case 13181:
                                    case 13182:
                                    case 4559:
                                    case 4560:
                                    case 4561:
                                    case 4562:
                                    case 4569:
                                    case 4574:
                                        start = ((settings[2].Equals("ecc2", StringComparison.CurrentCultureIgnoreCase)) || (settings[2].Equals("glitch2", StringComparison.CurrentCultureIgnoreCase) || settings[2].Equals("retail", StringComparison.CurrentCultureIgnoreCase)) || (settings[2].Equals("devkit", StringComparison.CurrentCultureIgnoreCase)));
                                        type = "glitch2";
                                        break;
                                    default:
                                        start = true;
                                        break;
                                }
                                if (!start)
                                {
                                    if(MessageBox.Show("WARNING: You are about to create a NAND that MAY cause your console NOT to work!\nAre you sure that " + settings[2] + " is the type of image you want to create?\nThe app suggests using: " + type + " (CB value: " + cb.ToString() + ")\nDo you want to use the suggested image type or select another one?", "WARNING Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                                        settings[2] = type;
                                        start = true;
                                    }
                                    else
                                        start = MessageBox.Show("Are you sure you want to use the image type you've selected?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                                }
                                #endregion
                                if (start)
                                {
                                    #region Xell Failsafe
                                    if ((!settings[2].StartsWith("ecc", StringComparison.CurrentCultureIgnoreCase)) || (!settings[2].Equals("retail", StringComparison.CurrentCultureIgnoreCase)) || (!settings[2].Equals("devkit", StringComparison.CurrentCultureIgnoreCase)))
                                    {
                                        #region Glitch
                                        if (settings[2].StartsWith("glitch", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            if (!settings[7].Equals("xellreloaded", StringComparison.CurrentCultureIgnoreCase))
                                            {
                                                if ((settings[7].Equals("customxell", StringComparison.CurrentCultureIgnoreCase)) && (!File.Exists(Main.dir + "\\xell.bin")))
                                                {
                                                    MessageBox.Show("WARNING: You've selected Custom Xell version however the file doesn't appear to exist, the program will now automatically select Xell-Reloaded instead!", "WARNING MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    settings[7] = "xellreloaded";
                                                }
                                                else
                                                {
                                                    MessageBox.Show("WARNING: You've selected an incompatible Xell version for Glitch type images, the program will now automatically correct it for you by selecting Xell-Reloaded!", "WARNING MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    settings[7] = "xellreloaded";
                                                }
                                            }
                                        }
                                        #endregion
                                        #region Others (JTAG)
                                        else
                                        {
                                            if ((settings[7].Equals("customxell", StringComparison.CurrentCultureIgnoreCase)) && (!File.Exists(Main.dir + "\\xell.bin")))
                                            {
                                                if (MessageBox.Show("WARNING: You've selected Custom Xell version however the file doesn't appear to exist, Do you want the program to use the recomended Xell Version instead? (Xell-Reloaded)", "WARNING MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) { settings[7] = "xellreloaded"; }
                                                else { start = false; }
                                            }
                                            else { start = true; }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        settings[7] = "";
                                    }
                                    #endregion
                                    #region SMC Failsafe
                                    //FileInfo fi = new FileInfo(Main.statc.source.Text);
                                    if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                                    {
                                        Main.nand.getkv_smc(Main.statc.source.Text);
                                        Main.smc = Main.crypt.DecryptSMC(Main.encsmc);
                                    }
                                    else
                                    {
                                        byte[] data = (BadBlock.find_bad_blocks_X(Main.statc.source.Text, 0x50));
                                        byte[] SMC = null;
                                        byte[] smc_len = new byte[4], smc_start = new byte[4];
                                        Buffer.BlockCopy(data, 0x78, smc_len, 0, 4);
                                        Buffer.BlockCopy(data, 0x7C, smc_start, 0, 4);
                                        SMC = new byte[Oper.ByteArrayToInt(smc_len)];
                                        Buffer.BlockCopy(data, Oper.ByteArrayToInt(smc_start), SMC, 0, Oper.ByteArrayToInt(smc_len));
                                        SMC = Nand.decrypt_SMC(SMC);
                                        Main.smc = SMC;
                                        //smcbox.Text = Main.test.smctype(Main.smc);
                                        //var smc = new Smc();
                                        //smcversion.Text = smc.GetVersion(ref Main.smc);
                                    }
                                    string smctype = Main.test.smctype(Main.smc);
                                    Directory.CreateDirectory(Main.dir + "\\files\\temp\\");
                                    Main.nand.savesmc(Main.dir + "\\files\\temp\\", Main.smc);
                                    string[] ret = Main.test.patchcheck(Main.dir + "\\files\\temp\\smc.bin");
                                    if (ret[0] == "Aud_clamp + Eject") { ret[0] = "aud_clamp2"; }
                                    if (settings[2] == "jtag")
                                    {
                                        if (!ret[0].Equals(settings[8], StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            if ((!settings[8].Equals("cygnos2", StringComparison.CurrentCultureIgnoreCase)) && ((smctype.Equals("retail", StringComparison.CurrentCultureIgnoreCase)) || (smctype.Equals("cygnos", StringComparison.CurrentCultureIgnoreCase)) || (smctype.Equals("jtag", StringComparison.CurrentCultureIgnoreCase))))
                                            {
                                                if ((settings[8].Equals("currentsmc", StringComparison.CurrentCultureIgnoreCase) && (smctype.Equals("retail", StringComparison.CurrentCultureIgnoreCase))))
                                                {
                                                    settings[8] = changesmc(smctype, settings[3]);
                                                    if (string.IsNullOrEmpty(settings[3])) { start = false; }
                                                    else { start = true; }
                                                }
                                                else { start = true; }
                                            }
                                            else { start = true; }
                                        }
                                        else { start = true; }
                                    }
                                    else
                                    {
                                        settings[8] = "currentsmc";
                                        start = true;
                                    }
                                    #endregion
                                }
                            }
                        }
                        if (start)
                        {
                            try { File.Delete(Main.dir + "\\files\\output.bin.log"); }
                            catch { }
                            Main.tabc.SelectedTab = Main.r.logtab;
                            Builder.initbuild(settings);
                        }
                    }
                    catch { MessageBox.Show("ERROR: There was one or more errors while checking your settings, this ussually means there is something very wrong with your nand! disable failsafe to bypass this check...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    if (!string.IsNullOrEmpty(settings[6].Trim()))
                    {
                        DialogResult res = MessageBox.Show("ERROR: Can't find cf_" + settings[6] + ".bin or su20076000_00000000 (required for all except for devkit) nor se_" + settings[6] + ".bin (required for devkit) in the data folder!\n\nDo you want to download the dashfiles for 2.0." + settings[6] + ".0?", "ERROR - Required dash files not found", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes)
                        {
                            try
                            {
                                Main.download.twistbtnstate();
                                Main.download.expected.Text = Main.download.dfmd5vals["2.0." + settings[6] + ".0"];
                                if (!File.Exists(Main.dir + "\\files\\" + settings[6] + "\\" + settings[6] + ".pirs"))
                                {
                                    Directory.CreateDirectory(Main.dir + "\\files\\" + settings[6] + "\\");
                                    string[] args = new string[2];
                                    args[0] = Main.download.dflinks["2.0." + settings[6] + ".0"];
                                    args[1] = Main.dir + "\\files\\" + settings[6] + "\\" + settings[6] + ".pirs";
                                    Main.download.dwlfile = args[1];
                                    Main.download.dwlstatus.Text = "Downloading " + settings[6] + ".pirs";
                                    Main.download.dwl(args);
                                    while (Main.wc.IsBusy)
                                    {
                                        Application.DoEvents();
                                        System.Threading.Thread.Sleep(100);
                                    }
                                    if (File.Exists(Main.dir + "\\files\\" + settings[6] + "\\" + settings[6] + ".pirs"))
                                    {
                                        Main.download.actual.Text = Main.misc.getmd5(Main.dir + "\\files\\" + settings[6] + "\\" + settings[6] + ".pirs");
                                        if (Main.download.expected.Text == Main.download.actual.Text)
                                        {
                                            File.Copy(Main.dir + "\\files\\" + settings[6] + "\\" + settings[6] + ".pirs", Main.dir + "\\files\\" + settings[6] + "\\su20076000_00000000", true);
                                        }
                                        else { MessageBox.Show("ERROR: The checksums don't match, try downloading again or edit the xml's!", "ERROR - MD5 Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                            }
                            catch { MessageBox.Show("ERROR: There was an error whiles trying to download/install the dashfiles... try again and make sure it's on the list...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
            }
            genbtn.Enabled = true;
        }
        public string[] getsettings()
        {
            string[] settings = new string[20];
            settings[0] = source.Text;
            settings[1] = output.Text;
            RadioButton rb;
            foreach (Control c in imgtype.Controls)
            {
                rb = c as RadioButton;
                if (rb.Checked) { settings[2] = rb.Name; }
            }
            if (settings[2] != null)
            {
                if (settings[2].StartsWith("ecc", StringComparison.CurrentCultureIgnoreCase)) { settings[1] += "\\" + eccname.Text; }
                else { settings[1] += "\\" + binname.Text; }
                settings[1] = System.Text.RegularExpressions.Regex.Replace(settings[1], "\\\\+", "\\");
            }
            foreach (Control c in mobo.Controls)
            {
                rb = c as RadioButton;
                if (rb.Checked) { settings[3] = rb.Name; }
            }
            settings[4] = cpukey.Text;
            if (!Main.ezmode) { settings[5] = blkey.Text; }
            else { settings[5] = "DD88AD0C9ED669E7B56794FB68563EFA"; }
            if (kernel.Text != "Custom") 
            {
                settings[6] = kernel.Text;
                settings[6] = settings[6].Replace("2.0.", "");
                settings[6] = settings[6].Replace(".0", "");
            }
            else { settings[6] = ckernel.Text; }
            foreach (Control c in xellver.Controls)
            {
                rb = c as RadioButton;
                if (rb.Checked) { settings[7] = rb.Name; }
            }
            foreach (Control c in smc.Controls)
            {
                rb = c as RadioButton;
                if (rb.Checked) { settings[8] = rb.Name; }
            }
            settings[9] = Main.mright.includedl.Checked.ToString();
            settings[10] = Main.mright.customdl.Checked.ToString();
            settings[11] = Main.mright.semiauto.Checked.ToString();
            if (!Main.ezmode)
            {
                settings[12] = Main.mright.customxebuild.Checked.ToString();
                settings[13] = Main.xeset.customini.Checked.ToString();
                settings[14] = Main.xeset.customininame.Text;
            }
            else
            {
                settings[12] = "false";
                settings[13] = "false";
                settings[14] = "";
            }
            settings[15] = Main.mright.cfldv.Text;
            settings[16] = Main.mright.autosavelog.Checked.ToString();
            settings[17] = Main.mright.logname.Text;
            return settings;
        }
        private void kernelchange(object sender, System.EventArgs e)
        {
            try { _type = Main.types[kernel.Text]; }
            catch { _type = ""; }
            Main.statc.retail.Enabled = ((_type == "") || (_type == "1") || (_type == "3") || (_type == "4"));
            Main.statc.jtag.Enabled = ((_type == "") || (_type == "2") || (_type == "3") || (_type == "4"));
            Main.statc.glitch.Enabled = ((_type == "") || (_type == "3") || (_type == "4"));
            Main.statc.glitch2.Enabled = ((_type == "") || (_type == "4"));
            Main.statc.devkit.Enabled = ((_type == "")  || (_type == "5"));
            activatenohdmi(_type);
            Main.statusupdate();
        }
        private string changesmc(string current, string mobo)
        {
            if (MessageBox.Show("Do you want to use the current SMC or change it?", "What SMC do you want to use?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!current.Equals("retail", StringComparison.CurrentCultureIgnoreCase)) { return "currentsmc"; }
                else
                {
                    MessageBox.Show("ERROR: Please fix your settings and select a SMC hack to use!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            else if (MessageBox.Show("Do you want to use the \"Normal\" (OLD) SMC-Hack?", "What SMC do you want to use?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return "normal";
            }
            else if (!mobo.Equals("xenon", StringComparison.CurrentCultureIgnoreCase))
            {
                if (MessageBox.Show("Do you want to use Aud_Clamp SMC Hack?", "What SMC do you want to use?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return "aud_clamp";
                }
                else if (MessageBox.Show("Do you want to use Aud_Clamp + Eject SMC Hack?", "What SMC do you want to use?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return "aud_clamp2";
                }
                else if (MessageBox.Show("Do you want to use Cygnos SMC Hack?", "What SMC do you want to use?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return "cygnos";
                }
                else if (mobo.Equals("zephyr", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (MessageBox.Show("Do you want to use Alternative Cygnos SMC Hack for Zephyr?", "What SMC do you want to use?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        return "cygnos2";
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Please fix your settings and select a SMC hack to use!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: Please fix your settings and select a SMC hack to use!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            else if (mobo.Equals("xenon", StringComparison.CurrentCultureIgnoreCase))
            {
                if (MessageBox.Show("Do you want to use Cygnos SMC Hack?", "What SMC do you want to use?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return "cygnos";
                }
                else
                {
                    MessageBox.Show("ERROR: Please fix your settings and select a SMC hack to use!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            else
            {
                MessageBox.Show("ERROR: Please fix your settings and select a SMC hack to use!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }            
        }
        private void xellip_KeyUp(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { getkey_networkbtn_Click(null, null); } }
        private void activatenohdmi(string type)
        {            
            if ((!Main.statc.devkit.Checked) && (!Main.statc.retail.Checked)) 
            {
                Main.mright.nohdmiwait.Enabled = ((type == "4") || (type == "") && (!xenon.Checked));
                Main.mright.nohdd.Enabled = ((type == "4") || (type == ""));
                Main.mright.notrinmu.Enabled = (((type == "4") || (type == "")) && (trinity.Checked));
            }
            else 
            {
                Main.mright.nohdmiwait.Enabled = false;
                Main.mright.nohdd.Enabled = false;
                Main.mright.notrinmu.Enabled = false;
            }
        }
    }
}