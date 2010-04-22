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

    public class VariationeffectgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT int1;
        public UINT int2;
        public UINT int3;
        public UINT int4;
        public UINT int5;
        public UNICODE effect;
        public ASCF attribute;
    }

    #endregion

    #region Parser

    public class Variationeffectgrp : DatParser
    {
        public override Definition getDefinition()
        {
            return new VariationeffectgrpInfo();
        }
    }

    #endregion
}