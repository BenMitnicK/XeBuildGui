using System;
using System.Windows.Forms;
using System.IO;

namespace xeBuild_GUI
{
    public partial class outtab : UserControl
    {
        public static RichTextBox rtb;
        public outtab() 
        {
            InitializeComponent();
            rtb = outputlog;
        }
        private void resetbtn_Click(object sender, EventArgs e) { outtab.rtb.Text = ""; }
        private void savebtn_Click(object sender, EventArgs e)
        {
            savelog.InitialDirectory = Main.dir;
            DialogResult res = savelog.ShowDialog();
            if (res == DialogResult.OK)
            {
                if (!logsave(savelog.FileName))
                {
                    MessageBox.Show("ERROR: There was an error when trying to save your log!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            savelog.FileName = "xeBuild_GUI.log";
        }
        public static bool logsave(string saveloc)
        {
            try
            {
                string[] oldlines = new string[1];
                if (File.Exists(saveloc))
                {
                    oldlines = File.ReadAllLines(saveloc);
                }
                using (StreamWriter sw = new StreamWriter(saveloc))
                {
                    foreach (string line in outtab.rtb.Lines)
                    {
                        sw.WriteLine(line);
                    }
                    foreach (string line in oldlines)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                }
                return true;
            }
            catch { return false; }
        }
        private void outputlog_TextChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = (outputlog.Text.Length > 0);
        }
    }
}