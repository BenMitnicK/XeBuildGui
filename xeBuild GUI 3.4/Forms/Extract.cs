using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using xeBuild_GUI.x360utils.NAND;


namespace xeBuild_GUI
{
    public partial class Extract : Form
    {
        public Extract() { InitializeComponent(); }
        private void hexinput(object sender, KeyPressEventArgs e) { Main.test.hexinput(sender, e); }
        private void ctrlfix(object sender, KeyEventArgs e) { Main.test.ctrlfix(sender, e); }
        public static PrivateN nand = new PrivateN();
        private string path;
        private void Extract_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void Extract_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int ok = 0;
            foreach (string s in FileList)
            {
                if (s.EndsWith(".bin", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (ok == 0) { nandfile.Text = s; }
                    ok++;
                }
            }
        }
        private void Extract_Load(object sender, EventArgs e) 
        {
            cpukey.Text = Main.statc.cpukey.Text;
            blkey.Text = Main.statc.blkey.Text;
            nandfile.Text = Main.statc.source.Text;
        }
        private void reloadbtn_Click(object sender, EventArgs e) { Extract_Load(sender, e); }
        private void cpukey_TextChanged(object sender, EventArgs e) 
        {

            if (cpukey.Text.Length == 32 && nandfile.Text != "") {
                FileInfo fi = new FileInfo(nandfile.Text);
                if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
            {
                deckvbtn.Enabled = (Main.test.keycheck(cpukey.Text) && File.Exists(nandfile.Text));
            }else
                {
                corona4gbtn.Enabled = (Main.test.keycheck(cpukey.Text) && File.Exists(nandfile.Text));
                confbtn.Enabled = false;
                fcrtbtn.Enabled = false;
                decsmcbtn.Enabled = false;
                encsmcbtn.Enabled = false;
                enckvbtn.Enabled = false;
                enccbbtn.Enabled = false;
                enccfbtn.Enabled = false;
                deckvbtn.Enabled = false;
                deccbbtn.Enabled = false;
                deccfbtn.Enabled = false;
                }
            } else if (string.IsNullOrEmpty(cpukey.Text) && nandfile.Text != "")
            {
                FileInfo fi = new FileInfo(nandfile.Text);

                if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
                {

                }
                else
                {
                    corona4gbtn.Enabled = false;
                    confbtn.Enabled = false;
                    fcrtbtn.Enabled = false;
                    decsmcbtn.Enabled = false;
                    encsmcbtn.Enabled = false;
                    enckvbtn.Enabled = false;
                    enccbbtn.Enabled = false;
                    enccfbtn.Enabled = false;
                    deckvbtn.Enabled = false;
                    deccbbtn.Enabled = false;
                    deccfbtn.Enabled = false;
                }
            }
            else { deckvbtn.Enabled = false; }
        }
        private void encsmcbtn_Click(object sender, EventArgs e)
        {
            Main.nand.getkv_smc(nandfile.Text);
            if (Main.encsmc.Length > 1)
            {
                save.FileName = "smc_enc.bin";
                save.Title = "Select where to save Encrypted SMC";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(save.FileName, Main.encsmc);
                }
            }
            else { MessageBox.Show("ERROR: Unable to dump your SMC, something's horribly wrong here...", "ERROR - Unable to dump SMC", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void decsmcbtn_Click(object sender, EventArgs e)
        {
            Main.nand.getkv_smc(nandfile.Text);
            if (Main.encsmc.Length > 1)
            {
                Main.smc = Main.crypt.DecryptSMC(Main.encsmc);
                save.FileName = "smc_dec.bin";
                save.Title = "Select where to save Decrypted SMC";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(save.FileName, Main.smc);
                }
            }
            else { MessageBox.Show("ERROR: Unable to dump your SMC, something's horribly wrong here...", "ERROR - Unable to dump SMC", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void enckvbtn_Click(object sender, EventArgs e)
        {
            Main.nand.getkv_smc(nandfile.Text);
            if (Main.enckv.Length > 1)
            {
                save.FileName = "kv_enc.bin";
                save.Title = "Select where to save Encrypted Keyvault";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(save.FileName, Main.enckv);
                }
            }
            else { MessageBox.Show("ERROR: Unable to dump your KV, something's horribly wrong here...", "ERROR - Unable to dump KV", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void deckvbtn_Click(object sender, EventArgs e)
        {
            Main.nand.getkv_smc(nandfile.Text);
            if (Main.enckv.Length > 1)
            {
                Main.kv = Main.crypt.DecryptKV(Main.enckv, cpukey.Text);
                if (Main.crypt.kvcheck(Main.kv, cpukey.Text))
                {
                    save.FileName = "kv_dec.bin";
                    save.Title = "Select where to save Decrypted Keyvault";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(save.FileName, Main.kv);
                    }
                }
                else { MessageBox.Show("ERROR: Unable to save a decrypted CPUKey, it's etheir corrupt or you supplied the wrong key...", "ERROR - KV Decryption failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("ERROR: Unable to dump your KV, something's horribly wrong here...", "ERROR - Unable to dump KV", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void confbtn_Click(object sender, EventArgs e)
        {
            byte[] confbytes = Main.nand.dump_conf(nandfile.Text);
            if (confbytes.Length > 1)
            {
                save.FileName = "SMC_Config.bin";
                save.Title = "Select where to save SMC Config";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(save.FileName, confbytes);
                }
            }
            else { MessageBox.Show("ERROR: Unable to dump SMC_Config... something's horribly wrong!", "ERROR - Unable to dump SMC_Config", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void nandfile_TextChanged(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(nandfile.Text);
            if ((fi.Length == 17301504) || (fi.Length == 69206016) || (fi.Length == 276824064) || (fi.Length == 553648128))
            {
                corona4gbtn.Enabled = false;
                confbtn.Enabled = (File.Exists(nandfile.Text));
                fcrtbtn.Enabled = (File.Exists(nandfile.Text));
                decsmcbtn.Enabled = (File.Exists(nandfile.Text));
                encsmcbtn.Enabled = (File.Exists(nandfile.Text));
                enckvbtn.Enabled = (File.Exists(nandfile.Text));
                enccbbtn.Enabled = (File.Exists(nandfile.Text));
                enccfbtn.Enabled = (File.Exists(nandfile.Text));
                blkey_TextChanged(sender, e);
                cpukey_TextChanged(sender, e);
            }else
            {
                cpukey_TextChanged(sender, e);
            }
            
        }
        private void fcrtbtn_Click(object sender, EventArgs e)
        {
            byte[] fcrtbytes = Main.nand.get_fcrt(nandfile.Text);
            if (fcrtbytes.Length > 1)
            {
                save.FileName = "fcrt.bin";
                save.Title = "Select where to save fcrt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(save.FileName, fcrtbytes);
                }
            }
            else { MessageBox.Show("ERROR: Can't seem to find any entry of FCRT.bin in your nand, are you sure this is a trinity nand?", "ERROR - No FCRT.bin found in nand", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void blkey_leave(object sender, EventArgs e) { if (string.IsNullOrEmpty(blkey.Text)) { blkey.Text = "DD88AD0C9ED669E7B56794FB68563EFA"; } }
        private void blkey_TextChanged(object sender, EventArgs e)
        {
            if (blkey.Text.Length == 32) 
            { 
                deccbbtn.Enabled = (Main.test.keycheck(blkey.Text) && File.Exists(nandfile.Text));
                deccfbtn.Enabled = deccbbtn.Enabled;
            }
            else 
            {
                deccbbtn.Enabled = false;
                deccfbtn.Enabled = false;
            }
        }
        private void selectnandbtn_Click(object sender, EventArgs e)
        {
            if (select.ShowDialog() == DialogResult.OK)
            {
                nandfile.Text = select.FileName;
                path = Path.GetDirectoryName(select.FileName);
            }
            if (select.FileName.Length > 0) { select.FileName = Path.GetFileName(select.FileName); }
            else { select.FileName = "nand.bin"; }
            /*FileInfo fi = new FileInfo(nandfile.Text);
            if (string.IsNullOrEmpty(cpukey.Text))
            {
                MessageBox.Show(fi.Length.ToString());
                if ((fi.Length != 17301504) || (fi.Length != 69206016) || (fi.Length != 276824064) || (fi.Length != 553648128))
                {
                    corona4gbtn.Enabled = false;
                    confbtn.Enabled = false;
                    fcrtbtn.Enabled = false;
                    decsmcbtn.Enabled = false;
                    encsmcbtn.Enabled = false;
                    enckvbtn.Enabled = false;
                    enccbbtn.Enabled = false;
                    enccfbtn.Enabled = false;
                    deckvbtn.Enabled = false;
                    deccbbtn.Enabled = false;
                    deccfbtn.Enabled = false;
                }
            }*/
        }
        private void enccbbtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(nandfile.Text))
            {
                byte[] cba_data = Main.nand.getcba(nandfile.Text);
                if (cba_data.Length > 1)
                {
                    byte[] cbb_data = Main.nand.getcbb(nandfile.Text, 0x8000 + cba_data.Length);
                    if (cbb_data.Length < 1) 
                    {
                        save.Title = "Select where to save extracted CB";
                        save.FileName = "enc_cb.bin";
                    }
                    else 
                    {
                        save.Title = "Select where to save extracted CB_A";
                        save.FileName = "enc_cba.bin";
                    }
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            if (File.Exists(save.FileName)) { File.Delete(save.FileName); }
                            File.WriteAllBytes(save.FileName, cba_data);
                            if (cbb_data.Length > 1)
                            {
                                save.Title = "Select where to save extracted CB_B";
                                save.FileName = "enc_cbb.bin";
                                if (save.ShowDialog() == DialogResult.OK)
                                {
                                    try
                                    {
                                        if (File.Exists(save.FileName)) { File.Delete(save.FileName); }
                                        File.WriteAllBytes(save.FileName, cbb_data);
                                    }
                                    catch { MessageBox.Show("ERROR: Unable to save your extracted CB!", "ERROR - Can't save file...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                        }
                        catch { MessageBox.Show("ERROR: Unable to save your extracted CB!", "ERROR - Can't save file...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
            else { MessageBox.Show("ERROR: Cannot extract CB from a file that don't exists!", "ERROR - Missing file", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void enccfbtn_Click(object sender, EventArgs e)
        {
            string file = nandfile.Text;
            if (File.Exists(file))
            {
                int[] ret = Main.nand.getcf_offsets(file);
                if (ret[0] > 0)
                {
                    byte[] data = Main.nand.getcf(file, ret[0]);
                    if (data.Length > 1)
                    {
                        save.Title = "Select where to save CF slot 0";
                        save.FileName = "enc_cf_slot0.bin";
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                if (File.Exists(save.FileName)) { File.Delete(save.FileName); }
                                File.WriteAllBytes(save.FileName, data);
                                if (ret[1] > 1) { data = Main.nand.getcf(file, ret[1]); }
                                else { data = new byte[0]; }
                                if (data.Length > 1)
                                {
                                    save.Title = "Select where to save CF slot 1";
                                    save.FileName = "enc_cf_slot1.bin";
                                    if (save.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {
                                            if (File.Exists(save.FileName)) { File.Delete(save.FileName); }
                                            File.WriteAllBytes(save.FileName, data);
                                        }
                                        catch { MessageBox.Show("ERROR: Unable to save your extracted CF slot 1!", "ERROR - Unable to save CF slot 1", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                            }
                            catch { MessageBox.Show("ERROR: Unable to save your extracted CF slot 0!", "ERROR - Unable to save CF slot 0", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
            }
        }
        private void deccbbtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(nandfile.Text))
            {
                byte[] cba_data = Main.nand.getcba(nandfile.Text);
                if (cba_data.Length > 1)
                {
                    byte[] cbb_data = Main.nand.getcbb(nandfile.Text, 0x8000 + cba_data.Length);
                    cba_data = Main.crypt.DecryptCB(cba_data, Main.misc.cpukeytoarray(blkey.Text), null);
                    if (Main.crypt.blcheck(ref cba_data, 0x270, 0x120))
                    {
                        if (cbb_data.Length < 1)
                        {
                            save.Title = "Select where to save extracted CB";
                            save.FileName = "dec_cb.bin";
                        }
                        else
                        {
                            save.Title = "Select where to save extracted CB_A";
                            save.FileName = "dec_cba.bin";
                        }
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                if (File.Exists(save.FileName)) { File.Delete(save.FileName); }
                                File.WriteAllBytes(save.FileName, cba_data);
                                if ((cbb_data.Length > 1) && (cpukey.Text.Length == 32))
                                {
                                    cbb_data = Main.crypt.DecryptCB(cbb_data, Main.misc.cpukeytoarray(cpukey.Text), cba_data);
                                    if (Main.crypt.blcheck(ref cbb_data, 0x270, 0x120))
                                    {
                                        save.Title = "Select where to save extracted CB_B";
                                        save.FileName = "dec_cbb.bin";
                                        if (save.ShowDialog() == DialogResult.OK)
                                        {
                                            try
                                            {
                                                if (File.Exists(save.FileName)) { File.Delete(save.FileName); }
                                                File.WriteAllBytes(save.FileName, cbb_data);
                                            }
                                            catch { MessageBox.Show("ERROR: Unable to save your extracted CB!", "ERROR - Can't save file...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                                    else { MessageBox.Show("ERROR: Unable to decrypt CB! check cpukey!", "ERROR - Can't decrypt CB", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                            catch { MessageBox.Show("ERROR: Unable to save your extracted CB!", "ERROR - Can't save file...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    else { MessageBox.Show("ERROR: Unable to decrypt CB! check 1blkey!", "ERROR - Can't decrypt CB", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else { MessageBox.Show("ERROR: Cannot extract CB from a file that don't exists!", "ERROR - Missing file", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void deccfbtn_Click(object sender, EventArgs e)
        {
            string file = nandfile.Text;
            if (File.Exists(file))
            {
                int[] ret = Main.nand.getcf_offsets(file);
                if (ret[0] > 0)
                {
                    byte[] data = Main.nand.getcf(file, ret[0]);
                    if (data.Length > 1)
                    {
                        data = Main.crypt.DecryptCF(data, Main.misc.cpukeytoarray(blkey.Text));
                        save.Title = "Select where to save CF slot 0";
                        save.FileName = "dec_cf_slot0.bin";
                        if (Main.crypt.blcheck(ref data, 0x1F0, 0x20))
                        {
                            if (save.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    if (File.Exists(save.FileName)) { File.Delete(save.FileName); }
                                    File.WriteAllBytes(save.FileName, data);
                                    if (ret[1] > 1) { data = Main.nand.getcf(file, ret[1]); }
                                    else { data = new byte[0]; }
                                    if (data.Length > 1)
                                    {
                                        data = Main.crypt.DecryptCF(data, Main.misc.cpukeytoarray(blkey.Text));
                                        save.Title = "Select where to save CF slot 1";
                                        save.FileName = "dec_cf_slot1.bin";
                                        if (Main.crypt.blcheck(ref data, 0x1F0, 0x20))
                                        {
                                            if (save.ShowDialog() == DialogResult.OK)
                                            {
                                                try
                                                {
                                                    if (File.Exists(save.FileName)) { File.Delete(save.FileName); }
                                                    File.WriteAllBytes(save.FileName, data);
                                                }
                                                catch { MessageBox.Show("ERROR: Unable to save your extracted CF slot 1!", "ERROR - Unable to save CF slot 1", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                            }
                                        }
                                        else { MessageBox.Show("ERROR: Unable to decrypt CF! check 1blkey!", "ERROR - Can't decrypt CF", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                                catch { MessageBox.Show("ERROR: Unable to save your extracted CF slot 0!", "ERROR - Unable to save CF slot 0", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                        }
                        else { MessageBox.Show("ERROR: Unable to decrypt CF! check 1blkey!", "ERROR - Can't decrypt CF", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }
        public void corona4gbtn_Click(object sender, EventArgs e)
        {         
                extractFilesFromNand(nandfile.Text, path, cpukey.Text);
        }
        public void extractFilesFromNand(string file, string path, string key)
        {
            try
            {
                //Console.WriteLine("Extracting..");
                nand = new PrivateN(file, key);
                if (!nand.ok) return;
                string tmpout = "";
                if (Main.statc.output.Text != "") { path = Main.statc.output.Text; }
                tmpout = Path.Combine(path, "Data");
                /*if ((variables.modder) && (variables.custname != ""))
                {
                    tmpout = Path.Combine(Main.statc.output.Text, "Data");
                }
                else
                {
                    tmpout = Path.Combine(Main.statc.output.Text, "Data");
                }*/

                if (Directory.Exists(tmpout) == false)
                {
                    Directory.CreateDirectory(tmpout);
                }

                //Console.WriteLine("Saving SMC_en.bin");
                Oper.savefile(Nand.encrypt_SMC(nand._smc), Path.Combine(tmpout, "SMC_en.bin"));
                //Console.WriteLine("Saving SMC_dec.bin");
                Oper.savefile(nand._smc, Path.Combine(tmpout, "SMC_dec.bin"));
                //Console.WriteLine("Saving KV_en.bin");
                Oper.savefile(nand._rawkv, Path.Combine(tmpout, "KV_en.bin"));

                if (!String.IsNullOrEmpty(nand._cpukey))
                {
                    //Console.WriteLine("Saving KV_dec.bin");
                    Oper.savefile(Nand.decryptkv(nand._rawkv, Oper.StringToByteArray(nand._cpukey)), Path.Combine(tmpout, "KV_dec.bin"));
                }
                //Console.WriteLine("Saving smc_config.bin");
                nand.getsmcconfig();
                Oper.savefile(nand._smc_config, Path.Combine(tmpout, "smc_config.bin"));

                //if (variables.ctyp.ID == 1 || variables.ctyp.ID == 10 || variables.ctyp.ID == 11)
                //{
                byte[] t;
                //Console.WriteLine("Working...");
                byte[] fcrt = nand.exctractFSfile("fcrt.bin");
                if (fcrt != null)
                {
                    //Console.WriteLine("Saving fcrt_en.bin");
                    Oper.savefile(fcrt, Path.Combine(tmpout, "fcrt_en.bin"));
                    byte[] fcrt_dec;
                    if (Nand.decrypt_fcrt(fcrt, Oper.StringToByteArray(nand._cpukey), out fcrt_dec))
                    {
                        //Console.WriteLine("Saving fcrt_dec.bin");
                        File.WriteAllBytes(Path.Combine(tmpout, "fcrt_dec.bin"), fcrt_dec);
                    }
                    t = responses(fcrt, Oper.StringToByteArray(nand._cpukey), nand.ki.dvdkey);

                    if (t != null)
                    {

                        //Console.WriteLine("Saving C-R.bin");
                        File.WriteAllBytes(Path.Combine(tmpout, "C-R.bin"), t);
                        //Console.WriteLine("Saving key.bin");
                        File.WriteAllBytes(Path.Combine(tmpout, "key.bin"), Oper.StringToByteArray(nand.ki.dvdkey));
                        //Console.WriteLine("Done");
                        //Console.WriteLine("Save location {0}", tmpout);
                    }
                    else MessageBox.Show("Failed to create C-R.bin");
                }
                else MessageBox.Show("Failed to find fcrt.bin");
                //MessageBox.Show("Finished");
            }
            catch { MessageBox.Show("ERROR: Unable to extracted files, Maybe corrupt Nand or wrong cpukey..."); }
            
        }
        public static byte[] responses(byte[] fcrt, byte[] cpukey, string dvdkey = "")
        {
            byte[] fcrt_dec;
            if (Nand.decrypt_fcrt(fcrt, cpukey, out fcrt_dec))
            {
                byte[] rfct = new byte[0x1F6 * 0x13];
                Oper.removeByteArray(ref fcrt_dec, 0, 0x140);
                Random rnd = new Random();
                int[] randomNumbers = Enumerable.Range(0, 502).OrderBy(i => rnd.Next()).ToArray();
                int counter = 0;
                while (counter < (rfct.Length / 0x13))
                {
                    byte[] cr = Oper.returnportion(fcrt_dec, counter * 0x20, 0x20);
                    Oper.removeByteArray(ref cr, 2, 0x10 - 3);
                    Buffer.BlockCopy(cr, 0, rfct, randomNumbers[counter] * cr.Length, cr.Length);
                    counter++;
                }
                for (int i = 0; i < 0x1f6; i++)
                {
                    if (Oper.allsame(Oper.returnportion(fcrt_dec, i * 0x20, 0x10), 0x00)) continue;
                    for (int j = i + 1; j < 0x1f6; j++)
                    {
                        if (Oper.allsame(Oper.returnportion(fcrt_dec, j * 0x20, 0x10), 0x00)) continue;
                        if (rfct[i * 0x13] == rfct[j * 0x13] &&
                            rfct[(i * 0x13) + 1] == rfct[(j * 0x13) + 1] &&
                            rfct[(i * 0x13) + 2] == rfct[(j * 0x13) + 2])
                        {
                            if (variables.debugme) Console.WriteLine("You're FUCKED");
                        }
                    }
                }
                return encryptFirmware(rfct, variables.xor, rfct.Length);
            }
            return null;
        }
        private static byte[] encryptFirmware(byte[] inputBuffer, byte[] XorList, int size)
        {
            int[] encryptBits = { 3, 2, 7, 6, 1, 0, 5, 4 };
            int i;
            byte bt, done;
            byte[] outputBuffer = new byte[size];
            for (i = 0; i < size; i++)
            {
                bt = (byte)(inputBuffer[i] ^ XorList[i]);
                done = swapBits(bt, encryptBits);
                outputBuffer[i] = done;
            }
            return outputBuffer;
        }
        private static byte swapBits(byte chunk, int[] bits)
        {
            byte result = 0;
            //var bit = (b & (1 << bits[i])) != 0;
            int i;
            for (i = 0; i < 8; i++)
            {
                byte bit = (byte)((chunk & (1 << bits[i])) >> bits[i]);
                result = (byte)((result << 1) | bit);
            }
            return result;
        }

    }
}