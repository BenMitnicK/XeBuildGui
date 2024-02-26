namespace xeBuild_GUI
{
    partial class outtab
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
            this.savebtn = new System.Windows.Forms.Button();
            this.resetbtn = new System.Windows.Forms.Button();
            this.outputlog = new System.Windows.Forms.RichTextBox();
            this.savelog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // savebtn
            // 
            this.savebtn.Enabled = false;
            this.savebtn.Location = new System.Drawing.Point(269, 491);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(208, 54);
            this.savebtn.TabIndex = 70;
            this.savebtn.Text = "Save Output log";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // resetbtn
            // 
            this.resetbtn.Location = new System.Drawing.Point(3, 491);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(208, 54);
            this.resetbtn.TabIndex = 71;
            this.resetbtn.Text = "Reset/Clear output log";
            this.resetbtn.UseVisualStyleBackColor = true;
            this.resetbtn.Click += new System.EventHandler(this.resetbtn_Click);
            // 
            // outputlog
            // 
            this.outputlog.Dock = System.Windows.Forms.DockStyle.Top;
            this.outputlog.Location = new System.Drawing.Point(0, 0);
            this.outputlog.Name = "outputlog";
            this.outputlog.ReadOnly = true;
            this.outputlog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.outputlog.Size = new System.Drawing.Size(480, 485);
            this.outputlog.TabIndex = 72;
            this.outputlog.Text = "";
            this.outputlog.WordWrap = false;
            this.outputlog.TextChanged += new System.EventHandler(this.outputlog_TextChanged);
            // 
            // savelog
            // 
            this.savelog.AddExtension = false;
            this.savelog.DefaultExt = "log";
            this.savelog.FileName = "xeBuild_GUI";
            this.savelog.Filter = "Log files|*.log|Text files|*.txt|All files|*.*";
            this.savelog.Title = "Choose where to save your xeBuild GUI log";
            // 
            // outtab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.outputlog);
            this.Controls.Add(this.resetbtn);
            this.Controls.Add(this.savebtn);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "outtab";
            this.Size = new System.Drawing.Size(480, 548);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button resetbtn;
        private System.Windows.Forms.RichTextBox outputlog;
        private System.Windows.Forms.SaveFileDialog savelog;




    }
}
