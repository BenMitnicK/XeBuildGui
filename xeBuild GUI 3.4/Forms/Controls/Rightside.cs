using System.Windows.Forms;

namespace xeBuild_GUI
{
    public partial class Right : UserControl
    {
        public TabPage maintab = new TabPage(), dwl = new TabPage(), xetab = new TabPage(),
            dlaunch = new TabPage(), logtab = new TabPage();
        public Right()
        {
            InitializeComponent();
        }
        public void init()
        {
            maintab.Controls.Add(Main.mright);
            maintab.Text = "Main";
            dwl.Controls.Add(Main.download);
            dwl.Text = "Download";
            //dlaunch.Controls.Add(Main.dlc);
            //dlaunch.Text = "Dashlaunch";
            xetab.Controls.Add(Main.xeset);
            xetab.Text = "xeBuild Settings";
            logtab.Controls.Add(Main.log);
            logtab.Text = "Output";
            load();
        }
        public void load()
        {
            Main.tabc.TabPages.Add(maintab);
            Main.tabc.TabPages.Add(dwl);            
            if (!Main.ezmode)
            {
                //Main.tabc.TabPages.Add(dlaunch);
                Main.tabc.TabPages.Add(xetab);
            }
            Main.tabc.TabPages.Add(logtab);
        }
        public void reload()
        {
            Main.tabc.TabPages.Clear();
            load();
        }
    }
}