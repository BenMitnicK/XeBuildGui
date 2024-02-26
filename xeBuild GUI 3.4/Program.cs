using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace xeBuild_GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch (Exception e) { crash(e); }
        }
        static void crash(Exception e)
        {
            try
            {
                StringBuilder newdir = new StringBuilder(Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).CodeBase));
                string dir = newdir.Remove(0, 6).ToString();
                using (StreamWriter sw = new StreamWriter(dir + "\\crashlog.txt"))
                {
                    string asm = Assembly.GetAssembly(typeof(Program)).FullName;
                    asm = asm.Substring(asm.IndexOf("Version", StringComparison.CurrentCultureIgnoreCase) + 8);
                    asm = asm.Substring(0, asm.IndexOf(","));
                    OperatingSystem os = Environment.OSVersion;
                    sw.WriteLine("xeBuild GUI v" + asm + " crashlog");
                    sw.WriteLine("log was created: " + DateTime.Today.DayOfWeek.ToString() + " " + DateTime.Now.ToString());
                    sw.WriteLine("");
                    sw.WriteLine(" *** System information ***");
                    sw.WriteLine("");
                    sw.WriteLine("OSName: " + wmi.getname());
                    sw.WriteLine("Platform: " + os.Platform.ToString());
                    sw.WriteLine("OS Version: " + os.Version.ToString());
                    sw.WriteLine("OS Version String: " + os.VersionString.ToString());
                    sw.WriteLine("Bootmode: " + SystemInformation.BootMode.ToString());
                    try
                    {
                        if (VistaTools.IsReallyVista())
                        {
                            TOKEN_ELEVATION_TYPE tet = TOKEN_ELEVATION_TYPE.TokenElevationTypeDefault;
                            sw.WriteLine("Elevated: " + VistaTools.IsElevated());
                            tet = VistaTools.GetElevationType();
                            sw.Write("UAC status: ");
                            if (tet == TOKEN_ELEVATION_TYPE.TokenElevationTypeDefault) { sw.WriteLine("Disabled"); }
                            else if (tet == TOKEN_ELEVATION_TYPE.TokenElevationTypeFull) { sw.WriteLine("Enabled, running as administrator"); }
                            else if (tet == TOKEN_ELEVATION_TYPE.TokenElevationTypeLimited) { sw.WriteLine("Enabled, NOT running as administrator"); }
                        }
                    }
                    catch { }
                    sw.WriteLine("");
                    sw.WriteLine(" *** ERROR Information (exception message) *** ");
                    sw.WriteLine("");
                    sw.WriteLine(e);
                    sw.Close();
                }
                MessageBox.Show("A Unhandled Exception occured, please send me crashlog.txt (located in the application directory) to: admin@swizzy.se\n\n More information about the error:\n\n" + e, "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("FATAL CRASH! Unable to save a crashlog! MEGA FAIL ERROR!", "FATAL CRASH", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
