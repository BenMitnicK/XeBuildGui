using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using xeBuild_GUI.Forms;

namespace xeBuild_GUI
{
    public partial class Main : Form
    {
        public Main() 
        {
            InitializeComponent();
            this.AcceptButton = Main.statc.genbtn;
        }
        #region declarations
        public static ToolStripStatusLabel sourcestatuslabel, sourcestatus, outputstatuslabel, outputstatus, 
            typestatuslabel, typestatus, mobostatuslabel, mobostatus, cpukeystatuslabel, cpukeystatus,
            blkeystatuslabel, blkeystatus, kernelstatuslabel, kernelstatus, xellstatuslabel, xellstatus,
            smcstatuslabel, smcstatus;
        public static TabPage tp;
        public static TabControl tabc;
        public static string dir = "", appdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), version = "";
        public static Right r = new Right();
        public static Static statc = new Static();
        public static Mainright mright = new Mainright();
        public static xeBuildset xeset = new xeBuildset();
        public static dwltab download = new dwltab();
        public static outtab log = new outtab();
        public static Dictionary<string, string> xebuildsettings = new Dictionary<string, string>(),
            dashlaunchsettings = new Dictionary<string, string>(),
            dashlaunchplugins = new Dictionary<string, string>(),
            dashlaunchqlbtns = new Dictionary<string, string>(),
            types = new Dictionary<string, string>();
        public static bool ezmode = true, disfailsafe = false;
        internal static Checks test = new Checks();
        internal static Misc misc = new Misc();
        internal static NandOP nand = new NandOP();
        internal static crypto crypt = new crypto();
        public static WebClient wc;
        public static Assembly app;
        public static byte[] smc = new byte[0], kv = new byte[0], encsmc = new byte[0], enckv = new byte[0];
        public static Random random = new Random();
        #endregion
        private void makestatus()
        {
            #region Status Source
            Main.sourcestatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            Main.sourcestatus = new System.Windows.Forms.ToolStripStatusLabel();
            Main.sourcestatuslabel.Text = "Source";
            Main.sourcestatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            Main.sourcestatus.Image = global::xeBuild_GUI.Properties.Resources.error;
            Main.sourcestatus.Text = "false";
            Main.sourcestatus.TextChanged += new System.EventHandler(Main.statusiconupd);
            #endregion
            #region Status Output
            Main.outputstatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            Main.outputstatus = new System.Windows.Forms.ToolStripStatusLabel();
            Main.outputstatuslabel.Text = "Output";
            Main.outputstatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            Main.outputstatus.Image = global::xeBuild_GUI.Properties.Resources.error;
            Main.outputstatus.Text = "false";
            Main.outputstatus.TextChanged += new System.EventHandler(Main.statusiconupd);
            #endregion
            #region Status Type
            Main.typestatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            Main.typestatus = new System.Windows.Forms.ToolStripStatusLabel();
            Main.typestatuslabel.Text = "Type";
            Main.typestatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            Main.typestatus.Image = global::xeBuild_GUI.Properties.Resources.error;
            Main.typestatus.Text = "false";
            Main.typestatus.TextChanged += new System.EventHandler(Main.statusiconupd);
            #endregion
            #region Status Mobo
            Main.mobostatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            Main.mobostatus = new System.Windows.Forms.ToolStripStatusLabel();
            Main.mobostatuslabel.Text = "Motherboard";
            Main.mobostatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            Main.mobostatus.Image = global::xeBuild_GUI.Properties.Resources.error;
            Main.mobostatus.Text = "false";
            Main.mobostatus.TextChanged += new System.EventHandler(Main.statusiconupd);
            #endregion
            #region Status CPUKey
            Main.cpukeystatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            Main.cpukeystatus = new System.Windows.Forms.ToolStripStatusLabel();
            Main.cpukeystatuslabel.Text = "CPUKey";
            Main.cpukeystatuslabel.Visible = false;
            Main.cpukeystatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            Main.cpukeystatus.Image = global::xeBuild_GUI.Properties.Resources.error;
            Main.cpukeystatus.Text = "false";
            Main.cpukeystatus.Visible = false;
            Main.cpukeystatus.TextChanged += new System.EventHandler(Main.statusiconupd);
            #endregion
            #region Status 1BLKey
            Main.blkeystatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            Main.blkeystatus = new System.Windows.Forms.ToolStripStatusLabel();
            Main.blkeystatuslabel.Text = "1BLKey";
            Main.blkeystatuslabel.Visible = false;
            Main.blkeystatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            Main.blkeystatus.Image = global::xeBuild_GUI.Properties.Resources.good;
            Main.blkeystatus.Text = "true";
            Main.blkeystatus.Visible = false;
            Main.blkeystatus.TextChanged += new System.EventHandler(Main.statusiconupd);
            #endregion
            #region Status Kernel Version
            Main.kernelstatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            Main.kernelstatus = new System.Windows.Forms.ToolStripStatusLabel();
            Main.kernelstatuslabel.Text = "Dashboard version";
            Main.kernelstatuslabel.Visible = false;
            Main.kernelstatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            Main.kernelstatus.Image = global::xeBuild_GUI.Properties.Resources.error;
            Main.kernelstatus.Text = "false";
            Main.kernelstatus.Visible = false;
            Main.kernelstatus.TextChanged += new System.EventHandler(Main.statusiconupd);
            #endregion
            #region Status Xell Version
            Main.xellstatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            Main.xellstatus = new System.Windows.Forms.ToolStripStatusLabel();
            Main.xellstatuslabel.Text = "Xell";
            Main.xellstatuslabel.Visible = false;
            Main.xellstatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            Main.xellstatus.Image = global::xeBuild_GUI.Properties.Resources.good;
            Main.xellstatus.Text = "true";
            Main.xellstatus.Visible = false;
            Main.xellstatus.TextChanged += new System.EventHandler(Main.statusiconupd);
            #endregion
            #region Status SMC
            Main.smcstatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            Main.smcstatus = new System.Windows.Forms.ToolStripStatusLabel();
            Main.smcstatuslabel.Text = "SMC Hack";
            Main.smcstatuslabel.Visible = false;
            Main.smcstatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            Main.smcstatus.Image = global::xeBuild_GUI.Properties.Resources.error;
            Main.smcstatus.Text = "false";
            Main.smcstatus.Visible = false;
            Main.smcstatus.TextChanged += new System.EventHandler(Main.statusiconupd);
            #endregion
            addstatus();
        }

        private void modelGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/coronaguide.jpg");
            mylist.Add("/files/Pics/Xbox360_Model_Guide.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void topPowerGuideSlimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/xbox_360_slim_mainboard_power sources_top.jpg");
            mylist.Add("/files/Pics/Xbox360_Model_Guide.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void phatCRQSBInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/phat_install_qsb.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void phatCRWiresInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/tx_revc_phat_rgh1.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void phatCRWiresRGH2InstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/tx_revc_phat_rgh2.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void trinityCRQSBInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/slim_install_qsb.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void trinityCRWiresInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/tx_revc_slim.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void coronaCRWiresInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/Corona250_wires.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void cR3LiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/cr3lite.png");
            mylist.Add("/files/Pics/coronaguide.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void cRRevCUpgradeQuartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/48crystal.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void demoNTrinityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/slim_install_diagram_final.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void demoNPhatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/phat_install_diagram_final.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void nandXPhatInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/nandxphat.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void nandXCoronaInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/nandxCorona.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void nandXTrinityInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/nandxslim.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void uSBNandXUpdateCableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/nandxUSB.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void cK3iX360USBProV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/ck3iCOM.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void rJTAGInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/RJTAG-1.jpg");
            mylist.Add("/files/Pics/RJTAG-2.jpg");
            mylist.Add("/files/Pics/RJTAG-3.jpg");
            mylist.Add("/files/Pics/RJTAG-4.jpg");
            mylist.Add("/files/Pics/RJTAG-5.jpg");
            mylist.Add("/files/Pics/RJTAG-6.jpg");
            mylist.Add("/files/Pics/RJTAG-7.jpg");
            mylist.Add("/files/Pics/RJTAG-8.jpg");
            mylist.Add("/files/Pics/RJTAG-9.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void jTAGXenonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/xenon1.jpg");
            mylist.Add("/files/Pics/xenon2.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void jTAGNonXenonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/non_xenon1.jpg");
            mylist.Add("/files/Pics/non_xenon2.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void jTAGBootLoadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/bootloader.png");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void fATOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/rgh_1.2.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void trinityCoronaV1V2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/dgx_wires.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void coronaV3V4V5V6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/S-RGH_Corona_V3.4.5.6.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void trinityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/muffin_trinity.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        private void coronaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> mylist = new List<string>();
            mylist.Add("/files/Pics/muffin_corona.jpg");
            PictureViewer PicView = new PictureViewer(mylist);
            PicView.Show();
        }

        public static void statusupdate()
        {
            string type = "";
            bool mb = false, ck = false, bl = false, ke = false, xl = false, sm = false, so = false, ou = false;
            int failed = 0;
            #region Type
            foreach (Control c in Main.statc.imgtype.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb.Checked)
                {
                    type = rb.Name;
                }
                else { failed++; }
            }
            if (failed < Main.statc.imgtype.Controls.Count) { typestatus.Text = "true"; }
            else { typestatus.Text = "false"; type = ""; }
            failed = 0;
            #endregion
            #region Mobo
            foreach (Control c in Main.statc.mobo.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (!rb.Checked) { failed++; }
            }
            if (failed < Main.statc.mobo.Controls.Count) { mb = true; mobostatus.Text = "true"; }
            else { mb = false; mobostatus.Text = "false"; }
            failed = 0;
            #endregion
            #region Paths
            #region Input
            if (Main.statc.source.Text.Length > 0)
            {
                if (File.Exists(statc.source.Text)) { so = true; }
                else { so = false; }
            }
            else
            {
                if ((Main.mright.extvital.Checked) && (!type.Equals("ecc", StringComparison.CurrentCultureIgnoreCase))) { so = true; }
                else { so = false; }
            }
            if (so) { sourcestatus.Text = "true"; }
            else { sourcestatus.Text = "false"; }
            #endregion
            #region Output
            if (Main.statc.output.Text.Length > 0) { ou = true;}
            else { ou = false;  }
            if (ou)
            {
                if (type.Equals("ecc", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (Main.statc.eccname.Text.Length > 0) { ou = true; }
                    else { ou = false; }
                }
                else
                {
                    if (Main.statc.binname.Text.Length > 0) { ou = true; }
                    else { ou = false; }
                }
            }
            if (ou) { outputstatus.Text = "true"; }
            else { outputstatus.Text = "false"; }
            #endregion
            #endregion
            #region Keys
            if (Main.statc.cpukey.Text.Length == 32) { ck = (Main.test.keycheck(Main.statc.cpukey.Text));}
            else { ck = false;}
            if (Main.statc.blkey.Text.Length == 32) { bl = (Main.test.keycheck(Main.statc.blkey.Text)); }
            else { bl = false;}
            if (bl) { blkeystatus.Text = "true"; }
            else { blkeystatus.Text = "false"; }
            if (ck) { cpukeystatus.Text = "true"; }
            else { cpukeystatus.Text = "false"; }
            #endregion
            #region Kernel
            if (Main.statc.kernel.Text.Equals("custom", StringComparison.CurrentCultureIgnoreCase))
            {
                if (Main.statc.ckernel.Text.Trim().Length > 1) { ke = true; kernelstatus.Text = "true"; }
                else { ke = false; kernelstatus.Text = "false"; }
            }
            else if (!string.IsNullOrEmpty(Main.statc.kernel.Text.Trim())) { ke = true; kernelstatus.Text = "true"; }
            else { ke = false; kernelstatus.Text = "false"; }
            #endregion
            #region Xell
            foreach (Control c in statc.xellver.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (!rb.Checked) { failed++; }
            }
            if (failed < statc.xellver.Controls.Count) { xl = true; xellstatus.Text = "true"; }
            else { xl = false; xellstatus.Text = "false"; }
            failed = 0;
            #endregion
            #region SMC
            foreach (Control c in Main.statc.smc.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (!rb.Checked) { failed++; }
            }
            if (failed < Main.statc.smc.Controls.Count) { sm = true; smcstatus.Text = "true"; }
            else { sm = false; smcstatus.Text = "false"; }
            failed = 0;
            #endregion
            #region Enable Generate Button
            if (type.Equals("ecc", StringComparison.CurrentCultureIgnoreCase))
            {
                Main.statc.genbtn.Enabled = ((mb) && (so) && (ou) && (!build.procrunning));
            }
            else if (type.Equals("ecc2", StringComparison.CurrentCultureIgnoreCase))
            {
                Main.statc.genbtn.Enabled = ((so) && (ou) && (!build.procrunning));
            }
            else if ((type.Equals("retail", StringComparison.CurrentCultureIgnoreCase)) || (type.Equals("devkit", StringComparison.CurrentCultureIgnoreCase)))
            {
                Main.statc.genbtn.Enabled = ((mb) && (so) && (ou) && (ck) && (bl) && (ke) && (sm) && (!build.procrunning));
            }
            else if (type.Equals("jtag", StringComparison.CurrentCultureIgnoreCase))
            {
                Main.statc.genbtn.Enabled = ((mb) && (so) && (ou) && (ck) && (bl) && (ke) && (xl) && (sm) && (!build.procrunning));
            }
            else
            {
                Main.statc.genbtn.Enabled = ((!string.IsNullOrEmpty(type)) && (mb) && (so) && (ou) && (ck) && (bl) && (ke) && (xl) && (!build.procrunning));
            }
            #endregion
            #region Hide/Show Status icons
            Main.cpukeystatus.Visible = ((Main.statc.retail.Checked) || (Main.statc.devkit.Checked) || (Main.statc.jtag.Checked) || (Main.statc.glitch.Checked) || (Main.statc.glitch2.Checked));
            Main.cpukeystatuslabel.Visible = ((Main.statc.retail.Checked) || (Main.statc.devkit.Checked) || (Main.statc.jtag.Checked) || (Main.statc.glitch.Checked) || (Main.statc.glitch2.Checked));
            Main.blkeystatus.Visible = ((Main.statc.retail.Checked) || (Main.statc.devkit.Checked) || (Main.statc.jtag.Checked) || (Main.statc.glitch.Checked) || (Main.statc.glitch2.Checked));
            Main.blkeystatuslabel.Visible = ((Main.statc.retail.Checked) || (Main.statc.devkit.Checked) || (Main.statc.jtag.Checked) || (Main.statc.glitch.Checked) || (Main.statc.glitch2.Checked));
            Main.kernelstatus.Visible = ((Main.statc.retail.Checked) || (Main.statc.devkit.Checked) || (Main.statc.jtag.Checked) || (Main.statc.glitch.Checked) || (Main.statc.glitch2.Checked));
            Main.kernelstatuslabel.Visible = ((Main.statc.retail.Checked) || (Main.statc.devkit.Checked) || (Main.statc.jtag.Checked) || (Main.statc.glitch.Checked) || (Main.statc.glitch2.Checked));
            Main.xellstatus.Visible = ((Main.statc.jtag.Checked) || (Main.statc.glitch.Checked) || (Main.statc.glitch2.Checked));
            Main.xellstatuslabel.Visible = ((Main.statc.jtag.Checked) || (Main.statc.glitch.Checked) || (Main.statc.glitch2.Checked));
            Main.smcstatus.Visible = ((Main.statc.jtag.Checked) || (Main.statc.retail.Checked) || (Main.statc.devkit.Checked));
            Main.smcstatuslabel.Visible = ((Main.statc.jtag.Checked) || (Main.statc.retail.Checked) || (Main.statc.devkit.Checked));
            Main.mobostatus.Visible = (!Main.statc.ecc2.Checked);
            Main.mobostatuslabel.Visible = (!Main.statc.ecc2.Checked);
            #endregion
        }
        public static void statusiconupd(object sender, EventArgs e)
        {
            ToolStripStatusLabel tssl = sender as ToolStripStatusLabel;
            if (tssl.Text.Equals("true", StringComparison.CurrentCultureIgnoreCase)) { tssl.Image = global::xeBuild_GUI.Properties.Resources.good; }
            else { tssl.Image = global::xeBuild_GUI.Properties.Resources.error; }
        }
        private void addstatus()
        {
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            Main.typestatus, Main.typestatuslabel, Main.sourcestatus, Main.sourcestatuslabel,
            Main.outputstatus, Main.outputstatuslabel, Main.mobostatus, Main.mobostatuslabel,
            Main.cpukeystatus, Main.cpukeystatuslabel, Main.blkeystatus, Main.blkeystatuslabel,
            Main.kernelstatus, Main.kernelstatuslabel, Main.xellstatus, Main.xellstatuslabel,
            Main.smcstatus, Main.smcstatuslabel});
        }
        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int ok = 0;
            foreach (string s in FileList)
            {
                if (s.EndsWith(".bin", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (ok == 0) 
                    {
                        Main.statc.source.Text = s;
                        Main.statc.output.Text = System.IO.Path.GetDirectoryName(s) + "\\";
                        if (Main.mright.semiauto.Checked) { Main.mright.checkmobo(); }
                    }
                    ok++;
                } 
            }
        }        
        private void Main_Load(object sender, EventArgs e)
        {
            Main.tabc = Tabs;
            r.init();
            StringBuilder newdir = new StringBuilder(Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).CodeBase));
            dir = newdir.Remove(0, 6).ToString();
            string[] versionpart = this.ProductVersion.Split('.');
            version = versionpart[0] + "." + versionpart[1];
            if (!versionpart[versionpart.Length - 1].Equals("0")) { version += " BETA" + versionpart[versionpart.Length - 1]; }
            else if (!versionpart[versionpart.Length - 2].Equals("0")) { version += " RC" + versionpart[versionpart.Length - 2]; }
            this.Text += Main.version + " Modified by BenMitnicK";
            lpanel.Controls.Add(statc);
            rpanel.Controls.Add(r);
            app = Assembly.GetExecutingAssembly();
            makestatus();
            getxeBuildStatus();
            getDashLaunchStatus();
            download.drivelist();
            download.fillversions("updates.xml", "dashfiles.xml");
            #region autoload
            if (File.Exists(Main.dir + "\\default.xml")) { loadsettings(Main.dir + "\\default.xml"); }
            if (File.Exists(Main.dir + "\\flashdmp.bin")) 
            { 
                Main.statc.source.Text = Main.dir + "\\flashdmp.bin";
                Main.statc.output.Text = Path.GetDirectoryName(Main.statc.source.Text) + "\\";
                if (Main.mright.semiauto.Checked) { Main.mright.checkmobo(); }
            }
            if (File.Exists(Main.dir + "\\smc.bin"))
            {
                ezmode = false;
                Main.statc.customsmc.Checked = true;
            }
            if (File.Exists(Main.dir + "\\xell.bin"))
            {
                ezmode = false;
                Main.statc.customxell.Checked = true;
            }
            if ((File.Exists(Main.dir + "\\kv.bin")) || (File.Exists(Main.dir + "\\smc_config.bin")))
            {
                ezmode = false;
                Main.mright.extvital.Checked = true;
            }
            #region cpukey
            if (File.Exists(Main.dir + "\\FUSE.txt"))
            {
                string[] ret = Static.Getkey.readfusefile(Main.dir + "\\FUSE.txt");
                Main.statc.cpukey.Text = ret[0];
                Main.mright.cfldv.Text = ret[1];
            }
            else if (File.Exists(Main.dir + "\\cpukey.txt"))
            {
                Main.statc.cpukey.Text = Static.Getkey.readkeyfile(Main.dir + "\\cpukey.txt");
            }
            #endregion
            #region xebuildsettings
            if (File.Exists(Main.dir + "\\options.ini"))
            {
                Main.xeset.loadxebuild(Main.dir + "\\options.ini");
                Main.mright.customxebuild.Checked = true;
                ezmode = false;
            }
            //if (File.Exists(Main.dir + "\\launch.ini"))
            //{
            //    Main.dlc.loaddlsettings(Main.dir + "\\launch.ini");
            //}
            #endregion
            modeswitch_Click(null, null);
            #endregion
            Main.mright.dlbeta.Visible = (File.Exists(Main.dir + "\\files\\dlaunchbeta\\launch.xex"));
            Directory.CreateDirectory(Main.dir + "\\files\\temp\\");
        }
        private void MenuExit_Click(object sender, EventArgs e) { Close(); }
        private void modeswitch_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                ezmode = (!ezmode);
            }
            tp = Main.tabc.SelectedTab;
            r.reload();
            rpanel.Controls.Add(r);
            statc.devkit.Visible = (!ezmode);
            statc.jaspersb.Visible = (!ezmode);
            statc.jasperbigffs.Visible = (!ezmode);
            statc.customxell.Visible = ((!ezmode) && (File.Exists(Main.dir + "\\xell.bin")));
            statc.customsmc.Visible = ((!ezmode) && (File.Exists(Main.dir + "\\smc.bin")));
            statc.customxell.Checked = false;
            statc.customsmc.Checked = false;
            mright.customxebuild.Visible = (!ezmode);
            mright.paramedit.Visible = (!ezmode);
            mright.extvital.Visible = (!ezmode);
            extractToolStripMenuItem.Visible = (!ezmode);
            Main.statc.blkey.ReadOnly = (ezmode);
            if (Main.tabc.TabPages.Contains(tp)) { Main.tabc.SelectedTab = tp; }
            else { Main.tabc.SelectedIndex = 0; }
            modetext();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (wc != null)
            {
                if (wc.IsBusy) { download.dwlcancelbtn_Click(sender, e); MessageBox.Show("ERROR: Please cancel download before closing!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else { e.Cancel = false; }
            }
            else { e.Cancel = false; }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadset.ShowDialog() == DialogResult.OK)
            {
                loadsettings(loadset.FileName);
            }
            loadset.FileName = "settings.xml";
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveset.InitialDirectory = Main.dir;
            if (saveset.ShowDialog() == DialogResult.OK)
            {
                savesettings(saveset.FileName);
            }
            loadset.FileName = "settings.xml";
        }
        public static void debug(string[] settings)
        {
            using (StreamWriter sw = new StreamWriter(Main.dir + "\\debug.log"))
            {
                sw.WriteLine("========================================================");
                sw.WriteLine(" xeBuild GUI v " + Main.version + " Debuglog");
                sw.WriteLine(" " + DateTime.Today.ToString() + " " + DateTime.Now.ToString());
                sw.WriteLine("========================================================");
                sw.WriteLine(" *** Settings variables ***");
                sw.WriteLine("Source: " + settings[0]);
                sw.WriteLine("Output: " + settings[1]);
                sw.WriteLine("Image Type: " + settings[2]);
                sw.WriteLine("Mobo: " + settings[3]);
                sw.WriteLine("CPUKey: " + settings[4]);
                sw.WriteLine("1BLKey: " + settings[5]);
                sw.WriteLine("Kernel version: " + settings[6]);
                sw.WriteLine("Xell Version: " + settings[7]);
                sw.WriteLine("SMC Hack: " + settings[8]);
                sw.WriteLine("Include Dashlaunch: " + settings[9]);
                sw.WriteLine("Custom Dashlaunch settings: " + settings[10]);
                sw.WriteLine("Automatic Selection: " + settings[11]);
                sw.WriteLine("Custom xeBuild: " + settings[12]);
                sw.WriteLine("Custom filelist/patch: " + settings[13]);
                sw.WriteLine("Custom filelist/patch (Name): " + settings[14]);
                sw.WriteLine("CFLDV: " + settings[15]);
                sw.WriteLine("Auto Save Log: " + settings[16]);
                sw.WriteLine("Auto Save Log (Dir + Name): " + settings[17]);
                sw.WriteLine("Simple Mode:" + Main.ezmode.ToString());
                sw.WriteLine("Verbose xeBuild Output:" + Main.xeset.verbose.Checked.ToString());
                sw.WriteLine(" *** MD5 hashes ***");
                if (File.Exists(Main.dir + "\\files\\xebuild.exe"))
                {
                    sw.WriteLine("          xeBuild.exe: " + Main.misc.getmd5(Main.dir + "\\files\\xebuild.exe"));
                    sw.WriteLine("Original with release: 678C93B8642D142F78A21D8FA09C4343");
                }
                else { sw.WriteLine("ERROR: no xebuild!"); }
                if (File.Exists(Main.dir + "\\files\\dlaunch\\launch.xex"))
                {
                    sw.WriteLine("           launch.xex: " + Main.misc.getmd5(Main.dir + "\\files\\dlaunch\\launch.xex"));
                    sw.WriteLine("Original with release: 9356939823865BE749333C02E1AB480D");
                }
                else { sw.WriteLine("ERROR: no dashlaunch (launch.xex)!"); }
                if (File.Exists(Main.dir + "\\files\\dlaunch\\lhelper.xex"))
                {
                    sw.WriteLine("          lhelper.xex: " + Main.misc.getmd5(Main.dir + "\\files\\dlaunch\\lhelper.xex"));
                    sw.WriteLine("Original with release: F0BC94D451BA7496B9DBC7BB42882569");
                }
                else { sw.WriteLine("ERROR: no dashlaunch (lhelper.xex)!"); }
                if (File.Exists(Main.dir + "\\files\\ecc\\build.py"))
                {
                    sw.WriteLine("          build.py:    " + Main.misc.getmd5(Main.dir + "\\files\\ecc\\build.py"));
                    sw.WriteLine("Original with release: 1E3BE54136B3A9DE25D2B75CC6BC8C9E");
                }
                else { sw.WriteLine("ERROR: no python build script!"); }
                sw.WriteLine("");
                sw.WriteLine(" *** Actual log ***");
                foreach (string s in outtab.rtb.Lines) { sw.WriteLine(s); }
                if (File.Exists(Main.dir + "\\files\\output.bin.log"))
                {
                    sw.WriteLine("");
                    sw.WriteLine(" *** xeBuild's verbose log *** ");
                    sw.WriteLine(" it was last updated: " + File.GetLastWriteTime(Main.dir + "\\files\\output.bin.log").ToString());
                    sw.WriteLine("");
                    string[] lines = File.ReadAllLines(Main.dir + "\\files\\output.bin.log");
                    foreach (string s in lines) { sw.WriteLine(s); }
                }
            }
        }
        public void modetext()
        {
            if (ezmode) { modeswitch.Text = "Switch to advanced mode"; }
            else { modeswitch.Text = "Switch to simple mode"; }
        }
        private void loadsettings (string file)
        {
            using (XmlReader xml = XmlReader.Create(file))
            {
                while (xml.Read())
                {
                    if (xml.IsStartElement())
                    {
                        switch (xml.Name.ToLower())
                        {
                            #region Type
                            case "type":
                                xml.Read();
                                switch (xml.Value.ToLower())
                                {
                                    case "ecc":
                                        Main.statc.ecc.Checked = true;
                                        break;
                                    case "glitch":
                                        Main.statc.glitch.Checked = true;
                                        break;
                                    case "jtag":
                                        Main.statc.jtag.Checked = true;
                                        break;
                                    case "retail":
                                        Main.statc.retail.Checked = true;
                                        break;
                                    case "devkit":
                                        Main.statc.devkit.Checked = true;
                                        break;
                                    default:
                                        Main.statc.ecc.Checked = false;
                                        Main.statc.glitch.Checked = false;
                                        Main.statc.jtag.Checked = false;
                                        Main.statc.retail.Checked = false;
                                        Main.statc.devkit.Checked = false;
                                        break;
                                }
                                break;
                            #endregion
                            #region Mobo
                            case "mobo":
                                xml.Read();
                                switch (xml.Value.ToLower())
                                {
                                    case "xenon":
                                        Main.statc.xenon.Checked = true;
                                        break;
                                    case "falcon":
                                        Main.statc.falcon.Checked = true;
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
                                    case "zephyr":
                                        Main.statc.zephyr.Checked = true;
                                        break;
                                    case "trinity":
                                        Main.statc.trinity.Checked = true;
                                        break;
                                    case "corona":
                                        Main.statc.trinity.Checked = true;
                                        break;
                                    default:
                                        Main.statc.xenon.Checked = false;
                                        Main.statc.falcon.Checked = false;
                                        Main.statc.jasper.Checked = false;
                                        Main.statc.jasperbigffs.Checked = false;
                                        Main.statc.jaspersb.Checked = false;
                                        Main.statc.zephyr.Checked = false;
                                        Main.statc.trinity.Checked = false;
                                        Main.statc.corona.Checked = false;
                                        break;
                                }
                                break;
                            #endregion
                            #region SMC
                            case "smc":
                                xml.Read();
                                switch (xml.Value.ToLower())
                                {
                                    case "cygnos":
                                        Main.statc.cygnos.Checked = true;
                                        break;
                                    case "cygnos2":
                                        Main.statc.cygnos2.Checked = true;
                                        break;
                                    case "aud_clamp":
                                        Main.statc.aud_clamp.Checked = true;
                                        break;
                                    case "aud_clamp2":
                                        Main.statc.aud_clamp2.Checked = true;
                                        break;
                                    case "normal":
                                        Main.statc.normal.Checked = true;
                                        break;
                                    case "customsmc":
                                        Main.statc.customsmc.Checked = true;
                                        break;
                                    case "custom":
                                        Main.statc.customsmc.Checked = true;
                                        break;
                                    case "currentsmc":
                                        Main.statc.currentsmc.Checked = true;
                                        break;
                                    default:
                                        Main.statc.cygnos.Checked = false;
                                        Main.statc.cygnos2.Checked = false;
                                        Main.statc.customsmc.Checked = false;
                                        Main.statc.normal.Checked = false;
                                        Main.statc.aud_clamp.Checked = false;
                                        Main.statc.aud_clamp2.Checked = false;
                                        Main.statc.currentsmc.Checked = false;
                                        break;
                                }
                                break;
                            #endregion
                            #region Xell
                            case "xell":
                                xml.Read();
                                switch (xml.Value.ToLower())
                                {
                                    case "xell":
                                        Main.statc.xell.Checked = true;
                                        break;
                                    case "xellous":
                                        Main.statc.xellous.Checked = true;
                                        break;
                                    case "xellreloaded":
                                        Main.statc.xellreloaded.Checked = true;
                                        break;
                                    case "xell-reloaded":
                                        Main.statc.xellreloaded.Checked = true;
                                        break;
                                    case "customxell":
                                        Main.statc.customxell.Checked = true;
                                        break;
                                    case "custom":
                                        Main.statc.customxell.Checked = true;
                                        break;
                                    default:
                                        Main.statc.xell.Checked = false;
                                        Main.statc.xellous.Checked = false;
                                        Main.statc.xellreloaded.Checked = false;
                                        Main.statc.customxell.Checked = false;
                                        break;
                                }
                                break;
                            #endregion
                            #region Others
                            case "dashlaunch":
                                xml.Read();
                                Main.mright.includedl.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                break;
                            case "dlbeta":
                                xml.Read();
                                Main.mright.dlbeta.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                if (File.Exists(Main.dir + "\\files\\dlaunchbeta\\launch.xex")) { Main.mright.dlbeta.Visible = true; }
                                else
                                {
                                    Main.mright.dlbeta.Visible = false;
                                    Main.mright.dlbeta.Checked = false;
                                }
                                break;
                            case "customdashlaunch":
                                xml.Read();
                                Main.mright.customdl.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                break;
                            case "nomu":
                                xml.Read();
                                Main.mright.nomu.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                break;
                            case "cpukey":
                                xml.Read();
                                if (xml.Value != "none") { Main.statc.cpukey.Text = xml.Value; } 
                                else { Main.statc.cpukey.Text = ""; }
                                break;
                            case "bl1key":
                                xml.Read();
                                if (xml.Value != "none") { Main.statc.blkey.Text = xml.Value; }
                                else { Main.statc.blkey.Text = "DD88AD0C9ED669E7B56794FB68563EFA"; }
                                break;
                            case "source":
                                xml.Read();
                                if (xml.Value != "none") { Main.statc.source.Text = xml.Value; } 
                                else { Main.statc.source.Text = ""; }
                                break;
                            case "output":
                                xml.Read();
                                if (xml.Value != "none")
                                {
                                    Main.statc.output.Text = System.IO.Path.GetDirectoryName(xml.Value);
                                    string filename = System.IO.Path.GetFileName(xml.Value);
                                    if (filename.EndsWith(".bin", StringComparison.CurrentCultureIgnoreCase)) { Main.statc.binname.Text = filename; }
                                    else if (filename.EndsWith(".ecc", StringComparison.CurrentCultureIgnoreCase)) { Main.statc.eccname.Text = filename; }
                                }
                                else { Main.statc.output.Text = ""; }
                                break;
                            case "eccname":
                                xml.Read();
                                if (xml.Value != "none")
                                {
                                    Main.statc.eccname.Text = xml.Value;
                                }
                                break;
                            case "binname":
                                xml.Read();
                                if (xml.Value != "none")
                                {
                                    Main.statc.binname.Text = xml.Value;
                                }
                                break;
                            case "kernel":
                                xml.Read();
                                Main.statc.kernel.Text = "2.0." + xml.Value.Trim() + ".0";
                                if (Main.statc.kernel.Text != "2.0." + xml.Value.Trim() + ".0") { Main.statc.ckernel.Text = xml.Value.Trim(); }
                                break;
                            case "custombuild":
                                xml.Read();
                                Main.mright.customxebuild.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                break;
                            case "nofcrt":
                                xml.Read();
                                Main.mright.nofcrt.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                break;
                            case "autolog":
                                xml.Read();
                                Main.mright.autosavelog.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));                                
                                break;
                            case "logdir":
                                xml.Read();
                                if (xml.Value != "none") { Main.mright.logname.Text = xml.Value; } 
                                else { Main.mright.logname.Text = "xeBuild_GUI.log"; }
                                break;
                            case "autoselect":
                                xml.Read();
                                Main.mright.semiauto.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));                                
                                break;
                            case "custompatch":
                                xml.Read();
                                Main.xeset.customini.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                break;
                            case "custompatchname":
                                xml.Read();
                                if (xml.Value != "none") { Main.xeset.customininame.Text = xml.Value; }
                                else { Main.xeset.customini.Text = ""; }
                                break;
                            case "verbose":
                                xml.Read();
                                Main.xeset.verbose.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));                                
                                break;
                            case "xellip":
                                xml.Read();
                                if (xml.Value != "none") { Main.statc.xellip.Text = xml.Value; }
                                else { Main.statc.xellip.Text = ""; }
                                break;
                            case "simplemode":
                                xml.Read();
                                Main.ezmode = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                modeswitch_Click(null, null);
                                break;
                            case "nohdmiwait":
                                xml.Read();
                                Main.mright.nohdmiwait.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                modeswitch_Click(null, null);
                                break;
                            case "nohdd":
                                xml.Read();
                                Main.mright.nohdd.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                modeswitch_Click(null, null);
                                break;
                            case "notrinmu":
                                xml.Read();
                                Main.mright.notrinmu.Checked = (xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase));
                                modeswitch_Click(null, null);
                                break;
                            default:
                                break;
                            #endregion
                        }
                    }
                }
            }
            if ((Main.mright.semiauto.Checked && (File.Exists(Main.statc.source.Text)))) { Main.mright.checkmobo(); }
        }
        private void savesettings(string file)
        {
            string[] config = Main.statc.getsettings();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            for (int i = 0; i < config.Length - 1; i++)
            {
                if (string.IsNullOrEmpty(config[i])) { config[i] = "none"; }
            }
            using (XmlWriter xmlw = XmlWriter.Create(file, settings))
            {
                xmlw.WriteStartDocument();
                xmlw.WriteStartElement("config");
                xmlw.WriteElementString("source", config[0]);
                xmlw.WriteElementString("output", config[1]);
                xmlw.WriteElementString("eccname", Main.statc.eccname.Text);
                xmlw.WriteElementString("binname", Main.statc.binname.Text);
                xmlw.WriteElementString("type", config[2]);
                xmlw.WriteElementString("mobo", config[3]);
                xmlw.WriteElementString("cpukey", config[4]);
                xmlw.WriteElementString("bl1key", config[5]);
                xmlw.WriteElementString("kernel", config[6]);
                xmlw.WriteElementString("xell", config[7]);
                xmlw.WriteElementString("smc", config[8]);
                xmlw.WriteElementString("dashlaunch", config[9]);
                xmlw.WriteElementString("dlbeta", Main.mright.dlbeta.Checked.ToString());
                xmlw.WriteElementString("customdashlaunch", config[10]);
                xmlw.WriteElementString("autoselect", config[11]);
                xmlw.WriteElementString("custombuild", config[12]);
                xmlw.WriteElementString("custompatch", config[13]);
                xmlw.WriteElementString("custompatchname", config[14]);
                xmlw.WriteElementString("autolog", config[16]);
                xmlw.WriteElementString("logdir", config[17]);
                xmlw.WriteElementString("nomu", Main.mright.nomu.Checked.ToString());
                xmlw.WriteElementString("notrinmu", Main.mright.notrinmu.Checked.ToString());
                xmlw.WriteElementString("nohdd", Main.mright.nohdd.Checked.ToString());
                xmlw.WriteElementString("nofcrt", Main.mright.nofcrt.Checked.ToString());
                xmlw.WriteElementString("nohdmiwait", Main.mright.nohdmiwait.Checked.ToString());
                xmlw.WriteElementString("verbose", Main.xeset.verbose.Checked.ToString());
                xmlw.WriteElementString("xellip", Main.statc.xellip.Text);
                xmlw.WriteElementString("simplemode", Main.ezmode.ToString());
                xmlw.WriteEndDocument();
            }
        }
        private void nandpro_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form a in Application.OpenForms)
            {
                if (a is Nandpro)
                {
                    isopen = true;
                    a.Visible = true;
                    a.TopMost = true;
                    a.Focus();
                    a.BringToFront();
                    a.TopMost = false;
                }
            }
            if (isopen == false)
            {
                Nandpro nandform = new Nandpro();
                nandform.ShowDialog(this);
            }
        }
        private void scanForXellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form a in Application.OpenForms)
            {
                if (a is IPScan)
                {
                    isopen = true;
                    a.Visible = true;
                    a.TopMost = true;
                    a.Focus();
                    a.BringToFront();
                    a.TopMost = false;
                }
            }
            if (isopen == false)
            {
                IPScan ipform = new IPScan();
                ipform.ShowDialog(this);
            }
        }
        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form a in Application.OpenForms)
            {
                if (a is Extract)
                {
                    isopen = true;
                    a.Visible = true;
                    a.TopMost = true;
                    a.Focus();
                    a.BringToFront();
                    a.TopMost = false;
                }
            }
            if (isopen == false)
            {
                Extract form = new Extract();
                form.ShowDialog(this);
            }
        }
        private void imageCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form a in Application.OpenForms)
            {
                if (a is Versions)
                {
                    isopen = true;
                    a.Visible = true;
                    a.TopMost = true;
                    a.Focus();
                    a.BringToFront();
                    a.TopMost = false;
                }
            }
            if (isopen == false)
            {
                Versions form = new Versions();
                form.ShowDialog(this);
            }
        }
        private void dashlaunchIniEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form a in Application.OpenForms)
            {
                if (a is DLConf)
                {
                    isopen = true;
                    a.Visible = true;
                    a.TopMost = true;
                    a.Focus();
                    a.BringToFront();
                    a.TopMost = false;
                }
            }
            if (isopen == false)
            {
                DLConf form = new DLConf();
                form.ShowDialog(this);
            }
        }
        private void hclabel_Click(object sender, EventArgs e) { Process.Start("http://www.homebrew-connection.org/"); }
        private void checkSMCConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form a in Application.OpenForms)
            {
                if (a is SMCConfigEdit)
                {
                    isopen = true;
                    a.Visible = true;
                    a.TopMost = true;
                    a.Focus();
                    a.BringToFront();
                    a.TopMost = false;
                }
            }
            if (isopen == false)
            {
                SMCConfigEdit form = new SMCConfigEdit();
                form.ShowDialog(this);
            }
        }

        private void disableFailsafeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disableFailsafeToolStripMenuItem.Text = !disfailsafe ? "Enable Failsafe" : "Disable Failsafe";
            disfailsafe = !disfailsafe;
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https:\\www.modconsoles.fr"); }

        private void nandMMCOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form a in Application.OpenForms)
            {
                if (a is xeBuild_GUI.NandMMC.nandMMC)
                {
                    isopen = true;
                    a.Visible = true;
                    a.TopMost = true;
                    a.Focus();
                    a.BringToFront();
                    a.TopMost = false;
                }
            }
            if (isopen == false)
            {
                xeBuild_GUI.NandMMC.nandMMC form = new xeBuild_GUI.NandMMC.nandMMC();
                form.ShowDialog(this);
            }
        }
        public void getxeBuildStatus() {

            string xmd5 = Oper.GetMD5HashFromFile(variables.update_path + "xeBuild.exe").ToUpper();

            if (variables.xebuilds.ContainsKey(xmd5.ToUpper()))
            {
                if (variables.debugme) Console.WriteLine("Known xebuild md5 found");
                xeBuildStatus.Text = variables.xebuilds[xmd5.ToUpper()];
                variables.xebuild = variables.xebuilds[xmd5.ToUpper()];
            }
            else
            {
                xeBuildStatus.Text = "";
                variables.xebuild = "";
            }

        }
        public void getDashLaunchStatus()
        {

            string dlmd5 = Oper.GetMD5HashFromFile(variables.update_path2 + "launch.xex").ToUpper();

            if (variables.dls.ContainsKey(dlmd5.ToUpper()))
            {
                if (variables.debugme) Console.WriteLine("Known dl md5 found");
                DashLaunchStatus.Text = variables.dls[dlmd5.ToUpper()];
                variables.dashlaunch = variables.dls[dlmd5.ToUpper()];
            }
            else
            {
                DashLaunchStatus.Text = "";
                variables.dashlaunch = "";
            }

        }
    }
}