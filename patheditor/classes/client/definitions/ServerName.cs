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

    public class ServerNameInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public ASCF server_desc;
        public UINT server_id;
        public ASCF server_name;
        public UINT tag;

        public uint ServerId
        {
            get { return server_id.Value; }
            set { server_id.Value = value; }
        }

        public uint Tag
        {
            get { return tag.Value; }
            set { tag.Value = value; }
        }

        public String ServerName
        {
            get { return server_name.Text; }
            set { server_name.Text = value; }
        }

        public String ServerDescription
        {
            get { return server_desc.Text; }
            set { server_desc.Text = value; }
        }

        public override string ToString()
        {
            return server_id.ToString();
        }
    }

    #endregion

    #region Parser

    public class ServerName : DatParser
    {
        public override Definition getDefinition()
        {
            return new ServerNameInfo();
        }
    }

    #endregion
}