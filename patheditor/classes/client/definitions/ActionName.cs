﻿#region Using

using System;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;

#endregion

/**
 * Tested:
 * - Gracia 1 [WORK]
 * - Gracia 2 [WORK]
 * - Gracia Final [WORK]
 * - Gracia Plus [WORK]
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
        public CNTRINT_PAIR cat2;
        public UINT category;
        public ASCF cmd;
        public UNICODE desc;
        public ASCF icon;
        public UINT id;
        public ASCF name;
        public UINT tag;
        public INT type;

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

    #endregion

    #region Parser

    public class ActionName : DatParser
    {
        public override Definition getDefinition()
        {
            return new ActionNameInfo();
        }
    }

    #endregion
}