#region Using

using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

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

    public class CastleNameInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public ASCF castle_name;
        public ASCF desc;
        public UINT id;
        public ASCF location;
        public UINT nbr;
        public UINT tag;
    }

    public class CastleNameInfo_Gracia_Final : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public ASCF castle_name;
        public ASCF desc;
        public UINT id;
        public ASCF location;
        public UINT nbr;
        public UINT tag;
        public ASCF unk_1;
        public ASCF unk_2;
        public ASCF unk_3;
        public ASCF unk_4;
    }

    #endregion

    #region Parser

    public class CastleName : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
                return new CastleNameInfo_Gracia_Final();
            else
                return new CastleNameInfo();
        }
    }

    #endregion
}