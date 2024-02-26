using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace xeBuild_GUI
{
    public partial class Dashlaunch : UserControl
    {
        private string device = null;
        private TextBox tb = null;
        public Dashlaunch() { InitializeComponent(); }
        public bool getdashlaunchsettings()
        {
            Main.dashlaunchsettings.Clear();
            #region Page 1
            Main.dashlaunchsettings.Add("fatalfreeze", fatalfreeze.Checked.ToString());
            Main.dashlaunchsettings.Add("fatalreboot", fatalreboot.Checked.ToString());
            Main.dashlaunchsettings.Add("safereboot", safereboot.Checked.ToString());
            Main.dashlaunchsettings.Add("exechandler", exechandler.Checked.ToString());
            Main.dashlaunchsettings.Add("dumpfile", dumpfile.Text);
            Main.dashlaunchsettings.Add("nohud", nohud.Checked.ToString());
            Main.dashlaunchsettings.Add("nxemini", nxemini.Checked.ToString());
            Main.dashlaunchsettings.Add("nosysexit", nosysexit.Checked.ToString());
            Main.dashlaunchsettings.Add("liveblock", liveblock.Checked.ToString());
            Main.dashlaunchsettings.Add("livestrong", livestrong.Checked.ToString());
            Main.dashlaunchsettings.Add("noupdater", noupdater.Checked.ToString());
            Main.dashlaunchsettings.Add("pingpatch", pingpatch.Checked.ToString());
            Main.dashlaunchsettings.Add("contpatch", contpatch.Checked.ToString());
            Main.dashlaunchsettings.Add("xhttp", xhttp.Checked.ToString());
            Main.dashlaunchsettings.Add("signnotice", signnotice.Checked.ToString());
            Main.dashlaunchsettings.Add("autoshut", autoshut.Checked.ToString());
            Main.dashlaunchsettings.Add("xblaexitdash", xblaexitdash.Checked.ToString());
            Main.dashlaunchsettings.Add("remotenxe", remotenxe.Checked.ToString());
            Main.dashlaunchsettings.Add("dvdexitdash", dvdexitdash.Checked.ToString());
            Main.dashlaunchsettings.Add("autooff", autooff.Checked.ToString());
            Main.dashlaunchsettings.Add("fakelive", fakelive.Checked.ToString());
            #endregion
            #region Page 2
            Main.dashlaunchsettings.Add("hddalive", hddalive.Checked.ToString());
            Main.dashlaunchsettings.Add("hddtimer", hddtimer.Text);
            Main.dashlaunchsettings.Add("tempbcast", tempbcast.Checked.ToString());
            Main.dashlaunchsettings.Add("temptime", temptime.Text);
            Main.dashlaunchsettings.Add("tempport", tempport.Text);
            Main.dashlaunchsettings.Add("bootdelay", bootdelay.Text);
            Main.dashlaunchsettings.Add("regionspoof", regionspoof.Checked.ToString());
            foreach (Control c in region.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb.Checked)
                {
                    Main.dashlaunchsettings.Add("region", "0x" + rb.Name.Substring(1, rb.Name.Length - 1));
                }
            }
            #endregion
            return true;
        }
        public bool getdashlaunchplugins()
        {
            int errorplugins = 0;
            Main.dashlaunchplugins.Clear();
            if ((devcheck(plugin1.Text)) && (endcheck(plugin1.Text, true))) { Main.dashlaunchplugins.Add("plugin1", plugin1.Text); }
            else { errorplugins++; }
            if ((devcheck(plugin2.Text)) && (endcheck(plugin2.Text, true))) { Main.dashlaunchplugins.Add("plugin2", plugin2.Text); }
            else { errorplugins++; }
            if ((devcheck(plugin3.Text)) && (endcheck(plugin3.Text, true))) { Main.dashlaunchplugins.Add("plugin3", plugin3.Text); }
            else { errorplugins++; }
            if ((devcheck(plugin4.Text)) && (endcheck(plugin4.Text, true))) { Main.dashlaunchplugins.Add("plugin4", plugin4.Text); }
            else { errorplugins++; }
            if ((devcheck(plugin5.Text)) && (endcheck(plugin5.Text, true))) { Main.dashlaunchplugins.Add("plugin5", plugin5.Text); }
            else { errorplugins++; }
            if (errorplugins == 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("ERROR: Check your Plugins configuartion on Dashlaunch Settings Page 2", "Plugins ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool getdashlaunchqlbtns()
        {
            int errorqlbtns = 0;
            Main.dashlaunchqlbtns.Clear();
            if ((devcheck(BUT_A.Text)) && (endcheck(BUT_A.Text, false)) && (totalcheck(BUT_A.Text))) { Main.dashlaunchqlbtns.Add("BUT_A", BUT_A.Text); }
            else { errorqlbtns++; }
            if ((devcheck(BUT_B.Text)) && (endcheck(BUT_B.Text, false)) && (totalcheck(BUT_B.Text))) { Main.dashlaunchqlbtns.Add("BUT_B", BUT_B.Text); }
            else { errorqlbtns++; }
            if ((devcheck(BUT_X.Text)) && (endcheck(BUT_X.Text, false)) && (totalcheck(BUT_X.Text))) { Main.dashlaunchqlbtns.Add("BUT_X", BUT_X.Text); }
            else { errorqlbtns++; }
            if ((devcheck(BUT_Y.Text)) && (endcheck(BUT_Y.Text, false)) && (totalcheck(BUT_Y.Text))) { Main.dashlaunchqlbtns.Add("BUT_Y", BUT_Y.Text); }
            else { errorqlbtns++; }
            if ((devcheck(Start.Text)) && (endcheck(Start.Text, false)) && (totalcheck(Start.Text))) { Main.dashlaunchqlbtns.Add("Start", Start.Text); }
            else { errorqlbtns++; }
            if ((devcheck(Back.Text)) && (endcheck(Back.Text, false)) && (totalcheck(Back.Text))) { Main.dashlaunchqlbtns.Add("Back", Back.Text); }
            else { errorqlbtns++; }
            if ((devcheck(LBump.Text)) && (endcheck(LBump.Text, false)) && (totalcheck(LBump.Text))) { Main.dashlaunchqlbtns.Add("LBump", LBump.Text); }
            else { errorqlbtns++; }
            if ((devcheck(Default.Text)) && (endcheck(Default.Text, false)) && (totalcheck(Default.Text))) { Main.dashlaunchqlbtns.Add("Default", Default.Text); }
            else { errorqlbtns++; }
            if ((devcheck(Power.Text)) && (endcheck(Power.Text, false)) && (totalcheck(Power.Text))) { Main.dashlaunchqlbtns.Add("Power", Power.Text); }
            else { errorqlbtns++; }
            if ((devcheck(Guide.Text)) && (endcheck(Guide.Text, false)) && (totalcheck(Guide.Text))) { Main.dashlaunchqlbtns.Add("Guide", Guide.Text); }
            else { errorqlbtns++; }
            if (errorqlbtns == 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("ERROR: Check your configuration on Page 3 of Dashlaunch settings!", "Quick Launch Buttons ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool devcheck(string test)
        {
            if (!String.IsNullOrEmpty(test))
            {
                test = Regex.Replace(test, "//", "\\");
                if ((!test.StartsWith("USB:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.StartsWith("HDD:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.StartsWith("USBMU:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.StartsWith("MU:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.StartsWith("FLASHMU:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.StartsWith("INTMU:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.StartsWith("DVD:\\", StringComparison.CurrentCultureIgnoreCase)))
                { return false; }
                else { return true; }
            }
            else { return true; }
        }
        private bool endcheck(string test, bool type)
        {
            if (!String.IsNullOrEmpty(test))
            {
                if ((!test.EndsWith(".dll", StringComparison.CurrentCultureIgnoreCase)) && (!test.EndsWith(".xex", StringComparison.CurrentCultureIgnoreCase)) && (type)) { return false; }
                else { return true; }
                }
            else { return true; }
        }
        private bool totalcheck(string test)
        {
            if ((!test.Equals("USB:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.Equals("HDD:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.Equals("USBMU:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.Equals("MU:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.Equals("FLASHMU:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.Equals("INTMU:\\", StringComparison.CurrentCultureIgnoreCase)) &&
                    (!test.Equals("DVD:\\", StringComparison.CurrentCultureIgnoreCase)))
            { return true; }
            else { return false; }
        }
        private void DLMan_Enter(object sender, EventArgs e)
        {
            dlsettings.Text = "";
            dlplugins.Text = "";
            dlqlbtns.Text = "";
            if (getdashlaunchsettings())
            {
                foreach (KeyValuePair<string, string> pair in Main.dashlaunchsettings)
                {
                    if ((!string.IsNullOrEmpty(pair.Value)) && (pair.Value != "none"))
                    {
                        dlsettings.AppendText(pair.Key + "=" + pair.Value + "\n");
                    }
                }
            }
            if (getdashlaunchplugins())
            {
                foreach (KeyValuePair<string, string> pair in Main.dashlaunchplugins)
                {
                    if ((!string.IsNullOrEmpty(pair.Value)) && (pair.Value != "none"))
                    {
                        dlplugins.AppendText(pair.Key + "=" + pair.Value + "\n");
                    }
                }
            }
            if (getdashlaunchqlbtns())
            {
                {
                foreach (KeyValuePair<string, string> pair in Main.dashlaunchqlbtns)
                {
                    if ((!string.IsNullOrEmpty(pair.Value)) && (pair.Value != "none"))
                    {
                        dlqlbtns.AppendText(pair.Key + "=" + pair.Value + "\n");
                    }
                }
                }
            }
        }
        private void devchanged(object sender, EventArgs e)
        {
            foreach (Control c in DLDevices.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked)
                    {
                        device = rb.Name.ToUpper();
                        setdevenable();
                    }
                }
            }
        }
        private void tbchanged(object sender, EventArgs e)
        {
            tb = sender as TextBox;
            setdevenable();
        }
        private void setdevenable()
        {
            if ((device != null) && (tb != null))
            {
                setdevbtn.Enabled = true;
                if ((tb == dumpfile) && ((device == "DVD") || (string.IsNullOrEmpty(device))))
                {
                    device = "";
                    DVD.Checked = false;
                    setdevbtn.Text = "Select a device and textbox to activate this feature/button";
                    setdevbtn.Enabled = false;
                }
                else
                {
                    setdevbtn.Text = "Set " + device + ":\\ as device for " + tb.Name;
                }
            }
        }
        private void setdevbtn_Click(object sender, EventArgs e)
        {
            string text = tb.Text;
            if (!String.IsNullOrEmpty(text))
            {
                if (text.Contains(":\\"))
                {
                    string[] splittxt = text.Split('\\');
                    string newtxt = "";
                    splittxt[0] = device + ":";
                    for (int i = 0; i < splittxt.Length; i++)
                    {
                        newtxt += "\\" + splittxt[i];
                    }
                    text = newtxt.Remove(0, 1);
                }
                else { text = device + ":\\" + text; }
            }
            else { text = device + ":\\" + text; }
            tb.Text = text;
            if (!String.IsNullOrEmpty(tb.Text))
            {
                tb.Text = Regex.Replace(tb.Text, "\\\\+", "\\");
            }
        }
        private void numeric(object sender, KeyPressEventArgs e) { Main.test.numinput(sender, e); }
        private void savebtn_Click(object sender, EventArgs e)
        {
            savelaunch.InitialDirectory = Main.dir;
            if (Dashlaunchtab.SelectedTab != DLMan)
            {
                Dashlaunchtab.SelectedTab = DLMan;
            }
            if (savelaunch.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savelaunch.FileName, false, System.Text.Encoding.ASCII))
                {
                    sw.WriteLine(";Generated by xeBuild GUI " + Main.version);
                    string[] lines = dlqlbtns.Lines;
                    if (lines.Length > 0)
                    {
                        sw.WriteLine("[QuickLaunchButtons]");
                        foreach (string s in lines)
                        {
                            sw.WriteLine(s);
                        }
                    }
                    lines = dlplugins.Lines;
                    if (lines.Length > 0)
                    {
                        sw.WriteLine("[Plugins]");
                        foreach (string s in lines)
                        {
                            sw.WriteLine(s);
                        }
                    }
                    lines = dlsettings.Lines;
                    if (lines.Length > 0)
                    {
                        sw.WriteLine("[Settings]");
                        foreach (string s in lines)
                        {
                            sw.WriteLine(s);
                        }
                    }
                }
            }
            savelaunch.FileName = "launch.ini";
        }
        private void loadbtn_Click(object sender, EventArgs e)
        {
            openlaunch.InitialDirectory = Main.dir;
            if (openlaunch.ShowDialog() == DialogResult.OK)
            {
                loaddlsettings(openlaunch.FileName);
            }
            openlaunch.FileName = "launch.ini";
        }
        public void loaddlsettings(string source)
        {
            resetbtn_Click(null, null);
            string line = "";
            string[] tmp = new string[1];
            using (StreamReader sr = new StreamReader(source))
            {
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {
                        if (!line.StartsWith(";"))
                        {
                            tmp = line.Split('=');
                            switch (tmp[0].ToLower().Trim())
                            {
                                    #region Quick Launch Buttons
                                case "but_a":
                                    BUT_A.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("BUT_A = " + tmp[1].Trim() + "\n");
                                    break;
                                case "but_b":
                                    BUT_B.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("BUT_B = " + tmp[1].Trim() + "\n");
                                    break;
                                case "but_x":
                                    BUT_X.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("BUT_X = " + tmp[1].Trim() + "\n");
                                    break;
                                case "but_y":
                                    BUT_Y.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("BUT_Y = " + tmp[1].Trim() + "\n");
                                    break;
                                case "start":
                                    Start.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("Start = " + tmp[1].Trim() + "\n");
                                    break;
                                case "back":
                                    Back.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("Back = " + tmp[1].Trim() + "\n");
                                    break;
                                case "lbump":
                                    LBump.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("LBump = " + tmp[1].Trim() + "\n");
                                    break;
                                case "default":
                                    Default.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("Default = " + tmp[1].Trim() + "\n");
                                    break;
                                case "guide":
                                    Guide.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("Guide = " + tmp[1].Trim() + "\n");
                                    break;
                                case "power":
                                    Power.Text = tmp[1].Trim();
                                    dlqlbtns.AppendText("Power = " + tmp[1].Trim() + "\n");
                                    break;
                                    #endregion
                                    #region Plugins
                                case "plugin1":
                                    plugin1.Text = tmp[1].Trim();
                                    dlplugins.AppendText("plugin1 = " + tmp[1].Trim() + "\n");
                                    break;
                                case "plugin2":
                                    plugin2.Text = tmp[1].Trim();
                                    dlplugins.AppendText("plugin2 = " + tmp[1].Trim() + "\n");
                                    break;
                                case "plugin3":
                                    plugin3.Text = tmp[1].Trim();
                                    dlplugins.AppendText("plugin3 = " + tmp[1].Trim() + "\n");
                                    break;
                                case "plugin4":
                                    plugin4.Text = tmp[1].Trim();
                                    dlplugins.AppendText("plugin4 = " + tmp[1].Trim() + "\n");
                                    break;
                                case "plugin5":
                                    plugin5.Text = tmp[1].Trim();
                                    dlplugins.AppendText("plugin5 = " + tmp[1].Trim() + "\n");
                                    break;
                                    #endregion
                                    #region Settings
                                case "nxemini":
                                    nxemini.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("nxemini = " + tmp[1].Trim() + "\n");
                                    break;
                                case "pingpatch":
                                    pingpatch.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("pingpatch = " + tmp[1].Trim() + "\n");
                                    break;
                                case "contpatch":
                                    contpatch.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("contpatch = " + tmp[1].Trim() + "\n");
                                    break;
                                case "fatalfreeze":
                                    fatalfreeze.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("fatalfreeze = " + tmp[1].Trim() + "\n");
                                    break;
                                case "fatalreboot":
                                    fatalreboot.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("fatalreboot = " + tmp[1].Trim() + "\n");
                                    break;
                                case "safereboot":
                                    safereboot.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("safereboot = " + tmp[1].Trim() + "\n");
                                    break;
                                case "regionspoof":
                                    regionspoof.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("regionspoof = " + tmp[1].Trim() + "\n");
                                    break;
                                case "region":
                                    foreach (Control c in region.Controls)
                                    {
                                        RadioButton rb = c as RadioButton;
                                        rb.Checked = (rb.Name == ("r" + tmp[1].Trim().Substring(2, tmp[1].Trim().Length - 2).ToUpper()));
                                    }
                                    dlsettings.AppendText("region = " + tmp[1].Trim() + "\n");
                                    break;
                                case "dvdexitdash":
                                    dvdexitdash.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("dvdexitdash = " + tmp[1].Trim() + "\n");
                                    break;
                                case "xblaexitdash":
                                    xblaexitdash.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("xblaexitdash = " + tmp[1].Trim() + "\n");
                                    break;
                                case "nosysexit":
                                    nosysexit.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("nosysexit = " + tmp[1].Trim() + "\n");
                                    break;
                                case "nohud":
                                    nohud.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("nohud = " + tmp[1].Trim() + "\n");
                                    break;
                                case "noupdater":
                                    noupdater.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("noupdater = " + tmp[1].Trim() + "\n");
                                    break;
                                case "debugout":
                                    debugout.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("debugout = " + tmp[1].Trim() + "\n");
                                    break;
                                case "exechandler":
                                    exechandler.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("exechandler = " + tmp[1].Trim() + "\n");
                                    break;
                                case "dumpfile":
                                    dumpfile.Text = tmp[1].Trim();
                                    dlsettings.AppendText("dumpfile = " + tmp[1].Trim() + "\n");
                                    break;
                                case "bootdelay":
                                    if (tmp[1].Trim().StartsWith("0x", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        bootdelay.Text = int.Parse(tmp[1].Trim().Substring(2, tmp[1].Trim().Length - 2), System.Globalization.NumberStyles.HexNumber).ToString();
                                    }
                                    else
                                    {
                                        bootdelay.Text = tmp[1].Trim();
                                    }
                                    dlsettings.AppendText("bootdelay = " + bootdelay.Text);
                                    break;
                                case "liveblock":
                                    liveblock.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("liveblock = " + tmp[1].Trim() + "\n");
                                    break;
                                case "livestrong":
                                    livestrong.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("livestrong = " + tmp[1].Trim() + "\n");
                                    break;
                                case "hddalive":
                                    hddalive.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("hddalive = " + tmp[1].Trim() + "\n");
                                    break;
                                case "hddtimer":
                                    hddtimer.Text = tmp[1].Trim();
                                    dlsettings.AppendText("hddtimer = " + tmp[1].Trim() + "\n");
                                    break;
                                case "signnotice":
                                    signnotice.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("signnotice = " + tmp[1].Trim() + "\n");
                                    break;
                                case "autooff":
                                    autooff.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("autooff = " + tmp[1].Trim() + "\n");
                                    break;
                                case "autoshut":
                                    autoshut.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("autoshut = " + tmp[1].Trim() + "\n");
                                    break;
                                case "xhttp":
                                    xhttp.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("xhttp = " + tmp[1].Trim() + "\n");
                                    break;
                                case "tempbcast":
                                    tempbcast.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("tempbcast = " + tmp[1].Trim() + "\n");
                                    break;
                                case "temptime":
                                    temptime.Text = tmp[1].Trim();
                                    dlsettings.AppendText("temptime = " + tmp[1].Trim() + "\n");
                                    break;
                                case "tempport":
                                    tempport.Text = tmp[1].Trim();
                                    dlsettings.AppendText("tempport = " + tmp[1].Trim() + "\n");
                                    break;
                                case "fakelive":
                                    fakelive.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                    dlsettings.AppendText("fakelive = " + tmp[1].Trim() + "\n");
                                    break;
                                    #endregion
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
        private void resetbtn_Click(object sender, EventArgs e)
        {
            dlplugins.Text = "";
            dlqlbtns.Text = "";
            dlsettings.Text = "";
            BUT_A.Text = "";
            BUT_B.Text = "";
            BUT_X.Text = "";
            BUT_Y.Text = "";
            Start.Text = "";
            Back.Text = "";
            LBump.Text = "";
            Default.Text = "";
            Guide.Text = "";
            Power.Text = "";
            plugin1.Text = "";
            plugin2.Text = "";
            plugin3.Text = "";
            plugin4.Text = "";
            plugin5.Text = "";
            nxemini.Checked = true;
            pingpatch.Checked = false;
            contpatch.Checked = false;
            fatalfreeze.Checked = false;
            fatalreboot.Checked = false;
            safereboot.Checked = false;
            regionspoof.Checked = false;
            r7FFF.Checked = true;
            dvdexitdash.Checked = false;
            xblaexitdash.Checked = false;
            nosysexit.Checked = false;
            nohud.Checked = false;
            noupdater.Checked = true;
            debugout.Checked = false;
            exechandler.Checked = true;
            dumpfile.Text = "";
            bootdelay.Text = "42";
            liveblock.Checked = true;
            livestrong.Checked = false;
            remotenxe.Checked = false;
            hddalive.Checked = false;
            hddtimer.Text = "210";
            signnotice.Checked = true;
            autoshut.Checked = false;
            autooff.Checked = false;
            xhttp.Checked = true;
            tempbcast.Checked = false;
            temptime.Text = "10";
            tempport.Text = "7030";
            fakelive.Checked = false;
        }
    }
}