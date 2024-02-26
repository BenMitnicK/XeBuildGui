namespace xeBuild_GUI
{
    partial class SMCConfigEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMCConfigEdit));
            this.reloadbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nandfile = new System.Windows.Forms.TextBox();
            this.selectnandbtn = new System.Windows.Forms.Button();
            this.loadnand = new System.Windows.Forms.OpenFileDialog();
            this.checkbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gputemp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rammax = new System.Windows.Forms.TextBox();
            this.gpumax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ramtemp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cpumax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cputemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gpufan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cpufan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dvdregion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gameregion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.videoregion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.macid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // reloadbtn
            // 
            this.reloadbtn.Location = new System.Drawing.Point(12, 68);
            this.reloadbtn.Name = "reloadbtn";
            this.reloadbtn.Size = new System.Drawing.Size(240, 23);
            this.reloadbtn.TabIndex = 0;
            this.reloadbtn.Text = "Get Source from Main window";
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
            this.groupBox2.Text = "Get SMC Config information from";
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
            this.selectnandbtn.Text = "Select nand to use";
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
            // checkbtn
            // 
            this.checkbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkbtn.Enabled = false;
            this.checkbtn.Location = new System.Drawing.Point(12, 251);
            this.checkbtn.Name = "checkbtn";
            this.checkbtn.Size = new System.Drawing.Size(486, 23);
            this.checkbtn.TabIndex = 12;
            this.checkbtn.Text = "Check/Update SMC Config information";
            this.checkbtn.UseVisualStyleBackColor = true;
            this.checkbtn.Click += new System.EventHandler(this.checkbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gputemp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rammax);
            this.groupBox1.Controls.Add(this.gpumax);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ramtemp);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cpumax);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cputemp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.gpufan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cpufan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 71);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thermal (Temperatures and fanspeed)";
            // 
            // gputemp
            // 
            this.gputemp.Location = new System.Drawing.Point(307, 19);
            this.gputemp.Name = "gputemp";
            this.gputemp.ReadOnly = true;
            this.gputemp.Size = new System.Drawing.Size(46, 20);
            this.gputemp.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "GPU Temp:";
            // 
            // rammax
            // 
            this.rammax.Location = new System.Drawing.Point(434, 45);
            this.rammax.Name = "rammax";
            this.rammax.ReadOnly = true;
            this.rammax.Size = new System.Drawing.Size(46, 20);
            this.rammax.TabIndex = 17;
            // 
            // gpumax
            // 
            this.gpumax.Location = new System.Drawing.Point(307, 45);
            this.gpumax.Name = "gpumax";
            this.gpumax.ReadOnly = true;
            this.gpumax.Size = new System.Drawing.Size(46, 20);
            this.gpumax.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(368, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "RAM MAX:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "GPU MAX:";
            // 
            // ramtemp
            // 
            this.ramtemp.Location = new System.Drawing.Point(434, 19);
            this.ramtemp.Name = "ramtemp";
            this.ramtemp.ReadOnly = true;
            this.ramtemp.Size = new System.Drawing.Size(46, 20);
            this.ramtemp.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(364, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "RAM Temp:";
            // 
            // cpumax
            // 
            this.cpumax.Location = new System.Drawing.Point(187, 45);
            this.cpumax.Name = "cpumax";
            this.cpumax.ReadOnly = true;
            this.cpumax.Size = new System.Drawing.Size(46, 20);
            this.cpumax.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "CPU MAX:";
            // 
            // cputemp
            // 
            this.cputemp.Location = new System.Drawing.Point(186, 19);
            this.cputemp.Name = "cputemp";
            this.cputemp.ReadOnly = true;
            this.cputemp.Size = new System.Drawing.Size(46, 20);
            this.cputemp.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CPU Temp:";
            // 
            // gpufan
            // 
            this.gpufan.Location = new System.Drawing.Point(66, 45);
            this.gpufan.Name = "gpufan";
            this.gpufan.ReadOnly = true;
            this.gpufan.Size = new System.Drawing.Size(46, 20);
            this.gpufan.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "GPU Fan:";
            // 
            // cpufan
            // 
            this.cpufan.Location = new System.Drawing.Point(66, 19);
            this.cpufan.Name = "cpufan";
            this.cpufan.ReadOnly = true;
            this.cpufan.Size = new System.Drawing.Size(46, 20);
            this.cpufan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPU Fan:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dvdregion);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.gameregion);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.videoregion);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.macid);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 71);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other information";
            // 
            // dvdregion
            // 
            this.dvdregion.Location = new System.Drawing.Point(314, 45);
            this.dvdregion.Name = "dvdregion";
            this.dvdregion.ReadOnly = true;
            this.dvdregion.Size = new System.Drawing.Size(166, 20);
            this.dvdregion.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(243, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "DVD region:";
            // 
            // gameregion
            // 
            this.gameregion.Location = new System.Drawing.Point(81, 45);
            this.gameregion.Name = "gameregion";
            this.gameregion.ReadOnly = true;
            this.gameregion.Size = new System.Drawing.Size(152, 20);
            this.gameregion.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Game region:";
            // 
            // videoregion
            // 
            this.videoregion.Location = new System.Drawing.Point(314, 19);
            this.videoregion.Name = "videoregion";
            this.videoregion.ReadOnly = true;
            this.videoregion.Size = new System.Drawing.Size(166, 20);
            this.videoregion.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(239, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Video region:";
            // 
            // macid
            // 
            this.macid.Location = new System.Drawing.Point(81, 19);
            this.macid.Name = "macid";
            this.macid.ReadOnly = true;
            this.macid.Size = new System.Drawing.Size(152, 20);
            this.macid.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "MAC Adress:";
            // 
            // SMCConfigEdit
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(510, 286);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkbtn);
            this.Controls.Add(this.selectnandbtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.reloadbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SMCConfigEdit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xeBuild GUI SMC Config Information";
            this.Load += new System.EventHandler(this.SMCConfigEdit_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reloadbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox nandfile;
        private System.Windows.Forms.Button selectnandbtn;
        private System.Windows.Forms.OpenFileDialog loadnand;
        private System.Windows.Forms.Button checkbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox cpumax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cputemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox gpufan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cpufan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gpumax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rammax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ramtemp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox macid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox videoregion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox gameregion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox dvdregion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gputemp;
        private System.Windows.Forms.Label label6;

    }
}

