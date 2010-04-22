#region Using

using System;
using System.ComponentModel;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;

#endregion

/**
 * Tested:
 * - Hellbound [WORK]
 * - Gracia 2 [WORK]
 * - Gracia Final [WORK]
 * - Gracia Plus [WORK]
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class MobskillanimgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT npc_id;
        public UINT skill_id;
        public UNICODE seq_name;
        public ASCF skill_name;
        public ASCF npc_name;
        public ASCF npc_class;

        [Description("Npc id")]
        public uint NpcId
        {
            get { return npc_id.Value; }
            set { npc_id.Value = value; }
        }

        [Description("Skill id")]
        public uint SkillId
        {
            get { return skill_id.Value; }
            set { skill_id.Value = value; }
        }

        [Description("Seq Name")]
        public String SeqName
        {
            get { return seq_name.Text; }
            set { seq_name.Text = value; }
        }

        [Description("Skill Name")]
        public String SkillName
        {
            get { return skill_name.Text; }
            set { skill_name.Text = value; }
        }

        [Description("Npc Name")]
        public String NpcName
        {
            get { return npc_name.Text; }
            set { npc_name.Text = value; }
        }

        [Description("Npc Class")]
        public String NpcClass
        {
            get { return npc_class.Text; }
            set { npc_class.Text = value; }
        }

        public override string ToString()
        {
            return npc_id.ToString();
        }
    }

    #endregion

    #region Parser

    public class Mobskillanimgrp : DatParser
    {
        public override Definition getDefinition()
        {
            return new MobskillanimgrpInfo();
        }
    }

    #endregion
}