#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{
    #region Definition

    public class SkillNameInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UINT level;
        public ASCF name;
        public ASCF description;
        public ASCF desc_add1;
        public ASCF desc_add2;

        public override string ToString()
        {
            return id.ToString();
        }
        [Description("Skill Id")]
        public uint Id
        {
            get
            {
                return id.Value;
            }
            set
            {
                id.Value = value;
            }
        }

        [Description("Skill Level")]
        public uint Level
        {
            get
            {
                return level.Value;
            }
            set
            {
                level.Value = value;
            }
        }

        [Description("Skill Name")]
        public String Name
        {
            get
            {
                return name.Text;
            }
            set
            {
                name.Text = value;
            }
        }

        [Description("Skill Description")]
        public String Description
        {
            get
            {
                return description.Text;
            }
            set
            {
                description.Text = value;
            }
        }

        [Description("Skill Enchant Type")]
        public String EnchantType
        {
            get
            {
                return desc_add1.Text;
            }
            set
            {
                desc_add1.Text = value;
            }
        }

        [Description("Skill Enchant Description")]
        public String EnchantDesc
        {
            get
            {
                return desc_add2.Text;
            }
            set
            {
                desc_add2.Text = value;
            }
        }
    }

    #endregion

    #region Parser

    public class SkillName : DatParser
    {
        public override Definition getDefinition()
        {
            return new SkillNameInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            var info = new SkillNameInfo();
            info = (SkillNameInfo) base.ReadFieldValue(f, info, "id", "description");
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                info = (SkillNameInfo) base.ReadFieldValue(f, info, "desc_add1", "desc_add2");
            return info;
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            var info = (SkillNameInfo) infos[RecNo];
            base.WriteFieldValue(f, info, "id", "description");
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                base.WriteFieldValue(f, info, "desc_add1", "desc_add2");
        }
    }

    #endregion
}