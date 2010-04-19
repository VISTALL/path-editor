using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;

namespace com.jds.PathEditor.classes.client.types
{
    public class FLOAT : IType
    {
        public FLOAT()
        {
            Value = 0;
        }

        public float Value { get; set; }

        #region IType Members

        public IType read(BinaryReader b)
        {
            Value = b.ReadSingle();
            return this;
        }

        public IType write(BinaryWriter f)
        {
            f.Write(Value);
            return this;
        }

        public void writeHeader(String name, StreamWriter stream)
        {
            stream.Write(name + "\t");
        }

        public void parse(String value, String[] tokens, int index, out int outindex)
        {
            outindex = index;
            Value = Convert.ToSingle(value.Trim());
        }

        #endregion

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}