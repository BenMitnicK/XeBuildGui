using System;
using System.Windows.Forms;


namespace xeBuild_GUI
{
    public partial class ParamEdit : Form
    {
        public ParamEdit() { InitializeComponent(); }
        private void ParamEdit_Load(object sender, EventArgs e)
        {
            oldparam.Text = Main.statc.Builder.param;
            newparam.Text = Main.statc.Builder.param;
        }
        private void runbtn_Click(object sender, EventArgs e)
        {
            Main.statc.Builder.param = newparam.Text;
            Close();
        }
        private void abortbtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ParamEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            build.runit = true;
        }
    }
}