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

    public class HuntingZoneInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UINT hunting_type;
        public UINT level;
        public UINT UNK_1;
        public FLOAT loc_x;
        public FLOAT loc_y;
        public FLOAT loc_z;
        public ASCF UNK_2;
        public UINT affiliated_area_id;
        public ASCF name;
    }

    #endregion

    #region Parser

    public class HuntingZone : DatParser
    {
        public override Definition getDefinition()
        {
            return new HuntingZoneInfo();
        }
    }

    #endregion
}