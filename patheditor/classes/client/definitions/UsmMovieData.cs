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

    public class UsmMovieDataInfo : Definition
    {
        /*
           by VISTALL
        */
        public UINT movie_id;
        public ASCF file_name;
        public UINT pos_x;
        public UINT pos_y;
        public UINT width;
        public UINT height;
        public UINT target_anchor_point_type;
        public UINT clip_anchor_point_type;
        public ASCF skin_type;
        public ASCF skin_button_type;
    }

    #endregion

    #region Parser

    public class UsmMovieData : DatParser
    {
        public override Definition getDefinition()
        {
            if(RConfig.Instance.DatVersionAsEnum >= DatVersion.CT3_Awakening)
                return new UsmMovieDataInfo();

            return null;
        }   
    }
    #endregion
}