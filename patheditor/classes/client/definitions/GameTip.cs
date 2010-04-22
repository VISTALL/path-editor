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

    public class GameTipInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UINT int1;
        public UINT int2;
        public UINT enable;
        public ASCF tip;

        [Description("Id")]
        public UINT Id
        {
            get { return id; }
            set { id = value; }
        }

        [Description("Int1")]
        public UINT Int1
        {
            get { return int1; }
            set { int1 = value; }
        }

        [Description("Int2")]
        public UINT Int2
        {
            get { return int2; }
            set { int2 = value; }
        }

        [Description("Enable")]
        public UINT Enable
        {
            get { return enable; }
            set { enable = value; }
        }

        [Description("Tip")]
        public String Tip
        {
            get { return tip.Text; }
            set { tip.Text = value; }
        }

        public override String ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class GameTip : DatParser
    {
        public override Definition getDefinition()
        {
            return new GameTipInfo();
        }
    }

    #endregion
}