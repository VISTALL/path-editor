#region Using

using System;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;

#endregion

/**
 * Tested:
 * - Hellbound [WORK]
 * - Gracia 2 [WORK]
 * - Gracia Final [WORK]
 * - Gracia Plus [WORK]
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class StaticObjectInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UNICODE name;

        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

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

    public class StaticObject : DatParser
    {
        public override Definition getDefinition()
        {
            return new StaticObjectInfo();
        }
    }

    #endregion
}