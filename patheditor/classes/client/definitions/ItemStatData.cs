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

    public class ItemStatDataInfo : Definition
    {
        /*
           by VISTALL
        */
        public UINT item_id;
        public FLOAT p_def;
        public FLOAT m_def;
        public FLOAT p_attack;
        public FLOAT m_attack;
        public FLOAT p_attack_speed;
        public FLOAT m_attack_speed;
        public FLOAT p_hit;
        public FLOAT m_hit;
        public FLOAT p_crit;
        public FLOAT m_crit;
        public FLOAT speed;
        public FLOAT shield_defence;
        public FLOAT shield_defence_rate;
        public FLOAT p_void;
        public FLOAT m_void;
        public INT property_params;
    }

    #endregion

    #region Parser

    public class ItemStatData : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.CT3_Awakening)
                return new ItemStatDataInfo();

            return null;
        }
    }
    #endregion
}