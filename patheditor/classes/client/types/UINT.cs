using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;

namespace com.jds.PathEditor.classes.client.types
{
    public class UINT : IType, IComparable<UINT>
    {
        public UINT()
        {
            Value = 0;
        }

        public uint Value { get; set; }

        #region IType Members

        public IType read(BinaryReader b)
        {
            Value = b.ReadUInt32();
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
            Value = Convert.ToUInt32(value.Trim());
        }

        #endregion

        public override string ToString()
        {
            return Value.ToString();
        }

        public int CompareTo(UINT obj)
        {
            return Value.CompareTo(obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is UINT ? Value == ((UINT)obj).Value : false;
        }
    }
}