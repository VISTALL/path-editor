#region Using

using System;
using System.Collections.Generic;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

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
    
    public class RecipeInfo_C3 : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public ASCF name;
        public UINT id_mk;
        public UINT id_recipe;
        public UINT level;
        public UINT id_item;
        public UINT count;
        public UINT mp_cost;
        public UINT success_rate;
        public MAT materials;
    }

    public class RecipeInfo_CT2 : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public ASCF name;
        public UINT id_mk;
        public UINT id_recipe;
        public UINT level;
        public UINT id_item;
        public UINT count;
        public UINT mp_cost;
        public UINT success_rate;
        public MAT2 materials;
    }

    #endregion

    #region Parser

    public class Recipe : DatParser
    {
        public override Definition getDefinition()
        {
            if(RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
            {
                return new RecipeInfo_CT2();
            }

            return new RecipeInfo_C3();
        }
    }

    #endregion
}