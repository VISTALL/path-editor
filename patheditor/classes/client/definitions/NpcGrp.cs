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
 * - Frey [NOT WORK]
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class NpcgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public CNTTXT_PAIR UNK_0_NEW;
        public UINT UNK_0_OLD;
        public CNTRINT_PAIR UNK_1_NEW;
        public UINT UNK_1_OLD;
        public UINT UNK_2;
        public UINT class_lim;
        public CNTRINT_PAIR dtab1;
        public UNICODE effect;
        public UINT level_lim_dn;
        public UINT level_lim_up;
        public UNICODE mesh;
        public UNICODE npc_class;
        public FLOAT npc_speed;
        public UINT quest_be;
        public UNICODE rb_effect;
        public FLOAT rb_effect_fl;
        public UINT rb_effect_on;
        public CNTTXT_PAIR snd1;
        public CNTTXT_PAIR snd2;
        public CNTTXT_PAIR snd3;
        public FLOAT sound_rad;
        public FLOAT sound_rnd;
        public FLOAT sound_vol;
        public UINT tag;
        public CNTTXT_PAIR tex1;
        public CNTTXT_PAIR tex2;
    }

    public class NpcgrpInfo_Gracia_Plus : Definition
    {
        public CNTTXT_PAIR UNK_0_NEW;
        public UINT UNK_0_OLD; //
        public CNTRINT_PAIR UNK_1_NEW;
        public UINT UNK_1_OLD;
        public UINT UNK_2;
        public UINT class_lim;
        public CNTRINT_PAIR dtab1; //
        public UNICODE effect;
        public UINT level_lim_dn;
        public UINT level_lim_up;
        public UNICODE mesh;
        public UNICODE npc_class;
        public ASCF_PAIR npc_end;
        public FLOAT npc_speed;
        public UINT quest_be;
        public UNICODE rb_effect; //
        public FLOAT rb_effect_fl;
        public UINT rb_effect_on;
        public CNTTXT_PAIR snd1;
        public CNTTXT_PAIR snd2;
        public CNTTXT_PAIR snd3; //
        public FLOAT sound_rad; //
        public FLOAT sound_rnd;
        public FLOAT sound_vol;
        public UINT tag;
        public CNTTXT_PAIR tex1;
        public CNTTXT_PAIR tex2;
    }

    public class NpcGrpInfo_Freya : Definition
    {
        public UNICODE mesh;
        public CNTTXT_PAIR new_0; //
        public UNICODE npc_class;
        public UINT npc_id;
        public FLOAT npc_speed;
        public CNTRINT_PAIR skills; //
        public CNTTXT_PAIR snd1;
        public CNTTXT_PAIR snd2;
        public CNTTXT_PAIR snd3; //
        public CNTTXT_PAIR tex1;
        public CNTTXT_PAIR tex2;
        public UINT unk_0; //
    }

    #endregion

    #region Parser

    public class Npcgrp : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
                return new NpcgrpInfo_Gracia_Plus();
            else
                return new NpcgrpInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            Definition dat;

            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
            {
                var info = new NpcgrpInfo_Gracia_Plus();
                info.InitFieldValues();

                info = (NpcgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "tag", "npc_speed");
                info = (NpcgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "UNK_0_NEW");
                info = (NpcgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "snd1", "snd3");

                info = (NpcgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "rb_effect_on");
                if (info.rb_effect_on.Value == 1)
                    info = (NpcgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "rb_effect", "rb_effect_fl");

                info = (NpcgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "UNK_1_NEW");
                info = (NpcgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "effect", "npc_end");

                dat = info;
            }
            else
            {
                var info = new NpcgrpInfo();
                info.InitFieldValues();
                info = (NpcgrpInfo) base.ReadFieldValue(f, info, "tag", "npc_speed");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                    info = (NpcgrpInfo) base.ReadFieldValue(f, info, "UNK_0_NEW");
                else
                    info = (NpcgrpInfo) base.ReadFieldValue(f, info, "UNK_0_OLD");
                info = (NpcgrpInfo) base.ReadFieldValue(f, info, "snd1", "snd3");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude)
                {
                    info = (NpcgrpInfo) base.ReadFieldValue(f, info, "rb_effect_on");
                    if (info.rb_effect_on.Value == 1)
                        info = (NpcgrpInfo) base.ReadFieldValue(f, info, "rb_effect", "rb_effect_fl");
                }
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                    info = (NpcgrpInfo) base.ReadFieldValue(f, info, "UNK_1_NEW");
                else
                    info = (NpcgrpInfo) base.ReadFieldValue(f, info, "UNK_1_OLD", "level_lim_up");

                info = (NpcgrpInfo) base.ReadFieldValue(f, info, "effect", "class_lim");

                dat = info;
            }


            return dat;
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
            {
                var info = (NpcgrpInfo_Gracia_Plus) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "npc_speed");
                base.WriteFieldValue(f, info, "UNK_0_NEW");
                base.WriteFieldValue(f, info, "snd1", "snd3");

                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude)
                {
                    base.WriteFieldValue(f, info, "rb_effect_on");
                    if (info.rb_effect_on.Value == 1)
                        base.WriteFieldValue(f, info, "rb_effect", "rb_effect_fl");
                }

                base.WriteFieldValue(f, info, "UNK_1_NEW");

                base.WriteFieldValue(f, info, "effect", "npc_end");
            }
            else
            {
                var info = (NpcgrpInfo) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "npc_speed");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                    base.WriteFieldValue(f, info, "UNK_0_NEW");
                else
                    base.WriteFieldValue(f, info, "UNK_0_OLD");
                base.WriteFieldValue(f, info, "snd1", "snd3");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude)
                {
                    base.WriteFieldValue(f, info, "rb_effect_on");
                    if (info.rb_effect_on.Value == 1)
                        base.WriteFieldValue(f, info, "rb_effect", "rb_effect_fl");
                }
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                    base.WriteFieldValue(f, info, "UNK_1_NEW");
                else
                    base.WriteFieldValue(f, info, "UNK_1_OLD", "level_lim_up");

                base.WriteFieldValue(f, info, "effect", "class_lim");
            }
        }
    }

    #endregion
}