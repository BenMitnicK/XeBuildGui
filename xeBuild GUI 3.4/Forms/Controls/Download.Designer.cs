namespace xeBuild_GUI
{
    partial class dwltab
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
            this.dwlcancelbtn = new System.Windows.Forms.Button();
            this.md5match = new System.Windows.Forms.RichTextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dwlerrorlog = new System.Windows.Forms.RichTextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label64 = new System.Windows.Forms.Label();
            this.dfvers = new System.Windows.Forms.ComboBox();
            this.dwldashbtn = new System.Windows.Forms.Button();
            this.dwlprogtxt = new System.Windows.Forms.TextBox();
            this.expected = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.actual = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.dwlstatusstrip = new System.Windows.Forms.StatusStrip();
            this.dwlprogbar = new System.Windows.Forms.ToolStripProgressBar();
            this.statlbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dwlstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label55 = new System.Windows.Forms.Label();
            this.dwlavatarbtn = new System.Windows.Forms.Button();
            this.prepdrive = new System.Windows.Forms.Button();
            this.formatbtn = new System.Windows.Forms.Button();
            this.avers = new System.Windows.Forms.ComboBox();
            this.updrivelistbtn = new System.Windows.Forms.Button();
            this.inchdd = new System.Windows.Forms.CheckBox();
            this.label51 = new System.Windows.Forms.Label();
            this.drive = new System.Windows.Forms.ComboBox();
            this.formatworker = new System.ComponentModel.BackgroundWorker();
            this.unpackworker = new System.ComponentModel.BackgroundWorker();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.dwlstatusstrip.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // dwlcancelbtn
            // 
            this.dwlcancelbtn.Enabled = false;
            this.dwlcancelbtn.Location = new System.Drawing.Point(351, 501);
            this.dwlcancelbtn.Name = "dwlcancelbtn";
            this.dwlcancelbtn.Size = new System.Drawing.Size(117, 20);
            this.dwlcancelbtn.TabIndex = 58;
            this.dwlcancelbtn.Text = "Cancel Download";
            this.dwlcancelbtn.UseVisualStyleBackColor = true;
            this.dwlcancelbtn.Click += new System.EventHandler(this.dwlcancelbtn_Click);
            // 
            // md5match
            // 
            this.md5match.Cursor = System.Windows.Forms.Cursors.Default;
            this.md5match.Location = new System.Drawing.Point(391, 475);
            this.md5match.MaxLength = 6;
            this.md5match.Multiline = false;
            this.md5match.Name = "md5match";
            this.md5match.ReadOnly = true;
            this.md5match.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.md5match.Size = new System.Drawing.Size(77, 20);
            this.md5match.TabIndex = 60;
            this.md5match.Text = "N/A";
            this.md5match.WordWrap = false;
            this.md5match.TextChanged += new System.EventHandler(this.md5match_TextChanged);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(391, 452);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(77, 13);
            this.label63.TabIndex = 59;
            this.label63.Text = "MD5 Matches:";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dwlerrorlog);
            this.groupBox12.Location = new System.Drawing.Point(6, 184);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox12.Size = new System.Drawing.Size(468, 259);
            this.groupBox12.TabIndex = 57;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Errorlog";
            // 
            // dwlerrorlog
            // 
            this.dwlerrorlog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dwlerrorlog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dwlerrorlog.Cursor = System.Windows.Forms.Cursors.Default;
            this.dwlerrorlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwlerrorlog.Location = new System.Drawing.Point(8, 21);
            this.dwlerrorlog.Name = "dwlerrorlog";
            this.dwlerrorlog.ReadOnly = true;
            this.dwlerrorlog.Size = new System.Drawing.Size(452, 230);
            this.dwlerrorlog.TabIndex = 0;
            this.dwlerrorlog.Text = "";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label64);
            this.groupBox11.Controls.Add(this.dfvers);
            this.groupBox11.Controls.Add(this.dwldashbtn);
            this.groupBox11.Location = new System.Drawing.Point(6, 121);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(468, 57);
            this.groupBox11.TabIndex = 56;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Download/Install Dashfiles";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(6, 27);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(151, 13);
            this.label64.TabIndex = 33;
            this.label64.Text = "Dashboard version (Dashfiles):";
            // 
            // dfvers
            // 
            this.dfvers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dfvers.FormattingEnabled = true;
            this.dfvers.Location = new System.Drawing.Point(158, 24);
            this.dfvers.Name = "dfvers";
            this.dfvers.Size = new System.Drawing.Size(86, 21);
            this.dfvers.TabIndex = 32;
            this.dfvers.SelectedIndexChanged += new System.EventHandler(this.downloadversionchanged);
            // 
            // dwldashbtn
            // 
            this.dwldashbtn.Location = new System.Drawing.Point(250, 17);
            this.dwldashbtn.Name = "dwldashbtn";
            this.dwldashbtn.Size = new System.Drawing.Size(212, 32);
            this.dwldashbtn.TabIndex = 28;
            this.dwldashbtn.Text = "Download/Install Dashfiles";
            this.dwldashbtn.UseVisualStyleBackColor = true;
            this.dwldashbtn.Click += new System.EventHandler(this.dwldashbtn_Click);
            // 
            // dwlprogtxt
            // 
            this.dwlprogtxt.Location = new System.Drawing.Point(113, 501);
            this.dwlprogtxt.Name = "dwlprogtxt";
            this.dwlprogtxt.ReadOnly = true;
            this.dwlprogtxt.Size = new System.Drawing.Size(232, 20);
            this.dwlprogtxt.TabIndex = 55;
            // 
            // expected
            // 
            this.expected.Location = new System.Drawing.Point(113, 449);
            this.expected.Name = "expected";
            this.expected.ReadOnly = true;
            this.expected.Size = new System.Drawing.Size(232, 20);
            this.expected.TabIndex = 54;
            this.expected.TextChanged += new System.EventHandler(this.expected_TextChanged);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(26, 452);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(81, 13);
            this.label52.TabIndex = 53;
            this.label52.Text = "Expected MD5:";
            // 
            // actual
            // 
            this.actual.Location = new System.Drawing.Point(113, 475);
            this.actual.Name = "actual";
            this.actual.ReadOnly = true;
            this.actual.Size = new System.Drawing.Size(232, 20);
            this.actual.TabIndex = 52;
            this.actual.TextChanged += new System.EventHandler(this.actual_TextChanged);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(13, 478);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(94, 13);
            this.label53.TabIndex = 51;
            this.label53.Text = "MD5 of download:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(6, 504);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(101, 13);
            this.label54.TabIndex = 50;
            this.label54.Text = "Download progress:";
            // 
            // dwlstatusstrip
            // 
            this.dwlstatusstrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dwlstatusstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dwlprogbar,
            this.statlbl1,
            this.dwlstatus});
            this.dwlstatusstrip.Location = new System.Drawing.Point(0, 526);
            this.dwlstatusstrip.Name = "dwlstatusstrip";
            this.dwlstatusstrip.Size = new System.Drawing.Size(480, 22);
            this.dwlstatusstrip.SizingGrip = false;
            this.dwlstatusstrip.TabIndex = 49;
            // 
            // dwlprogbar
            // 
            this.dwlprogbar.Name = "dwlprogbar";
            this.dwlprogbar.Size = new System.Drawing.Size(100, 16);
            // 
            // statlbl1
            // 
            this.statlbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statlbl1.Name = "statlbl1";
            this.statlbl1.Size = new System.Drawing.Size(85, 17);
            this.statlbl1.Text = "Current Status:";
            // 
            // dwlstatus
            // 
            this.dwlstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dwlstatus.Name = "dwlstatus";
            this.dwlstatus.Size = new System.Drawing.Size(131, 17);
            this.dwlstatus.Text = "Waiting for user input...";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label55);
            this.groupBox10.Controls.Add(this.dwlavatarbtn);
            this.groupBox10.Controls.Add(this.prepdrive);
            this.groupBox10.Controls.Add(this.formatbtn);
            this.groupBox10.Controls.Add(this.avers);
            this.groupBox10.Controls.Add(this.updrivelistbtn);
            this.groupBox10.Controls.Add(this.inchdd);
            this.groupBox10.Controls.Add(this.label51);
            this.groupBox10.Controls.Add(this.drive);
            this.groupBox10.Location = new System.Drawing.Point(6, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(468, 112);
            this.groupBox10.TabIndex = 48;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Avatar Preperations";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(8, 86);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(144, 13);
            this.label55.TabIndex = 31;
            this.label55.Text = "Dashboard version (Avatars):";
            // 
            // dwlavatarbtn
            // 
            this.dwlavatarbtn.Location = new System.Drawing.Point(250, 79);
            this.dwlavatarbtn.Name = "dwlavatarbtn";
            this.dwlavatarbtn.Size = new System.Drawing.Size(212, 27);
            this.dwlavatarbtn.TabIndex = 27;
            this.dwlavatarbtn.Text = "Download Avatar update";
            this.dwlavatarbtn.UseVisualStyleBackColor = true;
            this.dwlavatarbtn.Click += new System.EventHandler(this.dwlavatarbtn_Click);
            // 
            // prepdrive
            // 
            this.prepdrive.Location = new System.Drawing.Point(356, 46);
            this.prepdrive.Name = "prepdrive";
            this.prepdrive.Size = new System.Drawing.Size(106, 27);
            this.prepdrive.TabIndex = 29;
            this.prepdrive.Text = "Prepare drive";
            this.prepdrive.UseVisualStyleBackColor = true;
            this.prepdrive.Click += new System.EventHandler(this.prepdrive_Click);
            // 
            // formatbtn
            // 
            this.formatbtn.Location = new System.Drawing.Point(250, 46);
            this.formatbtn.Name = "formatbtn";
            this.formatbtn.Size = new System.Drawing.Size(100, 27);
            this.formatbtn.TabIndex = 28;
            this.formatbtn.Text = "Format Drive";
            this.formatbtn.UseVisualStyleBackColor = true;
            this.formatbtn.Click += new System.EventHandler(this.formatbtn_Click);
            // 
            // avers
            // 
            this.avers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.avers.FormattingEnabled = true;
            this.avers.Items.AddRange(new object[] {
            "Custom"});
            this.avers.Location = new System.Drawing.Point(158, 83);
            this.avers.Name = "avers";
            this.avers.Size = new System.Drawing.Size(86, 21);
            this.avers.TabIndex = 30;
            this.avers.SelectedIndexChanged += new System.EventHandler(this.downloadversionchanged);
            // 
            // updrivelistbtn
            // 
            this.updrivelistbtn.Location = new System.Drawing.Point(9, 46);
            this.updrivelistbtn.Name = "updrivelistbtn";
            this.updrivelistbtn.Size = new System.Drawing.Size(112, 27);
            this.updrivelistbtn.TabIndex = 26;
            this.updrivelistbtn.Text = "Update drive list";
            this.updrivelistbtn.UseVisualStyleBackColor = true;
            this.updrivelistbtn.Click += new System.EventHandler(this.upddrivelist);
            // 
            // inchdd
            // 
            this.inchdd.AutoSize = true;
            this.inchdd.Location = new System.Drawing.Point(128, 52);
            this.inchdd.Name = "inchdd";
            this.inchdd.Size = new System.Drawing.Size(115, 17);
            this.inchdd.TabIndex = 25;
            this.inchdd.Text = "Include Harddrives";
            this.inchdd.UseVisualStyleBackColor = true;
            this.inchdd.Click += new System.EventHandler(this.upddrivelist);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(6, 23);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(60, 13);
            this.label51.TabIndex = 23;
            this.label51.Text = "USB Drive:";
            // 
            // drive
            // 
            this.drive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drive.FormattingEnabled = true;
            this.drive.Location = new System.Drawing.Point(72, 19);
            this.drive.Name = "drive";
            this.drive.Size = new System.Drawing.Size(390, 21);
            this.drive.TabIndex = 22;
            // 
            // formatworker
            // 
            this.formatworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.formatworker_DoWork);
            this.formatworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.formatworker_RunWorkerCompleted);
            // 
            // unpackworker
            // 
            this.unpackworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.unpackworker_DoWork);
            // 
            // dwltab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.dwlcancelbtn);
            this.Controls.Add(this.md5match);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.dwlprogtxt);
            this.Controls.Add(this.expected);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.actual);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.dwlstatusstrip);
            this.Controls.Add(this.groupBox10);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "dwltab";
            this.Size = new System.Drawing.Size(480, 548);
            this.groupBox12.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.dwlstatusstrip.ResumeLayout(false);
            this.dwlstatusstrip.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button dwlcancelbtn;
        public System.Windows.Forms.RichTextBox md5match;
        public System.Windows.Forms.Label label63;
        public System.Windows.Forms.GroupBox groupBox12;
        public System.Windows.Forms.RichTextBox dwlerrorlog;
        public System.Windows.Forms.GroupBox groupBox11;
        public System.Windows.Forms.Label label64;
        public System.Windows.Forms.ComboBox dfvers;
        public System.Windows.Forms.Button dwldashbtn;
        public System.Windows.Forms.TextBox dwlprogtxt;
        public System.Windows.Forms.TextBox expected;
        public System.Windows.Forms.Label label52;
        public System.Windows.Forms.TextBox actual;
        public System.Windows.Forms.Label label53;
        public System.Windows.Forms.Label label54;
        public System.Windows.Forms.StatusStrip dwlstatusstrip;
        public System.Windows.Forms.ToolStripStatusLabel statlbl1;
        public System.Windows.Forms.ToolStripStatusLabel dwlstatus;
        public System.Windows.Forms.ToolStripProgressBar dwlprogbar;
        public System.Windows.Forms.GroupBox groupBox10;
        public System.Windows.Forms.Label label55;
        public System.Windows.Forms.Button dwlavatarbtn;
        public System.Windows.Forms.Button prepdrive;
        public System.Windows.Forms.Button formatbtn;
        public System.Windows.Forms.ComboBox avers;
        public System.Windows.Forms.Button updrivelistbtn;
        public System.Windows.Forms.CheckBox inchdd;
        public System.Windows.Forms.Label label51;
        public System.Windows.Forms.ComboBox drive;
        private System.ComponentModel.BackgroundWorker formatworker;
        private System.ComponentModel.BackgroundWorker unpackworker;


    }
}
