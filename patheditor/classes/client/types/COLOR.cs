using System;
using System.Drawing;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.lm;

namespace com.jds.PathEditor.classes.client.types
{
    public class COLOR : IType
    {
        public Color Value { get; set; }

        #region IType Members

        public IType read(BinaryReader b)
        {
            Value = Color.FromArgb(b.ReadInt32());
            return this;
        }

        public IType write(BinaryWriter d)
        {
            d.Write(Value.ToArgb());
            return this;
        }

        public void writeHeader(String name, StreamWriter stream)
        {
            stream.Write(name + "\t");
        }

        public void parse(String value, String[] tokens, int index, out int outindex)
        {
            outindex = index;
            Value = ConvertUtilities.HtmlColorToColor(value.Trim());
        }

        #endregion

        public override string ToString()
        {
            return ConvertUtilities.ColorToHtmlColor(Value);
        }

        public String toText()
        {
            return ToString();
        }
    }
}