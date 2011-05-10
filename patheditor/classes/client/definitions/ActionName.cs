#region Using

using System;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

#endregion

/**
 * Tested:
 * - Gracia 1 [WORK]
 * - Gracia 2 [WORK]
 * - Gracia Final [WORK]
 * - Gracia Plus [WORK]
 * - CT3 [WORK]
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class ActionNameInfo : Definition
    {
        /*
         Info from l2asm-disasm
         */
        public UINT tag;
        public UINT id;
        public INT type;
        public UINT category;
        public CNTRINT_PAIR cat2;
        public ASCF cmd;
        public ASCF icon;
        public ASCF name;
        public UNICODE desc;

        public uint Tag
        {
            get { return tag.Value; }
            set { tag.Value = value; }
        }

        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        public int Type
        {
            get { return type.Value; }
            set { type.Value = value; }
        }

        public uint Category
        {
            get { return category.Value; }
            set { category.Value = value; }
        }

        public int Category2Length
        {
            get { return cat2.Length; }
            set { cat2.Length = value; }
        }

        public String Category2Text
        {
            get { return cat2.Text; }
            set { cat2.Text = value; }
        }

        public String Cmd
        {
            get { return cmd.Text; }
            set { cmd.Text = value; }
        }

        public String Icon
        {
            get { return icon.Text; }
            set { icon.Text = value; }
        }

        public String Name
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public String Description
        {
            get { return desc.Text; }
            set { desc.Text = value; }
        }

        public override string ToString()
        {
            return tag.ToString();
        }
    }

    /**
     * @author VISTALL 
     */
    public class ActionNameInfo_CT3 : Definition
    {
        public UINT tag;
        public UINT id;
        public INT type;
        public UINT category;
        public CNTRINT_PAIR cat2;
        public ASCF cmd;
        public ASCF icon;
        public ASCF icon_ex;
        public ASCF desc;
        public INT toggle_group_id;
        public UNICODE command;
    }
    #endregion

    #region Parser

    public class ActionName : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Goddness_of_Destruction)
                return new ActionNameInfo_CT3();
            return new ActionNameInfo();
        }

        public override Definition ParseMain(System.IO.BinaryReader f, int RecNo)
        {
            Definition def = base.ParseMain(f, RecNo);
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Goddness_of_Destruction)
            {
                //
            }
            else
            {
                ActionNameInfo definition = def as ActionNameInfo;
                if (definition == null)
                    return null;
                String devString = " (id: " + definition.Id + ")";

                if (RConfig.Instance.DevelopMode && !definition.Name.EndsWith(devString))
                    definition.Name = definition.Name + devString;
                else if (!RConfig.Instance.DevelopMode && definition.Name.EndsWith(devString))
                    definition.Name = definition.Name.Replace(devString, "");
            }


            return def;
        }
    }

    #endregion
}