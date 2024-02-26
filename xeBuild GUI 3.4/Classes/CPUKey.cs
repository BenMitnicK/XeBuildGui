using System;
using System.IO;
using System.Text.RegularExpressions;

namespace xeBuild_GUI
{
    class cpukey
    {
        public string[] readfusefile(string file)
        {
            string[] ret = new string[2];
            string val = "", cfldv = "";
            int ldval = 0;
            Int64 key1 = 0, key2 = 0, key3 = 0, key4 = 0;
            using (StreamReader sr = new StreamReader(file))
            {
                while (val != null)
                {
                    val = sr.ReadLine();
                    if (val != null)
                    {
                        if (val.StartsWith("fuseset 03:")) { key1 = Int64.Parse(val.Remove(0, 11), System.Globalization.NumberStyles.HexNumber); }
                        else if (val.StartsWith("fuseset 04:")) { key2 = Int64.Parse(val.Remove(0, 11), System.Globalization.NumberStyles.HexNumber); }
                        else if (val.StartsWith("fuseset 05:")) { key3 = Int64.Parse(val.Remove(0, 11), System.Globalization.NumberStyles.HexNumber); }
                        else if (val.StartsWith("fuseset 06:")) { key4 = Int64.Parse(val.Remove(0, 11), System.Globalization.NumberStyles.HexNumber); }
                        else if (val.StartsWith("fuseset 07:")) 
                        {
                            cfldv = val.Remove(0, 11);
                            cfldv = Regex.Replace(cfldv, " ", "");
                        }
                        else if (val.StartsWith("fuseset 08:"))
                        {
                            cfldv += val.Remove(0, 11);
                            cfldv = Regex.Replace(cfldv, " ", "");
                            foreach (char c in cfldv)
                            {
                                if (c.ToString().Equals("f", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    ldval++;
                                }
                            }
                        }
                    }
                }
                sr.Close();
            }
            if ((key1 != 0) && (key2 != 0) && (key3 != 0) && (key4 != 0))
            {
                ret[0] = (key1 | key2).ToString("X16") + (key3 | key4).ToString("X16");
                ret[1] = ldval.ToString();
            }
            else
            {
                ret[0] = "";
                ret[1] = "";
            }
            return ret;
        }
        public string readkeyfile(string file)
        {
            string ret = "";
            using (StreamReader sr = new StreamReader(file))
            {
                ret = sr.ReadLine();
                ret = ret.Trim();
                if ((ret.IndexOf("cpukey", StringComparison.OrdinalIgnoreCase) >= 0) && (ret.Length > 38))
                {
                    ret = ret.Substring(ret.Length - 32, 32);
                }
                sr.Close();
            }
            return ret;
        }
    }
}