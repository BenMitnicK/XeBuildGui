using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using xeBuild_GUI.x360utils.NAND;

namespace xeBuild_GUI
{
    public partial class Mainright : UserControl
    {
        public Mainright() { InitializeComponent(); }
        private void numeric(object sender, KeyPressEventArgs e) { Main.test.numinput(sender, e); }
        private void ctrlfix(object sender, KeyEventArgs e) { Main.test.ctrlfix(sender, e); }
        private void logname_TextChanged(object sender, System.EventArgs e) { logname.Text = logname.Text.Replace("/", "\\"); }
        private readonly X360NAND _x360NAND = new X360NAND();
        private Versions kvinfoversion = new Versions();
        public string cf1 = "", cf0 = "", cf1_LDV = "", cf0_LDV = "";
        public int cf11 = 0, cf00 = 0; 
        private void checkbtn_Click(object sender, System.EventArgs e) {

                FileInfo fi = new FileInfo(Main.statc.source.Text);
                if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                {
                    checkmobo();
                }
                else
                {
                    checkcorona4gmobo();
                }
        }
        public void checkmobo()
        {
            try
            {
                Main.nand.getkv_smc(Main.statc.source.Text);
                Main.smc = Main.crypt.DecryptSMC(Main.encsmc);
                int cb = Main.nand.getcbversion(Main.statc.source.Text);
                if (cb > 1) { cbbox.Text = cb.ToString(); }
                else { cbbox.Text = "N/A"; }
                mobobox.Text = Main.test.cbtranslate(cb, Main.statc.source.Text);
                smcbox.Text = Main.test.smctype(Main.smc);
                Main.nand.savesmc(Main.dir + "\\files\\temp\\", Main.smc);
                string[] patches = Main.test.patchcheck(Main.dir + "\\files\\temp\\smc.bin");
                if ((smcbox.Text != "Retail") && (smcbox.Text != "Cygnos") && (smcbox.Text != "Glitch")) { tipsmc.Text = patches[0]; }
                else if ((smcbox.Text == "Cygnos") && (patches[0] == "Unkown")) { tipsmc.Text = "Cygnos v2"; }
                else if (patches[0] != "Unkown")
                {
                    smcbox.Text = "JTAG";
                    tipsmc.Text = patches[0];
                }
                else { tipsmc.Text = "N/A"; }
                tmsbox.Text = patches[1];
                tdibox.Text = patches[2];
                if (string.IsNullOrEmpty(patches[3])) { smcversion.Text = "N/A"; }
                else { smcversion.Text = patches[3]; }
                #region Auto Selection
                if (semiauto.Checked)
                {
                    switch (cb)
                    {
                        case 1888: case 1902: case 1903: case 1920: case 1921:
                            Main.statc.xenon.Checked = true;
                            Main.statc.jtag.Checked = true;
                            break;
                        case 7375: case 1923: case 1940:
                            Main.statc.xenon.Checked = true;
                            ecc_glitch();
                            break;
                        case 4558: case 4570: case 4571:case 4580:
                            Main.statc.zephyr.Checked = true;
                            Main.statc.jtag.Checked = true;
                            break;
                        case 4578: case 4579: case 4572:
                            Main.statc.zephyr.Checked = true;
                            if(cb != 4572)
                                ecc_glitch();
                            else
                                Main.statc.glitch.Checked = true;
                            break;
                        case 5761: case 5766: case 5770:
                            Main.statc.falcon.Checked = true;
                            Main.statc.jtag.Checked = true;
                            break;
                        case 5771: 
                            Main.statc.falcon.Checked = true;
                            ecc_glitch();
                            break;
                        case 6712: case 6723:
                            jaspermodel();
                            Main.statc.jtag.Checked = true;
                            break;
                        case 6750: case 6751:
                            jaspermodel();
                            ecc_glitch();
                            break;
                        case 9188: case 9230:
                            Main.statc.trinity.Checked = true;
                            ecc_glitch();
                            break;
                        case 9231:
                            Main.statc.trinity.Checked = true;
                            Main.statc.glitch.Checked = true;
                            break;
                        case 4575: case 4577: case 4559: case 4560: case 4561: case 4562: case 4569: case 4574:
                            Main.statc.zephyr.Checked = true;
                            if(cb == 4575 || cb == 4577)
                                ecc_glitch2();
                            else
                                Main.statc.glitch2.Checked = true;
                            break;
                        case 5772: case 5773: case 5774:
                            Main.statc.falcon.Checked = true;
                            if (cb != 5774)
                                ecc_glitch2();
                            else
                                Main.statc.glitch2.Checked = true;
                            break;
                        case 6752: case 6753: case 6754:
                            jaspermodel();
                            if (cb != 6754)
                                ecc_glitch2();
                            else
                                Main.statc.glitch2.Checked = true;
                            break;
                        case 13121: case 13180:
                            //coronamodel();
                            Main.statc.corona.Checked = true;
                            ecc_glitch2();
                            break;
                        case 13181: case 13182:
                            //coronamodel();
                            Main.statc.corona.Checked = true;
                            Main.statc.glitch2.Checked = true;
                            break;
                        default:
                            Main.statc.xenon.Checked = false;
                            Main.statc.zephyr.Checked = false;
                            Main.statc.falcon.Checked = false;
                            Main.statc.jasper.Checked = false;
                            Main.statc.trinity.Checked = false;
                            Main.statc.jaspersb.Checked = false;
                            Main.statc.jasperbigffs.Checked = false;
                            break;
                    }
                    switch (tipsmc.Text.Trim())
                    {
                        case "Normal":
                            Main.statc.normal.Checked = true;
                            break;
                        case "Aud_clamp":
                            Main.statc.aud_clamp.Checked = true;
                            break;
                        case "Aud_clamp + Tray_Open":
                            Main.statc.aud_clamp2.Checked = true;
                            break;
                        case "Cygnos v2":
                            Main.statc.cygnos.Checked = (!Main.statc.zephyr.Checked);
                            break;
                        default:
                            Main.statc.normal.Checked = false;
                            Main.statc.cygnos.Checked = false;
                            Main.statc.cygnos2.Checked = false;
                            Main.statc.aud_clamp.Checked = false;
                            Main.statc.aud_clamp2.Checked = false;
                            Main.statc.customsmc.Checked = (File.Exists(Main.dir + "\\smc.bin"));
                            break;
                    }
                }
                #endregion
            }
            catch
            {
                mobobox.Text = "ERROR";
                smcbox.Text = "ERROR";
                tipsmc.Text = "ERROR";
                tmsbox.Text = "N/A";
                tdibox.Text = "N/A";
                smcversion.Text = "N/A";
                cbbox.Text = "N/A";
            }
        }
        public void checkcorona4gmobo()
        {
            mobobox.Text = "";
            tipsmc.Text = "N/A";
            smcbox.Text = "";
            tmsbox.Text = "N/A";
            tdibox.Text = "N/A";
            smcversion.Text = "";
            cbbox.Text = "";
            try
            {
                int cb = Main.nand.getcbversioncorona4g(Main.statc.source.Text);
                if (cb > 1) { cbbox.Text = cb.ToString(); }
                else { cbbox.Text = "N/A"; }
                mobobox.Text = Main.test.cbtranslate(cb, Main.statc.source.Text);
                if (semiauto.Checked)
                {
                    switch (cb)
                    {
                        case 13121:
                        case 13180:
                            //coronamodel();
                            Main.statc.corona4g.Checked = true;
                            ecc_glitch2();
                            break;
                        case 13181:
                        case 13182:
                            //coronamodel();
                            Main.statc.corona4g.Checked = true;
                            Main.statc.glitch2.Checked = true;
                            break;
                        default:
                            Main.statc.xenon.Checked = false;
                            Main.statc.zephyr.Checked = false;
                            Main.statc.falcon.Checked = false;
                            Main.statc.jasper.Checked = false;
                            Main.statc.trinity.Checked = false;
                            Main.statc.jaspersb.Checked = false;
                            Main.statc.jasperbigffs.Checked = false;
                            break;
                    }
                    /*switch (tipsmc.Text.Trim())
                    {
                        case "Normal":
                            Main.statc.normal.Checked = true;
                            break;
                        case "Aud_clamp":
                            Main.statc.aud_clamp.Checked = true;
                            break;
                        case "Aud_clamp + Tray_Open":
                            Main.statc.aud_clamp2.Checked = true;
                            break;
                        case "Cygnos v2":
                            Main.statc.cygnos.Checked = (!Main.statc.zephyr.Checked);
                            break;
                        default:
                            Main.statc.normal.Checked = false;
                            Main.statc.cygnos.Checked = false;
                            Main.statc.cygnos2.Checked = false;
                            Main.statc.aud_clamp.Checked = false;
                            Main.statc.aud_clamp2.Checked = false;
                            Main.statc.customsmc.Checked = (File.Exists(Main.dir + "\\smc.bin"));
                            break;
                    }*/
                }
                //using (var reader = new NANDReader(Main.statc.source.Text))
                //{
                    //AddOutput("Grabbing SMC from NAND: ");
                    //var data = _x360NAND.GetSmc(reader, true);
                byte[] data = (BadBlock.find_bad_blocks_X(Main.statc.source.Text, 0x50));
                //unpack_base_image(data, true);
                byte[] SMC = null;
                byte[] smc_len = new byte[4], smc_start = new byte[4];
                Buffer.BlockCopy(data, 0x78, smc_len, 0, 4);
                Buffer.BlockCopy(data, 0x7C, smc_start, 0, 4);
                SMC = new byte[Oper.ByteArrayToInt(smc_len)];
                Buffer.BlockCopy(data, Oper.ByteArrayToInt(smc_start), SMC, 0, Oper.ByteArrayToInt(smc_len));
                //if (variables.extractfiles) Oper.savefile(SMC, "output\\SMC_en.bin");
                SMC = Nand.decrypt_SMC(SMC);
                Main.smc = SMC;
                smcbox.Text = Main.test.smctype(Main.smc);
                    var smc = new Smc();
                    //var type = smc.GetType(ref Main.smc);
                    smcversion.Text = smc.GetVersion(ref Main.smc);
                    //Console.Write("\r\nSMC Version: {0} [{1}]", smc.GetVersion(ref Main.smc), smc.GetMotherBoardFromVersion(ref Main.smc));
                    //Console.Write("\r\nSMC Type: {0}", type);
                    //if (type == Smc.SmcTypes.Jtag || type == Smc.SmcTypes.RJtag)
                        //Smc.JtagsmcPatches.AnalyseSmc(ref Main.smc);
                    //Console.Write("\r\nSMC Glitch Patched: {0}", smc.CheckGlitchPatch(ref Main.smc) ? "Yes" : "No");
                //}
            }
            catch
            {
                mobobox.Text = "ERROR";
                smcbox.Text = "ERROR";
                tipsmc.Text = "ERROR";
                tmsbox.Text = "N/A";
                tdibox.Text = "N/A";
                smcversion.Text = "N/A";
                cbbox.Text = "N/A";
                MessageBox.Show("ERROR: Unable to decrypt your smc! maybe your dump is not valid", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ecc_glitch()
        {
            if (smcbox.Text == "Retail") { Main.statc.ecc.Checked = true; }
            else { Main.statc.glitch.Checked = true; }
            if ((File.Exists(Main.dir + "\\xeBuild_GUI.log")) || (File.Exists(Main.dir + "\\xeBuild_GUI.txt"))) { Main.statc.glitch.Checked = true; }
        }
        private void ecc_glitch2()
        {
            if (smcbox.Text == "Retail") { Main.statc.ecc2.Checked = true; }
            else { Main.statc.glitch2.Checked = true; }
            if ((File.Exists(Main.dir + "\\xeBuild_GUI.log")) || (File.Exists(Main.dir + "\\xeBuild_GUI.txt"))) { Main.statc.glitch2.Checked = true; }
        }
        private void coronamodel()
        {
            FileInfo fi = new FileInfo(Main.statc.source.Text);
            if (fi.Length == 17301504) { Main.statc.corona.Checked = true; }
            else { Main.statc.corona4g.Checked = true; }
        }
        private void jaspermodel()
        {
            FileInfo fi = new FileInfo(Main.statc.source.Text);
            if (fi.Length == 17301504) { Main.statc.jasper.Checked = true; }
            else { Main.statc.jasperbb.Checked = true; }
        }
        public void kvcheck_Click(object sender, System.EventArgs e)
        {
            FileInfo fi = new FileInfo(Main.statc.source.Text);
            if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
            {
                try
                {
                    currserial.Text = "";
                    currmfr.Text = "";
                    currosig.Text = "";
                    currdvdkey.Text = "";
                    currcid.Text = "";
                    currregion.Text = "";
                    Main.nand.getkv_smc(Main.statc.source.Text);
                    Main.kv = Main.crypt.DecryptKV(Main.enckv, Main.statc.cpukey.Text);
                    if (!Main.crypt.kvcheck(Main.kv, Main.statc.cpukey.Text))
                    {
                        MessageBox.Show("ERROR: Unable to decrypt kv! etheir it's corrupt or the CPUKey you supplied is incorrect!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fcrtreq.Font = new Font(fcrtreq.Font, FontStyle.Regular);
                        fcrtreq.ForeColor = Color.Black;
                        fcrtreq.Text = "UNK";
                        currcid.Text = "ERROR";
                        currdvdkey.Text = "ERROR";
                        currmfr.Text = "ERROR";
                        currosig.Text = "ERROR";
                        currregion.Text = "ERROR";
                        currserial.Text = "ERROR";
                    }
                    else
                    {
                        string[] kvinf = getkvinfo();
                        currserial.Text = kvinf[0];
                        currregion.Text = kvinf[1];
                        currdvdkey.Text = kvinf[2];
                        currcid.Text = kvinf[3];
                        currmfr.Text = kvinf[4];
                        currosig.Text = kvinf[5];
                        fcrtreq.Text = kvinf[6];
                        if (Main.misc.swap16(BitConverter.ToUInt16(Main.kv, 0x1C)) == 0x00F0) { fcrtreq.ForeColor = Color.Red; }
                        else { fcrtreq.ForeColor = Color.Green; }
                        fcrtreq.Font = new Font(fcrtreq.Font, FontStyle.Bold);
                    }
                }
                catch
                {
                    fcrtreq.Font = new Font(fcrtreq.Font, FontStyle.Regular);
                    fcrtreq.ForeColor = Color.Black;
                    fcrtreq.Text = "UNK";
                    currcid.Text = "ERROR";
                    currdvdkey.Text = "ERROR";
                    currmfr.Text = "ERROR";
                    currosig.Text = "ERROR";
                    currregion.Text = "ERROR";
                    currserial.Text = "ERROR";
                    MessageBox.Show("ERROR: Unable to decrypt your kv! check your CPUKey!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                corona4gkvinfo();
            }
            /*var reader = new NANDReader(Main.statc.source.Text);
            if (!reader.HasSpare)
            {
                corona4gkvinfo();
            }
            else
            {

                try
                {
                    currserial.Text = "";
                    currmfr.Text = "";
                    currosig.Text = "";
                    currdvdkey.Text = "";
                    currcid.Text = "";
                    currregion.Text = "";
                    Main.nand.getkv_smc(Main.statc.source.Text);
                    Main.kv = Main.crypt.DecryptKV(Main.enckv, Main.statc.cpukey.Text);
                    if (!Main.crypt.kvcheck(Main.kv, Main.statc.cpukey.Text))
                    {
                        MessageBox.Show("ERROR: Unable to decrypt kv! etheir it's corrupt or the CPUKey you supplied is incorrect!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fcrtreq.Font = new Font(fcrtreq.Font, FontStyle.Regular);
                        fcrtreq.ForeColor = Color.Black;
                        fcrtreq.Text = "UNK";
                        currcid.Text = "ERROR";
                        currdvdkey.Text = "ERROR";
                        currmfr.Text = "ERROR";
                        currosig.Text = "ERROR";
                        currregion.Text = "ERROR";
                        currserial.Text = "ERROR";
                    }
                    else
                    {
                        string[] kvinf = getkvinfo();
                        currserial.Text = kvinf[0];
                        currregion.Text = kvinf[1];
                        currdvdkey.Text = kvinf[2];
                        currcid.Text = kvinf[3];
                        currmfr.Text = kvinf[4];
                        currosig.Text = kvinf[5];
                        fcrtreq.Text = kvinf[6];
                        if (Main.misc.swap16(BitConverter.ToUInt16(Main.kv, 0x1C)) == 0x00F0) { fcrtreq.ForeColor = Color.Red; }
                        else { fcrtreq.ForeColor = Color.Green; }
                        fcrtreq.Font = new Font(fcrtreq.Font, FontStyle.Bold);
                    }
                }
                catch
                {
                    fcrtreq.Font = new Font(fcrtreq.Font, FontStyle.Regular);
                    fcrtreq.ForeColor = Color.Black;
                    fcrtreq.Text = "UNK";
                    currcid.Text = "ERROR";
                    currdvdkey.Text = "ERROR";
                    currmfr.Text = "ERROR";
                    currosig.Text = "ERROR";
                    currregion.Text = "ERROR";
                    currserial.Text = "ERROR";
                    MessageBox.Show("ERROR: Unable to decrypt your kv! check your CPUKey!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/ Main.mright.checkKvEnable();
        }
        public void corona4gkvinfo()
        {

            try
            {
                currserial.Text = "";
                currmfr.Text = "";
                currosig.Text = "";
                currdvdkey.Text = "";
                currcid.Text = "";
                currregion.Text = "";
                using (var reader = new NANDReader(Main.statc.source.Text))
                {
                    var kv = _x360NAND.GetKeyVault(reader, Main.statc.cpukey.Text);
                    var kvinfo = new xeBuild_GUI.x360utils.NAND.Keyvault();                    
                    currcid.Text = kvinfo.GetConsoleID(ref kv);
                    currserial.Text = kvinfo.GetConsoleSerial(ref kv);
                    currdvdkey.Text = kvinfo.GetDVDKey(ref kv);
                    if (kvinfo.FCRTRequired(ref kv) == true)
                    {
                        fcrtreq.ForeColor = Color.Red;
                        fcrtreq.Font = new Font(fcrtreq.Font, FontStyle.Bold);
                        fcrtreq.Text = "TRUE";
                    }
                    else
                    {
                        fcrtreq.Font = new Font(fcrtreq.Font, FontStyle.Bold);
                        fcrtreq.Text = "FALSE";
                    }
                    currregion.Text = kvinfo.GetGameRegion(ref kv, true);
                    currmfr.Text = kvinfo.GetMfrDate(ref kv, Keyvault.DateFormats.DDMMYY);
                    currosig.Text = kvinfo.GetOSIGData(ref kv);
                }
            }
            catch
            {
                fcrtreq.Font = new Font(fcrtreq.Font, FontStyle.Regular);
                fcrtreq.ForeColor = Color.Black;
                fcrtreq.Text = "UNK";
                currcid.Text = "ERROR";
                currdvdkey.Text = "ERROR";
                currmfr.Text = "ERROR";
                currosig.Text = "ERROR";
                currregion.Text = "ERROR";
                currserial.Text = "ERROR";
                MessageBox.Show("ERROR: Unable to decrypt your kv! check your CPUKey or your dump!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void currserial_Click(object sender, EventArgs e)
        {
            if (Main.test.isNumeric(currserial.Text.Trim(), System.Globalization.NumberStyles.Integer))
            {
                currserial.SelectAll();
                currserial.Copy();
                currserial.DeselectAll();
            }
        }
        private void currdvdkey_Click(object sender, EventArgs e)
        {
            if (currdvdkey.Text.Length == 32)
            {
                string strHex = String.Concat("[0-9A-Fa-f]{32}");
                if (Regex.IsMatch(currdvdkey.Text, strHex))
                {
                    currdvdkey.SelectAll();
                    currdvdkey.Copy();
                    currdvdkey.DeselectAll();
                }
            }
        }
        //private void Logo_Click(object sender, EventArgs e) { System.Diagnostics.Process.Start("http://whipland.no-ip.org/.downloads/release/"); }
        public string[] getkvinfo()
        {
            string[] ret = new string[7];
            byte[] serialbytes = new byte[16];
            byte[] mfrbytes = new byte[8];
            byte[] osigbytes = new byte[28];
            int t = 0;
            for (int i = 0; i < Main.kv.Length; i++)
            {
                #region Serial
                if ((i > 175) && (i < 192))
                {
                    serialbytes[t] = Main.kv[i];
                    t++;
                    if (i == 191) 
                    {
                        ret[0] = Encoding.ASCII.GetString(serialbytes);
                        t = 0;
                    }
                }
                #endregion
                #region Region
                else if ((i > 199) && (i < 202))
                {
                    if (t == 0)
                    {
                        ret[1] = "0x";
                        ret[1] += Main.kv[i].ToString("X2");
                    }
                    else
                    {
                        ret[1] += Main.kv[i].ToString("X2");
                        ret[1] = Main.misc.translateregion(ret[1]) + " (" + ret[1] + ")";
                    }
                    t++;
                    if (t == 201) { t = 0; }
                }
                #endregion
                #region DVDKey
                else if ((i > 255) && (i < 272))
                {
                    if (t == 0) { ret[2] = Main.kv[i].ToString("X2"); }
                    else { ret[2] += Main.kv[i].ToString("X2"); }
                    t++;
                    if (i == 271) { t = 0; }
                }
                #endregion
                #region Console ID
                else if ((i > 2505) && (i < 2511))
                {
                    if (t == 0) { ret[3] = Main.kv[i].ToString("X2"); }
                    else { ret[3] += Main.kv[i].ToString("X2"); }
                    t++;
                    if (i == 2510) { t = 0; }
                }
                #endregion
                #region MFR-Date
                else if ((i > 2531) && (i < 2540))
                {
                    mfrbytes[t] = Main.kv[i];
                    t++;
                    if (i == 2539)
                    {
                        if (Regex.IsMatch(Encoding.ASCII.GetString(mfrbytes), "^[0-9]{2}-[0-9]{2}-[0-9]{2}$"))
                        {
                            string[] splitdate = Encoding.ASCII.GetString(mfrbytes).Split('-');
                            ret[4] = splitdate[1] + "-" + splitdate[0] + "-" + splitdate[2];
                        }
                        t = 0;
                    }
                }
                #endregion
                #region OSIG String
                else if ((i > 3217) && (i < 3246))
                {
                    osigbytes[t] = Main.kv[i];
                    t++;
                    if (i == 3245)
                    {
                        ret[5] = Encoding.ASCII.GetString(osigbytes);
                        t = 0;
                        i = Main.kv.Length;
                    }
                }
                #endregion
            }
            ret[6] = (Main.misc.swap16(BitConverter.ToUInt16(Main.kv, 0x1C)) == 0x00F0).ToString();
            for (int i = 0; i < ret.Length; i++)
            {
                try { ret[i] = ret[i].Substring(0, ret[i].IndexOf("\0")); }
                catch { }
                if (ret[i] != null) { ret[i] = ret[i].Trim(); }
            }
            return ret;
        }
        private void includedl_CheckedChanged(object sender, EventArgs e) { dlbeta.Enabled = includedl.Checked; }

        private void kvsave_Click(object sender, EventArgs e)
        {

            string az = Main.statc.source.Text;
            /*string cf1 = "";
            string cf0 = "";
            string cf1_LDV = "";
            string cf0_LDV = "";
            //string BB = "";
            int cf11 = 0;
            int cf00 = 0;*/
            string DirKv = Main.statc.output.Text + "\\KVInfos.txt";
            string blkey = "DD88AD0C9ED669E7B56794FB68563EFA";
            if (File.Exists(az))
            {
                FileInfo fi = new FileInfo(az);
                if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                {
                        string file = az;
                        int[] ret = Main.nand.getbootloaderversions(file);
                        if (ret[4] > 1) { cf0 = ret[4].ToString(); }
                        else { cf0 = "N/A"; }
                        if (ret[6] > 1) { cf1 = ret[6].ToString(); }
                        else { cf1 = "N/A"; }
                        byte[] data = Main.nand.getcf(file, ret[8]);
                        if (ret[4] > 1)
                        {

                            //byte[] data2 = Main.nand.getcf(file, ret[8]);
                            if (data.Length > 1)
                            {
                                data = Main.crypt.DecryptCF(data, Main.misc.cpukeytoarray(blkey));
                                if (Main.crypt.blcheck(ref data, 0x1F0, 0x20))
                                {
                                    cf00 = data[0x21F];
                                    cf0_LDV = ((int)data[0x21F]).ToString();
                                }
                                else
                                {
                                    cf0_LDV = "N/A";
                                }
                            }
                        }
                        if (ret[6] > 1)
                        {
                            data = Main.nand.getcf(file, ret[8] + ret[10]);
                            if (data.Length > 1)
                            {
                                data = Main.crypt.DecryptCF(data, Main.misc.cpukeytoarray(blkey));
                                if (Main.crypt.blcheck(ref data, 0x1F0, 0x20))
                                {
                                    cf11 = data[0x21F];
                                    cf1_LDV = ((int)data[0x21F]).ToString();
                                }
                                else
                                {
                                    //cf1 = "N/A";
                                    cf1_LDV = "N/A";

                                }
                            }
                        }
                }
                else 
                {
                    byte[] data = (BadBlock.find_bad_blocks_X(Main.statc.source.Text, 0x50));
                    kvinfoversion.unpack_base_image(data, true);               
                }

            }
            if (File.Exists(DirKv))
            {
                var result = MessageBox.Show("KVInfo Exist Do You Want To Overwrite", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (StreamWriter sw = new StreamWriter(Main.statc.output.Text + "\\KVInfos.txt"))
                    {
                        sw.WriteLine("********************************************************");
                        sw.WriteLine("********************************************************");
                        sw.WriteLine("");
                        sw.WriteLine("XboxType: " + mobobox.Text);
                        sw.WriteLine("");
                        sw.WriteLine("CpuKey: " + Main.statc.cpukey.Text);
                        sw.WriteLine("");
                        sw.WriteLine("DVDKey: " + currdvdkey.Text);
                        sw.WriteLine("");
                        sw.WriteLine("MFRDate: " + currmfr.Text);
                        sw.WriteLine("");
                        sw.WriteLine("ConsoleID: " + currcid.Text);
                        sw.WriteLine("");
                        sw.WriteLine("Serial: " + currserial.Text);
                        sw.WriteLine("");
                        sw.WriteLine("Region: " + currregion.Text);
                        sw.WriteLine("");
                        sw.WriteLine("OSIG: " + currosig.Text);
                        sw.WriteLine("");
                        sw.WriteLine("CB: " + cbbox.Text);
                        sw.WriteLine("");
                        if (mobobox.Text == "Jasper BB" || mobobox.Text == "Jasper BB (256MB)" || mobobox.Text == "Jasper BB (512MB)")
                        {
                            sw.WriteLine("BigBlock: Yes");
                            sw.WriteLine("");
                        }
                        else
                        {
                            sw.WriteLine("BigBlock: No");
                            sw.WriteLine("");
                        }
                        if (cf00 > cf11)
                        {
                            sw.WriteLine("LDV: " + cf0_LDV);
                            sw.WriteLine("");
                            sw.WriteLine("DashVersion: " + cf0);
                            sw.WriteLine("");
                        }
                        else
                        {
                            sw.WriteLine("LDV: " + cf1_LDV);
                            sw.WriteLine("");
                            sw.WriteLine("DashVersion: " + cf1);
                            sw.WriteLine("");
                        }
                        sw.WriteLine("FCRT: " + fcrtreq.Text);
                        sw.WriteLine("");
                        sw.WriteLine("********************************************************");
                        sw.WriteLine("********************************************************");
                    }
                    MessageBox.Show("KVInfo: Success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {

                }

            }
            else
            {

                using (StreamWriter sw = new StreamWriter(Main.statc.output.Text + "\\KVInfos.txt"))
                {
                    sw.WriteLine("********************************************************");
                    sw.WriteLine("********************************************************");
                    sw.WriteLine("");
                    sw.WriteLine("XboxType: " + mobobox.Text);
                    sw.WriteLine("");
                    sw.WriteLine("CpuKey: " + Main.statc.cpukey.Text);
                    sw.WriteLine("");
                    sw.WriteLine("DVDKey: " + currdvdkey.Text);
                    sw.WriteLine("");
                    sw.WriteLine("MFRDate: " + currmfr.Text);
                    sw.WriteLine("");
                    sw.WriteLine("ConsoleID: " + currcid.Text);
                    sw.WriteLine("");
                    sw.WriteLine("Serial: " + currserial.Text);
                    sw.WriteLine("");
                    sw.WriteLine("Region: " + currregion.Text);
                    sw.WriteLine("");
                    sw.WriteLine("OSIG: " + currosig.Text);
                    sw.WriteLine("");
                    sw.WriteLine("CB: " + cbbox.Text);
                    sw.WriteLine("");
                    if (mobobox.Text == "Jasper BB" || mobobox.Text == "Jasper BB (256MB)" || mobobox.Text == "Jasper BB (512MB)")
                    {
                        sw.WriteLine("BigBlock: Yes");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("BigBlock: No");
                        sw.WriteLine("");
                    }
                    if (cf00 > cf11)
                    {
                        sw.WriteLine("LDV: " + cf0_LDV);
                        sw.WriteLine("");
                        sw.WriteLine("DashVersion: " + cf0);
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("LDV: " + cf1_LDV);
                        sw.WriteLine("");
                        sw.WriteLine("DashVersion: " + cf1);
                        sw.WriteLine("");
                    }
                    sw.WriteLine("FCRT: " + fcrtreq.Text);
                    sw.WriteLine("");
                    sw.WriteLine("********************************************************");
                    sw.WriteLine("********************************************************");
                }
                MessageBox.Show("KVInfo: Success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        public void checkKvEnable()
        {
            if (Main.mright.currdvdkey.Text == "ERROR" || string.IsNullOrEmpty(currdvdkey.Text))
                Main.mright.kvsave.Enabled = false;
            else Main.mright.kvsave.Enabled = true;
        }
    }
}
