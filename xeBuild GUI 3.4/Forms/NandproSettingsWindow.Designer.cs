namespace xeBuild_GUI
{
    partial class NandproSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NandproSettings));
            this.versionbox = new System.Windows.Forms.GroupBox();
            this.npcustom = new System.Windows.Forms.RadioButton();
            this.np30a = new System.Windows.Forms.RadioButton();
            this.np20d = new System.Windows.Forms.RadioButton();
            this.sizebox = new System.Windows.Forms.GroupBox();
            this.s512 = new System.Windows.Forms.RadioButton();
            this.s256 = new System.Windows.Forms.RadioButton();
            this.s64 = new System.Windows.Forms.RadioButton();
            this.s16 = new System.Windows.Forms.RadioButton();
            this.s2 = new System.Windows.Forms.RadioButton();
            this.s1 = new System.Windows.Forms.RadioButton();
            this.devbox = new System.Windows.Forms.GroupBox();
            this.lpt = new System.Windows.Forms.RadioButton();
            this.usb = new System.Windows.Forms.RadioButton();
            this.setworkdir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.workdir = new System.Windows.Forms.TextBox();
            this.defaultsettings = new System.Windows.Forms.Button();
            this.pathsettings = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.setdump3 = new System.Windows.Forms.Button();
            this.setdump2 = new System.Windows.Forms.Button();
            this.setdump1 = new System.Windows.Forms.Button();
            this.dump4name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dump3name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dump2name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dump1name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.setdump4 = new System.Windows.Forms.Button();
            this.savefile = new System.Windows.Forms.Button();
            this.loadfile = new System.Windows.Forms.Button();
            this.dumps = new System.Windows.Forms.GroupBox();
            this.d4 = new System.Windows.Forms.RadioButton();
            this.d3 = new System.Windows.Forms.RadioButton();
            this.d2 = new System.Windows.Forms.RadioButton();
            this.d1 = new System.Windows.Forms.RadioButton();
            this.savedump = new System.Windows.Forms.SaveFileDialog();
            this.selworkdir = new System.Windows.Forms.FolderBrowserDialog();
            this.loadset = new System.Windows.Forms.OpenFileDialog();
            this.saveset = new System.Windows.Forms.SaveFileDialog();
            this.workfile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.setworkfile = new System.Windows.Forms.Button();
            this.versionbox.SuspendLayout();
            this.sizebox.SuspendLayout();
            this.devbox.SuspendLayout();
            this.pathsettings.SuspendLayout();
            this.dumps.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionbox
            // 
            this.versionbox.Controls.Add(this.npcustom);
            this.versionbox.Controls.Add(this.np30a);
            this.versionbox.Controls.Add(this.np20d);
            this.versionbox.Location = new System.Drawing.Point(394, 12);
            this.versionbox.Name = "versionbox";
            this.versionbox.Size = new System.Drawing.Size(113, 65);
            this.versionbox.TabIndex = 10;
            this.versionbox.TabStop = false;
            this.versionbox.Text = "Default version";
            // 
            // npcustom
            // 
            this.npcustom.AutoSize = true;
            this.npcustom.Location = new System.Drawing.Point(6, 42);
            this.npcustom.Name = "npcustom";
            this.npcustom.Size = new System.Drawing.Size(60, 17);
            this.npcustom.TabIndex = 2;
            this.npcustom.Text = "Custom";
            this.npcustom.UseVisualStyleBackColor = true;
            // 
            // np30a
            // 
            this.np30a.AutoSize = true;
            this.np30a.Location = new System.Drawing.Point(58, 19);
            this.np30a.Name = "np30a";
            this.np30a.Size = new System.Drawing.Size(46, 17);
            this.np30a.TabIndex = 1;
            this.np30a.Text = "3.0a";
            this.np30a.UseVisualStyleBackColor = true;
            // 
            // np20d
            // 
            this.np20d.AutoSize = true;
            this.np20d.Checked = true;
            this.np20d.Location = new System.Drawing.Point(6, 19);
            this.np20d.Name = "np20d";
            this.np20d.Size = new System.Drawing.Size(46, 17);
            this.np20d.TabIndex = 0;
            this.np20d.TabStop = true;
            this.np20d.Text = "2.0d";
            this.np20d.UseVisualStyleBackColor = true;
            // 
            // sizebox
            // 
            this.sizebox.Controls.Add(this.s512);
            this.sizebox.Controls.Add(this.s256);
            this.sizebox.Controls.Add(this.s64);
            this.sizebox.Controls.Add(this.s16);
            this.sizebox.Controls.Add(this.s2);
            this.sizebox.Controls.Add(this.s1);
            this.sizebox.Location = new System.Drawing.Point(205, 12);
            this.sizebox.Name = "sizebox";
            this.sizebox.Size = new System.Drawing.Size(183, 65);
            this.sizebox.TabIndex = 9;
            this.sizebox.TabStop = false;
            this.sizebox.Text = "Default dump size";
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
            // devbox
            // 
            this.devbox.Controls.Add(this.lpt);
            this.devbox.Controls.Add(this.usb);
            this.devbox.Location = new System.Drawing.Point(12, 12);
            this.devbox.Name = "devbox";
            this.devbox.Size = new System.Drawing.Size(187, 65);
            this.devbox.TabIndex = 8;
            this.devbox.TabStop = false;
            this.devbox.Text = "Default device";
            // 
            // lpt
            // 
            this.lpt.AutoSize = true;
            this.lpt.Location = new System.Drawing.Point(6, 42);
            this.lpt.Name = "lpt";
            this.lpt.Size = new System.Drawing.Size(156, 17);
            this.lpt.TabIndex = 1;
            this.lpt.Text = "LPT (Home built LPT cable)";
            this.lpt.UseVisualStyleBackColor = true;
            // 
            // usb
            // 
            this.usb.AutoSize = true;
            this.usb.Checked = true;
            this.usb.Location = new System.Drawing.Point(6, 19);
            this.usb.Name = "usb";
            this.usb.Size = new System.Drawing.Size(176, 17);
            this.usb.TabIndex = 0;
            this.usb.TabStop = true;
            this.usb.Text = "USB (NAND-X, Olimex etc. etc.)";
            this.usb.UseVisualStyleBackColor = true;
            // 
            // setworkdir
            // 
            this.setworkdir.Location = new System.Drawing.Point(501, 16);
            this.setworkdir.Name = "setworkdir";
            this.setworkdir.Size = new System.Drawing.Size(190, 24);
            this.setworkdir.TabIndex = 11;
            this.setworkdir.Text = "Select default working directory";
            this.setworkdir.UseVisualStyleBackColor = true;
            this.setworkdir.Click += new System.EventHandler(this.setworkdir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Default working directory:";
            // 
            // workdir
            // 
            this.workdir.Location = new System.Drawing.Point(138, 19);
            this.workdir.Name = "workdir";
            this.workdir.Size = new System.Drawing.Size(357, 20);
            this.workdir.TabIndex = 13;
            // 
            // defaultsettings
            // 
            this.defaultsettings.Location = new System.Drawing.Point(250, 318);
            this.defaultsettings.Name = "defaultsettings";
            this.defaultsettings.Size = new System.Drawing.Size(221, 43);
            this.defaultsettings.TabIndex = 14;
            this.defaultsettings.Text = "Load Default settings";
            this.defaultsettings.UseVisualStyleBackColor = true;
            this.defaultsettings.Click += new System.EventHandler(this.defaultsettings_Click);
            // 
            // pathsettings
            // 
            this.pathsettings.Controls.Add(this.workfile);
            this.pathsettings.Controls.Add(this.label7);
            this.pathsettings.Controls.Add(this.setworkfile);
            this.pathsettings.Controls.Add(this.label6);
            this.pathsettings.Controls.Add(this.setdump3);
            this.pathsettings.Controls.Add(this.setdump2);
            this.pathsettings.Controls.Add(this.setdump1);
            this.pathsettings.Controls.Add(this.dump4name);
            this.pathsettings.Controls.Add(this.label5);
            this.pathsettings.Controls.Add(this.dump3name);
            this.pathsettings.Controls.Add(this.label4);
            this.pathsettings.Controls.Add(this.dump2name);
            this.pathsettings.Controls.Add(this.label3);
            this.pathsettings.Controls.Add(this.dump1name);
            this.pathsettings.Controls.Add(this.label2);
            this.pathsettings.Controls.Add(this.label1);
            this.pathsettings.Controls.Add(this.workdir);
            this.pathsettings.Controls.Add(this.setworkdir);
            this.pathsettings.Location = new System.Drawing.Point(12, 83);
            this.pathsettings.Name = "pathsettings";
            this.pathsettings.Size = new System.Drawing.Size(697, 229);
            this.pathsettings.TabIndex = 15;
            this.pathsettings.TabStop = false;
            this.pathsettings.Text = "Default directory/dump names";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(404, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "NOTE: any occurance of {size} will be replaced by the selected size of current du" +
    "mp";
            // 
            // setdump3
            // 
            this.setdump3.Location = new System.Drawing.Point(501, 106);
            this.setdump3.Name = "setdump3";
            this.setdump3.Size = new System.Drawing.Size(190, 24);
            this.setdump3.TabIndex = 24;
            this.setdump3.Text = "Select default name for dump 3";
            this.setdump3.UseVisualStyleBackColor = true;
            this.setdump3.Click += new System.EventHandler(this.setdump3_Click);
            // 
            // setdump2
            // 
            this.setdump2.Location = new System.Drawing.Point(501, 76);
            this.setdump2.Name = "setdump2";
            this.setdump2.Size = new System.Drawing.Size(190, 24);
            this.setdump2.TabIndex = 23;
            this.setdump2.Text = "Select default name for dump 2";
            this.setdump2.UseVisualStyleBackColor = true;
            this.setdump2.Click += new System.EventHandler(this.setdump2_Click);
            // 
            // setdump1
            // 
            this.setdump1.Location = new System.Drawing.Point(501, 46);
            this.setdump1.Name = "setdump1";
            this.setdump1.Size = new System.Drawing.Size(190, 24);
            this.setdump1.TabIndex = 22;
            this.setdump1.Text = "Select default name for dump 1";
            this.setdump1.UseVisualStyleBackColor = true;
            this.setdump1.Click += new System.EventHandler(this.setdump1_Click);
            // 
            // dump4name
            // 
            this.dump4name.Location = new System.Drawing.Point(138, 139);
            this.dump4name.Name = "dump4name";
            this.dump4name.Size = new System.Drawing.Size(357, 20);
            this.dump4name.TabIndex = 21;
            this.dump4name.Text = "dump{size}-4.bin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Default name for dump 4:";
            // 
            // dump3name
            // 
            this.dump3name.Location = new System.Drawing.Point(138, 109);
            this.dump3name.Name = "dump3name";
            this.dump3name.Size = new System.Drawing.Size(357, 20);
            this.dump3name.TabIndex = 19;
            this.dump3name.Text = "dump{size}-3.bin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Default name for dump 3:";
            // 
            // dump2name
            // 
            this.dump2name.Location = new System.Drawing.Point(138, 79);
            this.dump2name.Name = "dump2name";
            this.dump2name.Size = new System.Drawing.Size(357, 20);
            this.dump2name.TabIndex = 17;
            this.dump2name.Text = "dump{size}-2.bin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Default name for dump 2:";
            // 
            // dump1name
            // 
            this.dump1name.Location = new System.Drawing.Point(138, 49);
            this.dump1name.Name = "dump1name";
            this.dump1name.Size = new System.Drawing.Size(357, 20);
            this.dump1name.TabIndex = 15;
            this.dump1name.Text = "dump{size}-1.bin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Default name for dump 1:";
            // 
            // setdump4
            // 
            this.setdump4.Location = new System.Drawing.Point(513, 219);
            this.setdump4.Name = "setdump4";
            this.setdump4.Size = new System.Drawing.Size(190, 24);
            this.setdump4.TabIndex = 25;
            this.setdump4.Text = "Select default name for dump 4";
            this.setdump4.UseVisualStyleBackColor = true;
            this.setdump4.Click += new System.EventHandler(this.setdump4_Click);
            // 
            // savefile
            // 
            this.savefile.Location = new System.Drawing.Point(488, 318);
            this.savefile.Name = "savefile";
            this.savefile.Size = new System.Drawing.Size(221, 43);
            this.savefile.TabIndex = 26;
            this.savefile.Text = "Save to file";
            this.savefile.UseVisualStyleBackColor = true;
            this.savefile.Click += new System.EventHandler(this.savefile_Click);
            // 
            // loadfile
            // 
            this.loadfile.Location = new System.Drawing.Point(12, 318);
            this.loadfile.Name = "loadfile";
            this.loadfile.Size = new System.Drawing.Size(221, 43);
            this.loadfile.TabIndex = 27;
            this.loadfile.Text = "Load from file";
            this.loadfile.UseVisualStyleBackColor = true;
            this.loadfile.Click += new System.EventHandler(this.loadfile_Click);
            // 
            // dumps
            // 
            this.dumps.Controls.Add(this.d4);
            this.dumps.Controls.Add(this.d3);
            this.dumps.Controls.Add(this.d2);
            this.dumps.Controls.Add(this.d1);
            this.dumps.Location = new System.Drawing.Point(513, 12);
            this.dumps.Name = "dumps";
            this.dumps.Size = new System.Drawing.Size(196, 65);
            this.dumps.TabIndex = 11;
            this.dumps.TabStop = false;
            this.dumps.Text = "Default number of dumps";
            // 
            // d4
            // 
            this.d4.AutoSize = true;
            this.d4.Location = new System.Drawing.Point(101, 42);
            this.d4.Name = "d4";
            this.d4.Size = new System.Drawing.Size(89, 17);
            this.d4.TabIndex = 6;
            this.d4.Text = "Dump 4 times";
            this.d4.UseVisualStyleBackColor = true;
            // 
            // d3
            // 
            this.d3.AutoSize = true;
            this.d3.Checked = true;
            this.d3.Location = new System.Drawing.Point(101, 19);
            this.d3.Name = "d3";
            this.d3.Size = new System.Drawing.Size(89, 17);
            this.d3.TabIndex = 5;
            this.d3.TabStop = true;
            this.d3.Text = "Dump 3 times";
            this.d3.UseVisualStyleBackColor = true;
            // 
            // d2
            // 
            this.d2.AutoSize = true;
            this.d2.Location = new System.Drawing.Point(6, 42);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(89, 17);
            this.d2.TabIndex = 4;
            this.d2.Text = "Dump 2 times";
            this.d2.UseVisualStyleBackColor = true;
            // 
            // d1
            // 
            this.d1.AutoSize = true;
            this.d1.Location = new System.Drawing.Point(6, 19);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(84, 17);
            this.d1.TabIndex = 3;
            this.d1.Text = "Dump 1 time";
            this.d1.UseVisualStyleBackColor = true;
            // 
            // savedump
            // 
            this.savedump.DefaultExt = "bin";
            this.savedump.Filter = "Xbox 360 NAND|*.bin|All Files|*.*";
            this.savedump.Title = "Select default path/name for your dump";
            // 
            // loadset
            // 
            this.loadset.DefaultExt = "xml";
            this.loadset.FileName = "nandpro.xml";
            this.loadset.Filter = "xeBuild GUI NANDPro Configuration file|*.xml|All Files|*.*";
            this.loadset.Title = "Select configuration file";
            // 
            // saveset
            // 
            this.saveset.DefaultExt = "xml";
            this.saveset.FileName = "nandpro.xml";
            this.saveset.Filter = "xeBuild GUI NANDPro Configuration file|*.xml|All Files|*.*";
            this.saveset.Title = "Select configuration file";
            // 
            // workfile
            // 
            this.workfile.Location = new System.Drawing.Point(138, 169);
            this.workfile.Name = "workfile";
            this.workfile.Size = new System.Drawing.Size(357, 20);
            this.workfile.TabIndex = 27;
            this.workfile.Text = "updflash.bin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Default work NAND file:";
            // 
            // setworkfile
            // 
            this.setworkfile.Location = new System.Drawing.Point(501, 166);
            this.setworkfile.Name = "setworkfile";
            this.setworkfile.Size = new System.Drawing.Size(190, 24);
            this.setworkfile.TabIndex = 28;
            this.setworkfile.Text = "Select default work NAND file";
            this.setworkfile.UseVisualStyleBackColor = true;
            // 
            // NandproSettings
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(723, 372);
            this.Controls.Add(this.dumps);
            this.Controls.Add(this.loadfile);
            this.Controls.Add(this.savefile);
            this.Controls.Add(this.setdump4);
            this.Controls.Add(this.pathsettings);
            this.Controls.Add(this.defaultsettings);
            this.Controls.Add(this.versionbox);
            this.Controls.Add(this.sizebox);
            this.Controls.Add(this.devbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NandproSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nandpro Default Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NandproSettings_FormClosing);
            this.Load += new System.EventHandler(this.NandproSettings_Load);
            this.versionbox.ResumeLayout(false);
            this.versionbox.PerformLayout();
            this.sizebox.ResumeLayout(false);
            this.sizebox.PerformLayout();
            this.devbox.ResumeLayout(false);
            this.devbox.PerformLayout();
            this.pathsettings.ResumeLayout(false);
            this.pathsettings.PerformLayout();
            this.dumps.ResumeLayout(false);
            this.dumps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox versionbox;
        private System.Windows.Forms.RadioButton npcustom;
        private System.Windows.Forms.RadioButton np30a;
        private System.Windows.Forms.RadioButton np20d;
        private System.Windows.Forms.GroupBox sizebox;
        private System.Windows.Forms.RadioButton s512;
        private System.Windows.Forms.RadioButton s256;
        private System.Windows.Forms.RadioButton s64;
        private System.Windows.Forms.RadioButton s16;
        private System.Windows.Forms.RadioButton s2;
        private System.Windows.Forms.RadioButton s1;
        private System.Windows.Forms.GroupBox devbox;
        private System.Windows.Forms.RadioButton lpt;
        private System.Windows.Forms.RadioButton usb;
        private System.Windows.Forms.Button setworkdir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox workdir;
        private System.Windows.Forms.Button defaultsettings;
        private System.Windows.Forms.GroupBox pathsettings;
        private System.Windows.Forms.TextBox dump1name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dump4name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dump3name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dump2name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button setdump3;
        private System.Windows.Forms.Button setdump2;
        private System.Windows.Forms.Button setdump1;
        private System.Windows.Forms.Button setdump4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button savefile;
        private System.Windows.Forms.Button loadfile;
        private System.Windows.Forms.GroupBox dumps;
        private System.Windows.Forms.RadioButton d1;
        private System.Windows.Forms.RadioButton d4;
        private System.Windows.Forms.RadioButton d3;
        private System.Windows.Forms.RadioButton d2;
        private System.Windows.Forms.SaveFileDialog savedump;
        private System.Windows.Forms.FolderBrowserDialog selworkdir;
        private System.Windows.Forms.OpenFileDialog loadset;
        private System.Windows.Forms.SaveFileDialog saveset;
        private System.Windows.Forms.TextBox workfile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button setworkfile;

    }
}

