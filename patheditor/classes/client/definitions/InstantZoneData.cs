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

    public class InstantZoneDataInfo : Definition
    {
        public UINT id;
        public ASCF name;

        [Description("Instance Id")]
        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        [Description("Instance Name")]
        public String Name
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public override String ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class InstantZoneData : DatParser
    {
        public override Definition getDefinition()
        {
            return new InstantZoneDataInfo();
        }
    }

    #endregion
}