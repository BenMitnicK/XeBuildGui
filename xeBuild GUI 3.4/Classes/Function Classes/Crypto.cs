using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace xeBuild_GUI
{
    class crypto
    {
        private void RC4(ref Byte[] bytes, Byte[] key)
        {
            Byte[] s = new Byte[256], k = new Byte[256];
            Byte temp;
            int i, j;
            for (i = 0; i < 256; i++)
            {
                s[i] = (Byte)i;
                k[i] = key[i % key.GetLength(0)];
            }
            j = 0;
            for (i = 0; i < 256; i++)
            {
                j = (j + s[i] + k[i]) % 256;
                temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }
            i = j = 0;
            for (int x = 0; x < bytes.GetLength(0); x++)
            {
                i = (i + 1) % 256;
                j = (j + s[i]) % 256;
                temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                int t = (s[i] + s[j]) % 256;
                bytes[x] ^= s[t];
            }
        }
        public byte[] DecryptSMC(byte[] encdata)
        {
            byte[] key = { 0x42, 0x75, 0x4E, 0x79 };
            //int[] Keys = { 0x42, 0x75, 0x4E, 0x79 };
            int i = 0;
            int mod;
            byte[] decdata = new byte[encdata.Length];
            for (i = 0; i < encdata.Length; i++)
            {
                //int byteChar = encdata[i];
                mod = (encdata[i] * 0xFB);
                decdata[i] = (byte)(encdata[i] ^ (key[i & 3] & 0xFF));
                key[(i + 1) & 3] += (byte)mod;
                key[(i + 2) & 3] += Convert.ToByte(mod >> 8);
            }
            return decdata;
        }
        public byte[] DecryptKV(byte[] encdata, string cpukey)
        {
            byte[] key = Main.misc.cpukeytoarray(cpukey);
            byte[] tmp = new byte[encdata.Length - 0x10];
            byte[] header = new byte[0x10];
            Array.Copy(encdata, 0x0, header, 0x0, 0x10);
            Buffer.BlockCopy(encdata, 0x10, tmp, 0x0, tmp.Length);
            key = new HMACSHA1(key, false).ComputeHash(header);
            Array.Resize(ref key, 0x10);
            RC4(ref tmp, key);
            byte[] decdata = new byte[encdata.Length];
            Array.Copy(header, decdata, header.Length);
            Buffer.BlockCopy(tmp, 0x0, decdata, header.Length, tmp.Length);
            return decdata;
        }
        public byte[] DecryptCB(byte[] encdata, byte[] inkey, byte[] cba)
        {
            bool error = false;
            UInt16 type = 0;
            if (cba != null) { type = Main.misc.swap16(BitConverter.ToUInt16(cba, 6)); }
            else
            {
                type = Main.misc.swap16(BitConverter.ToUInt16(encdata, 6));
                if ((type == 0x800) || (type == 0x1800)) { type = 0; }
            }
            byte[] header = new byte[0x10];
            Array.Copy(encdata, 0x10, header, 0x0, 0x10);
            byte[] decdata = new byte[encdata.Length];
            Array.Copy(encdata, decdata, 0x10);
            byte[] key = new byte[0];
            if (type == 0) { key = new HMACSHA1(inkey).ComputeHash(header); }
            else if ((type == 0x800) && (cba != null))
            {
                Array.Resize(ref header, 0x20);
                Array.Copy(inkey, 0x0, header, 0x10, 0x10);
                byte[] cbakey = new byte[0x10];
                Array.Copy(cba, 0x10, cbakey, 0x0, 0x10);
                key = new HMACSHA1(cbakey).ComputeHash(header);
            }
            else if ((type == 0x1800) && (cba != null))
            {
                header = new byte[0x30];
                Array.Copy(encdata, 0x10, header, 0x0, 0x10);
                Array.Copy(inkey, 0x0, header, 0x10, 0x10);
                Array.Copy(cba, 0x0, header, 0x20, 0x6);
                Array.Copy(cba, 0x8, header, 0x20 + 0x8, 0x8);
                byte[] cbakey = new byte[0x10];
                Array.Copy(cba, 0x10, cbakey, 0x0, 0x10);
                key = new HMACSHA1(cbakey).ComputeHash(header);
            }
            else
            {
                error = true;
                MessageBox.Show("ERROR: Unkown crypto type! (0x" + type.ToString("X4") + ") or cba data is missing (major bug)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!error)
            {
                Array.Resize(ref key, 0x10);
                Array.Copy(key, 0x0, decdata, 0x10, 0x10);
                byte[] decrypted = new byte[encdata.Length - 0x20];
                Buffer.BlockCopy(encdata, 0x20, decrypted, 0x0, decrypted.Length);
                RC4(ref decrypted, key);
                Buffer.BlockCopy(decrypted, 0x0, decdata, 0x20, decrypted.Length);
                return decdata;
            }
            else { return new byte[0]; }
        }
        public byte[] DecryptCB(byte[] encdata, byte[] key) { return DecryptCB(encdata, key, null); }
        public byte[] DecryptCF(byte[] encdata, byte[] inkey)
        {
            byte[] header = new byte[0x10];
            Array.Copy(encdata, 0x20, header, 0x0, 0x10);
            byte[] key = new HMACSHA1(inkey).ComputeHash(header);
            Array.Resize(ref key, 0x10);
            byte[] decdata = new byte[encdata.Length];
            Buffer.BlockCopy(encdata, 0x0, decdata, 0x0, 0x20);
            Array.Copy(key, 0x0, decdata, 0x20, key.Length);
            byte[] decrypted = new byte[encdata.Length - 0x30];
            Buffer.BlockCopy(encdata, 0x30, decrypted, 0x0, decrypted.Length);
            RC4(ref decrypted, key);
            Buffer.BlockCopy(decrypted, 0x0, decdata, 0x30, decrypted.Length);
            return decdata;
        }
        public bool kvcheck(byte[] data, string key)
        {
            bool ret = true;
            byte[] header = new byte[0x10], tmp = new byte[0x4002 - 0x10];
            Array.Copy(data, 0x0, header, 0x0, 0x10);
            Array.Copy(data, 0x10, tmp, 0x0, 0x4000 - 0x10);
            tmp[0x3FF0] = 0x7;
            tmp[0x3FF1] = 0x12;
            byte[] checkdata = new HMACSHA1(Main.misc.cpukeytoarray(key), false).ComputeHash(tmp);
            Array.Resize(ref checkdata, 0x10);
            for (int i = 0; i < checkdata.Length; i++) { if (checkdata[i] != header[i]) { ret = false; } }
            return ret;
        }
        public bool blcheck(ref byte[] data, int offset, int length)
        {
            bool ret = true;
            for (int i = 0; i < length; i++) { if (data[offset + i] != 0x00) { ret = false; } }
            return ret;
        }
    }
}