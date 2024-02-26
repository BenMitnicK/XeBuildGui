using System;
using System.IO;
using System.Windows.Forms;
using xeBuild_GUI.x360utils.NAND;


namespace xeBuild_GUI
{
    public partial class SMCConfigEdit : Form
    {
        public SMCConfigEdit() { InitializeComponent(); }
        private void SMCConfigEdit_Load(object sender, EventArgs e) 
        {
            nandfile.Text = Main.statc.source.Text;
            checkbtn_Click(sender, e);
        }
        private void reloadbtn_Click(object sender, EventArgs e) { SMCConfigEdit_Load(sender, e); }
        private void selectnandbtn_Click(object sender, EventArgs e)
        {
            if (loadnand.ShowDialog() == DialogResult.OK)
            {
                nandfile.Text = loadnand.FileName;
                checkbtn_Click(sender, e);
            }
            loadnand.FileName = Path.GetFileName(loadnand.FileName);
        }
        private void nandfile_TextChanged(object sender, EventArgs e) { checkbtn.Enabled = (!string.IsNullOrEmpty(nandfile.Text)); }
        private readonly X360NAND _x360NAND = new X360NAND();
        private void checkbtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(nandfile.Text))
            {
                FileInfo fi = new FileInfo(nandfile.Text);
                if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                {
                    byte[] conf = Main.nand.dump_conf(nandfile.Text);
                    cpufan.Text = (conf[0x11] & 127).ToString() + "%";
                    if (cpufan.Text == "0%") { cpufan.Text = "AUTO"; }
                    else if (cpufan.Text == "127%") { cpufan.Text = "AUTO"; }
                    gpufan.Text = (conf[0x12] & 127).ToString() + "%";
                    if (gpufan.Text == "0%") { gpufan.Text = "AUTO"; }
                    else if (gpufan.Text == "127%") { gpufan.Text = "AUTO"; }
                    cputemp.Text = conf[0x29].ToString() + "°C";
                    gputemp.Text = conf[0x2A].ToString() + "°C";
                    ramtemp.Text = conf[0x2B].ToString() + "°C";
                    cpumax.Text = conf[0x2C].ToString() + "°C";
                    gpumax.Text = conf[0x2D].ToString() + "°C";
                    rammax.Text = conf[0x2E].ToString() + "°C";
                    macid.Text = conf[0x220].ToString("X2") + ":" + conf[0x221].ToString("X2") + ":" + conf[0x222].ToString("X2") + ":" +
                        conf[0x223].ToString("X2") + ":" + conf[0x224].ToString("X2") + ":" + conf[0x225].ToString("X2");
                    UInt16 vidregion = Main.misc.swap16(BitConverter.ToUInt16(conf, 0x22A));
                    if (vidregion == 0x300) { videoregion.Text = "PAL (0x300)"; }
                    else if (vidregion == 0x100) { videoregion.Text = "NTSC (0x100)"; }
                    else { videoregion.Text = "Unkown (0x" + vidregion.ToString("X3") + ")"; }
                    gameregion.Text = Main.misc.translateregion("0x" + conf[0x22C].ToString("X2") + conf[0x22D].ToString("X2")) + "(0x" + conf[0x22C].ToString("X2") + conf[0x22D].ToString("X2") + ")";
                    dvdregion.Text = Main.misc.translatedvd(conf[0x237]);
                }
                else
                {
                    using (var _reader = new NANDReader(nandfile.Text))
                    {
                        var cfg = _x360NAND.GetSmcConfig(_reader);
                        var config = new SmcConfig();
                        dvdregion.Text = config.GetDVDRegion(ref cfg);
                        cpufan.Text = config.GetFanSpeed(ref cfg, SmcConfig.SmcConfigFans.Cpu);
                        gpufan.Text = config.GetFanSpeed(ref cfg, SmcConfig.SmcConfigFans.Gpu);
                        gameregion.Text = config.GetGameRegion(ref cfg);
                        macid.Text = config.GetMACAdress(ref cfg);
                        cputemp.Text = config.GetTempString(ref cfg, SmcConfig.SmcConfigTemps.Cpu);
                        cpumax.Text = config.GetTempString(ref cfg, SmcConfig.SmcConfigTemps.CpuMax);
                        gputemp.Text = config.GetTempString(ref cfg, SmcConfig.SmcConfigTemps.Gpu);
                        gpumax.Text = config.GetTempString(ref cfg, SmcConfig.SmcConfigTemps.GpuMax);
                        ramtemp.Text = config.GetTempString(ref cfg, SmcConfig.SmcConfigTemps.Ram);
                        rammax.Text = config.GetTempString(ref cfg, SmcConfig.SmcConfigTemps.RamMax);
                        videoregion.Text = config.GetVideoRegion(ref cfg);
                    }
                }
            }
        }
    }
}