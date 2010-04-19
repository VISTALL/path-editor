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

    public class MusicInfoInfo : Definition
    {
        public UINT id;
        public CNTTXT_PAIR name;

        [Description("Id")]
        public UINT Id
        {
            get { return id; }
            set { id = value; }
        }

        [Description("Name Length")]
        public int NameLength
        {
            get { return name.Length; }
            set { name.Length = value; }
        }

        [Description("Name Text")]
        public String NameText
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class MusicInfo : DatParser
    {
        public override Definition getDefinition()
        {
            return new MusicInfoInfo();
        }
    }

    #endregion
}