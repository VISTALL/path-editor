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

    public class RaidDataInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT affiliated_area_id;
        public UINT id;
        public FLOAT loc_x;
        public FLOAT loc_y;
        public FLOAT loc_z;
        public UINT npc_id;
        public UINT npc_level;
        public ASCF raid_desc;
    }

    #endregion

    #region Parser

    public class RaidData : DatParser
    {
        public override Definition getDefinition()
        {
            return new RaidDataInfo();
        }
    }

    #endregion
}