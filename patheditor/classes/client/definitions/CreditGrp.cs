#region Using

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

    public class CreditgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT align;
        public ASCF html;
        public UINT id;
        public ASCF image;
        public UINT time;
    }

    #endregion

    #region Parser

    public class Creditgrp : DatParser
    {
        public override Definition getDefinition()
        {
            return new CreditgrpInfo();
        }
    }

    #endregion
}