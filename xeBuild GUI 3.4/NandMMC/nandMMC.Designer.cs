namespace xeBuild_GUI.NandMMC
{
    partial class nandMMC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nandMMC));
            this.size = new System.Windows.Forms.GroupBox();
            this.full = new System.Windows.Forms.RadioButton();
            this.sysonly = new System.Windows.Forms.RadioButton();
            this.opts = new System.Windows.Forms.GroupBox();
            this.incfixed = new System.Windows.Forms.CheckBox();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.Dumper = new System.ComponentModel.BackgroundWorker();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Flasher = new System.ComponentModel.BackgroundWorker();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.logo = new System.Windows.Forms.PictureBox();
            this.status = new xeBuild_GUI.NandMMC.SafeToolStripLabel();
            this.working = new xeBuild_GUI.NandMMC.LoadingCircle();
            this.abortbtn = new xeBuild_GUI.NandMMC.SafeButton();
            this.flashbtn = new xeBuild_GUI.NandMMC.SafeButton();
            this.dumpbtn = new xeBuild_GUI.NandMMC.SafeButton();
            this.Devicelist = new xeBuild_GUI.NandMMC.SafeComboBox();
            this.updatebtn = new xeBuild_GUI.NandMMC.SafeButton();
            this.size.SuspendLayout();
            this.opts.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // size
            // 
            this.size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.size.Controls.Add(this.full);
            this.size.Controls.Add(this.sysonly);
            this.size.Location = new System.Drawing.Point(12, 12);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(174, 71);
            this.size.TabIndex = 0;
            this.size.TabStop = false;
            this.size.Text = "Dump Size";
            // 
            // full
            // 
            this.full.AutoSize = true;
            this.full.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.full.Location = new System.Drawing.Point(6, 43);
            this.full.Name = "full";
            this.full.Size = new System.Drawing.Size(111, 17);
            this.full.TabIndex = 0;
            this.full.TabStop = true;
            this.full.Text = "Full Dump (3.5GB)";
            this.full.UseVisualStyleBackColor = false;
            this.full.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // sysonly
            // 
            this.sysonly.AutoSize = true;
            this.sysonly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sysonly.Checked = true;
            this.sysonly.Location = new System.Drawing.Point(6, 20);
            this.sysonly.Name = "sysonly";
            this.sysonly.Size = new System.Drawing.Size(120, 17);
            this.sysonly.TabIndex = 0;
            this.sysonly.TabStop = true;
            this.sysonly.Text = "System Only (48MB)";
            this.sysonly.UseVisualStyleBackColor = false;
            this.sysonly.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // opts
            // 
            this.opts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.opts.Controls.Add(this.incfixed);
            this.opts.Controls.Add(this.updatebtn);
            this.opts.Location = new System.Drawing.Point(192, 12);
            this.opts.Name = "opts";
            this.opts.Size = new System.Drawing.Size(143, 71);
            this.opts.TabIndex = 1;
            this.opts.TabStop = false;
            this.opts.Text = "Device Options";
            // 
            // incfixed
            // 
            this.incfixed.AutoSize = true;
            this.incfixed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.incfixed.Location = new System.Drawing.Point(6, 19);
            this.incfixed.Name = "incfixed";
            this.incfixed.Size = new System.Drawing.Size(131, 17);
            this.incfixed.TabIndex = 1;
            this.incfixed.Text = "Include Fixed Devices";
            this.incfixed.UseVisualStyleBackColor = false;
            this.incfixed.CheckedChanged += new System.EventHandler(this.IncfixedCheckedChanged);
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwDoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwRunWorkerCompleted);
            // 
            // Dumper
            // 
            this.Dumper.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DumperDoWork);
            this.Dumper.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DumperRunWorkerCompleted);
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "bin";
            this.sfd.FileName = "Dump.bin";
            this.sfd.Title = "Select where to save your dump";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 223);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(546, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Flasher
            // 
            this.Flasher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FlasherDoWork);
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "bin";
            this.ofd.FileName = "Nandflash.bin";
            this.ofd.Filter = "Xbox 360 Binary Files|*.bin|Xbox 360 ECC files|*.ecc|All Files|*.*";
            this.ofd.Title = "Select NAND to flash";
            // 
            // logo
            // 
            this.logo.Image = global::xeBuild_GUI.Properties.Resources.mmc_logo;
            this.logo.Location = new System.Drawing.Point(341, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(193, 208);
            this.logo.TabIndex = 5;
            this.logo.TabStop = false;
            this.logo.Click += new System.EventHandler(this.LogoClick);
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(122, 15);
            this.status.Text = "Waiting for user input";
            // 
            // working
            // 
            this.working.Active = false;
            this.working.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.working.Color = System.Drawing.Color.Black;
            this.working.InnerCircleRadius = 10;
            this.working.Location = new System.Drawing.Point(255, 116);
            this.working.Name = "working";
            this.working.NumberSpoke = 15;
            this.working.OuterCircleRadius = 30;
            this.working.RotationSpeed = 100;
            this.working.Size = new System.Drawing.Size(80, 104);
            this.working.SpokeThickness = 2;
            this.working.TabIndex = 3;
            this.working.Text = "loadingCircle1";
            // 
            // abortbtn
            // 
            this.abortbtn.Enabled = false;
            this.abortbtn.Location = new System.Drawing.Point(12, 162);
            this.abortbtn.Name = "abortbtn";
            this.abortbtn.Size = new System.Drawing.Size(237, 58);
            this.abortbtn.TabIndex = 2;
            this.abortbtn.Text = "Abort Operation";
            this.abortbtn.UseVisualStyleBackColor = true;
            this.abortbtn.Click += new System.EventHandler(this.AbortbtnClick);
            // 
            // flashbtn
            // 
            this.flashbtn.Enabled = false;
            this.flashbtn.Location = new System.Drawing.Point(133, 116);
            this.flashbtn.Name = "flashbtn";
            this.flashbtn.Size = new System.Drawing.Size(116, 40);
            this.flashbtn.TabIndex = 2;
            this.flashbtn.Text = "Flash";
            this.flashbtn.UseVisualStyleBackColor = true;
            this.flashbtn.Click += new System.EventHandler(this.FlashbtnClick);
            // 
            // dumpbtn
            // 
            this.dumpbtn.Enabled = false;
            this.dumpbtn.Location = new System.Drawing.Point(12, 116);
            this.dumpbtn.Name = "dumpbtn";
            this.dumpbtn.Size = new System.Drawing.Size(115, 40);
            this.dumpbtn.TabIndex = 2;
            this.dumpbtn.Text = "Dump";
            this.dumpbtn.UseVisualStyleBackColor = true;
            this.dumpbtn.Click += new System.EventHandler(this.DumpbtnClick);
            // 
            // Devicelist
            // 
            this.Devicelist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Devicelist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Devicelist.FormattingEnabled = true;
            this.Devicelist.Location = new System.Drawing.Point(12, 89);
            this.Devicelist.Name = "Devicelist";
            this.Devicelist.Size = new System.Drawing.Size(323, 21);
            this.Devicelist.Sorted = true;
            this.Devicelist.TabIndex = 1;
            this.Devicelist.SelectedIndexChanged += new System.EventHandler(this.DevicelistSelectedIndexChanged);
            this.Devicelist.TextChanged += new System.EventHandler(this.DevicelistTextChanged);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(6, 42);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(131, 23);
            this.updatebtn.TabIndex = 0;
            this.updatebtn.Text = "Update Device List";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.UpdatebtnClick);
            // 
            // nandMMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(546, 245);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.working);
            this.Controls.Add(this.abortbtn);
            this.Controls.Add(this.flashbtn);
            this.Controls.Add(this.dumpbtn);
            this.Controls.Add(this.Devicelist);
            this.Controls.Add(this.opts);
            this.Controls.Add(this.size);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "nandMMC";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "nandMMC";
            this.size.ResumeLayout(false);
            this.size.PerformLayout();
            this.opts.ResumeLayout(false);
            this.opts.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox size;
        private System.Windows.Forms.RadioButton sysonly;
        private System.Windows.Forms.RadioButton full;
        private System.Windows.Forms.GroupBox opts;
        private SafeButton updatebtn;
        private System.Windows.Forms.CheckBox incfixed;
        private SafeComboBox Devicelist;
        private SafeButton dumpbtn;
        private System.ComponentModel.BackgroundWorker bw;
        private System.ComponentModel.BackgroundWorker Dumper;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private SafeToolStripLabel status;
        private SafeButton abortbtn;
        private SafeButton flashbtn;
        private System.ComponentModel.BackgroundWorker Flasher;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.PictureBox logo;
        private LoadingCircle working;
    }
}

