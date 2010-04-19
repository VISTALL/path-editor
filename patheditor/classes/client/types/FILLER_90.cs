using System;
using System.IO;

namespace com.jds.PathEditor.classes.client.types
{
    public class FILLER_90
    {
        public string getHeaderText(string prefix)
        {
            return "filler_90\t";
        }

        public string getText()
        {
            return "0";
        }

        public void setText(string[] value)
        {
        }

        public int getFieldCount()
        {
            return 1;
        }

        public static FILLER_90 Parse(BinaryReader f)
        {
            var info = new FILLER_90();
            for (int i = 0; i < 90; i++)
            {
                f.ReadByte();
            }
            return info;
        }

        public static void Compile(BinaryWriter f, FILLER_90 info)
        {
        }

        public void parse(String value, String[] tokens, int index)
        {
        }
    }
}