using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;

namespace com.jds.PathEditor.classes.client.types
{
    public class STRING : IType
    {
        public STRING()
        {
            Value = "";
        }

        public String Value { get; set; }

        #region IType Members

        public IType read(BinaryReader b)
        {
            //Value = b.ReadString();
            return this;
        }

        public IType write(BinaryWriter f)
        {
            f.Write(Value);
            return this;
        }

        public void writeHeader(string name, StreamWriter writer)
        {
            writer.Write(name + "\t");
        }

        public void parse(string value, string[] tokens, int index, out int outindex)
        {
            outindex = index;
            Value = value;
        }

        #endregion

        public override string ToString()
        {
            return Value;
        }
    }
}