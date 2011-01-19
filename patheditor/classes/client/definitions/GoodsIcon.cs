#region Using

using System;
using System.ComponentModel;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

#endregion

/**
 * Tested:
 * - High Five part 4 [WORK]
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class GoodsIconInfo : Definition
    {
        public UINT item_id;
        public UNICODE icon;

        [Description("ItemId")]
        public UINT ItemId
        {
            get { return item_id; }
            set { item_id = value; }
        }

        [Description("icon")]
        public String Icon
        {
            get { return icon.Text; }
            set { icon.Text = value; }
        }

        public override String ToString()
        {
            return item_id.ToString();
        }
    }

    #endregion

    #region Parser

    public class GoodsIcon : DatParser
    {
        public override Definition getDefinition()
        {
            return RConfig.Instance.DatVersionAsEnum >= DatVersion.Anniversary ? new GoodsIconInfo() : null;
        }
    }

    #endregion
}