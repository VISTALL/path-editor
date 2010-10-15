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
 * - Freya [WORK]
 * - High Five [WORK]
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class OptiondataClientInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UINT level;
        public UINT var_of_level;
        public ASCF effect1_desc;
        public ASCF effect2_desc;
        public ASCF effect3_desc;
    }

    #endregion

    #region Parser

    public class OptionData_Client : DatParser
    {
        public override Definition getDefinition()
        {
            return new OptiondataClientInfo();
        }
    }

    #endregion
}