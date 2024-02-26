using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace xeBuild_GUI
{
    class Checks
    {
        public void hexinput(object sender, KeyPressEventArgs e) { if (e.KeyChar != '\b') e.Handled = !Uri.IsHexDigit(e.KeyChar); }
        public void macinput(object sender, KeyPressEventArgs e) { if ((e.KeyChar != '\b') && (e.KeyChar != ':')) e.Handled = !Uri.IsHexDigit(e.KeyChar); }
        public void numinput(object sender, KeyPressEventArgs e) { if ((e.KeyChar != '\b') && (e.KeyChar < 48 || e.KeyChar > 57)) e.Handled = true; }
        public void ipinput(object sender, KeyPressEventArgs e) { if ((e.KeyChar != '\b') && (e.KeyChar != '.') && (e.KeyChar < 48 || e.KeyChar > 57)) e.Handled = true; }
        public void ctrlfix(object sender, KeyEventArgs e)
        {
            if (sender is TextBox)
            {
                if (e.KeyData == (Keys.Control | Keys.V)) { (sender as TextBox).Paste(); }
                else if (e.KeyData == (Keys.Control | Keys.A)) { (sender as TextBox).SelectAll(); }
                else if (e.KeyData == (Keys.Control | Keys.X)) { (sender as TextBox).Cut(); }
                else if (e.KeyData == (Keys.Control | Keys.C)) { (sender as TextBox).Copy(); }
            }
        }
        public bool keycheck(string key)
        {
            if (key != null)
            {
                key = key.Trim();
                bool ret = false;
                if (key.Length < 32) { MessageBox.Show("ERROR: Invalid input, to short!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else if (key.Length == 32)
                {
                    string strHex = String.Concat("[0-9A-Fa-f]{", key.Length, "}");
                    ret = Regex.IsMatch(key, strHex);
                    if (!ret) { MessageBox.Show("ERROR: Invalid input, invalid characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBox.Show("ERROR: Invalid input, to long!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                return ret;
            }
            else { return false; }
        }
        public bool maccheck(string adress)
        {
            if (!String.IsNullOrEmpty(adress)) { return Regex.IsMatch(adress, "^([0-9a-fA-F][0-9a-fA-F]:){5}([0-9a-fA-F][0-9a-fA-F])$"); }
            else { return false; }
        }
        public string cbtranslate(int cb, string source)
        {
            switch (cb)
            {
                case 1888:
                case 1902:
                case 1903:
                case 1920:
                case 1921:
                case 1923:
                case 1940:
                case 7375:
                    return "Xenon";
                case 4558:
                case 4559:
                case 4560:
                case 4561:
                case 4562:
                case 4569:
                case 4570:
                case 4571:
                case 4572:
                case 4574:
                case 4575:
                case 4577:
                case 4578:
                case 4579:
                case 4580:
                    return "Zephyr";
                case 5761:
                case 5766:
                case 5770:
                case 5771:
                case 5772:
                case 5773:
                case 5774:
                    return "Falcon/Opus";
                case 6712:
                case 6723:
                case 6750:
                case 6751:
                case 6752:
                case 6753:
                case 6754:
                    var fi = new FileInfo(source);
                    switch (fi.Length)
                    {
                        case 17301504:
                            return "Jasper 16MB";
                        case 69206016:
                            return "Jasper BB";
                        case 276824064:
                            return "Jasper BB (256MB)";
                        case 553648128:
                            return "Jasper BB (512MB)";
                        default:
                            return "Unknown";
                    }
                case 9188:
                case 9230:
                case 9231:
                    return "Trinity";
                case 13121:
                case 13180:
                case 13181:
                case 13182:
                    //return "Corona";
                    var fi2 = new FileInfo(source);
                    if (fi2.Length == 17301504)
                    {
                        return "Corona";
                    }
                    else
                    {
                        return "Corona4g";
                    }
                default:
                    return "Unkown";
            }
        }
        public string smctype(byte[] smcdata)
        {
            string ret = "Unkown";
            for (int i = 0; i < smcdata.Length - 6; i++)
            {
                if (smcdata[i] == 0x05)
                {
                    if ((smcdata[i + 2] == 0xE5) && (smcdata[i + 4] == 0xB4) && (smcdata[i + 5] == 0x05))
                    {
                        ret = "Retail";
                    }
                }
                else if (smcdata[i] == 0x00)
                {
                    if ((smcdata[i + 1] == 0x00) && (smcdata[i + 2] == 0xE5) && (smcdata[i + 4] == 0xB4) && (smcdata[i + 5] == 0x05))
                    {
                        ret = "Glitch";
                    }
                }
                else if (smcdata[i] == 0x78)
                {
                    if ((smcdata[i + 1] == 0xBA) && (smcdata[i + 2] == 0xB6))
                    {
                        ret = "Cygnos";
                    }
                }
                else if (smcdata[i] == 0xD0)
                {
                    if ((smcdata[i + 1] == 0x00) && (smcdata[i + 2] == 0x00) && (smcdata[i + 3] == 0x1B))
                    {
                        ret = "JTAG";
                    }
                }                
            }
            return ret;
        }
        public string[] patchcheck(string smc)
        {
            string[] ret = new string[4];
            ret[0] = "Unkown";
            ret[1] = "N/A";
            ret[2] = "N/A";
            ProcessStartInfo smc_util = new ProcessStartInfo();
            smc_util.FileName = Main.dir + "\\files\\smc_util.exe";
            smc_util.Arguments = "analysis temp\\smc.bin";
            smc_util.UseShellExecute = false;
            smc_util.RedirectStandardOutput = true;
            smc_util.CreateNoWindow = true;
            smc_util.RedirectStandardError = true;
            smc_util.WorkingDirectory = Main.dir + "\\files\\";
            if (!File.Exists(Main.dir + "\\files\\smc_util.exe"))
            {
                FileInfo exe = new FileInfo(Main.dir + "\\files\\smc_util.exe");
                FileStream toexe = exe.OpenWrite();
                Stream fromexe = Main.app.GetManifestResourceStream("xeBuild_GUI.Embedded.smc_util.exe");
                const int size = 4096;
                byte[] bytes = new byte[size];
                int numBytes;
                while ((numBytes = fromexe.Read(bytes, 0, size)) > 0)
                {
                    toexe.Write(bytes, 0, numBytes);
                }
                toexe.Close();
                fromexe.Close();
            }
            if (!File.Exists(Main.dir + "\\files\\smc_util.ini"))
            {
                FileInfo ini = new FileInfo(Main.dir + "\\files\\smc_util.ini");
                FileStream toini = ini.OpenWrite();
                Stream fromini = Main.app.GetManifestResourceStream("xeBuild_GUI.Embedded.smc_util.ini");
                const int size = 4096;
                byte[] bytes = new byte[size];
                int numBytes;
                while ((numBytes = fromini.Read(bytes, 0, size)) > 0)
                {
                    toini.Write(bytes, 0, numBytes);
                }
                toini.Close();
                fromini.Close();
            }
            using (Process smc_utiler = Process.Start(smc_util))
            {
                using (StreamReader smc_utilread = smc_utiler.StandardOutput)
                {
                    string message = "";
                    while (message != null)
                    {
                        message = smc_utilread.ReadLine();
                        if (message != null && message != "")
                        {
                            if (message.StartsWith("TMS_PATCH:"))
                            {
                                string[] messages = message.Split(':');
                                message = messages[messages.Length - 1];
                                if (!message.EndsWith("not found"))
                                {
                                    message = message.Remove(0, message.Length - 4);
                                }
                                else
                                {
                                    message = "N/A";
                                }
                                ret[1] = message;
                            }
                            else if (message.StartsWith("TDI_PATCH_0_of_3:"))
                            {
                                string[] messages = message.Split(':');
                                message = messages[messages.Length - 1];
                                if (!message.EndsWith("not found"))
                                {
                                    message = message.Remove(0, message.Length - 4);
                                }
                                else
                                {
                                    message = "N/A";
                                }
                                ret[2] = message;
                            }
                            else if (message.StartsWith("SMC Version:"))
                            {
                                string[] messages = message.Split(':');
                                message = messages[1];
                                ret[3] = message;
                            }
                        }
                    }
                }
            }
            if ((ret[1] == "0x83") && (ret[2] == "0xC0"))
            {
                ret[0] = "Normal";
            }
            else if ((ret[1] == "N/A") && (ret[2] == "0xC0"))
            {
                ret[0] = "Normal";
            }
            else if ((ret[1] == "0xCC") && (ret[2] == "0xC0"))
            {
                ret[0] = "Aud_clamp";
            }
            else if ((ret[1] == "0xCC") && (ret[2] == "0xCF"))
            {
                ret[0] = "Aud_clamp + Eject";
            }
            else
            {
                ret[0] = "Unkown";
            }
            return ret;
        }
        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }
        public string getpirsversion(string file)
        {
            using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
            {
                if ((int)br.BaseStream.Length > 0x344)
                {
                    byte[] initheader = br.ReadBytes(0x344);
                    if (Main.misc.swap32(BitConverter.ToUInt32(initheader, 0)) == 0x50495253)
                    {
                        UInt32 headersize = Main.misc.swap32(BitConverter.ToUInt32(initheader, 0x340));
                        byte[] header = new byte[headersize];
                        byte[] headermeta = br.ReadBytes((int)headersize - 0x344);
                        Array.Copy(initheader, 0, header, 0, 0x344);
                        Array.Copy(headermeta, 0, header, 0x344, headersize - 0x344);
                        if (Main.misc.swap32(BitConverter.ToUInt32(header, 0x971A)) == 0x53555044) { return Main.misc.swap16(BitConverter.ToUInt16(header, 0x971A + 9)).ToString(); }
                        else
                        {
                            string installertype = "Unknown installer type";
                            if (Main.misc.swap32(BitConverter.ToUInt32(header, 0x971A)) == 0x54555044) { installertype = "Title update"; }
                            else if (Main.misc.swap32(BitConverter.ToUInt32(header, 0x971A)) == 0x50245044) { installertype = "Progress cache package download"; }
                            else if (Main.misc.swap32(BitConverter.ToUInt32(header, 0x971A)) == 0x50245355) { installertype = "Progress cache system update"; }
                            else if (Main.misc.swap32(BitConverter.ToUInt32(header, 0x971A)) == 0x50245455) { installertype = "Progress cache title update"; }
                            else if (Main.misc.swap32(BitConverter.ToUInt32(header, 0x971A)) == 0x50245443) { installertype = "Progress cache title content"; }
                            MessageBox.Show("ERROR: Installer doesn't seem to be a system update installer, it's a: " + installertype, "ERROR - Wrong installer type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return "";
                        }
                    }
                    else
                    {
                        string type = "Unkown container type";
                        if (Main.misc.swap32(BitConverter.ToUInt32(initheader, 0)) == 0x434F4E20) { type = "CON"; }
                        else if (Main.misc.swap32(BitConverter.ToUInt32(initheader, 0)) == 0x4C495645) { type = "LIVE"; }
                        MessageBox.Show("ERROR: Container is not expected type (PIRS) it's a: " + type, "ERROR - Wrong type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: File is to small to be a system update PIRS file!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
        }
    }
}