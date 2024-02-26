namespace xeBuild_GUI
{
    partial class Static
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.keys = new System.Windows.Forms.GroupBox();
            this.getipbtn = new System.Windows.Forms.Button();
            this.xellip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.getkey_networkbtn = new System.Windows.Forms.Button();
            this.getkey_fusestxtbtn = new System.Windows.Forms.Button();
            this.getkey_cpukeytxtbtn = new System.Windows.Forms.Button();
            this.cpukeylabel = new System.Windows.Forms.Label();
            this.blkeylabel = new System.Windows.Forms.Label();
            this.blkey = new System.Windows.Forms.TextBox();
            this.cpukey = new System.Windows.Forms.TextBox();
            this.imgtype = new System.Windows.Forms.GroupBox();
            this.ecc2 = new System.Windows.Forms.RadioButton();
            this.devkit = new System.Windows.Forms.RadioButton();
            this.glitch2 = new System.Windows.Forms.RadioButton();
            this.retail = new System.Windows.Forms.RadioButton();
            this.ecc = new System.Windows.Forms.RadioButton();
            this.glitch = new System.Windows.Forms.RadioButton();
            this.jtag = new System.Windows.Forms.RadioButton();
            this.mobo = new System.Windows.Forms.GroupBox();
            this.jasperbigffs = new System.Windows.Forms.RadioButton();
            this.jasperbb = new System.Windows.Forms.RadioButton();
            this.corona = new System.Windows.Forms.RadioButton();
            this.trinity = new System.Windows.Forms.RadioButton();
            this.zephyr = new System.Windows.Forms.RadioButton();
            this.jasper = new System.Windows.Forms.RadioButton();
            this.jaspersb = new System.Windows.Forms.RadioButton();
            this.falcon = new System.Windows.Forms.RadioButton();
            this.xenon = new System.Windows.Forms.RadioButton();
            this.smc = new System.Windows.Forms.GroupBox();
            this.currentsmc = new System.Windows.Forms.RadioButton();
            this.aud_clamp2 = new System.Windows.Forms.RadioButton();
            this.cygnos2 = new System.Windows.Forms.RadioButton();
            this.cygnos = new System.Windows.Forms.RadioButton();
            this.customsmc = new System.Windows.Forms.RadioButton();
            this.aud_clamp = new System.Windows.Forms.RadioButton();
            this.normal = new System.Windows.Forms.RadioButton();
            this.xellver = new System.Windows.Forms.GroupBox();
            this.customxell = new System.Windows.Forms.RadioButton();
            this.xellreloaded = new System.Windows.Forms.RadioButton();
            this.xellous = new System.Windows.Forms.RadioButton();
            this.xell = new System.Windows.Forms.RadioButton();
            this.paths = new System.Windows.Forms.GroupBox();
            this.binname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eccname = new System.Windows.Forms.TextBox();
            this.sourcelabel = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.outputlabel = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.openbtn = new System.Windows.Forms.Button();
            this.source = new System.Windows.Forms.TextBox();
            this.kernelver = new System.Windows.Forms.GroupBox();
            this.customkernellabel = new System.Windows.Forms.Label();
            this.ckernel = new System.Windows.Forms.TextBox();
            this.kernel = new System.Windows.Forms.ComboBox();
            this.genbtn = new System.Windows.Forms.Button();
            this.openkeystxt = new System.Windows.Forms.OpenFileDialog();
            this.openfusetxt = new System.Windows.Forms.OpenFileDialog();
            this.opennand = new System.Windows.Forms.OpenFileDialog();
            this.savebin = new System.Windows.Forms.SaveFileDialog();
            this.saveecc = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.corona4g = new System.Windows.Forms.RadioButton();
            this.keys.SuspendLayout();
            this.imgtype.SuspendLayout();
            this.mobo.SuspendLayout();
            this.smc.SuspendLayout();
            this.xellver.SuspendLayout();
            this.paths.SuspendLayout();
            this.kernelver.SuspendLayout();
            this.SuspendLayout();
            // 
            // keys
            // 
            this.keys.Controls.Add(this.getipbtn);
            this.keys.Controls.Add(this.xellip);
            this.keys.Controls.Add(this.label1);
            this.keys.Controls.Add(this.getkey_networkbtn);
            this.keys.Controls.Add(this.getkey_fusestxtbtn);
            this.keys.Controls.Add(this.getkey_cpukeytxtbtn);
            this.keys.Controls.Add(this.cpukeylabel);
            this.keys.Controls.Add(this.blkeylabel);
            this.keys.Controls.Add(this.blkey);
            this.keys.Controls.Add(this.cpukey);
            this.keys.Location = new System.Drawing.Point(4, 243);
            this.keys.Name = "keys";
            this.keys.Size = new System.Drawing.Size(518, 99);
            this.keys.TabIndex = 3;
            this.keys.TabStop = false;
            this.keys.Text = "Keys";
            // 
            // getipbtn
            // 
            this.getipbtn.Location = new System.Drawing.Point(155, 70);
            this.getipbtn.Name = "getipbtn";
            this.getipbtn.Size = new System.Drawing.Size(125, 23);
            this.getipbtn.TabIndex = 8;
            this.getipbtn.Text = "Get base IP";
            this.getipbtn.UseVisualStyleBackColor = true;
            this.getipbtn.Click += new System.EventHandler(this.getipbtn_Click);
            // 
            // xellip
            // 
            this.xellip.Location = new System.Drawing.Point(59, 72);
            this.xellip.MaxLength = 15;
            this.xellip.Name = "xellip";
            this.xellip.Size = new System.Drawing.Size(90, 20);
            this.xellip.TabIndex = 2;
            this.xellip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctrlfix);
            this.xellip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Ipinput);
            this.xellip.KeyUp += new System.Windows.Forms.KeyEventHandler(this.xellip_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "IP to Xell:";
            // 
            // getkey_networkbtn
            // 
            this.getkey_networkbtn.Location = new System.Drawing.Point(286, 70);
            this.getkey_networkbtn.Name = "getkey_networkbtn";
            this.getkey_networkbtn.Size = new System.Drawing.Size(226, 23);
            this.getkey_networkbtn.TabIndex = 5;
            this.getkey_networkbtn.Text = "Get CPUKey/CFLDV from Network";
            this.getkey_networkbtn.UseVisualStyleBackColor = true;
            this.getkey_networkbtn.Click += new System.EventHandler(this.getkey_networkbtn_Click);
            // 
            // getkey_fusestxtbtn
            // 
            this.getkey_fusestxtbtn.Location = new System.Drawing.Point(286, 42);
            this.getkey_fusestxtbtn.Name = "getkey_fusestxtbtn";
            this.getkey_fusestxtbtn.Size = new System.Drawing.Size(226, 23);
            this.getkey_fusestxtbtn.TabIndex = 4;
            this.getkey_fusestxtbtn.Text = "Get CPUKey/CFLDV from FUSE.txt";
            this.getkey_fusestxtbtn.UseVisualStyleBackColor = true;
            this.getkey_fusestxtbtn.Click += new System.EventHandler(this.getkey_fusestxtbtn_Click);
            // 
            // getkey_cpukeytxtbtn
            // 
            this.getkey_cpukeytxtbtn.Location = new System.Drawing.Point(286, 14);
            this.getkey_cpukeytxtbtn.Name = "getkey_cpukeytxtbtn";
            this.getkey_cpukeytxtbtn.Size = new System.Drawing.Size(226, 23);
            this.getkey_cpukeytxtbtn.TabIndex = 3;
            this.getkey_cpukeytxtbtn.Text = "Get CPUKey from Keys.txt";
            this.getkey_cpukeytxtbtn.UseVisualStyleBackColor = true;
            this.getkey_cpukeytxtbtn.Click += new System.EventHandler(this.GetkeyCpukeytxtbtnClick);
            // 
            // cpukeylabel
            // 
            this.cpukeylabel.AutoSize = true;
            this.cpukeylabel.Location = new System.Drawing.Point(6, 17);
            this.cpukeylabel.Name = "cpukeylabel";
            this.cpukeylabel.Size = new System.Drawing.Size(50, 13);
            this.cpukeylabel.TabIndex = 7;
            this.cpukeylabel.Text = "CPUKey:";
            // 
            // blkeylabel
            // 
            this.blkeylabel.AutoSize = true;
            this.blkeylabel.Location = new System.Drawing.Point(9, 46);
            this.blkeylabel.Name = "blkeylabel";
            this.blkeylabel.Size = new System.Drawing.Size(47, 13);
            this.blkeylabel.TabIndex = 9;
            this.blkeylabel.Text = "1BLKey:";
            // 
            // blkey
            // 
            this.blkey.Location = new System.Drawing.Point(59, 43);
            this.blkey.MaxLength = 32;
            this.blkey.Name = "blkey";
            this.blkey.Size = new System.Drawing.Size(221, 20);
            this.blkey.TabIndex = 1;
            this.blkey.Text = "DD88AD0C9ED669E7B56794FB68563EFA";
            this.blkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctrlfix);
            this.blkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Keycheck);
            this.blkey.Leave += new System.EventHandler(this.key_leave);
            // 
            // cpukey
            // 
            this.cpukey.Location = new System.Drawing.Point(59, 14);
            this.cpukey.MaxLength = 32;
            this.cpukey.Name = "cpukey";
            this.cpukey.Size = new System.Drawing.Size(221, 20);
            this.cpukey.TabIndex = 0;
            this.cpukey.TextChanged += new System.EventHandler(this.cpukey_TextChanged);
            this.cpukey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctrlfix);
            this.cpukey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Keycheck);
            this.cpukey.Leave += new System.EventHandler(this.key_leave);
            // 
            // imgtype
            // 
            this.imgtype.Controls.Add(this.ecc2);
            this.imgtype.Controls.Add(this.devkit);
            this.imgtype.Controls.Add(this.glitch2);
            this.imgtype.Controls.Add(this.retail);
            this.imgtype.Controls.Add(this.ecc);
            this.imgtype.Controls.Add(this.glitch);
            this.imgtype.Controls.Add(this.jtag);
            this.imgtype.Location = new System.Drawing.Point(3, 102);
            this.imgtype.Name = "imgtype";
            this.imgtype.Size = new System.Drawing.Size(519, 64);
            this.imgtype.TabIndex = 1;
            this.imgtype.TabStop = false;
            this.imgtype.Text = "Build type";
            // 
            // ecc2
            // 
            this.ecc2.AutoSize = true;
            this.ecc2.Location = new System.Drawing.Point(6, 41);
            this.ecc2.Name = "ecc2";
            this.ecc2.Size = new System.Drawing.Size(97, 17);
            this.ecc2.TabIndex = 6;
            this.ecc2.TabStop = true;
            this.ecc2.Text = "ECC (RGH 2.0)";
            this.toolTip1.SetToolTip(this.ecc2, "Used to generate a xell image for RGH 2.0 type consoles, check readme for more in" +
        "formation on which is which type...");
            this.ecc2.UseVisualStyleBackColor = true;
            this.ecc2.CheckedChanged += new System.EventHandler(this.type_changed);
            // 
            // devkit
            // 
            this.devkit.AutoSize = true;
            this.devkit.Location = new System.Drawing.Point(342, 41);
            this.devkit.Name = "devkit";
            this.devkit.Size = new System.Drawing.Size(56, 17);
            this.devkit.TabIndex = 4;
            this.devkit.TabStop = true;
            this.devkit.Text = "Devkit";
            this.toolTip1.SetToolTip(this.devkit, "Used to generate Devkit type images");
            this.devkit.UseVisualStyleBackColor = true;
            this.devkit.Visible = false;
            this.devkit.CheckedChanged += new System.EventHandler(this.type_changed);
            // 
            // glitch2
            // 
            this.glitch2.AutoSize = true;
            this.glitch2.Location = new System.Drawing.Point(109, 41);
            this.glitch2.Name = "glitch2";
            this.glitch2.Size = new System.Drawing.Size(118, 17);
            this.glitch2.TabIndex = 5;
            this.glitch2.Text = "Freeboot (RGH 2.0)";
            this.toolTip1.SetToolTip(this.glitch2, "Used to generate a Freeboot image for RGH 2.0 type consoles see readme for more i" +
        "nformation on which type your console belongs to");
            this.glitch2.UseVisualStyleBackColor = true;
            this.glitch2.CheckedChanged += new System.EventHandler(this.type_changed);
            // 
            // retail
            // 
            this.retail.AutoSize = true;
            this.retail.Location = new System.Drawing.Point(233, 18);
            this.retail.Name = "retail";
            this.retail.Size = new System.Drawing.Size(89, 17);
            this.retail.TabIndex = 3;
            this.retail.Text = "Retail (Stock)";
            this.toolTip1.SetToolTip(this.retail, "Used to generate a new original type image for your console");
            this.retail.UseVisualStyleBackColor = true;
            this.retail.CheckedChanged += new System.EventHandler(this.type_changed);
            // 
            // ecc
            // 
            this.ecc.AutoSize = true;
            this.ecc.Location = new System.Drawing.Point(6, 18);
            this.ecc.Name = "ecc";
            this.ecc.Size = new System.Drawing.Size(96, 17);
            this.ecc.TabIndex = 1;
            this.ecc.TabStop = true;
            this.ecc.Text = "ECC (RGH 1.x)";
            this.toolTip1.SetToolTip(this.ecc, "Used to generate a xell image for Glitch type consoles, check readme for more inf" +
        "ormation on which is which type...");
            this.ecc.UseVisualStyleBackColor = true;
            this.ecc.CheckedChanged += new System.EventHandler(this.type_changed);
            // 
            // glitch
            // 
            this.glitch.AutoSize = true;
            this.glitch.Location = new System.Drawing.Point(109, 18);
            this.glitch.Name = "glitch";
            this.glitch.Size = new System.Drawing.Size(117, 17);
            this.glitch.TabIndex = 2;
            this.glitch.Text = "Freeboot (RGH 1.x)";
            this.toolTip1.SetToolTip(this.glitch, "Used to generate a Freeboot image for Glitch type consoles see readme for more in" +
        "formation on which type your console belongs to");
            this.glitch.UseVisualStyleBackColor = true;
            this.glitch.CheckedChanged += new System.EventHandler(this.type_changed);
            // 
            // jtag
            // 
            this.jtag.AutoSize = true;
            this.jtag.Location = new System.Drawing.Point(233, 41);
            this.jtag.Name = "jtag";
            this.jtag.Size = new System.Drawing.Size(103, 17);
            this.jtag.TabIndex = 0;
            this.jtag.Text = "Freeboot (JTAG)";
            this.toolTip1.SetToolTip(this.jtag, "Used to generate a Freeboot image for JTAG type consoles see readme for more info" +
        "rmation on which type your console belongs to");
            this.jtag.UseVisualStyleBackColor = true;
            this.jtag.CheckedChanged += new System.EventHandler(this.type_changed);
            // 
            // mobo
            // 
            this.mobo.Controls.Add(this.corona4g);
            this.mobo.Controls.Add(this.jasperbigffs);
            this.mobo.Controls.Add(this.jasperbb);
            this.mobo.Controls.Add(this.corona);
            this.mobo.Controls.Add(this.trinity);
            this.mobo.Controls.Add(this.zephyr);
            this.mobo.Controls.Add(this.jasper);
            this.mobo.Controls.Add(this.jaspersb);
            this.mobo.Controls.Add(this.falcon);
            this.mobo.Controls.Add(this.xenon);
            this.mobo.Location = new System.Drawing.Point(3, 172);
            this.mobo.Name = "mobo";
            this.mobo.Size = new System.Drawing.Size(519, 65);
            this.mobo.TabIndex = 2;
            this.mobo.TabStop = false;
            this.mobo.Text = "Motherboard";
            // 
            // jasperbigffs
            // 
            this.jasperbigffs.Location = new System.Drawing.Point(232, 19);
            this.jasperbigffs.Name = "jasperbigffs";
            this.jasperbigffs.Size = new System.Drawing.Size(95, 17);
            this.jasperbigffs.TabIndex = 7;
            this.jasperbigffs.Text = "Jasper BB FFS";
            this.toolTip1.SetToolTip(this.jasperbigffs, "NOTE: Only use this if you know what you are doing!");
            this.jasperbigffs.UseVisualStyleBackColor = true;
            this.jasperbigffs.Visible = false;
            this.jasperbigffs.CheckedChanged += new System.EventHandler(this.aud_enable);
            // 
            // jasperbb
            // 
            this.jasperbb.AutoSize = true;
            this.jasperbb.Location = new System.Drawing.Point(340, 42);
            this.jasperbb.Name = "jasperbb";
            this.jasperbb.Size = new System.Drawing.Size(161, 17);
            this.jasperbb.TabIndex = 5;
            this.jasperbb.Text = "Jasper BB (256 MB/512 MB)";
            this.jasperbb.UseVisualStyleBackColor = true;
            this.jasperbb.CheckedChanged += new System.EventHandler(this.aud_enable);
            // 
            // corona
            // 
            this.corona.AutoSize = true;
            this.corona.Location = new System.Drawing.Point(163, 42);
            this.corona.Name = "corona";
            this.corona.Size = new System.Drawing.Size(59, 17);
            this.corona.TabIndex = 3;
            this.corona.Text = "Corona";
            this.corona.UseVisualStyleBackColor = true;
            this.corona.CheckedChanged += new System.EventHandler(this.trinity_CheckedChanged);
            // 
            // trinity
            // 
            this.trinity.AutoSize = true;
            this.trinity.Location = new System.Drawing.Point(163, 19);
            this.trinity.Name = "trinity";
            this.trinity.Size = new System.Drawing.Size(53, 17);
            this.trinity.TabIndex = 3;
            this.trinity.Text = "Trinity";
            this.trinity.UseVisualStyleBackColor = true;
            this.trinity.CheckedChanged += new System.EventHandler(this.trinity_CheckedChanged);
            // 
            // zephyr
            // 
            this.zephyr.AutoSize = true;
            this.zephyr.Location = new System.Drawing.Point(99, 42);
            this.zephyr.Name = "zephyr";
            this.zephyr.Size = new System.Drawing.Size(58, 17);
            this.zephyr.TabIndex = 6;
            this.zephyr.Text = "Zephyr";
            this.zephyr.UseVisualStyleBackColor = true;
            this.zephyr.CheckedChanged += new System.EventHandler(this.aud_enable);
            // 
            // jasper
            // 
            this.jasper.AutoSize = true;
            this.jasper.Location = new System.Drawing.Point(6, 42);
            this.jasper.Name = "jasper";
            this.jasper.Size = new System.Drawing.Size(87, 17);
            this.jasper.TabIndex = 0;
            this.jasper.Text = "Jasper 16MB";
            this.jasper.UseVisualStyleBackColor = true;
            this.jasper.CheckedChanged += new System.EventHandler(this.aud_enable);
            // 
            // jaspersb
            // 
            this.jaspersb.AutoSize = true;
            this.jaspersb.Location = new System.Drawing.Point(340, 19);
            this.jaspersb.Name = "jaspersb";
            this.jaspersb.Size = new System.Drawing.Size(104, 17);
            this.jaspersb.TabIndex = 8;
            this.jaspersb.Text = "Jasper 16MB SB";
            this.toolTip1.SetToolTip(this.jaspersb, "NOTE: Only use this if you know what you are doing!");
            this.jaspersb.UseVisualStyleBackColor = true;
            this.jaspersb.Visible = false;
            this.jaspersb.CheckedChanged += new System.EventHandler(this.aud_enable);
            // 
            // falcon
            // 
            this.falcon.AutoSize = true;
            this.falcon.Location = new System.Drawing.Point(6, 19);
            this.falcon.Name = "falcon";
            this.falcon.Size = new System.Drawing.Size(87, 17);
            this.falcon.TabIndex = 4;
            this.falcon.Text = "Falcon/Opus";
            this.falcon.UseVisualStyleBackColor = true;
            this.falcon.CheckedChanged += new System.EventHandler(this.aud_enable);
            // 
            // xenon
            // 
            this.xenon.AutoSize = true;
            this.xenon.Location = new System.Drawing.Point(99, 19);
            this.xenon.Name = "xenon";
            this.xenon.Size = new System.Drawing.Size(56, 17);
            this.xenon.TabIndex = 2;
            this.xenon.Text = "Xenon";
            this.xenon.UseVisualStyleBackColor = true;
            this.xenon.CheckedChanged += new System.EventHandler(this.xenon_CheckedChanged);
            // 
            // smc
            // 
            this.smc.Controls.Add(this.currentsmc);
            this.smc.Controls.Add(this.aud_clamp2);
            this.smc.Controls.Add(this.cygnos2);
            this.smc.Controls.Add(this.cygnos);
            this.smc.Controls.Add(this.customsmc);
            this.smc.Controls.Add(this.aud_clamp);
            this.smc.Controls.Add(this.normal);
            this.smc.Enabled = false;
            this.smc.Location = new System.Drawing.Point(4, 448);
            this.smc.Name = "smc";
            this.smc.Size = new System.Drawing.Size(518, 65);
            this.smc.TabIndex = 6;
            this.smc.TabStop = false;
            this.smc.Text = "SMC Hack";
            // 
            // currentsmc
            // 
            this.currentsmc.AutoSize = true;
            this.currentsmc.Checked = true;
            this.currentsmc.Location = new System.Drawing.Point(208, 19);
            this.currentsmc.Name = "currentsmc";
            this.currentsmc.Size = new System.Drawing.Size(117, 17);
            this.currentsmc.TabIndex = 6;
            this.currentsmc.TabStop = true;
            this.currentsmc.Text = "Current/Retail SMC";
            this.currentsmc.UseVisualStyleBackColor = true;
            // 
            // aud_clamp2
            // 
            this.aud_clamp2.AutoSize = true;
            this.aud_clamp2.Enabled = false;
            this.aud_clamp2.Location = new System.Drawing.Point(6, 19);
            this.aud_clamp2.Name = "aud_clamp2";
            this.aud_clamp2.Size = new System.Drawing.Size(115, 17);
            this.aud_clamp2.TabIndex = 0;
            this.aud_clamp2.Text = "Aud_Clamp + Eject";
            this.aud_clamp2.UseVisualStyleBackColor = true;
            this.aud_clamp2.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // cygnos2
            // 
            this.cygnos2.AutoSize = true;
            this.cygnos2.Enabled = false;
            this.cygnos2.Location = new System.Drawing.Point(208, 42);
            this.cygnos2.Name = "cygnos2";
            this.cygnos2.Size = new System.Drawing.Size(179, 17);
            this.cygnos2.TabIndex = 5;
            this.cygnos2.Text = "Cygnos v2 Alternative for Zephyr";
            this.cygnos2.UseVisualStyleBackColor = true;
            this.cygnos2.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // cygnos
            // 
            this.cygnos.AutoSize = true;
            this.cygnos.Location = new System.Drawing.Point(127, 42);
            this.cygnos.Name = "cygnos";
            this.cygnos.Size = new System.Drawing.Size(75, 17);
            this.cygnos.TabIndex = 4;
            this.cygnos.Text = "Cygnos v2";
            this.cygnos.UseVisualStyleBackColor = true;
            this.cygnos.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // customsmc
            // 
            this.customsmc.AutoSize = true;
            this.customsmc.Location = new System.Drawing.Point(331, 19);
            this.customsmc.Name = "customsmc";
            this.customsmc.Size = new System.Drawing.Size(86, 17);
            this.customsmc.TabIndex = 2;
            this.customsmc.Text = "Custom SMC";
            this.customsmc.UseVisualStyleBackColor = true;
            this.customsmc.Visible = false;
            this.customsmc.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // aud_clamp
            // 
            this.aud_clamp.AutoSize = true;
            this.aud_clamp.Enabled = false;
            this.aud_clamp.Location = new System.Drawing.Point(127, 19);
            this.aud_clamp.Name = "aud_clamp";
            this.aud_clamp.Size = new System.Drawing.Size(79, 17);
            this.aud_clamp.TabIndex = 1;
            this.aud_clamp.Text = "Aud_Clamp";
            this.aud_clamp.UseVisualStyleBackColor = true;
            this.aud_clamp.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // normal
            // 
            this.normal.AutoSize = true;
            this.normal.Location = new System.Drawing.Point(6, 42);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(113, 17);
            this.normal.TabIndex = 3;
            this.normal.Text = "Normal SMC Hack";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // xellver
            // 
            this.xellver.Controls.Add(this.customxell);
            this.xellver.Controls.Add(this.xellreloaded);
            this.xellver.Controls.Add(this.xellous);
            this.xellver.Controls.Add(this.xell);
            this.xellver.Enabled = false;
            this.xellver.Location = new System.Drawing.Point(4, 400);
            this.xellver.Name = "xellver";
            this.xellver.Size = new System.Drawing.Size(518, 42);
            this.xellver.TabIndex = 5;
            this.xellver.TabStop = false;
            this.xellver.Text = "Xell";
            // 
            // customxell
            // 
            this.customxell.AutoSize = true;
            this.customxell.Location = new System.Drawing.Point(216, 19);
            this.customxell.Name = "customxell";
            this.customxell.Size = new System.Drawing.Size(80, 17);
            this.customxell.TabIndex = 3;
            this.customxell.Text = "Custom Xell";
            this.customxell.UseVisualStyleBackColor = true;
            this.customxell.Visible = false;
            this.customxell.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // xellreloaded
            // 
            this.xellreloaded.AutoSize = true;
            this.xellreloaded.Checked = true;
            this.xellreloaded.Location = new System.Drawing.Point(119, 19);
            this.xellreloaded.Name = "xellreloaded";
            this.xellreloaded.Size = new System.Drawing.Size(91, 17);
            this.xellreloaded.TabIndex = 2;
            this.xellreloaded.TabStop = true;
            this.xellreloaded.Text = "Xell-Reloaded";
            this.xellreloaded.UseVisualStyleBackColor = true;
            this.xellreloaded.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // xellous
            // 
            this.xellous.AutoSize = true;
            this.xellous.Enabled = false;
            this.xellous.Location = new System.Drawing.Point(54, 19);
            this.xellous.Name = "xellous";
            this.xellous.Size = new System.Drawing.Size(59, 17);
            this.xellous.TabIndex = 1;
            this.xellous.Text = "Xellous";
            this.xellous.UseVisualStyleBackColor = true;
            this.xellous.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // xell
            // 
            this.xell.AutoSize = true;
            this.xell.Enabled = false;
            this.xell.Location = new System.Drawing.Point(6, 19);
            this.xell.Name = "xell";
            this.xell.Size = new System.Drawing.Size(42, 17);
            this.xell.TabIndex = 0;
            this.xell.Text = "Xell";
            this.xell.UseVisualStyleBackColor = true;
            this.xell.CheckedChanged += new System.EventHandler(this.updstat);
            // 
            // paths
            // 
            this.paths.Controls.Add(this.binname);
            this.paths.Controls.Add(this.label3);
            this.paths.Controls.Add(this.label2);
            this.paths.Controls.Add(this.eccname);
            this.paths.Controls.Add(this.sourcelabel);
            this.paths.Controls.Add(this.savebtn);
            this.paths.Controls.Add(this.outputlabel);
            this.paths.Controls.Add(this.output);
            this.paths.Controls.Add(this.openbtn);
            this.paths.Controls.Add(this.source);
            this.paths.Location = new System.Drawing.Point(3, 0);
            this.paths.Name = "paths";
            this.paths.Size = new System.Drawing.Size(519, 96);
            this.paths.TabIndex = 0;
            this.paths.TabStop = false;
            this.paths.Text = "Paths";
            // 
            // binname
            // 
            this.binname.Location = new System.Drawing.Point(274, 70);
            this.binname.Name = "binname";
            this.binname.Size = new System.Drawing.Size(125, 20);
            this.binname.TabIndex = 72;
            this.binname.Text = "updflash.bin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "BIN Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "ECC Name:";
            // 
            // eccname
            // 
            this.eccname.Location = new System.Drawing.Point(79, 70);
            this.eccname.Name = "eccname";
            this.eccname.Size = new System.Drawing.Size(124, 20);
            this.eccname.TabIndex = 69;
            this.eccname.Text = "image_00000000.ecc";
            // 
            // sourcelabel
            // 
            this.sourcelabel.AutoSize = true;
            this.sourcelabel.Location = new System.Drawing.Point(10, 22);
            this.sourcelabel.Name = "sourcelabel";
            this.sourcelabel.Size = new System.Drawing.Size(63, 13);
            this.sourcelabel.TabIndex = 65;
            this.sourcelabel.Text = "Source File:";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(405, 46);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(108, 23);
            this.savebtn.TabIndex = 3;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // outputlabel
            // 
            this.outputlabel.AutoSize = true;
            this.outputlabel.Location = new System.Drawing.Point(6, 49);
            this.outputlabel.Name = "outputlabel";
            this.outputlabel.Size = new System.Drawing.Size(67, 13);
            this.outputlabel.TabIndex = 68;
            this.outputlabel.Text = "Output Path:";
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(79, 46);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(320, 20);
            this.output.TabIndex = 2;
            this.output.TextChanged += new System.EventHandler(this.updstat);
            // 
            // openbtn
            // 
            this.openbtn.Location = new System.Drawing.Point(405, 17);
            this.openbtn.Name = "openbtn";
            this.openbtn.Size = new System.Drawing.Size(108, 23);
            this.openbtn.TabIndex = 1;
            this.openbtn.Text = "Open";
            this.openbtn.UseVisualStyleBackColor = true;
            this.openbtn.Click += new System.EventHandler(this.OpenbtnClick);
            // 
            // source
            // 
            this.source.Location = new System.Drawing.Point(79, 19);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(320, 20);
            this.source.TabIndex = 0;
            this.source.TextChanged += new System.EventHandler(this.source_TextChanged);
            // 
            // kernelver
            // 
            this.kernelver.Controls.Add(this.customkernellabel);
            this.kernelver.Controls.Add(this.ckernel);
            this.kernelver.Controls.Add(this.kernel);
            this.kernelver.Location = new System.Drawing.Point(4, 348);
            this.kernelver.Name = "kernelver";
            this.kernelver.Size = new System.Drawing.Size(518, 46);
            this.kernelver.TabIndex = 4;
            this.kernelver.TabStop = false;
            this.kernelver.Text = "Kernel version";
            // 
            // customkernellabel
            // 
            this.customkernellabel.AutoSize = true;
            this.customkernellabel.Location = new System.Drawing.Point(99, 22);
            this.customkernellabel.Name = "customkernellabel";
            this.customkernellabel.Size = new System.Drawing.Size(115, 13);
            this.customkernellabel.TabIndex = 29;
            this.customkernellabel.Text = "Custom Kernel version:";
            // 
            // ckernel
            // 
            this.ckernel.Location = new System.Drawing.Point(220, 19);
            this.ckernel.Name = "ckernel";
            this.ckernel.Size = new System.Drawing.Size(100, 20);
            this.ckernel.TabIndex = 1;
            this.ckernel.TextChanged += new System.EventHandler(this.ckernel_TextChanged);
            this.ckernel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctrlfix);
            this.ckernel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numeric);
            // 
            // kernel
            // 
            this.kernel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kernel.FormattingEnabled = true;
            this.kernel.Items.AddRange(new object[] {
            "Custom",
            "2.0.14699.0"});
            this.kernel.Location = new System.Drawing.Point(6, 19);
            this.kernel.Name = "kernel";
            this.kernel.Size = new System.Drawing.Size(84, 21);
            this.kernel.TabIndex = 0;
            this.kernel.SelectedIndexChanged += new System.EventHandler(this.kernelchange);
            // 
            // genbtn
            // 
            this.genbtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.genbtn.Enabled = false;
            this.genbtn.Location = new System.Drawing.Point(4, 516);
            this.genbtn.Margin = new System.Windows.Forms.Padding(0);
            this.genbtn.Name = "genbtn";
            this.genbtn.Size = new System.Drawing.Size(521, 54);
            this.genbtn.TabIndex = 7;
            this.genbtn.Text = "Generate hacked image";
            this.genbtn.UseVisualStyleBackColor = true;
            this.genbtn.Click += new System.EventHandler(this.genbtn_Click);
            // 
            // openkeystxt
            // 
            this.openkeystxt.AddExtension = false;
            this.openkeystxt.FileName = "keys.txt";
            this.openkeystxt.Filter = "Key textfile|*.txt|All Files|*.*";
            this.openkeystxt.Title = "Open Keys.txt or cpukey.txt (File cntaining etheir just the cpukey or first line " +
    "with cpukey and the actual key)";
            // 
            // openfusetxt
            // 
            this.openfusetxt.AddExtension = false;
            this.openfusetxt.FileName = "FUSE.txt";
            this.openfusetxt.Filter = "FUSE Textfile|*.txt|All Files|*.*";
            this.openfusetxt.Title = "Open File containing your consoles Fusesets";
            // 
            // opennand
            // 
            this.opennand.FileName = "flashdmp.bin";
            this.opennand.Filter = "Xbox 360 NAND files|*.bin|All Files|*.*";
            this.opennand.Title = "Open your Xbox 360 NAND dump";
            // 
            // savebin
            // 
            this.savebin.DefaultExt = "bin";
            this.savebin.FileName = "updflash.bin";
            this.savebin.Filter = "Xbox 360 NAND files|*.bin|Xbox 360 ECC image|*.ecc|All Files|*.*";
            this.savebin.Title = "Select where to save your output image";
            // 
            // saveecc
            // 
            this.saveecc.DefaultExt = "ecc";
            this.saveecc.FileName = "image_00000000.ecc";
            this.saveecc.Filter = "Xbox 360 NAND files|*.bin|Xbox 360 ECC image|*.ecc|All Files|*.*";
            this.saveecc.FilterIndex = 2;
            this.saveecc.Title = "Select where to save your output image";
            // 
            // corona4g
            // 
            this.corona4g.AutoSize = true;
            this.corona4g.Location = new System.Drawing.Point(232, 42);
            this.corona4g.Name = "corona4g";
            this.corona4g.Size = new System.Drawing.Size(71, 17);
            this.corona4g.TabIndex = 9;
            this.corona4g.TabStop = true;
            this.corona4g.Text = "Corona4g";
            this.corona4g.UseVisualStyleBackColor = true;
            this.corona4g.CheckedChanged += new System.EventHandler(this.trinity_CheckedChanged);
            // 
            // Static
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.genbtn);
            this.Controls.Add(this.kernelver);
            this.Controls.Add(this.paths);
            this.Controls.Add(this.keys);
            this.Controls.Add(this.imgtype);
            this.Controls.Add(this.mobo);
            this.Controls.Add(this.smc);
            this.Controls.Add(this.xellver);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Static";
            this.Padding = new System.Windows.Forms.Padding(4, 10, 0, 0);
            this.Size = new System.Drawing.Size(525, 570);
            this.Load += new System.EventHandler(this.StaticLoad);
            this.keys.ResumeLayout(false);
            this.keys.PerformLayout();
            this.imgtype.ResumeLayout(false);
            this.imgtype.PerformLayout();
            this.mobo.ResumeLayout(false);
            this.mobo.PerformLayout();
            this.smc.ResumeLayout(false);
            this.smc.PerformLayout();
            this.xellver.ResumeLayout(false);
            this.xellver.PerformLayout();
            this.paths.ResumeLayout(false);
            this.paths.PerformLayout();
            this.kernelver.ResumeLayout(false);
            this.kernelver.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RadioButton ecc;
        public System.Windows.Forms.GroupBox keys;
        public System.Windows.Forms.Label cpukeylabel;
        public System.Windows.Forms.Label blkeylabel;
        public System.Windows.Forms.TextBox blkey;
        public System.Windows.Forms.TextBox cpukey;
        public System.Windows.Forms.GroupBox imgtype;
        public System.Windows.Forms.RadioButton devkit;
        public System.Windows.Forms.RadioButton retail;
        public System.Windows.Forms.RadioButton glitch;
        public System.Windows.Forms.RadioButton jtag;
        public System.Windows.Forms.GroupBox mobo;
        public System.Windows.Forms.RadioButton jasperbigffs;
        public System.Windows.Forms.RadioButton trinity;
        public System.Windows.Forms.RadioButton jasper;
        public System.Windows.Forms.RadioButton zephyr;
        public System.Windows.Forms.RadioButton jaspersb;
        public System.Windows.Forms.RadioButton falcon;
        public System.Windows.Forms.RadioButton xenon;
        public System.Windows.Forms.GroupBox smc;
        public System.Windows.Forms.RadioButton aud_clamp2;
        public System.Windows.Forms.RadioButton cygnos2;
        public System.Windows.Forms.RadioButton cygnos;
        public System.Windows.Forms.RadioButton customsmc;
        public System.Windows.Forms.RadioButton aud_clamp;
        public System.Windows.Forms.RadioButton normal;
        public System.Windows.Forms.GroupBox xellver;
        public System.Windows.Forms.RadioButton customxell;
        public System.Windows.Forms.RadioButton xellreloaded;
        public System.Windows.Forms.RadioButton xellous;
        public System.Windows.Forms.RadioButton xell;
        public System.Windows.Forms.GroupBox paths;
        public System.Windows.Forms.Label sourcelabel;
        public System.Windows.Forms.Button savebtn;
        public System.Windows.Forms.Label outputlabel;
        public System.Windows.Forms.TextBox output;
        public System.Windows.Forms.Button openbtn;
        public System.Windows.Forms.TextBox source;
        public System.Windows.Forms.GroupBox kernelver;
        public System.Windows.Forms.ComboBox kernel;
        public System.Windows.Forms.Button genbtn;
        public System.Windows.Forms.Label customkernellabel;
        public System.Windows.Forms.TextBox ckernel;
        private System.Windows.Forms.Button getkey_cpukeytxtbtn;
        private System.Windows.Forms.Button getkey_fusestxtbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getkey_networkbtn;
        private System.Windows.Forms.Button getipbtn;
        private System.Windows.Forms.OpenFileDialog openkeystxt;
        private System.Windows.Forms.OpenFileDialog openfusetxt;
        private System.Windows.Forms.OpenFileDialog opennand;
        private System.Windows.Forms.SaveFileDialog savebin;
        private System.Windows.Forms.SaveFileDialog saveecc;
        public System.Windows.Forms.TextBox xellip;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox eccname;
        public System.Windows.Forms.TextBox binname;
        public System.Windows.Forms.RadioButton currentsmc;
        public System.Windows.Forms.RadioButton glitch2;
        public System.Windows.Forms.RadioButton ecc2;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.RadioButton jasperbb;
        public System.Windows.Forms.RadioButton corona;
        public System.Windows.Forms.RadioButton corona4g;
    }
}
