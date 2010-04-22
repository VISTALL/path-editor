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

    public class RecipeInfo : Definition
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
        public STRING materials;
        public UINT UNK0;
    }

    #endregion


    #region Parser

    public class Recipe : DatParser
    {
        public override Definition getDefinition()
        {
            return new RecipeInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            var info = new RecipeInfo();
            info.InitFieldValues();

            info = (RecipeInfo) base.ReadFieldValue(f, info, "name", "success_rate");
            int MatCnt = f.ReadInt32();
            for (int i = 0; i < MatCnt; i++)
            {
                info.materials.Value += "[" + f.ReadInt32();
                info.materials.Value += "(" + f.ReadInt32() + ")]";
                if (i < MatCnt - 1)
                    info.materials.Value += ",";
            }
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                info = (RecipeInfo) base.ReadFieldValue(f, info, "UNK0");
            return info;
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            var info = (RecipeInfo) infos[RecNo];
            base.WriteFieldValue(f, info, "name", "success_rate");
            string[] TmpStr = info.materials.Value.Split(new[] {','});
            f.Write(TmpStr.Length);
            for (int i = 0; i < TmpStr.Length; i++)
            {
                TmpStr[i] = TmpStr[i].Trim('[', ')', ']');
                String[] TmpStr2 = TmpStr[i].Split(new[] {'('});
                f.Write(Convert.ToInt32(TmpStr2[0]));
                f.Write(Convert.ToInt32(TmpStr2[1]));
            }
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                base.WriteFieldValue(f, info, "UNK0");
        }
    }

    #endregion
}