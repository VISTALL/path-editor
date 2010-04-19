using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.parser;

namespace com.jds.PathEditor.classes.client.types
{
    [Obsolete("Use insted CNTTXT_PAIR x2")]
    public class MTX : IType
    {
        private int cnt1;
        private int cnt2;
        private string text1; // [cnt1]
        private string text2; // [cnt2]

        #region IType Members

        public IType read(BinaryReader f)
        {
            cnt1 = f.ReadInt32();
            text1 = "";
            for (int i = 0; i < cnt1; i++)
            {
                text1 += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                if (i < cnt1 - 1)
                    text1 += DatTool.DELIMITER;
            }
            cnt2 = f.ReadInt32();
            text2 = "";
            for (int i = 0; i < cnt2; i++)
            {
                text2 += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                if (i < cnt2 - 1)
                    text2 += DatTool.DELIMITER;
            }
            return this;
        }

        public IType write(BinaryWriter f)
        {
            string[] TmpStr = text1.Split(new[] {DatTool.DELIMITER});
            f.Write(cnt1);
            for (int i = 0; i < cnt1; i++)
            {
                DatTool.WriteStringSimple_UnicodeInt32Length(f, TmpStr[i]);
            }
            TmpStr = text2.Split(new[] {DatTool.DELIMITER});
            f.Write(cnt2);
            for (int i = 0; i < cnt2; i++)
            {
                DatTool.WriteStringSimple_UnicodeInt32Length(f, TmpStr[i]);
            }

            return this;
        }

        public void writeHeader(String prefix, StreamWriter stream)
        {
            stream.Write(prefix + "_cnt1\t" + prefix + "_text1\t" + prefix + "_cnt2\t" + prefix + "_text2\t");
        }

        public void parse(String v, String[] tokens, int index, out int outindex)
        {
            outindex = index;
            var value = new string[4];
            for (int k = 0; k < 4; k++)
            {
                value[k] = tokens[outindex];
                if (k < 3)
                    outindex++;
            }

            cnt1 = Convert.ToInt32(value[0]);
            text1 = value[1];
            cnt2 = Convert.ToInt32(value[2]);
            text2 = value[3];
        }

        #endregion

        public override String ToString()
        {
            string res = "";

            res += cnt1 + "\t";

            if (cnt1 > 1)
                res += "\"" + text1 + "\"\t";
            else
                res += text1 + "\t";

            res += cnt2 + "\t";

            if (cnt2 > 1)
                res += "\"" + text2 + "\""; //"\t";
            else
                res += text2; // + "\t";

            return res;
        }
    }
}