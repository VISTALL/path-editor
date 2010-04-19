using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;

namespace com.jds.PathEditor.classes.client.types
{
    public class HEX : IType
    {
        private string text = "";

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        #region IType Members

        public IType read(BinaryReader f)
        {
            byte[] temp = f.ReadBytes(4);
            Text = BitConverter.ToString(temp);
            return this;
        }

        public IType write(BinaryWriter f)
        {
            string[] TmpStr = text.Split(new[] {'-'});
            for (int i = 0; i < TmpStr.Length; i++)
            {
                f.Write(Convert.ToByte(TmpStr[i], 16));
            }

            return this;
        }

        public void writeHeader(String name, StreamWriter stream)
        {
            stream.Write(name + "\t");
        }

        public void parse(String value, String[] tokens, int index, out int outindex)
        {
            outindex = index;
            Text = value;
        }

        #endregion

        public override string ToString()
        {
            return Text;
        }
    }
}