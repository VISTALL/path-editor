using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.parser;

namespace com.jds.PathEditor.classes.client.types
{
    public class MTX3 : IType
    {
        private int cnt1;
        private int cnt2;
        private string text1; // [cnt1]
        private string text2; // [cnt2]
        private string text3;
        private string unknown1; // [cnt1]

        #region IType Members

        public IType read(BinaryReader f)
        {
            cnt1 = f.ReadInt32();
            text1 = "";
            unknown1 = "";
            for (int i = 0; i < cnt1; i++)
            {
                text1 += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                if (i < cnt1 - 1)
                    text1 += DatTool.DELIMITER;

                byte[] temp = f.ReadBytes(2);
                unknown1 += BitConverter.ToString(temp);
                if (i < cnt1 - 1)
                    unknown1 += DatTool.DELIMITER;
            }
            cnt2 = f.ReadInt32();
            text2 = "";
            for (int i = 0; i < cnt2; i++)
            {
                text2 += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                if (i < cnt2 - 1)
                    text2 += DatTool.DELIMITER;
            }
            text3 += DatTool.ReadStringSimple_UnicodeInt32Length(f);

            return this;
        }

        public IType write(BinaryWriter f)
        {
            string[] TmpStr = text1.Split(new[] {DatTool.DELIMITER});
            string[] TmpStr2 = unknown1.Split(new[] {DatTool.DELIMITER});
            f.Write(cnt1);
            for (int i = 0; i < cnt1; i++)
            {
                DatTool.WriteStringSimple_UnicodeInt32Length(f, TmpStr[i]);
                string[] TmpStr3 = TmpStr2[i].Split(new[] {'-'});
                for (int j = 0; j < TmpStr3.Length; j++)
                {
                    f.Write(Convert.ToByte(TmpStr3[j], 16));
                }
            }
            TmpStr = text2.Split(new[] {DatTool.DELIMITER});
            f.Write(cnt2);
            for (int i = 0; i < cnt2; i++)
            {
                DatTool.WriteStringSimple_UnicodeInt32Length(f, TmpStr[i]);
            }
            DatTool.WriteStringSimple_UnicodeInt32Length(f, text3);

            return this;
        }

        public void writeHeader(String prefix, StreamWriter stream)
        {
            stream.Write(prefix + "_cnt1\t" +
                         prefix + "_text1\t" +
                         prefix + "_unknown1\t" +
                         prefix + "_cnt2\t" +
                         prefix + "_text2\t" +
                         prefix + "_text3\t");
        }

        public void parse(String v, String[] tokens, int index, out int outindex)
        {
            outindex = index;
            var value = new string[6];
            for (int k = 0; k < 6; k++)
            {
                value[k] = tokens[outindex];
                if (k < 5)
                    outindex++;
            }

            cnt1 = Convert.ToInt32(value[0]);
            text1 = value[1];
            unknown1 = value[2];
            cnt2 = Convert.ToInt32(value[3]);
            text2 = value[4];
            text3 = value[5];
        }

        #endregion

        public override String ToString()
        {
            string res = "";
            res += cnt1 + "\t";
            if (cnt1 > 1)
            {
                res += "\"" + text1 + "\"\t";
                res += "\"" + unknown1 + "\"\t";
            }
            else
            {
                res += text1 + "\t";
                res += unknown1 + "\t";
            }
            res += cnt2 + "\t";
            if (cnt2 > 1)
                res += "\"" + text2 + "\"\t";
            else
                res += text2 + "\t";

            res += text3; // + "\t";
            return res;
        }
    }
}