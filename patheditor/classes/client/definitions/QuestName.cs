#region Using

using System.Collections.Generic;
using System.IO;
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

    public class QuestNameInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */

        public UINT UNK_1;
                    //1 = same tab stack, 0 = end of stack (ex: |11110|10| if ur in the 2nd stack id 6 or 7 in quest prog |12345|67| the displayed stack would be |167| in the display) 

        public UINT UNK_2; //no clue 
        public UINT UNK_3; //unknown all 0 
        public UINT area_id; //area id (goddard, rune, giran, etc) 
        public UINT clan_pet_quest; //0 = reg quest, 1 = pet/clan quest 
        public UINT contact_npc_id; //who starts the quest 
        public FLOAT contact_npc_x; //start quest x_loc 
        public FLOAT contact_npc_y; //start quest x_loc 
        public FLOAT contact_npc_z; //start quest x_loc 
        public ASCF description;
        public ASCF entity_name; // 
        public UINT get_item_in_quest; //1 = get item in quest part, 0 = no item obtained in quest 
        public CNTRINT_PAIR items; //list of items to get by item_id 
        public UINT lvl_max; //recommended lvl max 
        public UINT lvl_min; //lvl req to start quest 
        public ASCF main_name;
        public CNTRINT_PAIR num_items; //num of each coressponding item (0 = infinity) 
        public ASCF prog_name;
        public UINT quest_id;
        public UINT quest_prog;

        public UINT quest_type;
                    //0 = quests that lead to rewards (varka, summoning rb, coin quest, etc), 1 = quests that lead to special items (lures, wedding dress), 2 = repeatable, 3 = one time 

        public FLOAT quest_x; //x coord of current "pin" on map 
        public FLOAT quest_y; //y coord of current "pin" on map 
        public FLOAT quest_z; //z coord of current "pin" on map 

        public CNTRINT_PAIR req_class; //id of class that can do quest 
        public CNTRINT_PAIR req_item; //id of items needed to do quest 
        public UINT req_quest_complete; //id of quest that must be completed first 
        public ASCF restricions; //can be race or quest pre-reqs 
        public ASCF short_description;
        public UINT tag;
    }

    public class QuestNameInfo_Gracia_Final : Definition
    {
        /*
        Info from l2asm-disasm
        */

        public UINT UNK_1;
                    //1 = same tab stack, 0 = end of stack (ex: |11110|10| if ur in the 2nd stack id 6 or 7 in quest prog |12345|67| the displayed stack would be |167| in the display) 

        public UINT UNK_2; //no clue 
        public UINT UNK_3; //unknown all 0 
        public UINT UNK_4;
        public UINT area_id; //area id (goddard, rune, giran, etc) 
        public UINT clan_pet_quest; //0 = reg quest, 1 = pet/clan quest 
        public UINT contact_npc_id; //who starts the quest 
        public FLOAT contact_npc_x; //start quest x_loc 
        public FLOAT contact_npc_y; //start quest x_loc 
        public FLOAT contact_npc_z; //start quest x_loc 
        public ASCF description;
        public ASCF entity_name; // 
        public UINT get_item_in_quest; //1 = get item in quest part, 0 = no item obtained in quest 
        public CNTRINT_PAIR items; //list of items to get by item_id 
        public UINT lvl_max; //recommended lvl max 
        public UINT lvl_min; //lvl req to start quest 
        public ASCF main_name;
        public CNTRINT_PAIR num_items; //num of each coressponding item (0 = infinity) 
        public ASCF prog_name;
        public UINT quest_id;
        public UINT quest_prog;

        public UINT quest_type;
                    //0 = quests that lead to rewards (varka, summoning rb, coin quest, etc), 1 = quests that lead to special items (lures, wedding dress), 2 = repeatable, 3 = one time 

        public FLOAT quest_x; //x coord of current "pin" on map 
        public FLOAT quest_y; //y coord of current "pin" on map 
        public FLOAT quest_z; //z coord of current "pin" on map 

        public CNTRINT_PAIR req_class; //id of class that can do quest 
        public CNTRINT_PAIR req_item; //id of items needed to do quest 
        public UINT req_quest_complete; //id of quest that must be completed first 
        public ASCF restricions; //can be race or quest pre-reqs 
        public ASCF short_description;
        public CNTRINT_PAIR tab5;
        public CNTRINT_PAIR tab6;
        public UINT tag;
    }

    #endregion

    #region Parser

    public class QuestName : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
                return new QuestNameInfo_Gracia_Final();
            else
                return new QuestNameInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            Definition info;
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var dat = new QuestNameInfo_Gracia_Final();
                dat = (QuestNameInfo_Gracia_Final) base.ReadFieldValue(f, dat, "id", "get_item_in_quest");
                dat = (QuestNameInfo_Gracia_Final) base.ReadFieldValue(f, dat, "UNK_1", "short_description");
                dat = (QuestNameInfo_Gracia_Final) base.ReadFieldValue(f, dat, "req_class", "tab6");
                info = dat;
            }
            else
            {
                var dat = new QuestNameInfo();
                dat = (QuestNameInfo) base.ReadFieldValue(f, dat, "id", "get_item_in_quest");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                    dat = (QuestNameInfo) base.ReadFieldValue(f, dat, "UNK_1", "short_description");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                    dat = (QuestNameInfo) base.ReadFieldValue(f, dat, "req_class", "area_id");
                info = dat;
            }
            return info;
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = (QuestNameInfo_Gracia_Final) infos[RecNo];
                base.WriteFieldValue(f, info, "id", "get_item_in_quest");
                base.WriteFieldValue(f, info, "UNK_1", "short_description");
                base.WriteFieldValue(f, info, "req_class", "tab6");
            }
            else
            {
                var info = (QuestNameInfo) infos[RecNo];
                base.WriteFieldValue(f, info, "id", "get_item_in_quest");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                    base.WriteFieldValue(f, info, "UNK_1", "short_description");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                    base.WriteFieldValue(f, info, "req_class", "area_id");
            }
        }
    }

    #endregion
}