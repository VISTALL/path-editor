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
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class SymbolNameInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT UNK_0;
        public ASCF alias;
        public ASCF filename;
        public UINT id;

        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        public String FileName
        {
            get { return filename.Text; }
            set { filename.Text = value; }
        }

        public String Alias
        {
            get { return alias.Text; }
            set { alias.Text = value; }
        }

        public uint Unk0
        {
            get { return UNK_0.Value; }
            set { UNK_0.Value = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class SymbolName : DatParser
    {
        public override Definition getDefinition()
        {
            return new SymbolNameInfo();
        }
    }

    #endregion
}