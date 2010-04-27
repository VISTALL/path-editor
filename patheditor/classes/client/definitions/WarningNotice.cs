using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

/**
 * Tested:
 * - Frey [WORK]
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class WarningNotice_Info : Definition
    {
        /**
         * by VISTALL 
         */
        public ASCF text;

        public String Text
        {
            get { return text.Text; }
            set { text.Text = value; }
        }

        public override string ToString()
        {
            return text.ToString();
        }
    }

    #endregion

    #region Parser

    public class WarningNotice : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Freya)
                return new WarningNotice_Info();

            return null;
        }


        public override int readCount(BinaryReader f)
        {
            return 1;
        }

        public override void writeCount(BinaryWriter f, int i)
        {
        }
    }

    #endregion
}