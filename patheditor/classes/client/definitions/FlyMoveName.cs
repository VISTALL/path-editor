using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;
/**
 * Tested:
 * - CT3 Awakening [WORK]
 */
namespace com.jds.PathEditor.classes.client.definitions
{
    #region Definition

    public class FlyMoveNameInfo : Definition
    {
        /*
           by VISTALL
        */
        public UINT path;
        public UINT node;
        public ASCF name;
    }

    #endregion

    #region Parser

    public class FlyMoveName : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.CT3_Awakening)
                return new FlyMoveNameInfo();

            return null;
        }
    }
    #endregion
}