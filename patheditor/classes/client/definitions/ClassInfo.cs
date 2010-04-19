#region Using

using System;
using System.ComponentModel;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;

#endregion

/**
 * Tested:
 * - Hellbound [WORK]
 * - Gracia 2 [WORK]
 * - Gracia Final [WORK]
 * - Gracia Plus [WORK]
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class ClassInfoInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public ASCF name;

        [Description("Id")]
        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        [Description("Name")]
        public String Name
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class ClassInfo : DatParser
    {
        public override Definition getDefinition()
        {
            return new ClassInfoInfo();
        }
    }

    #endregion
}