using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace xeBuild_GUI
{
    public partial class DLConf : Form
    {
        private ListView currentview = new ListView();
        private ListViewItem item = new ListViewItem();
        private TextBox tb = null;
        private string device = null;
        public DLConf() { InitializeComponent(); }
        private void numeric(object sender, KeyPressEventArgs e) { Main.test.numinput(sender, e); }
        private void additem(ref ListView selection, string name, string value)
        {
            bool exists = false;
            foreach (ListViewItem itm in selection.Items)
            {
                if (itm.Text == name) 
                { 
                    item = itm;
                    selection.Items.Remove(itm);
                    exists = true;
                }
            }
            if (!exists) { item = new ListViewItem(); }
            item.Text = name;
            item.SubItems.Add(value);
            selection.Items.Add(item);
        }
        private void DLMan_Enter(object sender, EventArgs e)
        {
            settingsview.Items.Clear();
            extview.Items.Clear();
            qlbview.Items.Clear();
            pluginsview.Items.Clear();
            #region Settings
            #region Page 1
            #region Fatal Error Handling
            foreach (Control c in errorbox.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = c as CheckBox;
                    additem(ref settingsview, cb.Name, cb.Checked.ToString());
                }
            }
            if (!string.IsNullOrEmpty(dumpfile.Text)) { additem(ref settingsview, "dumpfile", dumpfile.Text); }
            #endregion
            #region Miniblades Options
            foreach (Control c in minibladesbox.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = c as CheckBox;
                    additem(ref settingsview, cb.Name, cb.Checked.ToString());
                }
            }
            #endregion
            #region Misc Options
            foreach (Control c in miscbox.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = c as CheckBox;
                    additem(ref settingsview, cb.Name, cb.Checked.ToString());
                }
            }
            #endregion
            #endregion
            #region Page 2
            #region HDD Alive
            if (hddalive.Checked)
            {
                additem(ref settingsview, "hddalive", hddalive.Checked.ToString());
                if (!string.IsNullOrEmpty(hddtimer.Text)) { additem(ref settingsview, "hddtimer", hddtimer.Text); }
                else { additem(ref settingsview, "hddtimer", "210"); }
            }
            else { additem(ref settingsview, "haddalive", hddalive.Checked.ToString()); }
            #endregion
            #region Tempbcast
            if (tempbcast.Checked)
            {
                additem(ref settingsview, "tempbcast", tempbcast.Checked.ToString());
                if (!string.IsNullOrEmpty(tempport.Text)) { additem(ref settingsview, "tempport", tempport.Text); }
                else { additem(ref settingsview, "tempport", "7030"); }
                if (!string.IsNullOrEmpty(temptime.Text)) { additem(ref settingsview, "temptime", temptime.Text); }
                else { additem(ref settingsview, "temptime", "10"); }
            }
            #endregion
            #region Bootdelay
            if (!string.IsNullOrEmpty(bootdelay.Text)) { additem(ref settingsview, "bootdelay", bootdelay.Text); }
            #endregion
            #region Region spoofing
            if (regionspoof.Checked)
            {
                additem(ref settingsview, "regionspoof", regionspoof.Checked.ToString());
                foreach (Control c in region.Controls)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked)
                    {
                        additem(ref settingsview, "region", "0x" + rb.Name.Substring(1, rb.Name.Length - 1));
                    }
                }
            }
            #endregion
            #endregion
            #region Expert Options on Page 1
            foreach (Control c in expertbox.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = c as CheckBox;
                    additem(ref settingsview, cb.Name, cb.Checked.ToString());
                }
            }
            #endregion
            #endregion
            #region Plugins
            int pluginerror = 0;
            if ((devcheck(plugin1.Text)) && (endcheck(plugin1.Text, true))) { additem(ref pluginsview, "plugin1", plugin1.Text); }
            else { pluginerror++; }
            if ((devcheck(plugin2.Text)) && (endcheck(plugin2.Text, true))) { additem(ref pluginsview, "plugin2", plugin2.Text); }
            else { pluginerror++; }
            if ((devcheck(plugin3.Text)) && (endcheck(plugin3.Text, true))) { additem(ref pluginsview, "plugin3", plugin3.Text); }
            else { pluginerror++; }
            if ((devcheck(plugin4.Text)) && (endcheck(plugin4.Text, true))) { additem(ref pluginsview, "plugin4", plugin4.Text); }
            else { pluginerror++; }
            if ((devcheck(plugin5.Text)) && (endcheck(plugin5.Text, true))) { additem(ref pluginsview, "plugin5", plugin5.Text); }
            else { pluginerror++; }
            #endregion
            #region Quick Launch Buttons
            int qlberror = 0;
            if ((devcheck(BUT_A.Text)) && (endcheck(BUT_A.Text, false)) && (totalcheck(BUT_A.Text))) { additem(ref qlbview, "BUT_A", BUT_A.Text); }
            else { qlberror++; }
            if ((devcheck(BUT_B.Text)) && (endcheck(BUT_B.Text, false)) && (totalcheck(BUT_B.Text))) { additem(ref qlbview, "BUT_B", BUT_B.Text); }
            else { qlberror++; }
            if ((devcheck(BUT_X.Text)) && (endcheck(BUT_X.Text, false)) && (totalcheck(BUT_X.Text))) { additem(ref qlbview, "BUT_X", BUT_X.Text); }
            else { qlberror++; }
            if ((devcheck(BUT_Y.Text)) && (endcheck(BUT_Y.Text, false)) && (totalcheck(BUT_Y.Text))) { additem(ref qlbview, "BUT_Y", BUT_A.Text); }
            else { qlberror++; }
            if ((devcheck(Start.Text)) && (endcheck(Start.Text, false)) && (totalcheck(Start.Text))) { additem(ref qlbview, "Start", Start.Text); }
            else { qlberror++; }
            if ((devcheck(Back.Text)) && (endcheck(Back.Text, false)) && (totalcheck(Back.Text))) { additem(ref qlbview, "Back", Back.Text); }
            else { qlberror++; }
            if ((devcheck(LBump.Text)) && (endcheck(LBump.Text, false)) && (totalcheck(LBump.Text))) { additem(ref qlbview, "LBump", LBump.Text); }
            else { qlberror++; }
            if ((devcheck(Default.Text)) && (endcheck(Default.Text, false)) && (totalcheck(Default.Text))) { additem(ref qlbview, "Default", Default.Text); }
            else { qlberror++; }
            if ((devcheck(Power.Text)) && (endcheck(Power.Text, false)) && (totalcheck(Power.Text))) { additem(ref qlbview, "Power", Power.Text); }
            else { qlberror++; }
            if ((devcheck(Guide.Text)) && (endcheck(Guide.Text, false)) && (totalcheck(Guide.Text))) { additem(ref qlbview, "Guide", Guide.Text); }
            else { qlberror++; }
            if ((devcheck(configapp.Text)) && (endcheck(configapp.Text, false)) && (totalcheck(configapp.Text))) { additem(ref qlbview, "configapp", configapp.Text); }
            else { qlberror++; }
            #endregion
            #region Externals
            additem(ref extview, "ftpserv", ftpserv.Checked.ToString());
            additem(ref extview, "ftpport", ftpport.Text);
            additem(ref extview, "calaunch", calaunch.Checked.ToString());
            #endregion
            if ((qlberror > 0) || (pluginerror > 0))
            {
                string errormsg = "There was one or more errors with your Plugins and/or\nQuick Launch button configurations\nPlease check the following pages and correct them:";
                if (pluginerror > 0) { errormsg += "\nPage 2: " + pluginerror.ToString() + " Error(s)"; }
                if (qlberror > 0) { errormsg += "\nPage 3: " + qlberror.ToString() + " Error(s)"; }
                MessageBox.Show("ERROR: " + errormsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void resetall()
        {
            settingsview.Items.Clear();
            pluginsview.Items.Clear();
            qlbview.Items.Clear();
            fatalfreeze.Checked = false;
            fatalreboot.Checked = true;
            exechandler.Checked = true;
            safereboot.Checked = true;
            dumpfile.Text = "USB:\\crashlog.txt";
            nohud.Checked = false;
            nxemini.Checked = true;
            nosysexit.Checked = false;
            liveblock.Checked = true;
            livestrong.Checked = false;
            noupdater.Checked = true;
            pingpatch.Checked = true;
            contpatch.Checked = false;
            xhttp.Checked = true;
            autoshut.Checked = false;
            fakelive.Checked = true;
            xblaexitdash.Checked = false;
            debugout.Checked = false;
            signnotice.Checked = false;
            autooff.Checked = false;
            dvdexitdash.Checked = false;
            remotenxe.Checked = false;
            nonetstore.Checked = true;
            sockpatch.Checked = false;
            passlaunch.Checked = false;
            plugin1.Text = "";
            plugin2.Text = "";
            plugin3.Text = "";
            plugin4.Text = "";
            plugin5.Text = "";
            hddalive.Checked = false;
            hddtimer.Text = "210";
            tempbcast.Checked = false;
            tempport.Text = "7030";
            temptime.Text = "10";
            bootdelay.Text = "30";
            regionspoof.Checked = false;
            r7FFF.Checked = true;
            BUT_A.Text = "";
            BUT_B.Text = "";
            BUT_X.Text = "";
            BUT_Y.Text = "";
            Start.Text = "";
            Back.Text = "";
            LBump.Text = "";
            Default.Text = "";
            Power.Text = "";
            Guide.Text = "";
            configapp.Text = "";
            ftpserv.Checked = true;
            ftpport.Text = "21";
            calaunch.Checked = false;
            shuttemps.Checked = false;
            devprof.Checked = false;
        }
        private void dldefault()
        {
            settingsview.Items.Clear();
            pluginsview.Items.Clear();
            qlbview.Items.Clear();
            fatalfreeze.Checked = false;
            fatalreboot.Checked = false;
            exechandler.Checked = true;
            safereboot.Checked = true;
            dumpfile.Text = "";
            nohud.Checked = false;
            nxemini.Checked = true;
            nosysexit.Checked = false;
            liveblock.Checked = true;
            livestrong.Checked = false;
            noupdater.Checked = true;
            pingpatch.Checked = false;
            contpatch.Checked = false;
            xhttp.Checked = true;
            autoshut.Checked = false;
            fakelive.Checked = false;
            xblaexitdash.Checked = false;
            debugout.Checked = false;
            signnotice.Checked = false;
            autooff.Checked = false;
            dvdexitdash.Checked = false;
            remotenxe.Checked = false;
            nonetstore.Checked = true;
            sockpatch.Checked = false;
            passlaunch.Checked = false;
            plugin1.Text = "";
            plugin2.Text = "";
            plugin3.Text = "";
            plugin4.Text = "";
            plugin5.Text = "";
            hddalive.Checked = false;
            hddtimer.Text = "210";
            tempbcast.Checked = false;
            tempport.Text = "7030";
            temptime.Text = "10";
            bootdelay.Text = "30";
            regionspoof.Checked = false;
            r7FFF.Checked = true;
            BUT_A.Text = "";
            BUT_B.Text = "";
            BUT_X.Text = "";
            BUT_Y.Text = "";
            Start.Text = "";
            Back.Text = "";
            LBump.Text = "";
            Default.Text = "";
            Power.Text = "";
            Guide.Text = "";
            configapp.Text = "";
            ftpserv.Checked = false;
            ftpport.Text = "21";
            shuttemps.Checked = false;
            devprof.Checked = false;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e) { if (loadset.ShowDialog() == DialogResult.OK) { loadsettings(loadset.FileName); } }
        private void RestoreDefaults_Click(object sender, EventArgs e) { resetall(); }
        private void DLDefaults_Click(object sender, EventArgs e) { dldefault(); }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveset.ShowDialog() == DialogResult.OK)
            {
                if (Dashlaunchtab.SelectedTab != DLMan) { Dashlaunchtab.SelectedTab = DLMan; }
                using (StreamWriter sw = new StreamWriter(saveset.FileName, false, System.Text.Encoding.ASCII))
                {
                    sw.WriteLine(";Generated by xeBuild GUI " + Main.version);
                    sw.WriteLine("[QuickLaunchButtons]");
                    foreach (ListViewItem itm in qlbview.Items)
                    {
                        sw.WriteLine(itm.Text + "=" + itm.SubItems[1].Text);
                    }
                    sw.WriteLine("[Externals]");
                    foreach (ListViewItem itm in extview.Items)
                    {
                        sw.WriteLine(itm.Text + "=" + itm.SubItems[1].Text);
                    }
                    sw.WriteLine("[Plugins]");
                    foreach (ListViewItem itm in pluginsview.Items)
                    {
                        sw.WriteLine(itm.Text + "=" + itm.SubItems[1].Text);
                    }
                    sw.WriteLine("[Settings]");
                    foreach (ListViewItem itm in settingsview.Items)
                    {
                        sw.WriteLine(itm.Text + "=" + itm.SubItems[1].Text);
                    }
                }
            }
            saveset.FileName = "launch.ini";
        }
        private void MenuExit_Click(object sender, EventArgs e) { Close(); }
        private void loadsettings(string file)
        {
            dldefault();
            string line = "";
            string[] tmp = new string[1];
            using (StreamReader sr = new StreamReader(file))
            {
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (!line.StartsWith(";"))
                        {
                            tmp = line.Split('=');
                            try
                            {
                                switch (tmp[0].ToLower().Trim())
                                {
                                    #region Quick Launch
                                    case "but_a":
                                        BUT_A.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "but_b":
                                        BUT_B.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "but_x":
                                        BUT_X.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "but_y":
                                        BUT_Y.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "start":
                                        Start.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "back":
                                        Back.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "lbump":
                                        LBump.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "default":
                                        Default.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "guide":
                                        Guide.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "power":
                                        Power.Text = tmp[1].Trim();
                                        additem(ref qlbview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    #endregion
                                    #region Plugins
                                    case "plugin1":
                                        plugin1.Text = tmp[1].Trim();
                                        additem(ref pluginsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "plugin2":
                                        plugin2.Text = tmp[1].Trim();
                                        additem(ref pluginsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "plugin3":
                                        plugin3.Text = tmp[1].Trim();
                                        additem(ref pluginsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "plugin4":
                                        plugin4.Text = tmp[1].Trim();
                                        additem(ref pluginsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "plugin5":
                                        plugin5.Text = tmp[1].Trim();
                                        additem(ref pluginsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    #endregion
                                    #region Settings
                                    case "nxemini":
                                        nxemini.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "pingpatch":
                                        pingpatch.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "contpatch":
                                        contpatch.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "fatalfreeze":
                                        fatalfreeze.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "fatalreboot":
                                        fatalreboot.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "safereboot":
                                        safereboot.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "regionspoof":
                                        regionspoof.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "region":
                                        if (tmp[1].Trim().Length > 0)
                                        {
                                            foreach (Control c in region.Controls)
                                            {
                                                if (c is RadioButton)
                                                {
                                                    RadioButton rb = c as RadioButton;
                                                    rb.Checked = (rb.Name == ("r" + tmp[1].Trim().Substring(2).ToUpper()));

                                                }
                                            }
                                            additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        }
                                        break;
                                    case "dvdexitdash":
                                        dvdexitdash.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "xblaexitdash":
                                        xblaexitdash.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "nosysexit":
                                        nosysexit.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "nohud":
                                        nohud.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "noupdater":
                                        noupdater.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "debugout":
                                        debugout.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "exechandler":
                                        exechandler.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "dumpfile":
                                        dumpfile.Text = tmp[1].Trim();
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "bootdelay":
                                        if (tmp[1].Trim().StartsWith("0x", StringComparison.CurrentCultureIgnoreCase)) { bootdelay.Text = int.Parse(tmp[1].Trim().Substring(2), System.Globalization.NumberStyles.HexNumber).ToString(); }
                                        else { bootdelay.Text = tmp[1].Trim(); }
                                        additem(ref settingsview, tmp[0].Trim(), bootdelay.Text);
                                        break;
                                    case "liveblock":
                                        liveblock.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "livestrong":
                                        livestrong.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "hddalive":
                                        hddalive.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "hddtimer":
                                        hddtimer.Text = tmp[1].Trim();
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "signnotice":
                                        signnotice.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "autooff":
                                        autooff.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "autoshut":
                                        autoshut.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "xhttp":
                                        xhttp.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "tempbcast":
                                        tempbcast.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "temptime":
                                        temptime.Text = tmp[1].Trim();
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "tempport":
                                        tempport.Text = tmp[1].Trim();
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "fakelive":
                                        fakelive.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "sockpatch":
                                        sockpatch.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "passlaunch":
                                        passlaunch.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "shuttemps":
                                        shuttemps.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "devprof":
                                        devprof.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref settingsview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    #endregion
                                    #region Externals
                                    case "ftpserv":
                                        ftpserv.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref extview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "ftpport":
                                        ftpport.Text = tmp[1].Trim();
                                        additem(ref extview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    case "calaunch":
                                        calaunch.Checked = (tmp[1].Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                        additem(ref extview, tmp[0].Trim(), tmp[1].Trim());
                                        break;
                                    #endregion
                                    default:
                                        break;
                                }
                            }
                            catch { continue; }
                        }
                    }
                }
            }
        }
        private void DLConf_Load(object sender, EventArgs e)
        {
            resetall();
            if (File.Exists(Main.dir + "\\launch.ini")) { loadsettings(Main.dir + "\\launch.ini"); }
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
            if (sender is TextBox) { tb = sender as TextBox; }
            else { tb = null; }
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
                else { setdevbtn.Text = "Set " + device + ":\\ as device for " + tb.Name; }
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
        private void DLConf_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void DLConf_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int ok = 0;
            foreach (string s in FileList)
            {
                if (s.EndsWith(".ini", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (ok == 0) { loadsettings(s); }
                    ok++;
                }
            }
        }
        private void ViewDoubleClick(object sender, EventArgs e)
        {
            if (sender is ListView)
            {
                currentview = sender as ListView;
                editname.Text = currentview.SelectedItems[0].Text;
                editvalue.Text = currentview.SelectedItems[0].SubItems[1].Text;
            }
        }
        private void editsavebtn_Click(object sender, EventArgs e) 
        {
            additem(ref currentview, editname.Text, editvalue.Text);
            editname.Text = "";
            editvalue.Text = "";
            editsavebtn.Enabled = false;
        }
        private void editname_TextChanged(object sender, EventArgs e) { editsavebtn.Enabled = ((editname.Text.Length > 0) && (editvalue.Text.Length > 0)); }
        private void regionspoof_CheckedChanged(object sender, EventArgs e) { region.Enabled = (regionspoof.Checked); }
    }
}