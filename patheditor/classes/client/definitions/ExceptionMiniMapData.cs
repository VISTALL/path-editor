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
    public class ExceptionMiniMapData_Info : Definition
    {
        public UINT location_id;
        public ASCF location_name;
        public INT max_x;
        public INT min_x;
        public INT max_y;
        public INT min_y;
        public INT max_z;
        public INT min_z;
        public INT seen_x;
        public INT seen_y;
    }
    #endregion

    #region Parser

    public class ExceptionMiniMapData : DatParser
    {
        public override Definition getDefinition()
        {
            return RConfig.Instance.DatVersionAsEnum >= DatVersion.High_Five ? new ExceptionMiniMapData_Info() : null;
        }
    }

    #endregion
}
