using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;

namespace com.jds.PathEditor.classes.client.types
{
    public class FLOAT_119 : IType
    {
        private readonly float[] _values = new float[119];

        #region IType Members

        public IType read(BinaryReader b)
        {
            for (int i = 0; i < _values.Length; i++)
            {
                _values[i] = b.ReadSingle();
            }
            return this;
        }

        public IType write(BinaryWriter f)
        {
            for (int i = 0; i < _values.Length; i++)
            {
                f.Write(_values[i]);
            }
            return this;
        }

        public void writeHeader(String prefix, StreamWriter stream)
        {
            String t = "";
            for (int i = 0; i < _values.Length; i++)
            {
                t += prefix + "_" + i + "\t";
            }
            stream.Write(t);
        }

        public void parse(String value, String[] tokens, int index, out int outindex)
        {
            outindex = index;
            for (int k = 0; k < 119; k++)
            {
                _values[k] = float.Parse(tokens[outindex]);

                if (k < 118)
                    outindex++;
            }
        }

        #endregion

        public override String ToString()
        {
            string res = "";
            for (int i = 0; i < 119; i++)
            {
                res += _values[i]; //+ "\t";
                if (i < 118)
                {
                    res += "\t";
                }
            }
            return res;
        }
    }
}