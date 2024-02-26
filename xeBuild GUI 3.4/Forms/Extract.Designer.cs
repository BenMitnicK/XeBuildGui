namespace xeBuild_GUI
{
    partial class Extract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Extract));
            this.reloadbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cpukey = new System.Windows.Forms.TextBox();
            this.encsmcbtn = new System.Windows.Forms.Button();
            this.decsmcbtn = new System.Windows.Forms.Button();
            this.deckvbtn = new System.Windows.Forms.Button();
            this.enckvbtn = new System.Windows.Forms.Button();
            this.confbtn = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.SaveFileDialog();
            this.fcrtbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nandfile = new System.Windows.Forms.TextBox();
            this.enccbbtn = new System.Windows.Forms.Button();
            this.deccbbtn = new System.Windows.Forms.Button();
            this.deccfbtn = new System.Windows.Forms.Button();
            this.enccfbtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.blkey = new System.Windows.Forms.TextBox();
            this.selectnandbtn = new System.Windows.Forms.Button();
            this.select = new System.Windows.Forms.OpenFileDialog();
            this.corona4gbtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // reloadbtn
            // 
            this.reloadbtn.Location = new System.Drawing.Point(12, 124);
            this.reloadbtn.Name = "reloadbtn";
            this.reloadbtn.Size = new System.Drawing.Size(240, 23);
            this.reloadbtn.TabIndex = 0;
            this.reloadbtn.Text = "Get Source/Keys from Main window";
            this.reloadbtn.UseVisualStyleBackColor = true;
            this.reloadbtn.Click += new System.EventHandler(this.reloadbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cpukey);
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPUKey";
            // 
            // cpukey
            // 
            this.cpukey.Location = new System.Drawing.Point(10, 19);
            this.cpukey.MaxLength = 32;
            this.cpukey.Name = "cpukey";
            this.cpukey.Size = new System.Drawing.Size(221, 20);
            this.cpukey.TabIndex = 2;
            this.cpukey.TextChanged += new System.EventHandler(this.cpukey_TextChanged);
            this.cpukey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctrlfix);
            this.cpukey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hexinput);
            // 
            // encsmcbtn
            // 
            this.encsmcbtn.Enabled = false;
            this.encsmcbtn.Location = new System.Drawing.Point(12, 153);
            this.encsmcbtn.Name = "encsmcbtn";
            this.encsmcbtn.Size = new System.Drawing.Size(240, 23);
            this.encsmcbtn.TabIndex = 2;
            this.encsmcbtn.Text = "Save Encrypted SMC";
            this.encsmcbtn.UseVisualStyleBackColor = true;
            this.encsmcbtn.Click += new System.EventHandler(this.encsmcbtn_Click);
            // 
            // decsmcbtn
            // 
            this.decsmcbtn.Enabled = false;
            this.decsmcbtn.Location = new System.Drawing.Point(258, 153);
            this.decsmcbtn.Name = "decsmcbtn";
            this.decsmcbtn.Size = new System.Drawing.Size(240, 23);
            this.decsmcbtn.TabIndex = 3;
            this.decsmcbtn.Text = "Save Decrypted SMC";
            this.decsmcbtn.UseVisualStyleBackColor = true;
            this.decsmcbtn.Click += new System.EventHandler(this.decsmcbtn_Click);
            // 
            // deckvbtn
            // 
            this.deckvbtn.Enabled = false;
            this.deckvbtn.Location = new System.Drawing.Point(258, 182);
            this.deckvbtn.Name = "deckvbtn";
            this.deckvbtn.Size = new System.Drawing.Size(240, 23);
            this.deckvbtn.TabIndex = 4;
            this.deckvbtn.Text = "Save Decrypted Keyvault";
            this.deckvbtn.UseVisualStyleBackColor = true;
            this.deckvbtn.Click += new System.EventHandler(this.deckvbtn_Click);
            // 
            // enckvbtn
            // 
            this.enckvbtn.Enabled = false;
            this.enckvbtn.Location = new System.Drawing.Point(12, 182);
            this.enckvbtn.Name = "enckvbtn";
            this.enckvbtn.Size = new System.Drawing.Size(240, 23);
            this.enckvbtn.TabIndex = 5;
            this.enckvbtn.Text = "Save Encrypted Keyvault";
            this.enckvbtn.UseVisualStyleBackColor = true;
            this.enckvbtn.Click += new System.EventHandler(this.enckvbtn_Click);
            // 
            // confbtn
            // 
            this.confbtn.Enabled = false;
            this.confbtn.Location = new System.Drawing.Point(12, 211);
            this.confbtn.Name = "confbtn";
            this.confbtn.Size = new System.Drawing.Size(486, 23);
            this.confbtn.TabIndex = 6;
            this.confbtn.Text = "Save SMC Config";
            this.confbtn.UseVisualStyleBackColor = true;
            this.confbtn.Click += new System.EventHandler(this.confbtn_Click);
            // 
            // save
            // 
            this.save.FileName = "Binary files|*.bin|All Files|*.*";
            // 
            // fcrtbtn
            // 
            this.fcrtbtn.Enabled = false;
            this.fcrtbtn.Location = new System.Drawing.Point(12, 269);
            this.fcrtbtn.Name = "fcrtbtn";
            this.fcrtbtn.Size = new System.Drawing.Size(486, 23);
            this.fcrtbtn.TabIndex = 6;
            this.fcrtbtn.Text = "Save FCRT.bin (NOTE: Only works on Trinity)";
            this.fcrtbtn.UseVisualStyleBackColor = true;
            this.fcrtbtn.Click += new System.EventHandler(this.fcrtbtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nandfile);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 50);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extract from";
            // 
            // nandfile
            // 
            this.nandfile.Location = new System.Drawing.Point(10, 19);
            this.nandfile.MaxLength = 32;
            this.nandfile.Name = "nandfile";
            this.nandfile.Size = new System.Drawing.Size(470, 20);
            this.nandfile.TabIndex = 2;
            this.nandfile.TextChanged += new System.EventHandler(this.nandfile_TextChanged);
            // 
            // enccbbtn
            // 
            this.enccbbtn.Enabled = false;
            this.enccbbtn.Location = new System.Drawing.Point(12, 298);
            this.enccbbtn.Name = "enccbbtn";
            this.enccbbtn.Size = new System.Drawing.Size(240, 23);
            this.enccbbtn.TabIndex = 7;
            this.enccbbtn.Text = "Extract Encrypted CB";
            this.enccbbtn.UseVisualStyleBackColor = true;
            this.enccbbtn.Click += new System.EventHandler(this.enccbbtn_Click);
            // 
            // deccbbtn
            // 
            this.deccbbtn.Enabled = false;
            this.deccbbtn.Location = new System.Drawing.Point(258, 298);
            this.deccbbtn.Name = "deccbbtn";
            this.deccbbtn.Size = new System.Drawing.Size(240, 23);
            this.deccbbtn.TabIndex = 8;
            this.deccbbtn.Text = "Extract Decrypted CB";
            this.deccbbtn.UseVisualStyleBackColor = true;
            this.deccbbtn.Click += new System.EventHandler(this.deccbbtn_Click);
            // 
            // deccfbtn
            // 
            this.deccfbtn.Enabled = false;
            this.deccfbtn.Location = new System.Drawing.Point(258, 327);
            this.deccfbtn.Name = "deccfbtn";
            this.deccfbtn.Size = new System.Drawing.Size(240, 23);
            this.deccfbtn.TabIndex = 10;
            this.deccfbtn.Text = "Extract Decrypted CF";
            this.deccfbtn.UseVisualStyleBackColor = true;
            this.deccfbtn.Click += new System.EventHandler(this.deccfbtn_Click);
            // 
            // enccfbtn
            // 
            this.enccfbtn.Enabled = false;
            this.enccfbtn.Location = new System.Drawing.Point(12, 327);
            this.enccfbtn.Name = "enccfbtn";
            this.enccfbtn.Size = new System.Drawing.Size(240, 23);
            this.enccfbtn.TabIndex = 9;
            this.enccfbtn.Text = "Extract Encrypted CF";
            this.enccfbtn.UseVisualStyleBackColor = true;
            this.enccfbtn.Click += new System.EventHandler(this.enccfbtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.blkey);
            this.groupBox3.Location = new System.Drawing.Point(258, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 50);
            this.groupBox3.TabIndex = 3;
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
            this.blkey.Leave += new System.EventHandler(this.blkey_leave);
            // 
            // selectnandbtn
            // 
            this.selectnandbtn.Location = new System.Drawing.Point(258, 124);
            this.selectnandbtn.Name = "selectnandbtn";
            this.selectnandbtn.Size = new System.Drawing.Size(240, 23);
            this.selectnandbtn.TabIndex = 11;
            this.selectnandbtn.Text = "Select nand to use";
            this.selectnandbtn.UseVisualStyleBackColor = true;
            this.selectnandbtn.Click += new System.EventHandler(this.selectnandbtn_Click);
            // 
            // select
            // 
            this.select.DefaultExt = "bin";
            this.select.FileName = "nand.bin";
            this.select.Filter = "Xbox 360 Nand|*.bin|All Files|*.*";
            this.select.Title = "Select nand to extract from";
            // 
            // corona4gbtn
            // 
            this.corona4gbtn.Enabled = false;
            this.corona4gbtn.Location = new System.Drawing.Point(12, 240);
            this.corona4gbtn.Name = "corona4gbtn";
            this.corona4gbtn.Size = new System.Drawing.Size(486, 23);
            this.corona4gbtn.TabIndex = 12;
            this.corona4gbtn.Text = "Extract Corona4g Files";
            this.corona4gbtn.UseVisualStyleBackColor = true;
            this.corona4gbtn.Click += new System.EventHandler(this.corona4gbtn_Click);
            // 
            // Extract
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(510, 362);
            this.Controls.Add(this.corona4gbtn);
            this.Controls.Add(this.selectnandbtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.deccfbtn);
            this.Controls.Add(this.enccfbtn);
            this.Controls.Add(this.deccbbtn);
            this.Controls.Add(this.enccbbtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.fcrtbtn);
            this.Controls.Add(this.confbtn);
            this.Controls.Add(this.enckvbtn);
            this.Controls.Add(this.deckvbtn);
            this.Controls.Add(this.decsmcbtn);
            this.Controls.Add(this.encsmcbtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reloadbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Extract";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xeBuild GUI Extract";
            this.Load += new System.EventHandler(this.Extract_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Extract_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Extract_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox cpukey;
        private System.Windows.Forms.Button encsmcbtn;
        private System.Windows.Forms.Button decsmcbtn;
        private System.Windows.Forms.Button deckvbtn;
        private System.Windows.Forms.Button enckvbtn;
        private System.Windows.Forms.Button confbtn;
        private System.Windows.Forms.Button reloadbtn;
        private System.Windows.Forms.SaveFileDialog save;
        private System.Windows.Forms.Button fcrtbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox nandfile;
        private System.Windows.Forms.Button enccbbtn;
        private System.Windows.Forms.Button deccbbtn;
        private System.Windows.Forms.Button deccfbtn;
        private System.Windows.Forms.Button enccfbtn;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox blkey;
        private System.Windows.Forms.Button selectnandbtn;
        private System.Windows.Forms.OpenFileDialog select;
        public System.Windows.Forms.Button corona4gbtn;

    }
}

