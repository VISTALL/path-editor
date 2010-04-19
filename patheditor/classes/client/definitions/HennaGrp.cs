#region Using

using System;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;

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

    public class HennagrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT dye_id;
        public ASCF icon;
        public UINT id;
        public ASCF name;
        public ASCF symbol_add_desc;
        public ASCF symbol_add_name;

        public UINT Id
        {
            get { return id; }
            set { id = value; }
        }

        public UINT DyeId
        {
            get { return dye_id; }
            set { dye_id = value; }
        }

        public String Name
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public String Icon
        {
            get { return icon.Text; }
            set { icon.Text = value; }
        }

        public String SymbolAddName
        {
            get { return symbol_add_name.Text; }
            set { symbol_add_name.Text = value; }
        }

        public String SymbolAddDescription
        {
            get { return symbol_add_desc.Text; }
            set { symbol_add_desc.Text = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class Hennagrp : DatParser
    {
        public override Definition getDefinition()
        {
            return new HennagrpInfo();
        }
    }

    #endregion
}