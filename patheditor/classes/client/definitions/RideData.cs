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

    public class RideDataInfo : Definition
    {
        public UINT tag;
        public HEX extra;
        public UNICODE name;
        public FLOAT_119 unk;
    }
    #endregion

    #region Parser

    public class RideData : DatParser
    {
        public override Definition getDefinition()
        {
            return new RideDataInfo();
        }
    }

    #endregion
}