namespace xeBuild_GUI
{
    partial class ParamEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParamEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.oldparam = new System.Windows.Forms.TextBox();
            this.newparam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.abortbtn = new System.Windows.Forms.Button();
            this.runbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original Parameter:";
            // 
            // oldparam
            // 
            this.oldparam.Location = new System.Drawing.Point(114, 12);
            this.oldparam.Name = "oldparam";
            this.oldparam.ReadOnly = true;
            this.oldparam.Size = new System.Drawing.Size(830, 20);
            this.oldparam.TabIndex = 1;
            // 
            // newparam
            // 
            this.newparam.Location = new System.Drawing.Point(114, 38);
            this.newparam.Name = "newparam";
            this.newparam.Size = new System.Drawing.Size(830, 20);
            this.newparam.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Parameter:";
            // 
            // abortbtn
            // 
            this.abortbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.abortbtn.Location = new System.Drawing.Point(15, 64);
            this.abortbtn.Name = "abortbtn";
            this.abortbtn.Size = new System.Drawing.Size(445, 42);
            this.abortbtn.TabIndex = 4;
            this.abortbtn.Text = "Cancel/Abort";
            this.abortbtn.UseVisualStyleBackColor = true;
            this.abortbtn.Click += new System.EventHandler(this.abortbtn_Click);
            // 
            // runbtn
            // 
            this.runbtn.Location = new System.Drawing.Point(466, 64);
            this.runbtn.Name = "runbtn";
            this.runbtn.Size = new System.Drawing.Size(478, 42);
            this.runbtn.TabIndex = 5;
            this.runbtn.Text = "Save the new parameters and run xeBuild/Python";
            this.runbtn.UseVisualStyleBackColor = true;
            this.runbtn.Click += new System.EventHandler(this.runbtn_Click);
            // 
            // ParamEdit
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CancelButton = this.abortbtn;
            this.ClientSize = new System.Drawing.Size(956, 118);
            this.Controls.Add(this.runbtn);
            this.Controls.Add(this.abortbtn);
            this.Controls.Add(this.newparam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldparam);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParamEdit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xeBuild GUI Parameter/Argument Editor";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParamEdit_FormClosing);
            this.Load += new System.EventHandler(this.ParamEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox oldparam;
        private System.Windows.Forms.TextBox newparam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button abortbtn;
        private System.Windows.Forms.Button runbtn;

    }
}

