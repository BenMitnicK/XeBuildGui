using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace xeBuild_GUI
{
    class Misc
    {
        public string checkxmlempty(string input, bool xml)
        {
            if (input != null)
            {
                if (input.Equals("none", StringComparison.CurrentCultureIgnoreCase)) { return ""; }
                else if (string.IsNullOrEmpty(input) && (xml)) { return "none"; }
                else { return input; }
            }
            else { return ""; }
        }
        public string getmd5(string file)
        {
            if (File.Exists(file))
            {
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                MD5 md5check = new MD5CryptoServiceProvider();
                byte[] retval = md5check.ComputeHash(fs);
                fs.Close();
                StringBuilder sb = new StringBuilder();
                foreach (byte b in retval)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("ERROR: File doesn't exist! cannot check MD5 of a file that don't exist!", "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return "error";
            }
        }
        public UInt16 swap16(UInt16 input) { return ((UInt16)(((0xFF00 & input) >> 8) | ((0x00FF & input) << 8))); }
        public UInt32 swap32(UInt32 input) { return (input & 0x000000FFU) << 24 | (input & 0x0000FF00U) << 8 | (input & 0x00FF0000U) >> 8 | (input & 0xFF000000U) >> 24; }
        public byte[] cpukeytoarray(string cpukey)
        {
            byte[] ret = new byte[cpukey.Length / 2];
            for (int i = 0; i < cpukey.Length; i += 2) { ret[i / 2] = byte.Parse(cpukey.Substring(i, 2), System.Globalization.NumberStyles.HexNumber); }
            return ret;
        }
        public string translateregion(string source)
        {
            switch (source)
            {
                case "": return "";
                case null: return "";
                case "0x02FE": return "PAL/Europe";
                case "PAL/Europe": return "0x02FE";
                case "0x0201": return "PAL/Australia";
                case "PAL/Australia": return "0x0201";
                case "0x00FF": return "NTSC/USA";
                case "NTSC/USA": return "0x00FF";
                case "0x01FE": return "NTSC/Japan";
                case "NTSC/Japan": return "0x01FE";
                case "0x01FC": return "NTSC/Korea";
                case "NTSC/Korea": return "0x01FC";
                case "0x0101": return "NTSC/Hong Kong";
                case "NTSC/Hong Kong": return "0x0101";
                case "0x7FFF": return "Devkit";
                case "Devkit": return "0x7FFF";
                default: return "Unkown";
            }
        }
        public string translatedvd(byte source)
        {
            switch (source)
            {
                case 1: return "1 (North America)";
                case 2: return "2 (Europe)";
                case 3: return "3 (South East Asia)";
                case 4: return "4 (Australia)";
                case 5: return "5 (Russia/South Asia)";
                case 6: return "6 (China)";
                case 7: return "7 (Unkown)";
                case 8: return "8 (Aircrafts etc.)";
                default: return "unkown";
            }
        }
    }
}