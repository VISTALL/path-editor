using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;

/**
 * @author VISTALL
 * 
 * Tested:
 * - CT3 [WORK]
 */
namespace com.jds.PathEditor.classes.client.definitions
{
     #region Definition

    public class QuestMarkConditionDataInfo : Definition
    {
        public UINT quest_id;
        public UINT npc_id;
        public CNTRINT_PAIR race_filter;
        public CNTRINT_PAIR class_filter;
        public FLOAT start_npc_x;
        public FLOAT start_npc_y;
        public FLOAT start_npc_z;
    }

    #endregion

    #region Parser

    public class QuestMarkConditionData : DatParser
    {
        public override Definition getDefinition()
        {
            return new QuestMarkConditionDataInfo();
        }
    }

    #endregion
}