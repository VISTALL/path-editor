using System;
using System.IO;

namespace com.jds.PathEditor.classes.client.mothers
{
    public interface IType
    {
        IType read(BinaryReader b);

        IType write(BinaryWriter f);

        void writeHeader(String name, StreamWriter writer);

        void parse(String value, String[] tokens, int index, out int outindex);
    }
}