using System;
using System.IO;
using System.Text;

namespace com.jds.PathEditor.classes.parser
{
    public class DatTool
    {
        public const char DELIMITER = '|';

        public static int ReadByteCount(BinaryReader f)
        {
            byte tmp = f.ReadByte();
            int len = tmp & 0x3F;
            if ((tmp & 0x40) > 0)
            {
                tmp = f.ReadByte();
                len += tmp << 6;
            }
            return len;
        }

        public static readonly byte BYTE_MAX_VALUE = 128;

        public static string ReadString(BinaryReader f)
        {
            int len = f.ReadByte();
            if (len == 0)
            {
                return "";
            }

            if (len >= 192)
            {
                byte len2 = f.ReadByte();
                
                if (len2 >= BYTE_MAX_VALUE)
                {
                    f.BaseStream.Seek(-2, SeekOrigin.Current); //go to start read
                    len = GetMediumInt(f);
                }
            }

            long start_pos = f.BaseStream.Position;
            long end_pos = start_pos;

            Encoding enc = Encoding.Default;
            byte one_ch_len = 1;

            if (len >= short.MaxValue)
            {
                // unicode string
                enc = Encoding.Unicode;
                one_ch_len = 3;

                while (true)
                {
                    short ch = f.ReadInt16();
                    if (ch == 0)
                    {
                        end_pos = f.BaseStream.Position;
                        break;
                    }
                }                    
            }
            else if (len >= BYTE_MAX_VALUE)
            {
                // unicode string
                enc = Encoding.Unicode;
                one_ch_len = 2;

                while (true)
                {
                    short ch = f.ReadInt16();
                    if (ch == 0)
                    {
                        end_pos = f.BaseStream.Position;
                        break;
                    }
                }
            }
            else
            {
                if (char.IsControl((char) f.PeekChar()))
                {
                    f.BaseStream.Seek(1, SeekOrigin.Current);
                    start_pos = f.BaseStream.Position;
                }

                // ansi string
                while (true)
                {
                    byte ch = f.ReadByte();
                    if (ch == 0)
                    {
                        end_pos = f.BaseStream.Position;
                        break;
                    }
                }
            }

            long real_len = end_pos - start_pos - one_ch_len;

            f.BaseStream.Seek(start_pos, SeekOrigin.Begin);

            byte[] buf = f.ReadBytes((int) real_len);
            string res = enc.GetString(buf);

            f.BaseStream.Seek(one_ch_len, SeekOrigin.Current);

            return res;
        }

        private static int GetMediumInt(BinaryReader binaryReader)
        {
            var b1 = binaryReader.ReadByte();
            var b2 = binaryReader.ReadByte();
            var b3 = binaryReader.ReadByte();

            return GetMediumInt(b3, b2, b1);
        }

        private static int GetMediumInt(byte b1, byte b2, byte b3)
        {
            long ret = b1 << 16 & 0xff0000 | b2 << 8 & 0xff00 | b3 & 0xff;
            // Check to see if the medium int is negative (high bit in b1 set)
            if ((b1 & 0x80) == 0x80)
            {
                // Make the the whole int negative
                ret |= 0xff000000;
            }
            return (int)ret;
        }

        public static string ReadStringSimple_UnicodeInt32Length(BinaryReader f)
        {
            long SavePos = f.BaseStream.Position;
            int len = f.ReadInt32();
            if (len > 10000)
            {
                f.BaseStream.Seek(SavePos, SeekOrigin.Begin);
                Console.Out.WriteLine("!!!!! [WARNING] !!!!!");
                Debug_ByteDump(f, 32);
            }
            if (len == 0)
                return "";

            var buf = new byte[len];
            f.Read(buf, 0, len);

            return Encoding.Unicode.GetString(buf);
        }

        public static void WriteByteCount(BinaryWriter f, int len)
        {
            if (len > 0x3F)
            {
                int LByte = len & 0x3F;
                int HByte = len >> 6;
                f.Write((byte) (LByte | 0x40));
                f.Write((byte) HByte);
            }
            else
            {
                f.Write((byte) len);
            }
        }

        public static void WriteString(BinaryWriter f, string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                bool is_unicode = false;
                for (int k = 0; k < str.Length; k++)
                {
                    int code = str[k];
                    if (code > 255 && code != 1081)
                    {
                        is_unicode = true;
                        break;
                    }
                }

                int len = str.Length + 1;
                
              /**  if (len >= 16384)//(short.Max_value + 1 / 2) TODO how it write
                {
                    int len_part3 = len / 16384;
                    int len_part2 = len - ((len_part3 - 1) * 16384);
                    int len_part1 = len - ((len_part2 - 1) * 16384);

                    // set highest bit cause to indicate it is Unicode
                    if (is_unicode)
                    {
                        len_part1 += 128;
                    }

                    f.Write(len_part1);
                    f.Write(len_part2);
                    f.Write(len_part3);
                }
                else*/
                if (len >= 64)
                {
                    int len_part2 = len/64;
                    int len_part1 = len - ((len_part2 - 1)*64);

                    // set highest bit cause to indicate it is Unicode
                    if (is_unicode)
                    {
                        len_part1 += 128;
                    }

                    f.Write((byte) len_part1);
                    f.Write((byte) len_part2);
                }
                else
                {
                    // set highest bit cause to indicate it is Unicode
                    if (is_unicode)
                        len += 128;

                    f.Write((byte) len);
                }

                if (is_unicode)
                {
                    f.Write(Encoding.Unicode.GetBytes(str));
                    f.Write((byte) 0x00);
                }
                else
                {
                    f.Write(Encoding.Default.GetBytes(str));
                }
            }

            f.Write((byte) 0x00);
        }

        public static void WriteStringSimple_UnicodeInt32Length(BinaryWriter f, string str)
        {
            f.Write((UInt32) (str.Length*2));

            if (str.Length > 0)
                f.Write(Encoding.Unicode.GetBytes(str));
        }

        public static void Debug_ByteDump(BinaryReader f, int cnt)
        {
            long SavePos = f.BaseStream.Position;
            Console.Out.WriteLine("+00 +01 +02 +03 +04 +05 +06 +07 +08 +09 +0A +0B +0C +0D +0E +0F");
            Console.Out.WriteLine("---------------------------------------------------------------");
            for (int i = 0, j = 1; i < cnt; i++, j++)
            {
                if (f.BaseStream.Position >= f.BaseStream.Length)
                    break;
                byte temp = f.ReadByte();
                Console.Out.Write(String.Format(" {0:X2} ", temp));
                if (j%16 == 0)
                    Console.Out.Write("\n");
            }
            Console.Out.Write("\n");
            f.BaseStream.Seek(SavePos, SeekOrigin.Begin);
        }

        public static string Debug_DumpString(BinaryReader f, long pos, int cnt)
        {
            string ret = "";
            f.BaseStream.Seek(pos, SeekOrigin.Begin);
            for (int i = 0; i < cnt; i++)
            {
                if (f.BaseStream.Position >= f.BaseStream.Length)
                    break;
                byte temp = f.ReadByte();
                ret += String.Format("{0:X2}:", temp);
            }
            return ret;
        }
    }
}