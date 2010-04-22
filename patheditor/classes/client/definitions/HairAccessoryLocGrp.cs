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

    public class HairaccessorylocgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        }
        */
        public UNICODE name;
        public FLOAT floats_1_1;
        public FLOAT floats_1_2;
        public FLOAT floats_1_3;
        public INT ints_1_1;
        public INT ints_1_2;
        public INT ints_1_3;
        public FLOAT floats_2_1;
        public FLOAT floats_2_2;
        public FLOAT floats_2_3;
        public INT ints_2_1;
        public INT ints_2_2;
        public INT ints_2_3;
        public FLOAT floats_3_1;
        public FLOAT floats_3_2;
        public FLOAT floats_3_3;
        public INT ints_3_1;
        public INT ints_3_2;
        public INT ints_3_3;
        public FLOAT floats_4_1;
        public FLOAT floats_4_2;
        public FLOAT floats_4_3;
        public INT ints_4_1;
        public INT ints_4_2;
        public INT ints_4_3;
        public FLOAT floats_5_1;
        public FLOAT floats_5_2;
        public FLOAT floats_5_3;
        public INT ints_5_1;
        public INT ints_5_2;
        public INT ints_5_3;
        public FLOAT floats_6_1;
        public FLOAT floats_6_2;
        public FLOAT floats_6_3;
        public INT ints_6_1;
        public INT ints_6_2;
        public INT ints_6_3;
        public FLOAT floats_7_1;
        public FLOAT floats_7_2;
        public FLOAT floats_7_3;
        public INT ints_7_1;
        public INT ints_7_2;
        public INT ints_7_3;
        public FLOAT floats_8_1;
        public FLOAT floats_8_2;
        public FLOAT floats_8_3;
        public INT ints_8_1;
        public INT ints_8_2;
        public INT ints_8_3;
        public FLOAT floats_9_1;
        public FLOAT floats_9_2;
        public FLOAT floats_9_3;
        public INT ints_9_1;
        public INT ints_9_2;
        public INT ints_9_3;
        public FLOAT floats_A_1;
        public FLOAT floats_A_2;
        public FLOAT floats_A_3;
        public INT ints_A_1;
        public INT ints_A_2;
        public INT ints_A_3;
        public FLOAT floats_B_1;
        public FLOAT floats_B_2;
        public FLOAT floats_B_3;
        public INT ints_B_1;
        public INT ints_B_2;
        public INT ints_B_3;
        public FLOAT floats_C_1;
        public FLOAT floats_C_2;
        public FLOAT floats_C_3;
        public INT ints_C_1;
        public INT ints_C_2;
        public INT ints_C_3;
        public FLOAT floats_D_1;
        public FLOAT floats_D_2;
        public FLOAT floats_D_3;
        public INT ints_D_1;
        public INT ints_D_2;
        public INT ints_D_3;
        public FLOAT floats_E_1;
        public FLOAT floats_E_2;
        public FLOAT floats_E_3;
        public INT ints_E_1;
        public INT ints_E_2;
        public INT ints_E_3;
        public FLOAT floats_F_1;
        public FLOAT floats_F_2;
        public FLOAT floats_F_3;
        public INT ints_F_1;
        public INT ints_F_2;
        public INT ints_F_3;
    }

    #endregion

    #region Parser

    public class Hairaccessorylocgrp : DatParser
    {
        public override Definition getDefinition()
        {
            return new HairaccessorylocgrpInfo();
        }
    }

    #endregion
}