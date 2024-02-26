namespace xeBuild_GUI
{
    partial class Nandpro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nandpro));
            this.outbox = new System.Windows.Forms.RichTextBox();
            this.logbox = new System.Windows.Forms.GroupBox();
            this.nandop = new System.Windows.Forms.GroupBox();
            this.comparebtn = new System.Windows.Forms.Button();
            this.ecctobinbtn = new System.Windows.Forms.Button();
            this.remapbtn = new System.Windows.Forms.Button();
            this.toblock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromblock = new System.Windows.Forms.TextBox();
            this.selectbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.worknand = new System.Windows.Forms.TextBox();
            this.sizebox = new System.Windows.Forms.GroupBox();
            this.s512 = new System.Windows.Forms.RadioButton();
            this.s256 = new System.Windows.Forms.RadioButton();
            this.s64 = new System.Windows.Forms.RadioButton();
            this.s16 = new System.Windows.Forms.RadioButton();
            this.s2 = new System.Windows.Forms.RadioButton();
            this.s1 = new System.Windows.Forms.RadioButton();
            this.hwop = new System.Windows.Forms.GroupBox();
            this.dumptimes = new System.Windows.Forms.ComboBox();
            this.flashcpldbtn = new System.Windows.Forms.Button();
            this.dunplabel = new System.Windows.Forms.Label();
            this.writenandbtn = new System.Windows.Forms.Button();
            this.writeeccbtn = new System.Windows.Forms.Button();
            this.erasebtn = new System.Windows.Forms.Button();
            this.dumpbtn = new System.Windows.Forms.Button();
            this.flashconfigbox = new System.Windows.Forms.GroupBox();
            this.flashconfig = new System.Windows.Forms.TextBox();
            this.selectnand = new System.Windows.Forms.OpenFileDialog();
            this.opencpld = new System.Windows.Forms.OpenFileDialog();
            this.openecc = new System.Windows.Forms.OpenFileDialog();
            this.savenand = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.currstatlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.logcontrols = new System.Windows.Forms.GroupBox();
            this.savelogbtn = new System.Windows.Forms.Button();
            this.clrbtn = new System.Windows.Forms.Button();
            this.savelog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runninglbl = new System.Windows.Forms.Label();
            this.nandproact = new LoadingCircle();
            this.logbox.SuspendLayout();
            this.nandop.SuspendLayout();
            this.sizebox.SuspendLayout();
            this.hwop.SuspendLayout();
            this.flashconfigbox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.logcontrols.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outbox
            // 
            this.outbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.outbox.Location = new System.Drawing.Point(6, 16);
            this.outbox.Name = "outbox";
            this.outbox.ReadOnly = true;
            this.outbox.Size = new System.Drawing.Size(340, 205);
            this.outbox.TabIndex = 0;
            this.outbox.Text = "";
            this.outbox.TextChanged += new System.EventHandler(this.outbox_TextChanged);
            // 
            // logbox
            // 
            this.logbox.Controls.Add(this.outbox);
            this.logbox.Location = new System.Drawing.Point(12, 27);
            this.logbox.Name = "logbox";
            this.logbox.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.logbox.Size = new System.Drawing.Size(352, 227);
            this.logbox.TabIndex = 1;
            this.logbox.TabStop = false;
            this.logbox.Text = "Nandpro Log";
            // 
            // nandop
            // 
            this.nandop.Controls.Add(this.comparebtn);
            this.nandop.Controls.Add(this.ecctobinbtn);
            this.nandop.Controls.Add(this.remapbtn);
            this.nandop.Controls.Add(this.toblock);
            this.nandop.Controls.Add(this.label3);
            this.nandop.Controls.Add(this.label2);
            this.nandop.Controls.Add(this.fromblock);
            this.nandop.Controls.Add(this.selectbtn);
            this.nandop.Controls.Add(this.label1);
            this.nandop.Controls.Add(this.worknand);
            this.nandop.Location = new System.Drawing.Point(370, 149);
            this.nandop.Name = "nandop";
            this.nandop.Size = new System.Drawing.Size(373, 105);
            this.nandop.TabIndex = 0;
            this.nandop.TabStop = false;
            this.nandop.Text = "NAND File Operations";
            // 
            // comparebtn
            // 
            this.comparebtn.Location = new System.Drawing.Point(9, 76);
            this.comparebtn.Name = "comparebtn";
            this.comparebtn.Size = new System.Drawing.Size(178, 23);
            this.comparebtn.TabIndex = 5;
            this.comparebtn.Text = "Compare NANDs";
            this.comparebtn.UseVisualStyleBackColor = true;
            this.comparebtn.Click += new System.EventHandler(this.comparebtn_Click);
            // 
            // ecctobinbtn
            // 
            this.ecctobinbtn.Enabled = false;
            this.ecctobinbtn.Location = new System.Drawing.Point(190, 76);
            this.ecctobinbtn.Name = "ecctobinbtn";
            this.ecctobinbtn.Size = new System.Drawing.Size(177, 23);
            this.ecctobinbtn.TabIndex = 6;
            this.ecctobinbtn.Text = "Write ECC to image";
            this.ecctobinbtn.UseVisualStyleBackColor = true;
            this.ecctobinbtn.Click += new System.EventHandler(this.ecctobinbtn_Click);
            // 
            // remapbtn
            // 
            this.remapbtn.Enabled = false;
            this.remapbtn.Location = new System.Drawing.Point(298, 45);
            this.remapbtn.Name = "remapbtn";
            this.remapbtn.Size = new System.Drawing.Size(69, 23);
            this.remapbtn.TabIndex = 4;
            this.remapbtn.Text = "Remap";
            this.remapbtn.UseVisualStyleBackColor = true;
            this.remapbtn.Click += new System.EventHandler(this.remapbtn_Click);
            // 
            // toblock
            // 
            this.toblock.Location = new System.Drawing.Point(242, 45);
            this.toblock.Name = "toblock";
            this.toblock.Size = new System.Drawing.Size(50, 20);
            this.toblock.TabIndex = 3;
            this.toblock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctrlfix);
            this.toblock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hexin);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Remap to block:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Block to remap:";
            // 
            // fromblock
            // 
            this.fromblock.Location = new System.Drawing.Point(98, 45);
            this.fromblock.Name = "fromblock";
            this.fromblock.Size = new System.Drawing.Size(50, 20);
            this.fromblock.TabIndex = 2;
            this.fromblock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctrlfix);
            this.fromblock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hexin);
            // 
            // selectbtn
            // 
            this.selectbtn.Location = new System.Drawing.Point(298, 16);
            this.selectbtn.Name = "selectbtn";
            this.selectbtn.Size = new System.Drawing.Size(69, 23);
            this.selectbtn.TabIndex = 1;
            this.selectbtn.Text = "Select";
            this.selectbtn.UseVisualStyleBackColor = true;
            this.selectbtn.Click += new System.EventHandler(this.selectbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File to work with:";
            // 
            // worknand
            // 
            this.worknand.Location = new System.Drawing.Point(98, 19);
            this.worknand.Name = "worknand";
            this.worknand.Size = new System.Drawing.Size(194, 20);
            this.worknand.TabIndex = 0;
            this.worknand.TextChanged += new System.EventHandler(this.worknand_TextChanged);
            // 
            // sizebox
            // 
            this.sizebox.Controls.Add(this.s512);
            this.sizebox.Controls.Add(this.s256);
            this.sizebox.Controls.Add(this.s64);
            this.sizebox.Controls.Add(this.s16);
            this.sizebox.Controls.Add(this.s2);
            this.sizebox.Controls.Add(this.s1);
            this.sizebox.Location = new System.Drawing.Point(560, 27);
            this.sizebox.Name = "sizebox";
            this.sizebox.Size = new System.Drawing.Size(183, 65);
            this.sizebox.TabIndex = 3;
            this.sizebox.TabStop = false;
            this.sizebox.Text = "Dump Size";
            // 
            // s512
            // 
            this.s512.AutoSize = true;
            this.s512.Location = new System.Drawing.Point(118, 42);
            this.s512.Name = "s512";
            this.s512.Size = new System.Drawing.Size(59, 17);
            this.s512.TabIndex = 5;
            this.s512.Text = "512MB";
            this.s512.UseVisualStyleBackColor = true;
            // 
            // s256
            // 
            this.s256.AutoSize = true;
            this.s256.Location = new System.Drawing.Point(118, 19);
            this.s256.Name = "s256";
            this.s256.Size = new System.Drawing.Size(59, 17);
            this.s256.TabIndex = 4;
            this.s256.Text = "256MB";
            this.s256.UseVisualStyleBackColor = true;
            // 
            // s64
            // 
            this.s64.AutoSize = true;
            this.s64.Location = new System.Drawing.Point(59, 42);
            this.s64.Name = "s64";
            this.s64.Size = new System.Drawing.Size(53, 17);
            this.s64.TabIndex = 3;
            this.s64.Text = "64MB";
            this.s64.UseVisualStyleBackColor = true;
            // 
            // s16
            // 
            this.s16.AutoSize = true;
            this.s16.Location = new System.Drawing.Point(59, 19);
            this.s16.Name = "s16";
            this.s16.Size = new System.Drawing.Size(53, 17);
            this.s16.TabIndex = 2;
            this.s16.Text = "16MB";
            this.s16.UseVisualStyleBackColor = true;
            // 
            // s2
            // 
            this.s2.AutoSize = true;
            this.s2.Checked = true;
            this.s2.Location = new System.Drawing.Point(6, 42);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(50, 17);
            this.s2.TabIndex = 1;
            this.s2.TabStop = true;
            this.s2.Text = "2 MB";
            this.s2.UseVisualStyleBackColor = true;
            // 
            // s1
            // 
            this.s1.AutoSize = true;
            this.s1.Location = new System.Drawing.Point(6, 19);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(47, 17);
            this.s1.TabIndex = 0;
            this.s1.Text = "1MB";
            this.s1.UseVisualStyleBackColor = true;
            // 
            // hwop
            // 
            this.hwop.Controls.Add(this.dumptimes);
            this.hwop.Controls.Add(this.flashcpldbtn);
            this.hwop.Controls.Add(this.dunplabel);
            this.hwop.Controls.Add(this.writenandbtn);
            this.hwop.Controls.Add(this.writeeccbtn);
            this.hwop.Controls.Add(this.erasebtn);
            this.hwop.Controls.Add(this.dumpbtn);
            this.hwop.Location = new System.Drawing.Point(12, 260);
            this.hwop.Name = "hwop";
            this.hwop.Size = new System.Drawing.Size(731, 52);
            this.hwop.TabIndex = 6;
            this.hwop.TabStop = false;
            this.hwop.Text = "Hardware Operations";
            // 
            // dumptimes
            // 
            this.dumptimes.FormattingEnabled = true;
            this.dumptimes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.dumptimes.Location = new System.Drawing.Point(264, 21);
            this.dumptimes.MaxDropDownItems = 4;
            this.dumptimes.Name = "dumptimes";
            this.dumptimes.Size = new System.Drawing.Size(29, 21);
            this.dumptimes.TabIndex = 6;
            this.dumptimes.Text = "3";
            // 
            // flashcpldbtn
            // 
            this.flashcpldbtn.Location = new System.Drawing.Point(299, 19);
            this.flashcpldbtn.Name = "flashcpldbtn";
            this.flashcpldbtn.Size = new System.Drawing.Size(86, 23);
            this.flashcpldbtn.TabIndex = 2;
            this.flashcpldbtn.Text = "Flash CPLD";
            this.flashcpldbtn.UseVisualStyleBackColor = true;
            this.flashcpldbtn.Click += new System.EventHandler(this.flashcpldbtn_Click);
            // 
            // dunplabel
            // 
            this.dunplabel.AutoSize = true;
            this.dunplabel.Location = new System.Drawing.Point(131, 24);
            this.dunplabel.Name = "dunplabel";
            this.dunplabel.Size = new System.Drawing.Size(127, 13);
            this.dunplabel.TabIndex = 5;
            this.dunplabel.Text = "Number of times to dump:";
            // 
            // writenandbtn
            // 
            this.writenandbtn.Location = new System.Drawing.Point(605, 19);
            this.writenandbtn.Name = "writenandbtn";
            this.writenandbtn.Size = new System.Drawing.Size(120, 23);
            this.writenandbtn.TabIndex = 5;
            this.writenandbtn.Text = "Write NAND Image";
            this.writenandbtn.UseVisualStyleBackColor = true;
            this.writenandbtn.Click += new System.EventHandler(this.writenandbtn_Click);
            // 
            // writeeccbtn
            // 
            this.writeeccbtn.Location = new System.Drawing.Point(491, 19);
            this.writeeccbtn.Name = "writeeccbtn";
            this.writeeccbtn.Size = new System.Drawing.Size(108, 23);
            this.writeeccbtn.TabIndex = 4;
            this.writeeccbtn.Text = "Write ECC Image";
            this.writeeccbtn.UseVisualStyleBackColor = true;
            this.writeeccbtn.Click += new System.EventHandler(this.writeeccbtn_Click);
            // 
            // erasebtn
            // 
            this.erasebtn.Location = new System.Drawing.Point(391, 19);
            this.erasebtn.Name = "erasebtn";
            this.erasebtn.Size = new System.Drawing.Size(94, 23);
            this.erasebtn.TabIndex = 3;
            this.erasebtn.Text = "Erase NAND";
            this.erasebtn.UseVisualStyleBackColor = true;
            this.erasebtn.Click += new System.EventHandler(this.erasebtn_Click);
            // 
            // dumpbtn
            // 
            this.dumpbtn.Location = new System.Drawing.Point(6, 19);
            this.dumpbtn.Name = "dumpbtn";
            this.dumpbtn.Size = new System.Drawing.Size(119, 23);
            this.dumpbtn.TabIndex = 0;
            this.dumpbtn.Text = "Dump/Read NAND";
            this.dumpbtn.UseVisualStyleBackColor = true;
            this.dumpbtn.Click += new System.EventHandler(this.dumpbtn_Click);
            // 
            // flashconfigbox
            // 
            this.flashconfigbox.Controls.Add(this.flashconfig);
            this.flashconfigbox.Location = new System.Drawing.Point(560, 98);
            this.flashconfigbox.Name = "flashconfigbox";
            this.flashconfigbox.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.flashconfigbox.Size = new System.Drawing.Size(183, 45);
            this.flashconfigbox.TabIndex = 1;
            this.flashconfigbox.TabStop = false;
            this.flashconfigbox.Text = "Flashconfig";
            // 
            // flashconfig
            // 
            this.flashconfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flashconfig.Location = new System.Drawing.Point(6, 16);
            this.flashconfig.Name = "flashconfig";
            this.flashconfig.ReadOnly = true;
            this.flashconfig.Size = new System.Drawing.Size(171, 20);
            this.flashconfig.TabIndex = 1;
            this.flashconfig.Text = "N/A";
            // 
            // selectnand
            // 
            this.selectnand.DefaultExt = "bin";
            this.selectnand.FileName = "nand.bin";
            this.selectnand.Filter = "Xbox 360 NAND File|*.bin|All Files|*.*";
            // 
            // opencpld
            // 
            this.opencpld.DefaultExt = "xsvf";
            this.opencpld.FileName = "motherboard.xsvf";
            this.opencpld.Filter = "Glitch chip program file|*.xsvf|All Files|*.*";
            // 
            // openecc
            // 
            this.openecc.DefaultExt = "ecc";
            this.openecc.FileName = "image_00000000.ecc";
            this.openecc.Filter = "ECC image file|*.ecc|All Files|*.*";
            // 
            // savenand
            // 
            this.savenand.DefaultExt = "bin";
            this.savenand.Filter = "Xbox 360 NAND File|*.bin|All Files|*.*";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currstatlabel,
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 320);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(752, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            // 
            // currstatlabel
            // 
            this.currstatlabel.Name = "currstatlabel";
            this.currstatlabel.Size = new System.Drawing.Size(84, 17);
            this.currstatlabel.Text = "Current status:";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(106, 17);
            this.status.Text = "Waiting for input...";
            // 
            // logcontrols
            // 
            this.logcontrols.Controls.Add(this.savelogbtn);
            this.logcontrols.Controls.Add(this.clrbtn);
            this.logcontrols.Location = new System.Drawing.Point(370, 27);
            this.logcontrols.Name = "logcontrols";
            this.logcontrols.Size = new System.Drawing.Size(184, 76);
            this.logcontrols.TabIndex = 9;
            this.logcontrols.TabStop = false;
            this.logcontrols.Text = "Log Tools";
            // 
            // savelogbtn
            // 
            this.savelogbtn.Location = new System.Drawing.Point(6, 18);
            this.savelogbtn.Name = "savelogbtn";
            this.savelogbtn.Size = new System.Drawing.Size(172, 23);
            this.savelogbtn.TabIndex = 1;
            this.savelogbtn.Text = "Save the NANDPro log";
            this.savelogbtn.UseVisualStyleBackColor = true;
            this.savelogbtn.Click += new System.EventHandler(this.savelogbtn_Click);
            // 
            // clrbtn
            // 
            this.clrbtn.Location = new System.Drawing.Point(6, 47);
            this.clrbtn.Name = "clrbtn";
            this.clrbtn.Size = new System.Drawing.Size(172, 23);
            this.clrbtn.TabIndex = 0;
            this.clrbtn.Text = "Clear log window";
            this.clrbtn.UseVisualStyleBackColor = true;
            this.clrbtn.Click += new System.EventHandler(this.clrbtn_Click);
            // 
            // savelog
            // 
            this.savelog.DefaultExt = "log";
            this.savelog.FileName = "nandpro.log";
            this.savelog.Filter = "Log files|*.log|All Files|*.*";
            this.savelog.Title = "Select where to save your log...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.SettingsToolStripMenuItem.Text = "Settings";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // runninglbl
            // 
            this.runninglbl.AutoSize = true;
            this.runninglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runninglbl.Location = new System.Drawing.Point(376, 118);
            this.runninglbl.Name = "runninglbl";
            this.runninglbl.Size = new System.Drawing.Size(120, 16);
            this.runninglbl.TabIndex = 11;
            this.runninglbl.Text = "Process is running:";
            // 
            // nandproact
            // 
            this.nandproact.Active = false;
            this.nandproact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nandproact.Color = System.Drawing.Color.Black;
            this.nandproact.InnerCircleRadius = 7;
            this.nandproact.Location = new System.Drawing.Point(502, 111);
            this.nandproact.Name = "nandproact";
            this.nandproact.NumberSpoke = 16;
            this.nandproact.OuterCircleRadius = 16;
            this.nandproact.RotationSpeed = 100;
            this.nandproact.Size = new System.Drawing.Size(51, 34);
            this.nandproact.SpokeThickness = 1;
            this.nandproact.TabIndex = 1;
            this.nandproact.Text = "loadingCircle1";
            // 
            // Nandpro
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(752, 342);
            this.Controls.Add(this.runninglbl);
            this.Controls.Add(this.nandproact);
            this.Controls.Add(this.logcontrols);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.flashconfigbox);
            this.Controls.Add(this.hwop);
            this.Controls.Add(this.sizebox);
            this.Controls.Add(this.nandop);
            this.Controls.Add(this.logbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Nandpro";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xeBuild GUI Nandpro Operations";
            this.Load += new System.EventHandler(this.Nandpro_Load);
            this.logbox.ResumeLayout(false);
            this.nandop.ResumeLayout(false);
            this.nandop.PerformLayout();
            this.sizebox.ResumeLayout(false);
            this.sizebox.PerformLayout();
            this.hwop.ResumeLayout(false);
            this.hwop.PerformLayout();
            this.flashconfigbox.ResumeLayout(false);
            this.flashconfigbox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.logcontrols.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outbox;
        private System.Windows.Forms.GroupBox logbox;
        private System.Windows.Forms.GroupBox nandop;
        private System.Windows.Forms.Button selectbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox worknand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox toblock;
        private System.Windows.Forms.GroupBox sizebox;
        private System.Windows.Forms.Button remapbtn;
        private System.Windows.Forms.Button ecctobinbtn;
        private System.Windows.Forms.GroupBox hwop;
        private System.Windows.Forms.Button dumpbtn;
        private System.Windows.Forms.Button writeeccbtn;
        private System.Windows.Forms.Button erasebtn;
        private System.Windows.Forms.Button writenandbtn;
        private System.Windows.Forms.Label dunplabel;
        private System.Windows.Forms.Button flashcpldbtn;
        private System.Windows.Forms.GroupBox flashconfigbox;
        private System.Windows.Forms.TextBox flashconfig;
        private System.Windows.Forms.OpenFileDialog selectnand;
        private System.Windows.Forms.OpenFileDialog opencpld;
        private System.Windows.Forms.OpenFileDialog openecc;
        private System.Windows.Forms.SaveFileDialog savenand;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel currstatlabel;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button comparebtn;
        private System.Windows.Forms.GroupBox logcontrols;
        private System.Windows.Forms.Button clrbtn;
        private System.Windows.Forms.Button savelogbtn;
        private System.Windows.Forms.SaveFileDialog savelog;
        private System.Windows.Forms.TextBox fromblock;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        public System.Windows.Forms.RadioButton s2;
        public System.Windows.Forms.RadioButton s1;
        public System.Windows.Forms.RadioButton s16;
        public System.Windows.Forms.RadioButton s64;
        public System.Windows.Forms.RadioButton s512;
        public System.Windows.Forms.RadioButton s256;
        private System.Windows.Forms.ComboBox dumptimes;
        private LoadingCircle nandproact;
        private System.Windows.Forms.Label runninglbl;

    }
}

