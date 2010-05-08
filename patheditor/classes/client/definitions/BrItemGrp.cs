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
        public UINT item_id_1;
        public UINT item_id_2;
        public UINT item_id_3;
        public UINT item_id_4;
        public UINT item_id_5;
        public UINT item_id_6;
        public UINT item_id_7;
        public UINT item_id_8;
        public UINT item_id_9;
        public UINT item_id_10;
        public INT unk_1;
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