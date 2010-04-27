using System;
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

    public class NpcString_Info : Definition
    {
        /**
         * by janiii 
         */
        public UINT id;
        public ASCF text;

        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        public String Text
        {
            get { return text.Text; }
            set { text.Text = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class NpcString : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Freya)
                return new NpcString_Info();

            return null;
        }
    }

    #endregion
}