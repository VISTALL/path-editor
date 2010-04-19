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

    public class ArmorgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public MTX NPC_MT;
        public UINT UNK_0;
        public UINT UNK_1;
        public MTX Unknown_MT;
        public UINT armor_type;
        public UNICODE att_eff;
        public UINT avoid_mod;
        public UINT body_part;
        public UINT crystal_type;
        public UINT crystallizable;
        public UINT drop_anim_type;
        public UINT drop_height;
        public UNICODE drop_mesh;
        public UINT drop_radius;
        public UNICODE drop_sound;
        public UNICODE drop_tex;
        public UINT drop_type;
        public UINT durability;
        public UNICODE equip_sound;
        public MTX f_DarkElf;
        public MTX f_Dorf;
        public MTX f_Elf;
        public MTX f_HumnFigh;
        public MTX f_HumnMyst;
        public MTX f_OrcFigh;
        public MTX f_OrcMage;
        public UNICODE icon1;
        public UNICODE icon2;
        public UNICODE icon3;
        public UNICODE icon4;
        public UNICODE icon5;
        public UINT id;
        public CNTTXT_PAIR item_sound;
        public MTX m_DarkElf;
        public MTX m_Dorf;
        public MTX m_Elf;
        public MTX m_HumnFigh;
        public MTX m_HumnMyst;
        public MTX m_OrcFigh;
        public MTX m_OrcMage;
        public UINT material;
        public UINT mdef;
        public UINT mpbonus;
        public UINT pdef;
        public UINT tag;
        public UINT weight;
    }

    public class ArmorgrpInfo_C4 : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public MTX ACC_MT;
        public MTX NPC_MT;
        public UINT UNK_0;
        public UINT UNK_1;
        public UINT UNK_2;
        public UINT UNK_3;
        public MTX Unknown_MT;
        public UINT armor_type;
        public UNICODE att_eff;
        public UINT avoid_mod;
        public UINT body_part;
        public UINT crystal_type;
        public UINT crystallizable;
        public UINT drop_anim_type;
        public UINT drop_height;
        public UNICODE drop_mesh;
        public UINT drop_radius;
        public UNICODE drop_sound;
        public UNICODE drop_tex;
        public UINT drop_type;
        public UINT durability;
        public UNICODE equip_sound;
        public MTX f_DarkElf;
        public MTX f_DarkElf_add;
        public MTX f_Dorf;
        public MTX f_Dorf_add;
        public MTX f_Elf;
        public MTX f_Elf_add;
        public MTX f_HumnFigh;
        public MTX f_HumnFigh_add;
        public MTX f_HumnMyst;
        public MTX f_HumnMyst_add;
        public MTX f_OrcFigh;
        public MTX f_OrcFigh_add;
        public MTX f_OrcMage;
        public MTX f_OrcMage_add;
        public UNICODE icon1;
        public UNICODE icon2;
        public UNICODE icon3;
        public UNICODE icon4;
        public UNICODE icon5;
        public UNICODE icon6;
        public UNICODE icon7;
        public UNICODE icon8;
        public UNICODE icon9;
        public UINT id;
        public CNTTXT_PAIR item_sound;
        public MTX m_DarkElf;
        public MTX m_DarkElf_add;
        public MTX m_Dorf;
        public MTX m_Dorf_add;
        public MTX m_Elf;
        public MTX m_Elf_add;
        public MTX m_HumnFigh;
        public MTX m_HumnFigh_add;
        public MTX m_HumnMyst;
        public MTX m_HumnMyst_add;
        public MTX m_OrcFigh;
        public MTX m_OrcFigh_add;
        public MTX m_OrcMage;
        public MTX m_OrcMage_add;
        public UINT material;
        public UINT mdef;
        public UINT mpbonus;
        public UINT pdef;
        public UINT tag;
        public UINT weight;
    }

    public class ArmorgrpInfo_CT1 : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public MTX NPC;
        public MTX2 NPC_add;
        public UINT UNK_0;
        public UINT UNK_1;
        public CNTINT_PAIR UNK_2;
        public UINT UNK_3;
        public UINT UNK_4;
        public UINT UNK_5;
        public UINT UNK_6;
        public UINT armor_type;
        public UNICODE att_eff;
        public UINT avoid_mod;
        public UINT body_part;
        public UINT crystal_type;
        public UINT crystallizable;
        public UINT drop_anim_type;
        public UINT drop_height;
        public UNICODE drop_mesh1;
        public UNICODE drop_mesh2;
        public UNICODE drop_mesh3;
        public UINT drop_radius;
        public UNICODE drop_sound;
        public UNICODE drop_tex1;
        public UNICODE drop_tex2;
        public UNICODE drop_tex3;
        public UINT drop_type;
        public UINT durability;
        public UNICODE equip_sound;
        public MTX f_DarkElf;
        public MTX2 f_DarkElf_add;
        public MTX f_Dorf;
        public MTX2 f_Dorf_add;
        public MTX f_Elf;
        public MTX2 f_Elf_add;
        public MTX f_HumnFigh;
        public MTX2 f_HumnFigh_add;
        public MTX f_HumnMyst;
        public MTX2 f_HumnMyst_add;
        public MTX f_Kamael;
        public MTX2 f_Kamael_add;
        public MTX f_OrcFigh;
        public MTX2 f_OrcFigh_add;
        public MTX f_OrcMage;
        public MTX2 f_OrcMage_add;
        public UNICODE icon1;
        public UNICODE icon2;
        public UNICODE icon3;
        public UNICODE icon4;
        public UNICODE icon5;
        public UINT id;
        public CNTTXT_PAIR item_sound;
        public MTX m_DarkElf;
        public MTX2 m_DarkElf_add;
        public MTX m_Dorf;
        public MTX2 m_Dorf_add;
        public MTX m_Elf;
        public MTX2 m_Elf_add;
        public MTX m_HumnFigh;
        public MTX2 m_HumnFigh_add;
        public MTX m_HumnMyst;
        public MTX2 m_HumnMyst_add;
        public MTX m_Kamael;
        public MTX2 m_Kamael_add;
        public MTX m_OrcFigh;
        public MTX2 m_OrcFigh_add;
        public MTX m_OrcMage;
        public MTX2 m_OrcMage_add;
        public UINT material;
        public UINT mdef;
        public UINT mpbonus;
        public UINT pdef;
        public UINT tag;
        public UNICODE timetab;
        public UINT weight;
    }

    public class ArmorgrpInfo_Gracia_Final : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public MTX NPC;
        public MTX3 NPC_add;
        public UINT UNK_0;
        public UINT UNK_1;
        public CNTINT_PAIR UNK_2;
        public UINT UNK_3;
        public UINT UNK_4;
        public UINT UNK_5;
        public UINT UNK_6;
        public UINT armor_type;
        public UNICODE att_eff;
        public UINT avoid_mod;
        public UINT body_part;
        public UINT crystal_type;
        public UINT crystallizable;
        public UINT drop_anim_type;
        public UNICODE drop_extratex1;
        public UINT drop_height;
        public UNICODE drop_mesh1;
        public UNICODE drop_mesh2;
        public UNICODE drop_mesh3;
        public UINT drop_radius;
        public UNICODE drop_sound;
        public UNICODE drop_tex1;
        public UNICODE drop_tex2;
        public UNICODE drop_tex3;
        public UINT drop_type;
        public UINT durability;
        public UNICODE equip_sound;
        public MTX f_DarkElf;
        public MTX3 f_DarkElf_add;
        public MTX f_Dorf;
        public MTX3 f_Dorf_add;
        public MTX f_Elf;
        public MTX3 f_Elf_add;
        public MTX f_HumnFigh;
        public MTX3 f_HumnFigh_add;
        public MTX f_HumnMyst;
        public MTX3 f_HumnMyst_add;
        public MTX f_Kamael;
        public MTX3 f_Kamael_add;
        public MTX f_OrcFigh;
        public MTX3 f_OrcFigh_add;
        public MTX f_OrcMage;
        public MTX3 f_OrcMage_add;
        public UNICODE icon1;
        public UNICODE icon2;
        public UNICODE icon3;
        public UNICODE icon4;
        public UNICODE icon5;
        public UINT id;
        public CNTTXT_PAIR item_sound;
        public MTX m_DarkElf;
        public MTX3 m_DarkElf_add;
        public MTX m_Dorf;
        public MTX3 m_Dorf_add;
        public MTX m_Elf;
        public MTX3 m_Elf_add;
        public MTX m_HumnFigh;
        public MTX3 m_HumnFigh_add;
        public MTX m_HumnMyst;
        public MTX3 m_HumnMyst_add;
        public MTX m_Kamael;
        public MTX3 m_Kamael_add;
        public MTX m_OrcFigh;
        public MTX3 m_OrcFigh_add;
        public MTX m_OrcMage;
        public MTX3 m_OrcMage_add;
        public UINT material;
        public UINT mdef;
        public UINT mpbonus;
        public UINT newdata1;
        public UINT newdata2;
        public UINT newdata3;
        public UINT newdata4;
        public UINT newdata5;
        public UINT newdata6;
        public UINT newdata7;
        public UINT newdata8;
        public UINT pdef;
        public UINT tag;
        public UNICODE timetab;
        public UINT weight;
    }

    #endregion

    #region Parser

    public class Armorgrp : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
                return new ArmorgrpInfo_Gracia_Final();
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                return new ArmorgrpInfo_CT1();
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                return new ArmorgrpInfo_C4();
            else
                return new ArmorgrpInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = new ArmorgrpInfo_Gracia_Final();
                info.InitFieldValues();
                info = (ArmorgrpInfo_Gracia_Final) base.ReadFieldValue(f, info, "tag", "UNK_6");
                return info;
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
            {
                var info = new ArmorgrpInfo_CT1();
                info.InitFieldValues();
                info = (ArmorgrpInfo_CT1) base.ReadFieldValue(f, info, "tag", "UNK_1");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                    info = (ArmorgrpInfo_CT1) base.ReadFieldValue(f, info, "UNK_2");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                    info = (ArmorgrpInfo_CT1) base.ReadFieldValue(f, info, "UNK_3");
                info = (ArmorgrpInfo_CT1) base.ReadFieldValue(f, info, "timetab", "UNK_6");
                return info;
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
            {
                var info = new ArmorgrpInfo_C4();
                info = (ArmorgrpInfo_C4) base.ReadFieldValue(f, info, "tag", "mpbonus");
                return info;
            }
            else
            {
                var info = new ArmorgrpInfo();
                info = (ArmorgrpInfo) base.ReadFieldValue(f, info, "tag", "mpbonus");
                return info;
            }
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = (ArmorgrpInfo_Gracia_Final) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "UNK_6");
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
            {
                var info = (ArmorgrpInfo_CT1) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "UNK_1");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                    base.WriteFieldValue(f, info, "UNK_2");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                    base.WriteFieldValue(f, info, "UNK_3");
                base.WriteFieldValue(f, info, "timetab", "UNK_6");
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
            {
                var info = (ArmorgrpInfo_C4) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "mpbonus");
            }
            else
            {
                var info = (ArmorgrpInfo) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "mpbonus");
            }
        }
    }

    #endregion
}