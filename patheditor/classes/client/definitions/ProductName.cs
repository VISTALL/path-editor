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

    public class ProductName_Info : Definition
    {
        public UNICODE icon;
        public UINT id;
        public UNICODE name;
        public ASCF str;
    }

    #endregion

    #region Parser

    public class ProductName : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
                return new ProductName_Info();
            else
                return null;
        }
    }

    #endregion
}