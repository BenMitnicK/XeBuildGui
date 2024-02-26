using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace xeBuild_GUI
{
    public partial class xeBuildset : UserControl
    {
        public xeBuildset() { InitializeComponent(); }
        public bool getxebuild()
        {
            int error = 0;
            Main.xebuildsettings.Clear();
            #region Page 1
            Main.xebuildsettings.Add("gpufan", (fanbar.Value * 5).ToString());
            Main.xebuildsettings.Add("cpufan", (fanbar.Value * 5).ToString());
            if (tempcheck(cputemp.Text, overcputemp.Text))
            {
                Main.xebuildsettings.Add("cputemp", cputemp.Text);
                Main.xebuildsettings.Add("overcputemp", overcputemp.Text);
            }
            else { error++; }
            if (tempcheck(gputemp.Text, overgputemp.Text))
            {
                Main.xebuildsettings.Add("gputemp", gputemp.Text);
                Main.xebuildsettings.Add("overgputemp", overgputemp.Text);
            }
            else { error++; }
            if (tempcheck(edramtemp.Text, overedramtemp.Text))
            {
                Main.xebuildsettings.Add("edramtemp", edramtemp.Text);
                Main.xebuildsettings.Add("overedramtemp", overedramtemp.Text);
            }
            else { error++; }
            string videomode = "";
            foreach (Control c in videobox.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb.Checked)
                {
                    if (rb == ntsc) { videomode = "0x100"; }
                    else if (rb == pal) { videomode = "0x300"; }
                    else { videomode = ""; }
                }
            }
            Main.xebuildsettings.Add("avregion", videomode);
            Main.xebuildsettings.Add("macid", macid.Text);
            Main.xebuildsettings.Add("nodvd", nodvd.Checked.ToString());
            Main.xebuildsettings.Add("olddvd", olddvd.Checked.ToString());
            Main.xebuildsettings.Add("cygnos", cygnosuart.Checked.ToString());
            Main.xebuildsettings.Add("dvdkey", dvdkey.Text);
            if ((dvdregion.Text.Length != 0) && (dvdregion.Text != "Current")) { Main.xebuildsettings.Add("dvdregion", dvdregion.Text.Substring(0, 1)); }
            else { Main.xebuildsettings.Add("dvdregion", ""); }
            if ((gameregion.Text.Length != 0) && (gameregion.Text != "Current")) { Main.xebuildsettings.Add("gameregion", Main.misc.translateregion(gameregion.Text)); }
            else { Main.xebuildsettings.Add("gameregion", ""); }
            Main.xebuildsettings.Add("nandmu", nandmu.Checked.ToString());
            Main.xebuildsettings.Add("nosecurity", nosecurity.Checked.ToString());
            Main.xebuildsettings.Add("nomobile", nomobile.Checked.ToString());
            Main.xebuildsettings.Add("noremap", noremap.Checked.ToString());
            Main.xebuildsettings.Add("noecdremap", noecdremap.Checked.ToString());
            #endregion
            #region Page 2
            string xellbtn = "";
            string xellbtn2 = "";
            string dual = "";
            foreach (Control c in xellbutton.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb.Checked)
                {
                    xellbtn = rb.Name.Substring(4, rb.Name.Length - 4);
                }
            }
            foreach (Control c in xellbutton2.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb.Checked)
                {
                    xellbtn2 = rb.Name.Substring(5, rb.Name.Length - 5);
                }
            }
            foreach (Control c in dualboot.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb.Checked)
                {
                    dual = rb.Name.Substring(4, rb.Name.Length - 4);
                }
            }
            if ((xellbtn != "none") && (xellbtn2 != "none") && (dual != "none"))
            {
                if (xellbtn != xellbtn2)
                {
                    if (xellbtn != dual)
                    {
                        Main.xebuildsettings.Add("xellbutton", xellbtn);
                        Main.xebuildsettings.Add("xellbutton2", xellbtn2);
                        Main.xebuildsettings.Add("dualboot", dual);
                    }
                    else { error++; }
                }
                else { error++; }
            }
            else
            {
                Main.xebuildsettings.Add("xellbutton", xellbtn);
                Main.xebuildsettings.Add("xellbutton2", xellbtn2);
                Main.xebuildsettings.Add("dualboot", dual);
            }
            #endregion
            Main.xebuildsettings.Add("cfldv", Main.mright.cfldv.Text);
            if (error == 0)
            {
                return true;
            }
            else
            {
                Main.xebuildsettings.Clear();
                return false;
            }
        }
        private void manualtab_Enter(object sender, System.EventArgs e)
        {
            xebuildsettings.Text = "";
            if (getxebuild())
            {
                foreach (KeyValuePair<string, string> pair in Main.xebuildsettings)
                {
                    if ((!string.IsNullOrEmpty(pair.Value)) && (pair.Value != "none"))
                    {
                        xebuildsettings.AppendText(pair.Key + "=" + pair.Value + "\n");
                    }
                }
            }
            else 
            {
                MessageBox.Show("ERROR: Check your xeBuild Settings configuration!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XBtab.SelectedTab = XBPage1;
            }
        }
        private void fanbar_ValueChanged(object sender, System.EventArgs e)
        {
            if (fanbar.Value != 0) { fanspeedbox.Text = "Fanspeed(s): " + (fanbar.Value * 5).ToString() + "%"; }
            else { fanspeedbox.Text = "Fanspeed(s): Automatic"; }
        }
        private void macid_KeyPress(object sender, KeyPressEventArgs e) { Main.test.macinput(sender, e); }
        private void ctrlfix(object sender, KeyEventArgs e) { Main.test.ctrlfix(sender, e); }
        private void dvdkey_KeyPress(object sender, KeyPressEventArgs e) { Main.test.hexinput(sender, e); }
        private void macid_TextChanged(object sender, System.EventArgs e) { macid.Text = macid.Text.Replace('-', ':'); }
        private void numeric(object sender, KeyPressEventArgs e) { Main.test.numinput(sender, e); }
        private bool tempcheck(string temp, string overtemp)
        {
            if ((!string.IsNullOrEmpty(temp)) || (!string.IsNullOrEmpty(overtemp)))
            {
                try { return (int.Parse(temp) < int.Parse(overtemp)); }
                catch { return false; }
            }
            else { return true; }
        }
        private void resetbtn_Click(object sender, System.EventArgs e)
        {
            fanbar.Value = 0;
            cputemp.Text = "";
            overcputemp.Text = "";
            gputemp.Text = "";
            overgputemp.Text = "";
            edramtemp.Text = "";
            overedramtemp.Text = "";
            current.Checked = true;
            macid.Text = "";
            nodvd.Checked = false;
            olddvd.Checked = false;
            cygnosuart.Checked = false;
            dvdkey.Text = "";
            dvdregion.Text = "Current";
            gameregion.Text = "Current";
            verbose.Checked = false;
            nandmu.Checked = false;
            nosecurity.Checked = false;
            nomobile.Checked = false;
            noremap.Checked = false;
            noecdremap.Checked = false;
            xellnone.Checked = true;
            xell2none.Checked = true;
            dualnone.Checked = true;
            xebuildsettings.Text = "";
        }
        private void loadbtn_Click(object sender, System.EventArgs e)
        {
            if (openini.ShowDialog() == DialogResult.OK)
            {
                loadxebuild(openini.FileName);
            }
            openini.FileName = "options.ini";
        }
        public void loadxebuild(string source)
        {
            string line = "";
            string[] tmp = new string[1];
            xebuildsettings.Text = "";
            using (StreamReader sr = new StreamReader(source))
            {
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (!line.StartsWith(";"))
                        {
                            xebuildsettings.AppendText(line + "\n");
                            tmp = line.Split('=');
                            switch (tmp[0].Trim().ToLower())
                            {
                                case "type":
                                    switch (tmp[1].Trim().ToLower())
                                    {
                                        case "falcon":
                                            Main.statc.falcon.Checked = true;
                                            break;
                                        case "xenon":
                                            Main.statc.xenon.Checked = true;
                                            break;
                                        case "zephyr":
                                            Main.statc.zephyr.Checked = true;
                                            break;
                                        case "jasper":
                                            Main.statc.jasper.Checked = true;
                                            break;
                                        case "jasper256":
                                            Main.statc.jasperbb.Checked = true;
                                            break;
                                        case "jasper512":
                                            Main.statc.jasperbb.Checked = true;
                                            break;
                                        case "jasperbb":
                                            Main.statc.jasperbb.Checked = true;
                                            break;
                                        case "jasperbigffs":
                                            Main.statc.jasperbigffs.Checked = true;
                                            break;
                                        case "jaspersb":
                                            Main.statc.jaspersb.Checked = true;
                                            break;
                                        case "trinity":
                                            Main.statc.trinity.Checked = true;
                                            break;
                                        case "corona":
                                            Main.statc.trinity.Checked = true;
                                            break;
                                        default:
                                            Main.statc.xenon.Checked = false;
                                            Main.statc.zephyr.Checked = false;
                                            Main.statc.falcon.Checked = false;
                                            Main.statc.jasper.Checked = false;
                                            Main.statc.corona.Checked = false;
                                            Main.statc.trinity.Checked = false;
                                            Main.statc.jasperbb.Checked = false;
                                            Main.statc.jaspersb.Checked = false;
                                            Main.statc.jasperbigffs.Checked = false;
                                            break;
                                    }
                                    break;
                                case "1blkey": case "cpukey": case "dvdkey":
                                    setkey(tmp[1].Trim(), tmp[0].Trim());
                                    break;
                                case "cfldv":
                                    setnumeric(tmp[1].Trim(), tmp[0].Trim());
                                    break;
                                case "xellbutton": case "xellbutton2": case "dualboot":
                                    setbootreason(tmp[1].Trim(), tmp[0].Trim());
                                    break;
                                case "cygnos":
                                    cygnosuart.Checked = (tmp[1].Trim().Equals("true", System.StringComparison.CurrentCultureIgnoreCase));
                                    break;
                                case "olddvd":
                                    olddvd.Checked = (tmp[1].Trim().Equals("true", System.StringComparison.CurrentCultureIgnoreCase));
                                    break;
                                case "nodvd":
                                    nodvd.Checked = (tmp[1].Trim().Equals("true", System.StringComparison.CurrentCultureIgnoreCase));
                                    break;
                                case "nomobile":
                                    nomobile.Checked = (tmp[1].Trim().Equals("true", System.StringComparison.CurrentCultureIgnoreCase));
                                    break;
                                case "noremap":
                                    noremap.Checked = (tmp[1].Trim().Equals("true", System.StringComparison.CurrentCultureIgnoreCase));
                                    break;
                                case "noecdremap":
                                    noecdremap.Checked = (tmp[1].Trim().Equals("true", System.StringComparison.CurrentCultureIgnoreCase));
                                    break;
                                case "nosecurity":
                                    nosecurity.Checked = (tmp[1].Trim().Equals("true", System.StringComparison.CurrentCultureIgnoreCase));
                                    break;
                                case "nandmu":
                                    nandmu.Checked = (tmp[1].Trim().Equals("true", System.StringComparison.CurrentCultureIgnoreCase));
                                    break;
                                case "cputemp": case "gputemp": case "edramtemp": case "overcputemp": case "overgputemp": case "overedramtemp":
                                    setnumeric(tmp[1].Trim(), tmp[0].Trim());
                                    break;
                                case "cpufan": case "gpufan":
                                    setfan(tmp[1].Trim());
                                    break;
                                case "avregion":
                                    if (tmp[1].Trim().Equals("0x100", System.StringComparison.CurrentCultureIgnoreCase)) { ntsc.Checked = true; }
                                    else if (tmp[1].Trim().Equals("0x300", System.StringComparison.CurrentCultureIgnoreCase)) { pal.Checked = true; }
                                    else { current.Checked = true; }
                                    break;
                                case "gameregion":
                                    gameregion.Text = Main.misc.translateregion(tmp[1].Trim());
                                    if (gameregion.Text == "") { gameregion.Text = "Current"; }
                                    break;
                                case "dvdregion":
                                    switch (tmp[1].Trim())
                                    {
                                        case "1":
                                            dvdregion.Text = "1 (North America)";
                                            break;
                                        case "2":
                                            dvdregion.Text = "2 (Europe)";
                                            break;
                                        case "3":
                                            dvdregion.Text = "3 (South East Asia)";
                                            break;
                                        case "4":
                                            dvdregion.Text = "4 (Australia)";
                                            break;
                                        case "5":
                                            dvdregion.Text = "5 (Russia/South Asia)";
                                            break;
                                        case "6":
                                            dvdregion.Text = "6 (China)";
                                            break;
                                        case "7":
                                            dvdregion.Text = "7 (Unkown)";
                                            break;
                                        case "8":
                                            dvdregion.Text = "8 (Aircrafts etc.)";
                                            break;
                                        default:
                                            dvdregion.Text = "Current";
                                            break;
                                    }
                                    break;
                                case "macid":
                                    if (Main.test.maccheck(tmp[1].Trim())) { macid.Text = tmp[1].Trim(); }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
        private void setkey(string source, string targettype)
        {
            if (Main.test.keycheck(source))
            {
                if (targettype == "1blkey") { Main.statc.blkey.Text = source; }
                else if (targettype == "cpukey") { Main.statc.cpukey.Text = source; }
                else if (targettype == "dvdkey") { Main.xeset.dvdkey.Text = source; }
            }
        }
        private void setnumeric(string source, string targettype)
        {
            if (Main.test.isNumeric(source, System.Globalization.NumberStyles.Integer))
            {
                if (targettype == "cfldv") { Main.mright.cfldv.Text = source; }
                else if (targettype == "cputemp") { Main.xeset.cputemp.Text = source; }
                else if (targettype == "gputemp") { Main.xeset.gputemp.Text = source; }
                else if (targettype == "edramtemp") { Main.xeset.edramtemp.Text = source; }
                else if (targettype == "overcputemp") { Main.xeset.overcputemp.Text = source; }
                else if (targettype == "overgputemp") { Main.xeset.overgputemp.Text = source; }
                else if (targettype == "overedramtemp") { Main.xeset.overedramtemp.Text = source; }
            }
        }
        int fancount = 0, mainfan = 0;
        private void setfan(string source)
        {
            if (Main.test.isNumeric(source, System.Globalization.NumberStyles.Integer))
            {
                if (fancount == 0) { mainfan = int.Parse(source); }
                else
                {
                    if (mainfan == int.Parse(source)) { Main.xeset.fanbar.Value = mainfan; }
                    else { Main.xeset.fanbar.Value = ((mainfan + int.Parse(source)) / 2); }
                }
            }
            fancount++;
            if (fancount == 2) { fancount = 0; }
        }
        private void setbootreason(string source, string targettype)
        {
            #region Xell Button
            if (targettype == "xellbutton")
            {
                switch (source)
                {
                    case "power":
                        xellpower.Checked = true;
                        break;
                    case "eject":
                        xellnone.Checked = true;
                        break;
                    case "wirelessx":
                        xellwirelessx.Checked = true;
                        break;
                    case "wiredx":
                        xellwiredx.Checked = true;
                        break;
                    case "remopower":
                        xellremopower.Checked = true;
                        break;
                    case "remox":
                        xellremox.Checked = true;
                        break;
                    case "winbutton":
                        xellwinbutton.Checked = true;
                        break;
                    default:
                        xellnone.Checked = true;
                        break;
                }
            }
            #endregion
            #region Secondary Xell Button
            if (targettype == "xellbutton2")
            {
                switch (source)
                {
                    case "power":
                        xell2power.Checked = true;
                        break;
                    case "eject":
                        xell2eject.Checked = true;
                        break;
                    case "wirelessx":
                        xell2wirelessx.Checked = true;
                        break;
                    case "wiredx":
                        xell2wiredx.Checked = true;
                        break;
                    case "remopower":
                        xell2remopower.Checked = true;
                        break;
                    case "remox":
                        xell2remox.Checked = true;
                        break;
                    case "winbutton":
                        xell2winbutton.Checked = true;
                        break;
                    default:
                        xell2none.Checked = true;
                        break;
                }
            }
            #endregion
            #region Dualboot Button
            if (targettype == "dualboot")
            {
                switch (source)
                {
                    case "power":
                        dualpower.Checked = true;
                        break;
                    case "eject":
                        dualeject.Checked = true;
                        break;
                    case "wirelessx":
                        dualwirelessx.Checked = true;
                        break;
                    case "wiredx":
                        dualwiredx.Checked = true;
                        break;
                    case "remopower":
                        dualremopower.Checked = true;
                        break;
                    case "remox":
                        dualremox.Checked = true;
                        break;
                    case "winbutton":
                        dualwinbutton.Checked = true;
                        break;
                    default:
                        dualnone.Checked = true;
                        break;
                }
            }
            #endregion
        }
        private void macid_Leave(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(macid.Text))
            {
                if (!Main.test.maccheck(macid.Text))
                {
                    MessageBox.Show("ERROR: Invalid MAC adress, Expected format: 0A:1B:2C:3E:4D:5E", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    macid.Text = "";
                }
            }
        }
        private void savebtn_Click(object sender, System.EventArgs e)
        {
            saveini.InitialDirectory = Main.dir + "\\files\\data\\";
            if (XBtab != null && XBtab.SelectedTab != manualtab)
            {
                XBtab.SelectedTab = manualtab;
            }
            if (saveini.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveini.FileName))
                {
                    sw.WriteLine(";Generated by xeBuild GUI " + Main.version);
                    foreach (string line in xebuildsettings.Lines)
                    {
                        sw.WriteLine(line);
                    }
                }
                saveini.FileName = "options.ini";
            }
        }
        private void genmac_Click(object sender, System.EventArgs e)
        {
            byte[] macbytes = new byte[6];
            Main.random.NextBytes(macbytes);
            string generated = "";
            foreach (byte b in macbytes)
            {
                generated += b.ToString("X2") + ":";
            }
            generated = generated.Substring(0, generated.Length - 1);
            macid.Text = generated;
        }
        private void customininame_TextChanged(object sender, System.EventArgs e)
        {
            customininame.Text = customininame.Text.Replace("/", "");
            customininame.Text = customininame.Text.Replace("\\", "");
        }
    }
}