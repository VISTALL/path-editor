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

    public class VehiclepartsgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public CNTTXT_PAIR mshtex1;
        public CNTTXT_PAIR mshtex2;
        public UNICODE name;
        //public MTX mshtex; 
        //public UNICODE sound0;
        public UNICODE sound1;
        public UNICODE sound2;
        public UNICODE sound3;
        public UNICODE sound4;
        public UNICODE sound5;
        public CNTTXT_PAIR sounds2;
        public CNTRINT_PAIR tab1;
        public CNTRINT_PAIR tab2;
        public UINT unk1;
        public UINT unk2;
    }

    #endregion

    #region Parser

    public class Vehiclepartsgrp : DatParser
    {
        public override Definition getDefinition()
        {
            return new VehiclepartsgrpInfo();
        }
    }

    #endregion
}