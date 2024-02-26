using System;
using System.Xml;

namespace xeBuild_GUI
{
    class NandproSet
    {
        public static string[] filenames = new string[0];
        public static string workdir = "", npvers = "", size = "", device = "", dumptimes = "", workfile = "";
        public static string eccfile = "", binfile = "";
        public static void loadsettings(string file)
        {
            workdir = "";
            npvers = "";
            size = "";
            device = "";
            dumptimes = "";
            eccfile = "";
            binfile = "";
            filenames = new string[4];
            using (XmlReader xml = XmlReader.Create(file))
            {
                while (xml.Read())
                {
                    if (xml.IsStartElement())
                    {
                        switch (xml.Name.ToLower())
                        {
                            case "workdir":
                                xml.Read();
                                workdir = xml.Value;
                                break;
                            case "workfile":
                                xml.Read();
                                workfile = xml.Value;
                                break;
                            case "npvers":
                                xml.Read();
                                npvers = xml.Value;
                                break;
                            case "size":
                                xml.Read();
                                size = xml.Value;
                                break;
                            case "device":
                                xml.Read();
                                device = xml.Value;
                                break;
                            case "dumptimes":
                                xml.Read();
                                npvers = xml.Value;
                                break;
                            #region Dump Names
                            case "dump1name":
                                xml.Read();
                                filenames[0] = xml.Value;
                                break;
                            case "dump2name":
                                xml.Read();
                                filenames[1] = xml.Value;
                                break;
                            case "dump3name":
                                xml.Read();
                                filenames[2] = xml.Value;
                                break;
                            case "dump4name":
                                xml.Read();
                                filenames[3] = xml.Value;
                                break;
                            #endregion
                            case "eccfile":
                                xml.Read();
                                eccfile = xml.Value;
                                break;
                            case "binfile":
                                xml.Read();
                                binfile = xml.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        public static void savesettings(string file)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xml = XmlWriter.Create(file, settings))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("nandpro");
                xml.WriteElementString("workdir", workdir);
                xml.WriteElementString("workfile", workfile);
                xml.WriteElementString("npvers", npvers);
                xml.WriteElementString("size", size);
                xml.WriteElementString("device", device);
                xml.WriteElementString("dumptimes", dumptimes);
                xml.WriteElementString("dump1name", filenames[0]);
                xml.WriteElementString("dump2name", filenames[1]);
                xml.WriteElementString("dump3name", filenames[2]);
                xml.WriteElementString("dump4name", filenames[3]);
                xml.WriteElementString("eccfile", eccfile);
                xml.WriteElementString("binfile", binfile);
                xml.WriteEndDocument();
            }
        }
    }
}