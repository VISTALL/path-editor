using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.parser;

namespace com.jds.PathEditor.classes.client.types
{
    public class CNTTXT_THIRD : IType
    {
        private int cnt;

        private string text; // [cnt]
        private string values; //[cnt]

        public int length
        {
            get { return cnt; }
        }

        #region IType Members

        public IType read(BinaryReader f)
        {
            cnt = f.ReadInt32();
            text = "";
            values = "";

            for (int i = 0; i < cnt; i++)
            {
                text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                if (i < cnt - 1)
                    text += DatTool.DELIMITER;
            }

            for (int i = 0; i < cnt; i++)
            {
                values += f.ReadInt32().ToString();
                if (i < cnt - 1)
                    values += DatTool.DELIMITER;
            }
            return this;
        }

        public IType write(BinaryWriter f)
        {
            string[] TmpStr = text.Split(new[] {DatTool.DELIMITER});
            string[] TmpValues = values.Split(new[] {DatTool.DELIMITER});
            f.Write(cnt);

            for (int i = 0; i < cnt; i++)
            {
                DatTool.WriteStringSimple_UnicodeInt32Length(f, TmpStr[i]);
            }

            for (int i = 0; i < cnt; i++)
            {
                f.Write(int.Parse(TmpValues[i]));
            }

            return this;
        }

        public void writeHeader(String prefix, StreamWriter stream)
        {
            stream.Write(prefix + "_cnt\t" + prefix + "_text\t" + prefix + "_values\t");
        }

        public void parse(String v, String[] tokens, int index, out int outindex)
        {
            outindex = index;
            var value = new string[3];
            for (int k = 0; k < 3; k++)
            {
                value[k] = tokens[outindex];
                if (k < 2)
                    outindex++;
            }

            cnt = Convert.ToInt32(value[0]);
            text = value[1];
            values = value[2];
        }

        #endregion

        public void setText(string[] value)
        {
            cnt = Convert.ToInt32(value[0]);
            text = value[1];
            values = value[2];
        }

        public int getFieldCount()
        {
            return 3;
        }

        public override String ToString()
        {
            string res = "";
            res += cnt + "\t";

            if (cnt > 1)
                res += "\"" + text + "\t" + values + "\""; //\t";
            else
                res += text + "\t" + values; // + "\t";

            return res;
        }
    }
}