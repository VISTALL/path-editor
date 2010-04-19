using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.lm;
using com.jds.PathEditor.classes.parser;

namespace com.jds.PathEditor.classes.client.types
{
    public class UNICODE : IType
    {
        private string text = "";

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        #region IType Members

        public IType read(BinaryReader r)
        {
            Text = DatTool.ReadStringSimple_UnicodeInt32Length(r);
            Text = ConvertUtilities.replaceOut(Text);
            return this;
        }

        public IType write(BinaryWriter f)
        {
            Text = ConvertUtilities.replaceIn(Text);
            DatTool.WriteStringSimple_UnicodeInt32Length(f, Text);
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