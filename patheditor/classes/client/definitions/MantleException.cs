using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

/**
 *  Tested:
 *  - High Five [WORK]
 */
namespace com.jds.PathEditor.classes.client.definitions
{
    #region Definition
    public class MantleException_Info : Definition
    {
        public UINT item_id;
        public FOR_INTASCF textures;
    }
    #endregion

    #region Parser

    public class MantleException : DatParser
    {
        public override Definition getDefinition()
        {
            return RConfig.Instance.DatVersionAsEnum >= DatVersion.High_Five ? new MantleException_Info() : null;
        }
    }

    #endregion
}
