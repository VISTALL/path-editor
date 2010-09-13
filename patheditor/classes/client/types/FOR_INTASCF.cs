using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.lm;
using com.jds.PathEditor.classes.parser;

namespace com.jds.PathEditor.classes.client.types
{
    public class FOR_INTASCF : IType
    {
        public FOR_INTASCF()
        {
            Value = "";
        }

        public string Value
        {
            get; set;
        }

        public IType read(BinaryReader b)
        {
            int size = b.ReadInt32();
            for(int i = 0; i < size; i ++)
            {
                int id = b.ReadInt32();
                String text = ConvertUtilities.replaceIn(DatTool.ReadString(b));
                Value += "(" + id + ":" + text + ")";
                if (i < size - 1)
                    Value += DatTool.DELIMITER;
            }

            return this;
        }

        public IType write(BinaryWriter f)
        {
            string[] values = Value.Split(DatTool.DELIMITER);
            f.Write(Convert.ToInt32(values.Length));
            foreach (string parseS in values)
            {
                string[] v = parseS.Replace("(", "").Replace(")", "").Split(':');
                f.Write(Convert.ToInt32(v[0]));
                DatTool.WriteString(f, ConvertUtilities.replaceIn(v[1]));
            }

            return this;
        }

        public void writeHeader(string name, StreamWriter writer)
        {
            writer.Write(name + "\t");
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
