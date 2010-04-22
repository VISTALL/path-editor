#region Using

using System;
using System.ComponentModel;
using System.Drawing.Design;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.lm;
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

    public class NpcNameInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public ASCF name;
        public ASCF description;
        public COLOR rgb;

        public override string ToString()
        {
            return id.ToString();
        }

        [Description("Npc Id")]
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

        [Description("Npc Name")]
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

        [Description("Npc Title")]
        public String Title
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

        [Description("Npc Name Color"), Editor(typeof(ColorValueEditor), typeof(UITypeEditor)), ListColor]
        public String NameColor
        {
            get
            {
                return ConvertUtilities.ColorToHtmlColor(rgb.Value);
            }
            set
            {
                rgb.Value = ConvertUtilities.HtmlColorToColor(value);
            }
        }
    }

    #endregion

    #region Parser

    public class NpcName : DatParser
    {
        public override Definition getDefinition()
        {
            return new NpcNameInfo();
        }
    }

    #endregion
}