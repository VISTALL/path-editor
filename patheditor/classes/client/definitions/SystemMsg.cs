#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
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

    public class SystemMsgInfo : Definition
    {
        public UINT id;
        public UINT UNK_0;
        public ASCF message;
        public UINT group;
        public COLOR rgb;
        public ASCF item_sound;
        public ASCF sys_msg_ref;
        public UINT UNK_1_1;
        public UINT UNK_1_2;
        public UINT UNK_1_3;
        public UINT UNK_1_4;
        public UINT UNK_1_5;
        public ASCF sub_msg;
        public ASCF type;

        [Description("Id of System Message")]
        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        [Description("Unknown")]
        public uint Unk0
        {
            get { return UNK_0.Value; }
            set { UNK_0.Value = value; }
        }

        [Description("Message")]
        public String Message
        {
            get { return message.Text; }
            set { message.Text = value; }
        }

        [Description("Group of System Message")]
        public uint Group
        {
            get { return group.Value; }
            set { group.Value = value; }
        }

        [Description("Color of System Message"), Editor(typeof (ColorValueEditor), typeof (UITypeEditor)), ListColor]
        public String RGB
        {
            get { return ConvertUtilities.ColorToHtmlColor(rgb.Value); }
            set { rgb.Value = ConvertUtilities.HtmlColorToColor(value); }
        }


        [Description("Item Sound")]
        public String ItemSound
        {
            get { return item_sound.Text; }
            set { item_sound.Text = value; }
        }

        [Description("System Message Ref")]
        public String SystemMessageRef
        {
            get { return sys_msg_ref.Text; }
            set { sys_msg_ref.Text = value; }
        }

        [Description("Unknown")]
        public uint Unk1_1
        {
            get { return UNK_1_1.Value; }
            set { UNK_1_1.Value = value; }
        }

        [Description("Unknown")]
        public uint Unk1_2
        {
            get { return UNK_1_2.Value; }
            set { UNK_1_2.Value = value; }
        }

        [Description("Unknown")]
        public uint Unk1_3
        {
            get { return UNK_1_3.Value; }
            set { UNK_1_3.Value = value; }
        }

        [Description("Unknown")]
        public uint Unk1_4
        {
            get { return UNK_1_4.Value; }
            set { UNK_1_4.Value = value; }
        }

        [Description("Unknown")]
        public uint Unk1_5
        {
            get { return UNK_1_5.Value; }
            set { UNK_1_5.Value = value; }
        }

        [Description("Sub of System Message")]
        public String SubMessage
        {
            get { return sub_msg.Text; }
            set { sub_msg.Text = value; }
        }

        [Description("Type of System Message")]
        public String Type
        {
            get { return type.Text; }
            set { type.Text = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class SystemMsg : DatParser
    {
        public override Definition getDefinition()
        {
            return new SystemMsgInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            var info = new SystemMsgInfo();
            info = (SystemMsgInfo) base.ReadFieldValue(f, info, "id", "sys_msg_ref");
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude)
                info = (SystemMsgInfo) base.ReadFieldValue(f, info, "UNK_1_1", "type");
            return info;
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            var info = (SystemMsgInfo) infos[RecNo];
            base.WriteFieldValue(f, info, "id", "sys_msg_ref");
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude)
                base.WriteFieldValue(f, info, "UNK_1_1", "type");
        }
    }

    #endregion
}