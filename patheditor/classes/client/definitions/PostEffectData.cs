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
    public class PostEffectData_Info : Definition
    {
        public UINT effect_id;
        public UNICODE effect_name;
        public UINT effect_sort;
        public UINT effect_play_type;
        public FLOAT play_time;
        public UINT effect_fix;
        public FLOAT effect_cor1_factor1;
        public FLOAT effect_cor1_factor2;
        public FLOAT effect_cor1_factor3;
        public FLOAT effect_cor2_factor1;
        public FLOAT effect_cor2_factor2;
        public FLOAT effect_cor2_factor3;
        public FLOAT effect_reservefactor1;
        public FLOAT effect_reservefactor2;
    }
    #endregion

    #region Parser

    public class PostEffectData : DatParser
    {
        public override Definition getDefinition()
        {
            return RConfig.Instance.DatVersionAsEnum >= DatVersion.High_Five ? new PostEffectData_Info() : null;
        }
    }

    #endregion
}
