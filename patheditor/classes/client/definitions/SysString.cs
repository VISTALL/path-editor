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
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class SysStringInfo : Definition
    {
        public UINT id;
        public ASCF name;

        [Description("Id of String")]
        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        [Description("Text of String")]
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

    public class SysString : DatParser
    {
        public override Definition getDefinition()
        {
            return new SysStringInfo();
        }
    }

    #endregion
}