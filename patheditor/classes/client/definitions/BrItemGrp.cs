#region Using

using System;
using System.ComponentModel;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

#endregion

/**
 * Tested:
 * - Gracia Plus [WORK]
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class BrItemGrp_Gracia_Plus : Definition
    {
        /*
         By VISTALL
         */
        public UINT item_id;
        public UINT zero_1;
        public UINT zero_2;
        public UNICODE effect;

        [Description("Item Id")]
        public uint ItemId
        {
            get { return item_id.Value; }
            set { item_id.Value = value; }
        }

        [Description("Unknown")]
        public uint Zero_1
        {
            get { return zero_1.Value; }
            set { zero_1.Value = value; }
        }

        [Description("Unknown")]
        public uint Zero_2
        {
            get { return zero_2.Value; }
            set { zero_2.Value = value; }
        }

        [Description("Effect. Dont Tested :(")]
        public String Effect
        {
            get { return effect.Text; }
            set { effect.Text = value; }
        }

        public override string ToString()
        {
            return item_id.ToString();
        }
    }

    #endregion

    #region Parser

    public class BrItemGrp : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
                return new BrItemGrp_Gracia_Plus();

            return null;
        }
    }

    #endregion
}