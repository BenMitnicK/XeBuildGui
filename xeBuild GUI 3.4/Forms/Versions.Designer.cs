namespace xeBuild_GUI
{
    partial class Versions
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Versions));
            this.reloadbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nandfile = new System.Windows.Forms.TextBox();
            this.selectnandbtn = new System.Windows.Forms.Button();
            this.loadnand = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cf0offset = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cf1offset = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.slots = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cf1_pairingbox = new System.Windows.Forms.TextBox();
            this.cf0_pairingbox = new System.Windows.Forms.TextBox();
            this.cbb_pairingbox = new System.Windows.Forms.TextBox();
            this.cba_pairingbox = new System.Windows.Forms.TextBox();
            this.cf1_ldvbox = new System.Windows.Forms.TextBox();
            this.cf0_ldvbox = new System.Windows.Forms.TextBox();
            this.cbb_ldvbox = new System.Windows.Forms.TextBox();
            this.cba_ldvbox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbb_ldvlbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cba_ldvlbl = new System.Windows.Forms.Label();
            this.cg1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cf1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ce = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cg0 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cf0 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_b = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_a = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkbtn = new System.Windows.Forms.Button();
            this.moboinfo = new System.Windows.Forms.GroupBox();
            this.smcv = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.mobo = new System.Windows.Forms.TextBox();
            this.smct = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.tdi = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.tms = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.blkey = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cpukey = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.moboinfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // reloadbtn
            // 
            this.reloadbtn.Location = new System.Drawing.Point(12, 68);
            this.reloadbtn.Name = "reloadbtn";
            this.reloadbtn.Size = new System.Drawing.Size(240, 23);
            this.reloadbtn.TabIndex = 0;
            this.reloadbtn.Text = "Get Source/Keys from Main window";
            this.reloadbtn.UseVisualStyleBackColor = true;
            this.reloadbtn.Click += new System.EventHandler(this.reloadbtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.nandfile);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 50);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Check versions from file";
            // 
            // nandfile
            // 
            this.nandfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nandfile.Location = new System.Drawing.Point(6, 19);
            this.nandfile.MaxLength = 32;
            this.nandfile.Name = "nandfile";
            this.nandfile.Size = new System.Drawing.Size(474, 20);
            this.nandfile.TabIndex = 2;
            this.nandfile.TextChanged += new System.EventHandler(this.nandfile_TextChanged);
            // 
            // selectnandbtn
            // 
            this.selectnandbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectnandbtn.Location = new System.Drawing.Point(258, 68);
            this.selectnandbtn.Name = "selectnandbtn";
            this.selectnandbtn.Size = new System.Drawing.Size(240, 23);
            this.selectnandbtn.TabIndex = 4;
            this.selectnandbtn.Text = "Select nand to check";
            this.selectnandbtn.UseVisualStyleBackColor = true;
            this.selectnandbtn.Click += new System.EventHandler(this.selectnandbtn_Click);
            // 
            // loadnand
            // 
            this.loadnand.DefaultExt = "bin";
            this.loadnand.FileName = "nand.bin";
            this.loadnand.Filter = "Xbox 360 NAND File|*.bin|All Files|*.*";
            this.loadnand.Title = "Select nand file to check versions from";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cf0offset);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cf1offset);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.slots);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cf1_pairingbox);
            this.groupBox1.Controls.Add(this.cf0_pairingbox);
            this.groupBox1.Controls.Add(this.cbb_pairingbox);
            this.groupBox1.Controls.Add(this.cba_pairingbox);
            this.groupBox1.Controls.Add(this.cf1_ldvbox);
            this.groupBox1.Controls.Add(this.cf0_ldvbox);
            this.groupBox1.Controls.Add(this.cbb_ldvbox);
            this.groupBox1.Controls.Add(this.cba_ldvbox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbb_ldvlbl);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cba_ldvlbl);
            this.groupBox1.Controls.Add(this.cg1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cf1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ce);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cg0);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cf0);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_b);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_a);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 227);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bootloaders";
            // 
            // cf0offset
            // 
            this.cf0offset.Location = new System.Drawing.Point(301, 175);
            this.cf0offset.Name = "cf0offset";
            this.cf0offset.ReadOnly = true;
            this.cf0offset.Size = new System.Drawing.Size(73, 20);
            this.cf0offset.TabIndex = 72;
            this.cf0offset.Text = "N/A";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(205, 204);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 13);
            this.label17.TabIndex = 71;
            this.label17.Text = "CF Offset (Slot 1):";
            // 
            // cf1offset
            // 
            this.cf1offset.Location = new System.Drawing.Point(301, 201);
            this.cf1offset.Name = "cf1offset";
            this.cf1offset.ReadOnly = true;
            this.cf1offset.Size = new System.Drawing.Size(73, 20);
            this.cf1offset.TabIndex = 70;
            this.cf1offset.Text = "N/A";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(205, 178);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 69;
            this.label16.Text = "CF Offset (Slot 0):";
            // 
            // slots
            // 
            this.slots.Location = new System.Drawing.Point(75, 201);
            this.slots.Name = "slots";
            this.slots.ReadOnly = true;
            this.slots.Size = new System.Drawing.Size(36, 20);
            this.slots.TabIndex = 68;
            this.slots.Text = "N/A";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 204);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 67;
            this.label15.Text = "Patch Slots:";
            // 
            // cf1_pairingbox
            // 
            this.cf1_pairingbox.Location = new System.Drawing.Point(301, 149);
            this.cf1_pairingbox.Name = "cf1_pairingbox";
            this.cf1_pairingbox.ReadOnly = true;
            this.cf1_pairingbox.Size = new System.Drawing.Size(73, 20);
            this.cf1_pairingbox.TabIndex = 66;
            this.cf1_pairingbox.Text = "N/A";
            // 
            // cf0_pairingbox
            // 
            this.cf0_pairingbox.Location = new System.Drawing.Point(301, 97);
            this.cf0_pairingbox.Name = "cf0_pairingbox";
            this.cf0_pairingbox.ReadOnly = true;
            this.cf0_pairingbox.Size = new System.Drawing.Size(73, 20);
            this.cf0_pairingbox.TabIndex = 66;
            this.cf0_pairingbox.Text = "N/A";
            // 
            // cbb_pairingbox
            // 
            this.cbb_pairingbox.Location = new System.Drawing.Point(301, 45);
            this.cbb_pairingbox.Name = "cbb_pairingbox";
            this.cbb_pairingbox.ReadOnly = true;
            this.cbb_pairingbox.Size = new System.Drawing.Size(73, 20);
            this.cbb_pairingbox.TabIndex = 66;
            this.cbb_pairingbox.Text = "N/A";
            // 
            // cba_pairingbox
            // 
            this.cba_pairingbox.Location = new System.Drawing.Point(301, 19);
            this.cba_pairingbox.Name = "cba_pairingbox";
            this.cba_pairingbox.ReadOnly = true;
            this.cba_pairingbox.Size = new System.Drawing.Size(73, 20);
            this.cba_pairingbox.TabIndex = 66;
            this.cba_pairingbox.Text = "N/A";
            // 
            // cf1_ldvbox
            // 
            this.cf1_ldvbox.Location = new System.Drawing.Point(191, 149);
            this.cf1_ldvbox.Name = "cf1_ldvbox";
            this.cf1_ldvbox.ReadOnly = true;
            this.cf1_ldvbox.Size = new System.Drawing.Size(32, 20);
            this.cf1_ldvbox.TabIndex = 65;
            this.cf1_ldvbox.Text = "N/A";
            // 
            // cf0_ldvbox
            // 
            this.cf0_ldvbox.Location = new System.Drawing.Point(191, 97);
            this.cf0_ldvbox.Name = "cf0_ldvbox";
            this.cf0_ldvbox.ReadOnly = true;
            this.cf0_ldvbox.Size = new System.Drawing.Size(32, 20);
            this.cf0_ldvbox.TabIndex = 64;
            this.cf0_ldvbox.Text = "N/A";
            // 
            // cbb_ldvbox
            // 
            this.cbb_ldvbox.Location = new System.Drawing.Point(191, 45);
            this.cbb_ldvbox.Name = "cbb_ldvbox";
            this.cbb_ldvbox.ReadOnly = true;
            this.cbb_ldvbox.Size = new System.Drawing.Size(32, 20);
            this.cbb_ldvbox.TabIndex = 63;
            this.cbb_ldvbox.Text = "N/A";
            // 
            // cba_ldvbox
            // 
            this.cba_ldvbox.Location = new System.Drawing.Point(191, 19);
            this.cba_ldvbox.Name = "cba_ldvbox";
            this.cba_ldvbox.ReadOnly = true;
            this.cba_ldvbox.Size = new System.Drawing.Size(32, 20);
            this.cba_ldvbox.TabIndex = 62;
            this.cba_ldvbox.Text = "N/A";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(229, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 61;
            this.label14.Text = "Pairing data:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(154, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "LDV:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(229, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Pairing data:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(154, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "LDV:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Pairing data:";
            // 
            // cbb_ldvlbl
            // 
            this.cbb_ldvlbl.AutoSize = true;
            this.cbb_ldvlbl.Location = new System.Drawing.Point(154, 48);
            this.cbb_ldvlbl.Name = "cbb_ldvlbl";
            this.cbb_ldvlbl.Size = new System.Drawing.Size(31, 13);
            this.cbb_ldvlbl.TabIndex = 59;
            this.cbb_ldvlbl.Text = "LDV:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Pairing data:";
            // 
            // cba_ldvlbl
            // 
            this.cba_ldvlbl.AutoSize = true;
            this.cba_ldvlbl.Location = new System.Drawing.Point(154, 22);
            this.cba_ldvlbl.Name = "cba_ldvlbl";
            this.cba_ldvlbl.Size = new System.Drawing.Size(31, 13);
            this.cba_ldvlbl.TabIndex = 58;
            this.cba_ldvlbl.Text = "LDV:";
            // 
            // cg1
            // 
            this.cg1.Location = new System.Drawing.Point(75, 175);
            this.cg1.Name = "cg1";
            this.cg1.ReadOnly = true;
            this.cg1.Size = new System.Drawing.Size(73, 20);
            this.cg1.TabIndex = 15;
            this.cg1.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "CG (Slot 1):";
            // 
            // cf1
            // 
            this.cf1.Location = new System.Drawing.Point(75, 149);
            this.cf1.Name = "cf1";
            this.cf1.ReadOnly = true;
            this.cf1.Size = new System.Drawing.Size(73, 20);
            this.cf1.TabIndex = 13;
            this.cf1.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "CF (Slot 1):";
            // 
            // ce
            // 
            this.ce.Location = new System.Drawing.Point(191, 71);
            this.ce.Name = "ce";
            this.ce.ReadOnly = true;
            this.ce.Size = new System.Drawing.Size(73, 20);
            this.ce.TabIndex = 11;
            this.ce.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "CE:";
            // 
            // cg0
            // 
            this.cg0.Location = new System.Drawing.Point(75, 123);
            this.cg0.Name = "cg0";
            this.cg0.ReadOnly = true;
            this.cg0.Size = new System.Drawing.Size(73, 20);
            this.cg0.TabIndex = 9;
            this.cg0.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "CG (Slot 0):";
            // 
            // cf0
            // 
            this.cf0.Location = new System.Drawing.Point(75, 97);
            this.cf0.Name = "cf0";
            this.cf0.ReadOnly = true;
            this.cf0.Size = new System.Drawing.Size(73, 20);
            this.cf0.TabIndex = 7;
            this.cf0.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "CF (Slot 0):";
            // 
            // cd
            // 
            this.cd.Location = new System.Drawing.Point(75, 71);
            this.cd.Name = "cd";
            this.cd.ReadOnly = true;
            this.cd.Size = new System.Drawing.Size(73, 20);
            this.cd.TabIndex = 5;
            this.cd.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CD:";
            // 
            // cb_b
            // 
            this.cb_b.Location = new System.Drawing.Point(75, 45);
            this.cb_b.Name = "cb_b";
            this.cb_b.ReadOnly = true;
            this.cb_b.Size = new System.Drawing.Size(73, 20);
            this.cb_b.TabIndex = 3;
            this.cb_b.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CB (CB_B):";
            // 
            // cb_a
            // 
            this.cb_a.Location = new System.Drawing.Point(75, 19);
            this.cb_a.Name = "cb_a";
            this.cb_a.ReadOnly = true;
            this.cb_a.Size = new System.Drawing.Size(73, 20);
            this.cb_a.TabIndex = 1;
            this.cb_a.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CB (CB_A):";
            // 
            // checkbtn
            // 
            this.checkbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkbtn.Enabled = false;
            this.checkbtn.Location = new System.Drawing.Point(12, 463);
            this.checkbtn.Name = "checkbtn";
            this.checkbtn.Size = new System.Drawing.Size(486, 23);
            this.checkbtn.TabIndex = 12;
            this.checkbtn.Text = "Check/Update Versions";
            this.checkbtn.UseVisualStyleBackColor = true;
            this.checkbtn.Click += new System.EventHandler(this.checkbtn_Click);
            // 
            // moboinfo
            // 
            this.moboinfo.Controls.Add(this.smcv);
            this.moboinfo.Controls.Add(this.label20);
            this.moboinfo.Controls.Add(this.label56);
            this.moboinfo.Controls.Add(this.mobo);
            this.moboinfo.Controls.Add(this.smct);
            this.moboinfo.Controls.Add(this.label58);
            this.moboinfo.Controls.Add(this.label60);
            this.moboinfo.Controls.Add(this.tdi);
            this.moboinfo.Controls.Add(this.label59);
            this.moboinfo.Controls.Add(this.tms);
            this.moboinfo.Location = new System.Drawing.Point(12, 386);
            this.moboinfo.Name = "moboinfo";
            this.moboinfo.Size = new System.Drawing.Size(486, 71);
            this.moboinfo.TabIndex = 57;
            this.moboinfo.TabStop = false;
            this.moboinfo.Text = "Motherboard information";
            // 
            // smcv
            // 
            this.smcv.Location = new System.Drawing.Point(322, 45);
            this.smcv.Name = "smcv";
            this.smcv.ReadOnly = true;
            this.smcv.Size = new System.Drawing.Size(42, 20);
            this.smcv.TabIndex = 11;
            this.smcv.Text = "N/A";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 13);
            this.label20.TabIndex = 52;
            this.label20.Text = "Suggested motherboard:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(259, 48);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(57, 13);
            this.label56.TabIndex = 10;
            this.label56.Text = "SMC Vers:";
            // 
            // mobo
            // 
            this.mobo.Location = new System.Drawing.Point(135, 19);
            this.mobo.Name = "mobo";
            this.mobo.ReadOnly = true;
            this.mobo.Size = new System.Drawing.Size(229, 20);
            this.mobo.TabIndex = 49;
            this.mobo.Text = "N/A";
            // 
            // smct
            // 
            this.smct.Location = new System.Drawing.Point(135, 45);
            this.smct.Name = "smct";
            this.smct.ReadOnly = true;
            this.smct.Size = new System.Drawing.Size(118, 20);
            this.smct.TabIndex = 7;
            this.smct.Text = "N/A";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(69, 48);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(60, 13);
            this.label58.TabIndex = 6;
            this.label58.Text = "SMC Type:";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(365, 22);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(64, 13);
            this.label60.TabIndex = 0;
            this.label60.Text = "TMS Patch:";
            // 
            // tdi
            // 
            this.tdi.Location = new System.Drawing.Point(435, 45);
            this.tdi.Name = "tdi";
            this.tdi.ReadOnly = true;
            this.tdi.Size = new System.Drawing.Size(42, 20);
            this.tdi.TabIndex = 3;
            this.tdi.Text = "N/A";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(370, 48);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(59, 13);
            this.label59.TabIndex = 1;
            this.label59.Text = "TDI Patch:";
            // 
            // tms
            // 
            this.tms.Location = new System.Drawing.Point(435, 19);
            this.tms.Name = "tms";
            this.tms.ReadOnly = true;
            this.tms.Size = new System.Drawing.Size(42, 20);
            this.tms.TabIndex = 2;
            this.tms.Text = "N/A";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.blkey);
            this.groupBox3.Location = new System.Drawing.Point(258, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 50);
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "1BLKey";
            // 
            // blkey
            // 
            this.blkey.Location = new System.Drawing.Point(10, 19);
            this.blkey.MaxLength = 32;
            this.blkey.Name = "blkey";
            this.blkey.Size = new System.Drawing.Size(221, 20);
            this.blkey.TabIndex = 2;
            this.blkey.Text = "DD88AD0C9ED669E7B56794FB68563EFA";
            this.blkey.TextChanged += new System.EventHandler(this.blkey_TextChanged);
            this.blkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hexinput);
            this.blkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ctrlfix);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cpukey);
            this.groupBox4.Location = new System.Drawing.Point(12, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 50);
            this.groupBox4.TabIndex = 73;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CPUKey";
            // 
            // cpukey
            // 
            this.cpukey.Location = new System.Drawing.Point(10, 19);
            this.cpukey.MaxLength = 32;
            this.cpukey.Name = "cpukey";
            this.cpukey.Size = new System.Drawing.Size(221, 20);
            this.cpukey.TabIndex = 2;
            this.cpukey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hexinput);
            this.cpukey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ctrlfix);
            // 
            // Versions
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(510, 498);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.moboinfo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.checkbtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.selectnandbtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.reloadbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Versions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xeBuild GUI Versions";
            this.Load += new System.EventHandler(this.Versions_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Versions_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Versions_DragEnter);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.moboinfo.ResumeLayout(false);
            this.moboinfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reloadbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox nandfile;
        private System.Windows.Forms.Button selectnandbtn;
        private System.Windows.Forms.OpenFileDialog loadnand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox cb_b;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cb_a;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ce;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cg0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cf0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button checkbtn;
        public System.Windows.Forms.GroupBox moboinfo;
        public System.Windows.Forms.TextBox smcv;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label56;
        public System.Windows.Forms.TextBox mobo;
        public System.Windows.Forms.TextBox smct;
        public System.Windows.Forms.Label label58;
        public System.Windows.Forms.Label label60;
        public System.Windows.Forms.TextBox tdi;
        public System.Windows.Forms.Label label59;
        public System.Windows.Forms.TextBox tms;
        private System.Windows.Forms.TextBox cg1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cf1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label cbb_ldvlbl;
        private System.Windows.Forms.Label cba_ldvlbl;
        private System.Windows.Forms.TextBox cf1_ldvbox;
        private System.Windows.Forms.TextBox cf0_ldvbox;
        private System.Windows.Forms.TextBox cbb_ldvbox;
        private System.Windows.Forms.TextBox cba_ldvbox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cf1_pairingbox;
        private System.Windows.Forms.TextBox cf0_pairingbox;
        private System.Windows.Forms.TextBox cbb_pairingbox;
        private System.Windows.Forms.TextBox cba_pairingbox;
        private System.Windows.Forms.TextBox slots;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox cf1offset;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox cf0offset;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox blkey;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.TextBox cpukey;

    }
}

