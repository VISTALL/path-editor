using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.parser;

namespace com.jds.PathEditor.classes.client.types
{
    public class CNTTXT_PAIR : IType
    {
        private int cnt;
        private string text; // [cnt]

        public int Length
        {
            get { return cnt; }
            set { cnt = value; }
        }

        public String Text
        {
            get { return text; }
            set { text = value; }
        }

        #region IType Members

        public IType read(BinaryReader f)
        {
            cnt = f.ReadInt32();
            text = "";
            for (int i = 0; i < cnt; i++)
            {
                text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                if (i < cnt - 1)
                    text += DatTool.DELIMITER;
            }
            return this;
        }

        public IType write(BinaryWriter f)
        {
            string[] TmpStr = text.Split(new[] {DatTool.DELIMITER});
            f.Write(cnt);

            for (int i = 0; i < cnt; i++)
            {
                DatTool.WriteStringSimple_UnicodeInt32Length(f, TmpStr[i]);
            }

            return this;
        }

        public void writeHeader(String prefix, StreamWriter stream)
        {
            stream.Write(prefix + "_cnt\t" + prefix + "_text\t");
        }

        public void parse(String v, String[] tokens, int index, out int outindex)
        {
            outindex = index;
            var value = new string[2];
            for (int k = 0; k < 2; k++)
            {
                value[k] = tokens[outindex];
                if (k < 1)
                    outindex++;
            }

            cnt = Convert.ToInt32(value[0]);
            text = value[1];
        }

        #endregion

        public override String ToString()
        {
            string res = "";
            res += cnt + "\t";
            if (cnt > 1)
                res += "\"" + text + "\""; //\t";
            else
                res += text; // +"\t";
            return res;
        }
    }
}