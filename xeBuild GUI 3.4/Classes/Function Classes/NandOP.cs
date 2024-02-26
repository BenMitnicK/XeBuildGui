using System;
using System.IO;
using System.Windows.Forms;

namespace xeBuild_GUI
{
    class NandOP
    {
        public static byte[] userdata = new byte[0], sparedata = new byte[0];
        private void readsplit(string source, int pages)
        {
            using (BinaryReader br = new BinaryReader(File.Open(source, FileMode.Open, FileAccess.Read)))
            {
                int size = ((512 + 16) * pages), filelen = (int)br.BaseStream.Length, i, j, useroffset = 0, spareoffset = 0;
                userdata = new byte[512 * pages];
                //MessageBox.Show("userdata = " + userdata[useroffset]);
                sparedata = new byte[16 * pages];
                if (filelen >= size)
                {
                    for (j = 0; j < pages; j++)
                    {
                        for (i = 0; i < 512; i++)
                        {
                            userdata[useroffset] = br.ReadByte();
                            //MessageBox.Show("" + userdata[useroffset]);
                            //Console.Write(userdata[useroffset] + "\n");
                            useroffset++;
                        }
                        for (i = 0; i < 16; i++) 
                        {
                            sparedata[spareoffset] = br.ReadByte();
                            spareoffset++;
                        }
                    }
                }
            }
        }
        private int getpages(string source)
        {
            FileInfo fi = new FileInfo(source);
            if (fi.Length == 17301504) { return (0x400 * 32); }
            else if ((fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128)) { return (0x1000 * 32); }
            else
            {
                DialogResult res = MessageBox.Show("ERROR: Can't determine if it's big or small block nand, do you want to continue anyways? (this is a sign that your nand is not properly dumped)", "ERROR - unable to determine dump size", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (res == DialogResult.Yes)
                {
                    return (int)(fi.Length / (512 + 16)) * 32;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int[] getbootloaderversions(string source)
        {
            int pages = getpages(source);
            if (pages != 0)
            {
                readsplit(source, pages);
                int[] ret = new int[11];
                int pos = 0x8000;
                //MessageBox.Show("" + userdata[pos]); ///////////////////////////////////////////
                if (userdata.Length > pos)
                {
                    if ((userdata[pos] == 0x43) && (userdata[pos + 1] == 0x42))
                    {
                        ret[0] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x2));
                        int size = (int)Main.misc.swap32(BitConverter.ToUInt32(userdata, pos + 0xC));
                        pos = pos + size;
                        while (userdata[pos] == 0x43)
                        {
                            if (pos + 0xD < userdata.Length)
                            {
                                switch (userdata[pos + 1])
                                {
                                    case 0x42:
                                        ret[1] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x2));
                                        break;
                                    case 0x44:
                                        ret[2] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x2));
                                        break;
                                    case 0x45:
                                        ret[3] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x2));
                                        break;
                                    default:
                                        pos = userdata.Length - 1;
                                        break;
                                }
                                if (pos != userdata.Length - 1)
                                {
                                    size = (int)Main.misc.swap32(BitConverter.ToUInt32(userdata, pos + 0xC));
                                    pos = pos + size;
                                }
                            }
                        }
                        pos = (int)Main.misc.swap32(BitConverter.ToUInt32(userdata, 0x64));
                        ret[8] = pos;
                        int patchcount = Main.misc.swap16(BitConverter.ToUInt16(userdata, 0x68));
                        ret[9] = patchcount;
                        size = (int)Main.misc.swap32(BitConverter.ToUInt32(userdata, 0x70));
                        if (size == 0x0) 
                        {
                            FileInfo fi = new FileInfo(source);
                            if (fi.Length < 17301505) { size = 0x10000; }
                            else { size = 0x20000; }
                        }
                        if ((patchcount > 0) && (size > 0) && (pos > 0))
                        {
                            if ((userdata[pos] == 0x43) && (userdata[pos + 1] == 0x46))
                            {
                                ret[4] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x2));
                                if (patchcount > 1)
                                {
                                    if ((userdata[pos + 0x10000] == 0x43) && (userdata[pos + 0x10001] == 0x46)) 
                                    {
                                        ret[6] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x10002));
                                        ret[10] = 0x10000;
                                    }
                                    else if ((userdata[pos + 0x20000] == 0x43) && (userdata[pos + 0x20001] == 0x46)) 
                                    {
                                        ret[6] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x20002));
                                        ret[10] = 0x20000;
                                    }
                                }
                                pos = pos + (int)Main.misc.swap32(BitConverter.ToUInt32(userdata, pos + 0xC));
                                if ((userdata[pos] == 0x43) && (userdata[pos + 1] == 0x47))
                                {
                                    ret[5] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x2));
                                    if (patchcount > 1)
                                    {
                                        if ((userdata[pos + 0x10000] == 0x43) && (userdata[pos + 0x10001] == 0x47)) { ret[7] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x10002)); }
                                        else if ((userdata[pos + 0x20000] == 0x43) && (userdata[pos + 0x20001] == 0x47)) { ret[7] = Main.misc.swap16(BitConverter.ToUInt16(userdata, pos + 0x20002)); }
                                    }
                                }
                            }
                        }
                    }
                    else { ret[0] = 0; }
                }
                return ret;
            }
            else { return new int[8]; }
        }
        public int getcbversion(string source)
        {
            int[] ret = getbootloaderversions(source);
            return ret[0];
        }
        public int getcbversioncorona4g(String source)
        {
            int ret = 0;
            try
            {
                byte[] data = (BadBlock.find_bad_blocks_X(source, 0x50));
                byte[] image = data;
                byte[] block_offset = new byte[4];
                block_offset = Oper.returnportion(image, 0x8, 4);
                int block = 0, block_size, id;
                byte block_id;
                int block_build;
                byte[] block_build_b = new byte[2], block_size_b = new byte[4];
                int block_offset_b = Convert.ToInt32(Oper.ByteArrayToString(block_offset), 16);
                //int semi = 0;
                //for (block = 0; block < 30; block++)
                //{
                    block_id = image[block_offset_b + 1];
                    Buffer.BlockCopy(image, block_offset_b + 2, block_build_b, 0, 2);
                    //block_build_b = returnportion(image, block_offset_b + 2, 2);
                    Buffer.BlockCopy(image, block_offset_b + 12, block_size_b, 0, 4);
                    //block_size_b = returnportion(image, block_offset_b + 12, 4);
                    block_size = Convert.ToInt32(Oper.ByteArrayToString(block_size_b), 16);
                    block_build = Convert.ToInt32(Oper.ByteArrayToString(block_build_b), 16);
                    block_size += 0xF;
                    block_size &= ~0xF;
                    id = block_id & 0xF;
                    ret = block_build;
                    //return ret;
                    //Console.Write(block_build);
                    //if (variables.debugme) Console.WriteLine("Found {0}BL (build {1}) at {2}", id, block_build, Convert.ToString(block_offset_b, 16));
                    //Console.Write("Found {0}BL (build {1}) at {2}", id, block_build, Convert.ToString(block_offset_b, 16));
                    //data = new byte[block_size];
                    //data = returnportion(image, block_offset_b, block_size);
                    /*if (block_offset_b + block_size <= image.Length) Buffer.BlockCopy(image, block_offset_b, data, 0, block_size);
                    if (id == 2)
                    {
                        if (semi == 0)
                        {
                            bl.CB_A = block_build;
                            CB_A = data;
                            semi = 1;
                        }
                        else if (semi == 1)
                        {
                            bl.CB_B = block_build;
                            CB_B = data;
                            semi = 0;
                        }

                        if (semi == 0)
                        {
                            //if (variables.extractfiles) Oper.savefile(data, "output\\CB_B.bin");
                            if (variables.cpkey != "")
                            {
                                cb_dec = Nand.decrypt_CB_cpukey(CB_B, Nand.decrypt_CB(CB_A), Oper.StringToByteArray(variables.cpkey));
                                //if (variables.extractfiles) Oper.savefile(cb_dec, "output\\CB_B_dec.bin");
                                uf.ldv_cb = cb_dec[0x192];
                                //if (Form1.debugme) Console.WriteLine("LDV CB: {1}", ldv_cb);
                                byte[] temppd = (Oper.returnportion(cb_dec, 0x20, 3));
                                Array.Reverse(temppd);
                                uf.pd_cb = "0x" + Oper.ByteArrayToString(temppd);
                                //if (variables.debugme) Console.WriteLine(uf.pd_cb);
                            }
                        }
                        else
                        {
                            cb_dec = Nand.decrypt_CB(CB_A);
                            //if (variables.extractfiles) Oper.savefile(data, "output\\CB_A.bin");
                            //if (variables.extractfiles) Oper.savefile(cb_dec, "output\\CB_A_dec.bin");
                            uf.ldv_cb = cb_dec[0x192];
                            //if (Form1.debugme) Console.WriteLine("LDV CB: {1}", ldv_cb);
                            byte[] temppd = (Oper.returnportion(cb_dec, 0x20, 3));
                            Array.Reverse(temppd);
                            uf.pd_cb = "0x" + Oper.ByteArrayToString(temppd);
                            //if (variables.debugme) Console.WriteLine(uf.pd_cb);
                        }

                    }
                    else if (id == 4)
                    {
                        bl.CD = block_build;
                        //if (variables.extractfiles) Oper.savefile(data, "output\\CD.bin");
                        cd_dec = Nand.decrypt_CD(data, cb_dec);
                        //if (variables.extractfiles) Oper.savefile(cd_dec, "output\\CD_dec.bin");
                        //CD = data;
                    }
                    else if (id == 5)
                    {
                        bl.CE = block_build;
                        //if (variables.extractfiles) Oper.savefile(data, "output\\CE.bin");
                        //CE = data;
                    }
                    block_offset_b += block_size;
                    if (id == 5) break;*/
                //}
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            return ret;

        }
        public void savesmc(string saveloc, byte[] smcdata) { save(saveloc + "\\smc.bin", smcdata); }
        public void savekv(string saveloc, byte[] kvdata) { save(saveloc + "\\kv.bin", kvdata); }
        public void saveconfig(string saveloc, byte[] configdata) { save(saveloc + "\\smc_config.bin", configdata); }
        public void getkv_smc(string source)
        {
            //MessageBox.Show(source);
            readsplit(source, 64);
            int hd = 0, ed = 0;
            #region SMC
            uint smcstart = Main.misc.swap32(BitConverter.ToUInt32(userdata, 0x7C));
            uint smcsize = Main.misc.swap32(BitConverter.ToUInt32(userdata, 0x78));
            int smcsizeint = Convert.ToInt32(smcsize);
            //MessageBox.Show("SMC Size = " + smcsizeint); //////////////////////////////
            Main.encsmc = new byte[smcsizeint];
            hd = Convert.ToInt32(smcstart);
            for (ed = 0; ed < smcsizeint; ed++)
            {
                Main.encsmc[ed] = userdata[hd];
                hd++;
            }
            #endregion
            #region Keyvault
            Main.enckv = new byte[0x4000];
            hd = 0x4000;
            for (ed = 0; ed < 0x4000; ed++)
            {
                Main.enckv[ed] = userdata[hd];
                hd++;
            }
            #endregion
        }
        public byte[] dump_conf(string source)
        {
            int pages = getpages(source), i, j;
            if (pages == (0x400 * 32)) { j = 0xf7c000; }
            else { j = 0x3be0000; }
            if (pages != 0)
            {
                readsplit(source, pages);
                byte[] smc_config = new byte[0x400];
                for (i = 0; i < smc_config.Length; i++)
                {
                    smc_config[i] = userdata[j];
                    j++;
                }
                return smc_config;
            }
            else { return null; }
        }
        public byte[] get_fcrt(string source)
        {
            int i = 0, pages = getpages(source);
            uint offset = 0, length = 0;
            if (pages != 0)
            {
                readsplit(source, pages);
                byte[] ret = new byte[0];
                #region Reading FCRT.bin
                for (i = 0; i < userdata.Length; i++)
                {
                    if (userdata[i] == 0x66)
                    {
                        if ((userdata[i + 1] == 0x63) && (userdata[i + 2] == 0x72) &&
                            (userdata[i + 3] == 0x74) && (userdata[i + 4] == 0x2E) &&
                            (userdata[i + 5] == 0x62) && (userdata[i + 6] == 0x69) &&
                            (userdata[i + 7] == 0x6E))
                        {
                            offset = (uint)(Main.misc.swap16(BitConverter.ToUInt16(userdata, i + 22)) * 0x4000);
                            length = Main.misc.swap32(BitConverter.ToUInt32(userdata, i + 24));
                            ret = new byte[length];
                            for (i = 0; i < length; i++)
                            {
                                ret[i] = userdata[offset];
                                offset++;
                            }
                            i = userdata.Length;
                        }
                    }
                }
                #endregion
                return ret;
            }
            else { return null; }
        }
        private void save(string file, byte[] data)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            if (File.Exists(file)) { File.Delete(file); }
            File.WriteAllBytes(file, data);
        }
        private byte[] getbootloader(int pos, int size)
        {
            byte[] data = new byte[size];
            Array.Copy(userdata, pos, data, 0, size);
            return data;
        }
        public byte[] getcf(string source, int pos)
        {
            byte[] data = new byte[0];
            if (userdata.Length > pos)
            {
                int size = (int)Main.misc.swap32(BitConverter.ToUInt32(userdata, pos + 0xC));
                if (userdata.Length > (pos + size))
                {
                    if ((userdata[pos] == 0x43) && (userdata[pos + 1] == 0x46))
                    {
                        data = getbootloader(pos, size);
                    }
                }
            }
            return data;
        }
        public byte[] getcba(string source)
        {
            byte[] data = new byte[0];
            int pages = getpages(source);
            if (pages != 0)
            {
                readsplit(source, pages);
                int pos = 0x8000;
                if (userdata.Length > pos)
                {
                    int size = (int)Main.misc.swap32(BitConverter.ToUInt32(userdata, pos + 0xC));
                    if (userdata.Length > (pos + size))
                    {
                        if ((userdata[pos] == 0x43) && (userdata[pos + 1] == 0x42))
                        {
                            data = getbootloader(pos, size);
                        }
                    }
                }
            }
            return data;
        }
        public byte[] getcbb(string source, int pos)
        {
            byte[] data = new byte[0];
            if (userdata.Length > pos)
            {
                int size = (int)Main.misc.swap32(BitConverter.ToUInt32(userdata, pos + 0xC));
                if (userdata.Length > (pos + size))
                {
                    if ((userdata[pos] == 0x43) && (userdata[pos + 1] == 0x42))
                    {
                        data = getbootloader(pos, size);
                    }
                }
            }
            return data;
        }
        public int[] getcf_offsets(string source)
        {
            int[] ret = new int[2];
            int pages = getpages(source);
            if (pages != 0)
            {
                readsplit(source, pages);
                int pos = (int)Main.misc.swap32(BitConverter.ToUInt32(userdata, 0x64));
                if (userdata.Length > (pos))
                {
                    if ((userdata[pos] == 0x43) && (userdata[pos + 1] == 0x46))
                    {
                        ret[0] = pos;
                        if ((userdata[pos + 0x10000] == 0x43) && (userdata[pos + 0x10001] == 0x46)) { ret[1] = pos + 0x10000; }
                        if ((userdata[pos + 0x20000] == 0x43) && (userdata[pos + 0x20001] == 0x46)) { ret[1] = pos + 0x20000; }
                    }
                }
            }
            return ret;
        }
    }
}