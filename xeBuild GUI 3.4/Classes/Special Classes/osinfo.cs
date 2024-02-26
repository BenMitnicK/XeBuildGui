using System;
using System.Management;
using System.Text.RegularExpressions;

namespace xeBuild_GUI
{
    class wmi
    {
        public static string getname()
        {
            ManagementObjectSearcher objsearch = new ManagementObjectSearcher("SELECT * FROM  Win32_OperatingSystem");
            string osname = "";
            int arch = 0;
            OperatingSystem osinf = Environment.OSVersion;
            try
            {
                foreach (ManagementObject managementobj in objsearch.Get())
                {
                    object caption = managementobj.GetPropertyValue("Caption");
                    if (caption != null)
                    {
                        string capt = Regex.Replace(caption.ToString(), "[^A-Za-z0-9 ]", "");
                        if (capt.StartsWith("Microsoft")) { capt = capt.Substring(9); }
                        osname = capt.Trim();
                        if (!String.IsNullOrEmpty(capt))
                        {
                            object spvers = null;
                            try
                            {
                                spvers = managementobj.GetPropertyValue("ServicePackMajorVersion");
                                if (spvers != null && spvers.ToString() != "0") { osname += " Service Pack " + spvers.ToString(); }
                                else { osname += osinf.ServicePack.ToString(); }
                            }
                            catch { osname += osinf.ServicePack.ToString(); }
                        }
                        object archobj = null;
                        try
                        {
                            archobj = managementobj.GetPropertyValue("OSArchitecture");
                            if (archobj != null)
                            {
                                string archs = archobj.ToString();
                                arch = (archs.Contains("64") ? 64 : 32);
                            }
                        }
                        catch { }
                    }
                }
            }
            catch { }
            if (osname == "")
            {
                switch (osinf.Platform)
                {
                    case PlatformID.Win32Windows:
                        switch (osinf.Version.Minor)
                        {
                            case 0:
                                osname = "Windows 95";
                                break;
                            case 10:
                                if (osinf.Version.Revision.ToString() == "2222A") { osname = "Windows 98 Second Edition"; }
                                else { osname = "Windows 98"; }
                                break;
                            case 90:
                                osname = "Windows Me";
                                break;
                        }
                        break;
                    case PlatformID.Win32NT:
                        switch (osinf.Version.Major)
                        {
                            case 3:
                                osname = "Windows NT 3.51";
                                break;
                            case 4:
                                osname = "Windows NT 4.0";
                                break;
                            case 5:
                                if (osinf.Version.Minor == 0) { osname = "Windows 2000"; }
                                else if (osinf.Version.Minor == 1) { osname = "Windows XP"; }
                                else if (osinf.Version.Minor == 2) { osname = "Windows Server 2003"; }
                                break;
                            case 6:
                                if (osinf.Version.Minor == 0) { osname = "Windows Vista"; }
                                else if (osinf.Version.Minor == 1) { osname = "Windows 7"; }
                                break;
                        }
                        break;
                }
            }
            if (arch == 0) { arch = getarch(); }
            return osname + " " + arch.ToString() + "-bit";
        }
        public static int getarch()
        {
            string pa = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return ((string.IsNullOrEmpty(pa) || string.Compare(pa, 0, "x86", 0, 3, true) == 0) ? 32 : 64);
        }
    }
}