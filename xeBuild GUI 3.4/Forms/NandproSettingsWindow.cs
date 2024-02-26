using System;
using System.IO;
using System.Windows.Forms;

namespace xeBuild_GUI
{
    public partial class NandproSettings : Form
    {
        public static string[] settings = new string[0];
        public NandproSettings(string[] current) 
        {
            InitializeComponent();
            selworkdir.SelectedPath = Main.dir;
            settings = current;
        }
        private void NandproSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            setsettings();
            Nandpro.updskip = false;
            foreach (Form a in Application.OpenForms) { if (a is Nandpro) { a.Show(); a.Select(); } }
            e.Cancel = false;
        }
        private void NandproSettings_Load(object sender, EventArgs e)
        {
            foreach (Form a in Application.OpenForms) { if (a is Nandpro) { a.Hide(); } }
            currentsettings();
        }
        private void currentsettings()
        {
            workdir.Text = Main.misc.checkxmlempty(settings[0], false);
            dump1name.Text = Main.misc.checkxmlempty(settings[1], false);
            dump2name.Text = Main.misc.checkxmlempty(settings[2], false);
            dump3name.Text = Main.misc.checkxmlempty(settings[3], false);
            dump4name.Text = Main.misc.checkxmlempty(settings[4], false);
            #region Device
                if (settings[5] == null) { }
                else if (settings[5].Equals("lpt", StringComparison.CurrentCultureIgnoreCase)) { lpt.Checked = true; }
                else if (settings[5].Equals("usb", StringComparison.CurrentCultureIgnoreCase)) { usb.Checked = true; }
                #endregion
            #region NANDPro Version
                if (settings[6] == null) { }
                else if (settings[6].Equals("20d", StringComparison.CurrentCultureIgnoreCase)) { np20d.Checked = true; }
                else if (settings[6].Equals("30a", StringComparison.CurrentCultureIgnoreCase)) { np30a.Checked = true; }
                else if (settings[6].Equals("custom", StringComparison.CurrentCultureIgnoreCase)) { npcustom.Checked = true; }
                #endregion
            #region Dump Size
                if (settings[7] == null) { }
                else if (settings[7].Equals("1", StringComparison.CurrentCultureIgnoreCase)) { s1.Checked = true; }
                else if (settings[7].Equals("2", StringComparison.CurrentCultureIgnoreCase)) { s2.Checked = true; }
                else if (settings[7].Equals("16", StringComparison.CurrentCultureIgnoreCase)) { s16.Checked = true; }
                else if (settings[7].Equals("64", StringComparison.CurrentCultureIgnoreCase)) { s64.Checked = true; }
                else if (settings[7].Equals("256", StringComparison.CurrentCultureIgnoreCase)) { s256.Checked = true; }
                else if (settings[7].Equals("512", StringComparison.CurrentCultureIgnoreCase)) { s512.Checked = true; }
                #endregion
            #region Dump Times
                if (settings[8] == null) { }
                else if (settings[8].Equals("1", StringComparison.CurrentCultureIgnoreCase)) { d1.Checked = true; }
                else if (settings[8].Equals("2", StringComparison.CurrentCultureIgnoreCase)) { d2.Checked = true; }
                else if (settings[8].Equals("3", StringComparison.CurrentCultureIgnoreCase)) { d3.Checked = true; }
                else if (settings[8].Equals("4", StringComparison.CurrentCultureIgnoreCase)) { d4.Checked = true; }
                #endregion
            workfile.Text = Main.misc.checkxmlempty(settings[9], false);
        }
        private void setsettingsxml()
        {
            #region Device
            foreach (Control c in devbox.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked) { NandproSet.device = rb.Name; }
                }
            }
            #endregion
            #region Nandpro Version
            foreach (Control c in versionbox.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked) { NandproSet.npvers = rb.Name.Substring(2); }
                }
            }
            #endregion
            #region Dump Size
            foreach (Control c in sizebox.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked) { NandproSet.size = rb.Name.Substring(1); }
                }
            }
            #endregion
            #region Dump Times
            foreach (Control c in dumps.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked) { NandproSet.dumptimes = rb.Name.Substring(1); }
                }
            }
            #endregion
            NandproSet.workdir = Main.misc.checkxmlempty(workdir.Text, true);
            NandproSet.filenames = new string[4];
            NandproSet.filenames[0] = Main.misc.checkxmlempty(dump1name.Text, true);
            NandproSet.filenames[1] = Main.misc.checkxmlempty(dump2name.Text, true);
            NandproSet.filenames[2] = Main.misc.checkxmlempty(dump3name.Text, true);
            NandproSet.filenames[3] = Main.misc.checkxmlempty(dump4name.Text, true);
            NandproSet.workfile = Main.misc.checkxmlempty(workfile.Text, true);
        }
        private void setsettings()
        {
            #region Device
            foreach (Control c in devbox.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked) { NandproSet.device = rb.Name; }
                }
            }
            #endregion
            #region Nandpro Version
            foreach (Control c in versionbox.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked) { NandproSet.npvers = rb.Name.Substring(2); }
                }
            }
            #endregion
            #region Dump Size
            foreach (Control c in sizebox.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked) { NandproSet.size = rb.Name.Substring(1); }
                }
            }
            #endregion
            #region Dump Times
            foreach (Control c in dumps.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked) { NandproSet.dumptimes = rb.Name.Substring(1); }
                }
            }
            #endregion
            NandproSet.workdir = Main.misc.checkxmlempty(workdir.Text, false);
            NandproSet.filenames = new string[4];
            NandproSet.filenames[0] = Main.misc.checkxmlempty(dump1name.Text, false);
            NandproSet.filenames[1] = Main.misc.checkxmlempty(dump2name.Text, false);
            NandproSet.filenames[2] = Main.misc.checkxmlempty(dump3name.Text, false);
            NandproSet.filenames[3] = Main.misc.checkxmlempty(dump4name.Text, false);
            NandproSet.workfile = Main.misc.checkxmlempty(workfile.Text, false);
        }
        private void defaultsettings_Click(object sender, EventArgs e)
        {
            usb.Checked = true;
            s2.Checked = true;
            np20d.Checked = true;
            Nandpro.conf.Text = "N/A";
            Nandpro.wnand.Text = "";
            Nandpro.fbl.Text = "";
            Nandpro.tbl.Text = "";
            Nandpro.dmpt.Text = "3";
        }
        private void setworkdir_Click(object sender, EventArgs e)
        {
            if (selworkdir.ShowDialog() == DialogResult.OK)
            {
                workdir.Text = selworkdir.SelectedPath;
            }
        }
        private void setdump1_Click(object sender, EventArgs e)
        {
            if (savedump.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetDirectoryName(savedump.FileName) == workdir.Text) { dump1name.Text = Path.GetFileName(savedump.FileName); }
                else { dump1name.Text = savedump.FileName; }
                savedump.FileName = Path.GetFileName(savedump.FileName);
            }
        }
        private void setdump2_Click(object sender, EventArgs e)
        {
            if (savedump.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetDirectoryName(savedump.FileName) == workdir.Text) { dump2name.Text = Path.GetFileName(savedump.FileName); }
                else { dump2name.Text = savedump.FileName; }
                savedump.FileName = Path.GetFileName(savedump.FileName);
            }
        }
        private void setdump3_Click(object sender, EventArgs e)
        {
            if (savedump.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetDirectoryName(savedump.FileName) == workdir.Text) { dump3name.Text = Path.GetFileName(savedump.FileName); }
                else { dump3name.Text = savedump.FileName; }
                savedump.FileName = Path.GetFileName(savedump.FileName);
            }
        }
        private void setdump4_Click(object sender, EventArgs e)
        {
            if (savedump.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetDirectoryName(savedump.FileName) == workdir.Text) { dump4name.Text = Path.GetFileName(savedump.FileName); }
                else { dump4name.Text = savedump.FileName; }
                savedump.FileName = Path.GetFileName(savedump.FileName);
            }
        }
        private void loadfile_Click(object sender, EventArgs e)
        {
            if (loadset.ShowDialog() == DialogResult.OK)
            {
                NandproSet.loadsettings(loadset.FileName);
                settings = new string[9];
                settings[0] = NandproSet.workdir;
                settings[1] = NandproSet.filenames[0];
                settings[2] = NandproSet.filenames[1];
                settings[3] = NandproSet.filenames[2];
                settings[4] = NandproSet.filenames[3];
                settings[5] = NandproSet.device;
                settings[6] = NandproSet.npvers;
                settings[7] = NandproSet.size;
                settings[8] = NandproSet.dumptimes;
                currentsettings();
            }
        }
        private void savefile_Click(object sender, EventArgs e)
        {
            if (saveset.ShowDialog() == DialogResult.OK)
            {
                setsettingsxml();
                NandproSet.savesettings(saveset.FileName);
            }
        }
    }
}