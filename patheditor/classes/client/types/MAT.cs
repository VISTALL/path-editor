using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;

namespace com.jds.PathEditor.classes.client.types
{
    public class MAT : IType
    {
        public MAT()
        {
            Value = "";
        }

        public string Value
        {
            get; set;
        }

        public IType read(BinaryReader b)
        {
            int MatCnt = b.ReadInt32();
            for (int i = 0; i < MatCnt; i++)
            {
                Value += "[" + b.ReadInt32();
                Value += "(" + b.ReadInt32() + ")]";
                if (i < MatCnt - 1)
                    Value += ",";
            }

            return this;
        }

        public IType write(BinaryWriter f)
        {
            string[] TmpStr = Value.Split(new[] { ',' });
            f.Write(TmpStr.Length);
            for (int i = 0; i < TmpStr.Length; i++)
            {
                TmpStr[i] = TmpStr[i].Trim('[', ')', ']');
                String[] TmpStr2 = TmpStr[i].Split(new[] { '(' });
                f.Write(Convert.ToInt32(TmpStr2[0]));
                f.Write(Convert.ToInt32(TmpStr2[1]));
            }

            return this;
        }

        public void writeHeader(string name, StreamWriter writer)
        {
            writer.Write("materials" + "\t");
        }

        public void parse(string value, string[] tokens, int index, out int outindex)
        {
            outindex = index;
            Value = value.Trim();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}