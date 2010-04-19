using System;
using System.IO;

namespace com.jds.PathEditor.classes.client.types
{
    public class FILLER_360
    {
        public string getHeaderText(string prefix)
        {
            return "filler_360\t";
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

        public static FILLER_360 Parse(BinaryReader f)
        {
            var info = new FILLER_360();
            for (int i = 0; i < 360; i++)
            {
                f.ReadByte();
            }

            return info;
        }

        public static void Compile(BinaryWriter f, FILLER_360 info)
        {
        }

        public void parse(String value, String[] tokens, int index)
        {
        }
    }
}