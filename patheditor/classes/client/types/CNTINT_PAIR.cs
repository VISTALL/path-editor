using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.lm;
using com.jds.PathEditor.classes.parser;

namespace com.jds.PathEditor.classes.client.types
{
    public class CNTINT_PAIR : IType
    {
        private int cnt;

        public String Text { get; set; }

        #region IType Members

        public IType read(BinaryReader f)
        {
            cnt = f.ReadInt32();
            Text = "";
            for (int i = 0; i < cnt; i++)
            {
                Text += f.ReadInt32().ToString();
                if (i < cnt - 1)
                    Text += DatTool.DELIMITER;
            }
            Text = ConvertUtilities.replaceIn(Text);
            return this;
        }

        public IType write(BinaryWriter f)
        {
            Text = ConvertUtilities.replaceOut(Text);
            string[] TmpStr = Text.Split(new[] {DatTool.DELIMITER});
            f.Write(cnt);

            for (int i = 0; i < cnt; i++)
            {
                f.Write(Convert.ToInt32(TmpStr[i]));
            }

            return this;
        }

        public void writeHeader(String prefix, StreamWriter w)
        {
            w.Write(prefix + "_cnt\t" + prefix + "_text\t");
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
            Text = value[1];
        }

        #endregion

        public override String ToString()
        {
            string res = "";
            res += cnt + "\t";
            if (cnt > 1)
                res += "\"" + Text + "\""; //\t";
            else
                res += Text; // + "\t";
            return res;
        }
    }
}