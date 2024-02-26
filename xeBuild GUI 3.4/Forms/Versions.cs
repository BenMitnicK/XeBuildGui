using System;
using System.IO;
using System.Windows.Forms;
using xeBuild_GUI.x360utils.NAND;


namespace xeBuild_GUI
{
    public partial class Versions : Form
    {
        public struct Bootloaders
        {
            public int CB_A;
            public int CB_B;
            public int CD;
            public int CE;
            public int CF_0;
            public int CG_0;
            public int CF_1;
            public int CG_1;
        }
        public struct Useful
        {
            public string pd_0;
            public string pd_1;
            public string pd_cb;
            public int ldv_p0;
            public int ldv_p1;
            public int ldv_cb;
        }
        public Bootloaders bl;
        public Useful uf;
        public byte[] _rawkv, _smc, _smc_config;
        public Versions() { InitializeComponent(); }
        private void hexinput(object sender, KeyPressEventArgs e) { Main.test.hexinput(sender, e); }
        private void ctrlfix(object sender, KeyEventArgs e) { Main.test.ctrlfix(sender, e); }
        private void blkey_leave(object sender, EventArgs e) { if (string.IsNullOrEmpty(blkey.Text)) { blkey.Text = "DD88AD0C9ED669E7B56794FB68563EFA"; } }
        private void Versions_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void Versions_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int ok = 0;
            foreach (string s in FileList)
            {
                if (s.EndsWith(".bin", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (ok == 0) 
                    {
                        nandfile.Text = s;
                        checkbtn_Click(sender, e);
                    }
                    ok++;
                }
            }
        }
        private void Versions_Load(object sender, EventArgs e)  
        {
            nandfile.Text = Main.statc.source.Text;
            cpukey.Text = Main.statc.cpukey.Text;
            blkey.Text = Main.statc.blkey.Text;
            if (File.Exists(nandfile.Text)) { checkbtn_Click(sender, e); }
        }
        private void reloadbtn_Click(object sender, EventArgs e) { Versions_Load(sender, e); }
        private void selectnandbtn_Click(object sender, EventArgs e)
        {
            if (loadnand.ShowDialog() == DialogResult.OK)
            {
                nandfile.Text = loadnand.FileName;
                checkbtn_Click(sender, e);
            }
            loadnand.FileName = Path.GetFileName(loadnand.FileName);
        }
        private void checkbtn_Click(object sender, EventArgs e)
        {
            cb_a.Text = "N/A";
            cba_ldvbox.Text = "N/A";
            cba_pairingbox.Text = "N/A";
            cb_b.Text = "N/A";
            cbb_ldvbox.Text = "N/A";
            cbb_pairingbox.Text = "N/A";
            cd.Text = "N/A";
            ce.Text = "N/A";
            cf0.Text = "N/A";
            cf0_ldvbox.Text = "N/A";
            cf0_pairingbox.Text = "N/A";
            cf0offset.Text = "N/A";
            cf1.Text = "N/A";
            cf1_ldvbox.Text = "N/A";
            cf1_pairingbox.Text = "N/A";
            cf1offset.Text = "N/A";
            slots.Text = "N/A";

            FileInfo fi = new FileInfo(nandfile.Text);
            if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
            {
                if (File.Exists(nandfile.Text))
                {
                    string file = nandfile.Text;
                    int[] ret = Main.nand.getbootloaderversions(file);
                    if (ret[0] > 1) { cb_a.Text = ret[0].ToString(); }
                    else { cb_a.Text = "N/A"; }
                    if (ret[1] > 1) { cb_b.Text = ret[1].ToString(); }
                    else { cb_b.Text = "N/A"; }
                    if (ret[2] > 1) { cd.Text = ret[2].ToString(); }
                    else { cd.Text = "N/A"; }
                    if (ret[3] > 1) { ce.Text = ret[3].ToString(); }
                    else { ce.Text = "N/A"; }
                    if (ret[4] > 1) { cf0.Text = ret[4].ToString(); }
                    else { cf0.Text = "N/A"; }
                    if (ret[5] > 1) { cg0.Text = ret[5].ToString(); }
                    else { cg0.Text = "N/A"; }
                    if (ret[6] > 1) { cf1.Text = ret[6].ToString(); }
                    else { cf1.Text = "N/A"; }
                    if (ret[7] > 1) { cg1.Text = ret[7].ToString(); }
                    else { cg1.Text = "N/A"; }
                    if (ret[8] > 0) { cf0offset.Text = "0x" + ret[8].ToString("X"); }
                    else { cf0offset.Text = "N/A"; }
                    if (ret[9] > 0) { slots.Text = ret[9].ToString(); }
                    else { slots.Text = "N/A"; }
                    if (ret[10] > 0) { cf1offset.Text = "0x" + (ret[8] + ret[10]).ToString("X"); }
                    else { cf1offset.Text = "N/A"; }
                    #region CB/CB_B LDV and Pairing
                    #region CB LDV/Pairing
                    if ((ret[0] > 1) && (ret[1] == 0))
                    {
                        byte[] data = Main.nand.getcba(file);
                        data = Main.crypt.DecryptCB(data, Main.misc.cpukeytoarray(blkey.Text), null);
                        if (Main.crypt.blcheck(ref data, 0x270, 0x120))
                        {
                            cba_pairingbox.Text = "0x" + data[0x22].ToString("X2");
                            cba_pairingbox.Text += data[0x21].ToString("X2");
                            cba_pairingbox.Text += data[0x20].ToString("X2");
                            cba_ldvbox.Text = ((int)data[0x23]).ToString();
                            cbb_ldvbox.Text = "";
                            cbb_pairingbox.Text = "";
                        }
                        else
                        {
                            cba_ldvbox.Text = "N/A";
                            cba_pairingbox.Text = "N/A";
                            cbb_ldvbox.Text = "N/A";
                            cbb_pairingbox.Text = "N/A";
                        }
                    }
                    #endregion
                    #region CB_B LDV/Pairing
                    else if (ret[1] > 1)
                    {
                        if (cpukey.Text.Length == 32)
                        {
                            byte[] data_a = Main.nand.getcba(file);
                            data_a = Main.crypt.DecryptCB(data_a, Main.misc.cpukeytoarray(blkey.Text), null);
                            if (Main.crypt.blcheck(ref data_a, 0x270, 0x120))
                            {
                                byte[] data = Main.nand.getcbb(file, 0x8000 + data_a.Length);
                                data = Main.crypt.DecryptCB(data, Main.misc.cpukeytoarray(cpukey.Text), data_a);
                                if (Main.crypt.blcheck(ref data, 0x270, 0x120))
                                {
                                    cbb_pairingbox.Text = "0x" + data[0x22].ToString("X2");
                                    cbb_pairingbox.Text += data[0x21].ToString("X2");
                                    cbb_pairingbox.Text += data[0x20].ToString("X2");
                                    cbb_ldvbox.Text = ((int)data[0x23]).ToString();
                                    cba_ldvbox.Text = "";
                                    cba_pairingbox.Text = "";
                                }
                                else
                                {
                                    cba_ldvbox.Text = "N/A";
                                    cba_pairingbox.Text = "N/A";
                                    cbb_ldvbox.Text = "N/A";
                                    cbb_pairingbox.Text = "N/A";
                                }
                            }
                            else
                            {
                                cba_ldvbox.Text = "N/A";
                                cba_pairingbox.Text = "N/A";
                                cbb_ldvbox.Text = "N/A";
                                cbb_pairingbox.Text = "N/A";
                            }
                        }
                        else
                        {
                            cba_ldvbox.Text = "N/A";
                            cba_pairingbox.Text = "N/A";
                            cbb_ldvbox.Text = "N/A";
                            cbb_pairingbox.Text = "N/A";
                        }
                    }
                    #endregion
                    #endregion
                    #region CF Slot 0 and Slot 1 LDV and Pairing
                    if (ret[4] > 1)
                    {
                        #region CF Slot 0 LDV/Pairing
                        byte[] data = Main.nand.getcf(file, ret[8]);
                        if (data.Length > 1)
                        {
                            data = Main.crypt.DecryptCF(data, Main.misc.cpukeytoarray(blkey.Text));
                            if (Main.crypt.blcheck(ref data, 0x1F0, 0x20))
                            {
                                cf0_pairingbox.Text = "0x" + data[0x21E].ToString("X2");
                                cf0_pairingbox.Text += data[0x21D].ToString("X2");
                                cf0_pairingbox.Text += data[0x21C].ToString("X2");
                                cf0_ldvbox.Text = ((int)data[0x21F]).ToString();
                                cf1_pairingbox.Text = "";
                                cf1_ldvbox.Text = "";
                            }
                            else
                            {
                                cf0_pairingbox.Text = "N/A";
                                cf0_ldvbox.Text = "N/A";
                                cf1_ldvbox.Text = "N/A";
                                cf1_pairingbox.Text = "N/A";
                            }
                        }
                        else
                        {
                            cf0_pairingbox.Text = "N/A";
                            cf0_ldvbox.Text = "N/A";
                            cf1_ldvbox.Text = "N/A";
                            cf1_pairingbox.Text = "N/A";
                        }
                        #endregion
                        #region CF Slot 1 LDV/Pairing
                        if (ret[6] > 1)
                        {
                            data = Main.nand.getcf(file, ret[8] + ret[10]);
                            if (data.Length > 1)
                            {
                                data = Main.crypt.DecryptCF(data, Main.misc.cpukeytoarray(blkey.Text));
                                if (Main.crypt.blcheck(ref data, 0x1F0, 0x20))
                                {
                                    cf1_pairingbox.Text = "0x" + data[0x21E].ToString("X2");
                                    cf1_pairingbox.Text += data[0x21D].ToString("X2");
                                    cf1_pairingbox.Text += data[0x21C].ToString("X2");
                                    cf1_ldvbox.Text = ((int)data[0x21F]).ToString();
                                }
                                else
                                {
                                    cf1_ldvbox.Text = "N/A";
                                    cf1_pairingbox.Text = "N/A";
                                }
                            }
                            else
                            {
                                cf1_ldvbox.Text = "N/A";
                                cf1_pairingbox.Text = "N/A";
                            }
                        }
                        else
                        {
                            cf1_ldvbox.Text = "N/A";
                            cf1_pairingbox.Text = "N/A";
                        }
                        #endregion
                    }
                    #endregion
                    Main.nand.getkv_smc(file);
                    Main.smc = Main.crypt.DecryptSMC(Main.encsmc);
                    mobo.Text = Main.test.cbtranslate(ret[0], file);
                    smct.Text = Main.test.smctype(Main.smc);
                    Main.nand.savesmc(Main.dir + "\\files\\temp\\", Main.smc);
                    string[] patches = Main.test.patchcheck(Main.dir + "\\files\\temp\\smc.bin");
                    tms.Text = patches[1];
                    tdi.Text = patches[2];
                    if (string.IsNullOrEmpty(patches[3])) { smcv.Text = "N/A"; }
                    else { smcv.Text = patches[3]; }
                }
                else { MessageBox.Show("ERROR: Can't check versions since the file you've selected don't exist!", "ERROR - File don't exist", MessageBoxButtons.OK, MessageBoxIcon.Error); }                
            }
            else
            {
                if (File.Exists(nandfile.Text))
                {
                    //string file = nandfile.Text;
                    byte[] data = (BadBlock.find_bad_blocks_X(nandfile.Text, 0x50));
                    unpack_base_image(data, true);
                    int cb = Main.nand.getcbversioncorona4g(nandfile.Text);
                    if (cb > 1) { mobo.Text = Main.test.cbtranslate(cb, nandfile.Text); }
                    else
                    {
                        mobo.Text = "N/A";
                    }


                }
                else { MessageBox.Show("ERROR: Can't check versions since the file you've selected don't exist!", "ERROR - File don't exist", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void nandfile_TextChanged(object sender, EventArgs e) { checkbtn.Enabled = (nandfile.Text.Length > 1); }
        private void blkey_TextChanged(object sender, EventArgs e)
        {
            if (blkey.Text.Length == 32) { checkbtn.Enabled = (Main.test.keycheck(blkey.Text)); }
            else { checkbtn.Enabled = false; }
        }

        public void unpack_base_image(byte[] image, bool bigblock)
        {
            byte[] data, cb_dec = { }, cd_dec = { };
            byte[] CB_A = null, CB_B = null; //SMC = null, CD = null, CE = null, Keyvault = null;
            bl.CB_A = 0; bl.CB_B = 0; bl.CD = 0; bl.CE = 0; bl.CF_0 = 0; bl.CG_0 = 0; bl.CF_1 = 0; bl.CG_1 = 0;
            uf.ldv_p0 = 0; uf.ldv_p1 = 0; uf.ldv_cb = 0; uf.pd_cb = ""; uf.pd_0 = ""; uf.pd_1 = "";

            /*if (Nand.rawecc(image)) Console.WriteLine("Image is raw. F11 to convert");
            if (Nand.hasecc_v2(ref image)) Nand.unecc(ref image, false);
            else noecc = true;*/

            //if (variables.debugme) Console.WriteLine("Has ecc? !{0}", noecc);

            byte[] block_offset = new byte[4];
            block_offset = Oper.returnportion(image, 0x8, 4);
            variables.smcmbtype = 0;
            try
            {
                byte[] SMC = null, Keyvault = null;
                byte[] smc_len = new byte[4], smc_start = new byte[4];
                Buffer.BlockCopy(image, 0x78, smc_len, 0, 4);
                Buffer.BlockCopy(image, 0x7C, smc_start, 0, 4);
                SMC = new byte[Oper.ByteArrayToInt(smc_len)];
                Buffer.BlockCopy(image, Oper.ByteArrayToInt(smc_start), SMC, 0, Oper.ByteArrayToInt(smc_len));
                //if (variables.extractfiles) Oper.savefile(SMC, "output\\SMC_en.bin");
                SMC = Nand.decrypt_SMC(SMC);
                //if (variables.extractfiles) Oper.savefile(SMC, "output\\SMC_dec.bin");
                variables.smcmbtype = SMC[0x100] >> 4 & 15;
                var smc = new Smc();
                smct.Text = Main.test.smctype(SMC);
                smcv.Text = smc.GetVersion(ref SMC);
                //Console.Write("\r\nSMC Version: {0} [{1}]", smc.GetVersion(ref SMC), smc.GetMotherBoardFromVersion(ref SMC));
                //Console.Write("\r\nSMC Type: {0}", type);
                /*if (type == Smc.SmcTypes.Jtag || type == Smc.SmcTypes.RJtag)
                    Smc.JtagsmcPatches.AnalyseSmc(ref SMC);
                Console.Write("\r\nSMC Glitch Patched: {0}", smc.CheckGlitchPatch(ref SMC) ? "Yes" : "No");*/
                //MessageBox.Show("smc = " + (SMC[0x100] >> 4 & 15).ToString());
                _smc = SMC;
                SMC = null;

                #region keyvault
                Keyvault = new byte[0x4000];
                Buffer.BlockCopy(image, 0x4000, Keyvault, 0, 0x4000);
                _rawkv = Keyvault;
                //if (variables.extractfiles) Oper.savefile(Keyvault, "output\\KV_en.bin");
                Keyvault = null;
                #endregion
            }
            catch (Exception ex) { if (variables.debugme) Console.WriteLine(ex.ToString()); }


            #region blocks
            try
            {
                int block = 0, block_size, id;
                byte block_id;
                int block_build;
                byte[] block_build_b = new byte[2], block_size_b = new byte[4];
                int block_offset_b = Convert.ToInt32(Oper.ByteArrayToString(block_offset), 16);
                int semi = 0;
                for (block = 0; block < 30; block++)
                {
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
                    //if (variables.debugme) Console.WriteLine("Found {0}BL (build {1}) at {2}", id, block_build, Convert.ToString(block_offset_b, 16));
                    //Console.Write("Found {0}BL (build {1}) at {2}", id, block_build, Convert.ToString(block_offset_b, 16));
                    data = new byte[block_size];
                    //data = returnportion(image, block_offset_b, block_size);
                    if (block_offset_b + block_size <= image.Length) Buffer.BlockCopy(image, block_offset_b, data, 0, block_size);
                    if (id == 2)
                    {
                        if (semi == 0)
                        {
                            bl.CB_A = block_build;
                            if (block_build > 1) { cb_a.Text = block_build.ToString(); }
                            else { cb_a.Text = "N/A"; }
                            //Console.Write("bl.CB_A = " + block_build + "\n");
                            CB_A = data;
                            semi = 1;
                        }
                        else if (semi == 1)
                        {
                            bl.CB_B = block_build;
                            if (block_build > 1) { cb_b.Text = block_build.ToString(); }
                            else { cb_b.Text = "N/A"; }
                            //Console.Write("bl.CB_B = " + block_build + "\n");
                            CB_B = data;
                            semi = 0;
                        }

                        if (semi == 0)
                        {
                            //if (variables.extractfiles) Oper.savefile(data, "output\\CB_B.bin");
                            if (cpukey.Text != "")
                            {
                                cb_dec = Nand.decrypt_CB_cpukey(CB_B, Nand.decrypt_CB(CB_A), Oper.StringToByteArray(cpukey.Text));
                                //if (variables.extractfiles) Oper.savefile(cb_dec, "output\\CB_B_dec.bin");
                                uf.ldv_cb = cb_dec[0x192];
                                cbb_ldvbox.Text = uf.ldv_cb.ToString();
                                /*if (uf.ldv_cb > 1) { cbb_ldvbox.Text = uf.ldv_cb.ToString(); }
                                else { cbb_ldvbox.Text = "N/A"; }*/
                                //Console.Write("uuuuuuf.ldv_cb = " + uf.ldv_cb + "\n");
                                //if (Form1.debugme) Console.WriteLine("LDV CB: {1}", ldv_cb);
                                byte[] temppd = (Oper.returnportion(cb_dec, 0x20, 3));
                                Array.Reverse(temppd);
                                uf.pd_cb = "0x" + Oper.ByteArrayToString(temppd);
                                if (uf.pd_cb != "") { cbb_pairingbox.Text = uf.pd_cb; cf0_pairingbox.Text = uf.pd_cb; cf1_pairingbox.Text = uf.pd_cb; }
                                else { cbb_pairingbox.Text = "N/A"; cf0_pairingbox.Text = "N/A"; cf1_pairingbox.Text = "N/A"; }
                                //Console.Write("uuuuuuuf.pd_cb = " + uf.pd_cb + "\n");
                                //if (variables.debugme) Console.WriteLine(uf.pd_cb);
                            }
                        }
                        else
                        {
                            cb_dec = Nand.decrypt_CB(CB_A);
                            //if (variables.extractfiles) Oper.savefile(data, "output\\CB_A.bin");
                            //if (variables.extractfiles) Oper.savefile(cb_dec, "output\\CB_A_dec.bin");
                            uf.ldv_cb = cb_dec[0x192];
                            cba_ldvbox.Text = uf.ldv_cb.ToString();
                            /*if (uf.ldv_cb > 1) { cba_ldvbox.Text = uf.ldv_cb.ToString(); }
                            else { cba_ldvbox.Text = "N/A"; }*/
                            //Console.Write("uuuuuuuuuuuuuuuf.ldv_cb = " + uf.ldv_cb + "\n");
                            //if (Form1.debugme) Console.WriteLine("LDV CB: {1}", ldv_cb);
                            byte[] temppd = (Oper.returnportion(cb_dec, 0x20, 3));
                            Array.Reverse(temppd);
                            uf.pd_cb = "0x" + Oper.ByteArrayToString(temppd);
                            //Console.Write("uuuuuuuuuuuuuuuuf.pd_cb = " + uf.pd_cb + "\n");
                            //if (variables.debugme) Console.WriteLine(uf.pd_cb);
                        }

                    }
                    else if (id == 4)
                    {
                        bl.CD = block_build;
                        if (block_build > 1) { cd.Text = block_build.ToString(); }
                        else { cd.Text = "N/A"; }
                        //Console.Write("bl.CD = " + bl.CD + "\n");
                        //if (variables.extractfiles) Oper.savefile(data, "output\\CD.bin");
                        cd_dec = Nand.decrypt_CD(data, cb_dec);
                        //Console.Write("cd_dec = " + cd_dec + "\n");
                        //if (variables.extractfiles) Oper.savefile(cd_dec, "output\\CD_dec.bin");
                        //CD = data;
                    }
                    else if (id == 5)
                    {
                        bl.CE = block_build;
                        if (block_build > 1) { ce.Text = block_build.ToString(); }
                        else { ce.Text = "N/A"; }
                        //Console.Write("bl.CE = " + bl.CE + "\n");
                        //if (variables.extractfiles) Oper.savefile(data, "output\\CE.bin");
                        //CE = data;
                    }
                    block_offset_b += block_size;
                    if (id == 5) break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            #endregion

            try
            {
                unpack_update(ref image, bigblock);
            }
            catch (System.IndexOutOfRangeException ex) { MessageBox.Show(ex.ToString()); }
            catch (System.OutOfMemoryException ex) { MessageBox.Show(ex.Message); }

        }
        void unpack_update(ref byte[] image, bool bigblock)
        {
            byte[] CF0 = new byte[0x100], CF1 = new byte[0x100];
            //if (variables.extractfiles) Oper.savefile(image, "image.bin");
            int size = image.Length;
            int blocksize, patch_offset = 0;
            if (bigblock) blocksize = 0x20000;
            else blocksize = 0x4000;
            int block = 0, block_size, id;
            byte block_id;
            int block_build;
            byte[] block_build_b = new byte[2], block_size_b = new byte[4];
            int block_offset_b = 0;
            int patch = 0;
            try
            {
                for (block = 0; block < 10; block++)
                {
                    if (block_offset_b + 1 >= image.Length || block_offset_b + 1 < 0) break;
                    block_id = image[block_offset_b + 1];
                    //if (variables.debugme) Console.WriteLine("Block ID: {0} | Block offset: {1:X}", block_id, block_offset_b);
                    int temp_block_offset = block_offset_b;
                    //block_build_b = returnportion(image, block_offset_b + 2, 2);
                    Buffer.BlockCopy(image, block_offset_b + 2, block_build_b, 0, 2);
                    //block_size_b = returnportion(image, block_offset_b + 12, 4);
                    Buffer.BlockCopy(image, block_offset_b + 12, block_size_b, 0, 4);
                    block_size = Convert.ToInt32(Oper.ByteArrayToString(block_size_b), 16);
                    block_build = Convert.ToInt32(Oper.ByteArrayToString(block_build_b), 16);
                    //if (variables.debugme) Console.WriteLine("Block Build {0} : Block Size {1:X}", block_build, block_size);
                    block_size += 0xF;
                    block_size &= ~0xF;
                    id = block_id & 0xF;
                    if (block_size > image.Length) break;
                    byte[] data = new byte[block_size];
                    //byte[] data = returnportion(image, block_offset_b, block_size);
                    if (block_size + block_offset_b <= image.Length)
                    {
                        //if (variables.debugme) Console.WriteLine("Copying to buffer..");
                        Buffer.BlockCopy(image, block_offset_b, data, 0, block_size);
                    }
                    else
                    {
                        //if (variables.debugme) Console.WriteLine("block size: 0x{0:X} - offset: 0x{1:X} - image: 0x{2:X}", block_size, block_offset_b, image.Length);
                    }

                    if (id == 6 || id == 7)
                    {
                        //if (variables.debugme) Console.WriteLine("-Found {0}BL Patch {3} (build {1}) at {2:X}", id, block_build, block_offset_b, patch);
                        if (id == 6)
                        {
                            patch_offset = block_offset_b;

                            if (patch == 0)
                            {
                                CF0 = Nand.decrypt_CF(data);
                                //Console.Write("cccccCF0 = " + CF0 + "\n");
                                bl.CF_0 = block_build;
                                if (block_build > 1) { cf0.Text = block_build.ToString(); Main.mright.cf0 = block_build.ToString(); }
                                else { cf0.Text = "N/A"; Main.mright.cf0 = "N/A"; }
                                //Console.Write("bl.CF_0 = " + bl.CF_0 + "\n");
                                uf.ldv_p0 = Nand.decrypt_CF(data)[0x21F];
                                Main.mright.cf00 = uf.ldv_p0;
                                if (uf.ldv_p0 > 1) { cf0_ldvbox.Text = uf.ldv_p0.ToString(); Main.mright.cf0_LDV = uf.ldv_p0.ToString(); }
                                else { cf0_ldvbox.Text = "N/A"; Main.mright.cf0_LDV = "N/A"; }
                                //Console.Write("2uf.ldv_p0 = " + uf.ldv_p0 + "\n");
                                if (variables.debugme) Console.WriteLine("-LDV Patch {0}: {1}", patch, uf.ldv_p0);
                                byte[] temppd = (Oper.returnportion(Nand.decrypt_CF(data), 0x21C, 3));
                                Array.Reverse(temppd);
                                uf.pd_0 = "0x" + Oper.ByteArrayToString(temppd);
                                if (variables.debugme) Console.WriteLine("-Pairing Data 0: {0:X}", uf.pd_0);
                            }
                            else
                            {
                                CF1 = Nand.decrypt_CF(data);
                                Console.Write("CF1 = " + CF1 + "\n");
                                bl.CF_1 = block_build;
                                if (block_build > 1) { cf1.Text = block_build.ToString(); Main.mright.cf1 = block_build.ToString(); }
                                else { cf1.Text = "N/A"; Main.mright.cf1 = "N/A"; }
                                //Console.Write("bl.CF_1 = " + bl.CF_1 + "\n");
                                uf.ldv_p1 = Nand.decrypt_CF(data)[0x21F];
                                Main.mright.cf11 = uf.ldv_p1;
                                if (uf.ldv_p1 > 1) { cf1_ldvbox.Text = uf.ldv_p1.ToString(); Main.mright.cf1_LDV = uf.ldv_p1.ToString(); }
                                else { cf1_ldvbox.Text = "N/A"; Main.mright.cf1_LDV = "N/A"; }
                                //Console.Write("2uf.ldv_p1 = " + uf.ldv_p1 + "\n");
                                //if (variables.debugme) Console.WriteLine("-LDV Patch {0}: {1}", patch, uf.ldv_p1);
                                byte[] temppd = (Oper.returnportion(Nand.decrypt_CF(data), 0x21C, 3));
                                Array.Reverse(temppd);
                                uf.pd_1 = "0x" + Oper.ByteArrayToString(temppd);
                                //if (variables.debugme) Console.WriteLine("-Pairing Data 1: {0:X}", uf.pd_1);
                            }

                            if (variables.extractfiles)
                            {
                                //Oper.savefile(data, "output\\CF" + patch + ".bin");
                                //Oper.savefile(Nand.decrypt_CF(data), "output\\CF" + patch + "_dec.bin");
                            }
                        }
                        else if (id == 7)
                        {
                            if (variables.extractfiles)
                            {
                                //Oper.savefile(data, "output\\CG" + patch + ".bin");
                                //Oper.savefile(Nand.decrypt_CG(data, patch == 0 ? CF0 : CF1), "output\\CG" + patch + "_dec.bin");
                            }
                            if (patch == 0)
                            {
                                bl.CG_0 = block_build;
                                if (block_build > 1) { cg0.Text = block_build.ToString(); }
                                else { cg0.Text = "N/A"; }
                                //Console.Write("bl.CG_0 = " + bl.CG_0 + "\n");
                                //block_offset_b += 0xBBB0;
                                patch = 1;
                            }
                            else
                            {
                                bl.CG_1 = block_build;
                                if (block_build > 1) { cg1.Text = block_build.ToString(); }
                                else { cg1.Text = "N/A"; }
                                //Console.Write("bl.CG_1 = " + bl.CG_1 + "\n");
                                break;
                            }
                        }
                    }
                    if ((patch_offset + blocksize + 1 > image.Length) || (patch_offset + 0x10001 > image.Length) || (block_offset_b + block_size + 1 > image.Length)) break;
                    int tem0 = image[patch_offset + blocksize];
                    int temo = image[patch_offset + blocksize + 1];
                    int tem2 = image[patch_offset + 0x10001];
                    int tem1 = image[patch_offset + 0x10000];
                    int tem3 = image[block_offset_b + 0x10000];
                    int tem4 = image[block_offset_b + 0x10001];
                    int tem5 = image[block_offset_b + block_size];
                    int tem6 = image[block_offset_b + block_size + 1];
                    if (patch == 1 && block_offset_b < 0x80000 && tem2 == 0x46 && tem1 == 0x43)
                    {
                        if (variables.debugme) Console.WriteLine("2 - {0:X}", block_offset_b);
                        block_offset_b = patch_offset + 0x10000;
                        continue;
                    }
                    else if (temo == 0x46 && tem0 == 0x43 && patch == 1)
                    {
                        if (variables.debugme) Console.WriteLine("1 - {0:X}", block_offset_b);
                        block_offset_b = patch_offset + blocksize;
                        continue;
                    }
                    else if (patch == 0 && tem3 == 0x43 && tem4 == 0x46 && tem5 != 0x43 && tem6 != 0x47)
                    {
                        if (variables.debugme) Console.WriteLine("4 - {0:X}", block_offset_b);
                        block_offset_b += 0x10000;
                        patch = 1;
                        continue;
                    }

                    else if (patch == 0 && block_offset_b > 0x80000 && patch_offset < 0x80000)
                    {
                        if (variables.debugme) Console.WriteLine("3 - {0:X}", block_offset_b);
                        patch = 1;
                        block_offset_b = 0x80000;
                        continue;
                    }
                    if (block_size == 0x10) { block_size = 0x20000; patch = 1; }
                    block_offset_b += block_size;
                    if (variables.debugme) Console.WriteLine("5 - {0:X}", block_offset_b);
                    if (temp_block_offset == block_offset_b) break;
                    if (block_offset_b > size) break;
                }
            }
            catch (System.OverflowException) { return; }
            catch (Exception ex) { if (variables.debugme) Console.WriteLine(ex.ToString()); }

        }
    }
}