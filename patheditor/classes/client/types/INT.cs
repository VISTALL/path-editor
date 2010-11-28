using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;

namespace com.jds.PathEditor.classes.client.types
{
    public class INT : IType, IComparable<INT>
    {
        public INT()
        {
            Value = 0;
        }

        public int Value { get; set; }

        #region IType Members

        public IType read(BinaryReader b)
        {
            Value = b.ReadInt32();
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
            Value = int.Parse(value.Trim());
        }

        #endregion

        public int CompareTo(INT other)
        {
            return Value.CompareTo(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            return obj is INT ? Value == ((INT)obj).Value : false;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}