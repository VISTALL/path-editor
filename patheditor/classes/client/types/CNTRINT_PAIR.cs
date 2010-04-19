using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.lm;
using com.jds.PathEditor.classes.parser;

namespace com.jds.PathEditor.classes.client.types
{
    public class CNTRINT_PAIR : IType
    {
        private int cntr;
        private string text; // [cnt]

        public String Text
        {
            get { return text; }
            set { text = value; }
        }

        public int Length
        {
            get { return cntr; }
            set { cntr = value; }
        }

        #region IType Members

        public IType read(BinaryReader f)
        {
            cntr = DatTool.ReadByteCount(f);
            text = "";
            for (int i = 0; i < cntr; i++)
            {
                text += f.ReadInt32().ToString();
                if (i < cntr - 1)
                    text += DatTool.DELIMITER;
            }

            text = ConvertUtilities.replaceOut(text);
            return this;
        }

        public IType write(BinaryWriter f)
        {
            text = ConvertUtilities.replaceIn(text);

            if (text.Length > 0)
            {
                string[] TmpStr = text.Split(new[] {DatTool.DELIMITER});
                DatTool.WriteByteCount(f, cntr);
                for (int i = 0; i < cntr; i++)
                {
                    f.Write(Convert.ToInt32(TmpStr[i]));
                }
            }
            else
                DatTool.WriteByteCount(f, 0);

            return this;
        }

        public void writeHeader(String prefix, StreamWriter stream)
        {
            stream.Write(prefix + "_cntr\t" + prefix + "_text\t");
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

            cntr = Convert.ToInt32(value[0].Trim());
            text = value[1];
        }

        #endregion

        public override String ToString()
        {
            string res = "";
            res += cntr + "\t";
            if (cntr > 1)
                res += "\"" + text + "\""; //\t";
            else
                res += text; // + "\t";

            return res;
        }
    }
}