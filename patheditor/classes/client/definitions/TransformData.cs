﻿#region Using

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

    public class TransformDataInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UINT npc_id;
        public UNICODE transform_effect_a;
        public UNICODE transform_effect_b;
        public UINT unk;
        public UINT weapon_id;
    }

    public class TransformDataInfo_Gracia_2 : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UINT npc_id;
        public UNICODE transform_effect_a;
        public UNICODE transform_effect_b;
        public UINT unk;
        public UINT unk_1;
        public UINT weapon_id;
    }

    public class TransformDataInfo_Gracia_Final : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UINT npc_id;
        public UNICODE transform_effect_a;
        public UNICODE transform_effect_b;
        public UINT unk;
        public UINT unk1;
        public UINT unk2;
        public UINT unk3;
        public UINT unk4;
        public UINT weapon_id;
    }

    #endregion

    #region Parser

    public class TransformData : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
                return new TransformDataInfo_Gracia_Final();
            else if (RConfig.Instance.DatVersionAsEnum == DatVersion.Gracia_1__Gracia_2)
                return new TransformDataInfo_Gracia_2();
            else
                return new TransformDataInfo();
        }
    }

    #endregion
}