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

    public class EntereventgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public ASCF UNK_0;
        public ASCF skill_sound;
        public FLOAT sound_vol;
        public FLOAT sound_rad;
        public UINT isrise;
        public UINT spawn_type;
        public UNICODE effect_name;
        public UNICODE anim_name;
    }

    #endregion

    #region Parser

    public class Entereventgrp : DatParser
    {
        public override Definition getDefinition()
        {
            return new EntereventgrpInfo();
        }
    }

    #endregion
}