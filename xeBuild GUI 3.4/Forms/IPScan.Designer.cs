namespace xeBuild_GUI
{
    partial class IPScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPScan));
            this.label1 = new System.Windows.Forms.Label();
            this.fromip = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toip = new System.Windows.Forms.TextBox();
            this.startscanbtn = new System.Windows.Forms.Button();
            this.progbar = new ProgressBarEx();
            this.getipbtn = new System.Windows.Forms.Button();
            this.baseipbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statustxt = new System.Windows.Forms.TextBox();
            this.timeout = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan from:";
            // 
            // fromip
            // 
            this.fromip.Location = new System.Drawing.Point(76, 19);
            this.fromip.MaxLength = 3;
            this.fromip.Name = "fromip";
            this.fromip.Size = new System.Drawing.Size(63, 20);
            this.fromip.TabIndex = 1;
            this.fromip.Text = "10";
            this.fromip.TextChanged += new System.EventHandler(this.testempty);
            this.fromip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.toip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fromip);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scan Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scan to:";
            // 
            // toip
            // 
            this.toip.Location = new System.Drawing.Point(198, 19);
            this.toip.MaxLength = 3;
            this.toip.Name = "toip";
            this.toip.Size = new System.Drawing.Size(63, 20);
            this.toip.TabIndex = 3;
            this.toip.Text = "100";
            this.toip.TextChanged += new System.EventHandler(this.testempty);
            this.toip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric);
            // 
            // startscanbtn
            // 
            this.startscanbtn.Location = new System.Drawing.Point(160, 99);
            this.startscanbtn.Name = "startscanbtn";
            this.startscanbtn.Size = new System.Drawing.Size(130, 23);
            this.startscanbtn.TabIndex = 3;
            this.startscanbtn.Text = "Start scanning for Xell";
            this.startscanbtn.UseVisualStyleBackColor = true;
            this.startscanbtn.Click += new System.EventHandler(this.startscanbtn_Click);
            // 
            // progbar
            // 
            this.progbar.Location = new System.Drawing.Point(11, 128);
            this.progbar.Name = "progbar";
            this.progbar.Size = new System.Drawing.Size(278, 23);
            this.progbar.TabIndex = 4;
            // 
            // getipbtn
            // 
            this.getipbtn.Location = new System.Drawing.Point(160, 71);
            this.getipbtn.Name = "getipbtn";
            this.getipbtn.Size = new System.Drawing.Size(130, 23);
            this.getipbtn.TabIndex = 15;
            this.getipbtn.Text = "Get base IP";
            this.getipbtn.UseVisualStyleBackColor = true;
            this.getipbtn.Click += new System.EventHandler(this.getipbtn_Click);
            // 
            // baseipbox
            // 
            this.baseipbox.Location = new System.Drawing.Point(61, 73);
            this.baseipbox.MaxLength = 12;
            this.baseipbox.Name = "baseipbox";
            this.baseipbox.Size = new System.Drawing.Size(90, 20);
            this.baseipbox.TabIndex = 14;
            this.baseipbox.TextChanged += new System.EventHandler(this.baseipbox_TextChanged);
            this.baseipbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipinput);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Base IP:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.statustxt);
            this.groupBox2.Location = new System.Drawing.Point(11, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 48);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // statustxt
            // 
            this.statustxt.Location = new System.Drawing.Point(6, 19);
            this.statustxt.Name = "statustxt";
            this.statustxt.ReadOnly = true;
            this.statustxt.Size = new System.Drawing.Size(266, 20);
            this.statustxt.TabIndex = 0;
            // 
            // timeout
            // 
            this.timeout.Location = new System.Drawing.Point(86, 101);
            this.timeout.MaxLength = 4;
            this.timeout.Name = "timeout";
            this.timeout.Size = new System.Drawing.Size(65, 20);
            this.timeout.TabIndex = 18;
            this.timeout.Text = "200";
            this.timeout.TextChanged += new System.EventHandler(this.testempty);
            this.timeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Ping Timeout:";
            // 
            // IPScan
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(302, 216);
            this.Controls.Add(this.timeout);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.getipbtn);
            this.Controls.Add(this.baseipbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progbar);
            this.Controls.Add(this.startscanbtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPScan";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xeBuild GUI IPScan";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IPScan_FormClosing);
            this.Load += new System.EventHandler(this.IPScan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fromip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox toip;
        private System.Windows.Forms.Button startscanbtn;
        private ProgressBarEx progbar;
        private System.Windows.Forms.Button getipbtn;
        public System.Windows.Forms.TextBox baseipbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox statustxt;
        public System.Windows.Forms.TextBox timeout;
        private System.Windows.Forms.Label label4;
    }
}

