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

    public class SkillgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public INT UNK_0;
        public INT UNK_1;
        public UNICODE ani_char;
        public INT cast_range;
        public UINT cast_style;
        public UNICODE desc;
        public UINT ench_skill_id;
        public UINT extra_eff;
        public FLOAT hit_time;
        public UINT hp_consume;
        public UNICODE icon_name;
        public UINT is_ench;
        public INT is_magic;
        public UINT mp_consume;
        public UINT oper_type;
        public UINT skill_id;
        public UINT skill_level;
    }

    public class SkillgrpInfo_CT1 : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT UNK_0;
        public INT UNK_1;
        public INT UNK_2;
        public INT UNK_3;
        public UNICODE ani_char;
        public INT cast_range;
        public UINT cast_style;
        public UNICODE desc;
        public UINT ench_skill_id;
        public UNICODE extra_eff;
        public FLOAT hit_time;
        public UINT hp_consume;
        public UNICODE icon_name;
        public UINT is_ench;
        public INT is_magic;
        public UINT mp_consume;
        public UINT oper_type;
        public UINT skill_id;
        public UINT skill_level;
    }

    public class SkillgrpInfo_Gracia_Plus : Definition
    {
        public UINT UNK_0;
        public UINT UNK_1;
        public INT UNK_2;
        public INT UNK_3;
        public UNICODE ani_char;
        public INT cast_range;
        public UINT cast_style;
        public UNICODE desc;
        public UINT ench_skill_id;
        public ASCF enchant_type;
        public UNICODE extra_eff;
        public FLOAT hit_time;
        public UINT hp_consume;
        public UNICODE icon_name;
        public UINT is_ench;
        public INT is_magic;
        public UINT mp_consume;
        public UINT oper_type;
        public UINT skill_id;
        public UINT skill_level;
    }

    #endregion

    #region Parser

    public class Skillgrp : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
                return new SkillgrpInfo_Gracia_Plus();
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
                return new SkillgrpInfo_CT1();
            else
                return new SkillgrpInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            var ret = new Definition();
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
            {
                var info = new SkillgrpInfo_Gracia_Plus();
                info = (SkillgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "skill_id", "skill_level");

                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                    info = (SkillgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "UNK_0");

                info = (SkillgrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "oper_type", "UNK_3");
                ret = info;
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = new SkillgrpInfo_CT1();
                info = (SkillgrpInfo_CT1) base.ReadFieldValue(f, info, "skill_id", "skill_level");

                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                    info = (SkillgrpInfo_CT1) base.ReadFieldValue(f, info, "UNK_0");

                info = (SkillgrpInfo_CT1) base.ReadFieldValue(f, info, "oper_type", "UNK_3");
                ret = info;
            }
            else
            {
                var info = new SkillgrpInfo();
                info = (SkillgrpInfo) base.ReadFieldValue(f, info, "skill_id", "extra_eff");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                    info = (SkillgrpInfo) base.ReadFieldValue(f, info, "is_ench", "UNK_1");
                ret = info;
            }
            return ret;
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
            {
                var info = (SkillgrpInfo_Gracia_Plus) infos[RecNo];
                base.WriteFieldValue(f, info, "skill_id", "skill_level");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                    base.WriteFieldValue(f, info, "UNK_0");
                base.WriteFieldValue(f, info, "oper_type", "UNK_3");
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = (SkillgrpInfo_CT1) infos[RecNo];
                base.WriteFieldValue(f, info, "skill_id", "skill_level");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                    base.WriteFieldValue(f, info, "UNK_0");
                base.WriteFieldValue(f, info, "oper_type", "UNK_3");
            }
            else
            {
                var info = (SkillgrpInfo) infos[RecNo];
                base.WriteFieldValue(f, info, "skill_id", "extra_eff");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                    base.WriteFieldValue(f, info, "is_ench", "UNK_1");
            }
        }
    }

    #endregion
}