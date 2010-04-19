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

    public class ShortcutAliasInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public ASCF name;
        public HEX val1;
        public HEX val2;
    }

    #endregion

    #region Parser

    public class ShortcutAlias : DatParser
    {
        public override Definition getDefinition()
        {
            return new ShortcutAliasInfo();
        }
    }

    #endregion
}