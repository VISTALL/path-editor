#region Using

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

    public class EtcitemgrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT tag;
        public UINT id;
        public UINT drop_type;
        public UINT drop_anim_type;
        public UINT drop_radius;
        public UINT drop_height;
        public UINT UNK_0;
        public UNICODE drop_mesh;
        public UNICODE drop_tex;
        public UNICODE icon1;
        public UNICODE icon2;
        public UNICODE icon3;
        public UNICODE icon4;
        public UNICODE icon5;
        public UINT durability;
        public UINT weight;
        public UINT material;
        public UINT crystallizable;
        public UINT UNK_1;
        public MTX mesh_tex_pair;
        public UNICODE item_sound;
        public UNICODE equip_sound;
        public UINT stackable;
        public UINT family;
        public UINT grade;
    }

    public class EtcitemgrpInfo_C4 : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT tag;
        public UINT id;
        public UINT drop_type;
        public UINT drop_anim_type;
        public UINT drop_radius;
        public UINT drop_height;
        public UINT UNK_0;
        public UNICODE drop_mesh;
        public UNICODE drop_tex;
        public UNICODE icon1;
        public UNICODE icon2;
        public UNICODE icon3;
        public UNICODE icon4;
        public UNICODE icon5;
        public UNICODE icon6;
        public UNICODE icon7;
        public UNICODE icon8;
        public UNICODE icon9;
        public UINT durability;
        public UINT weight;
        public UINT material;
        public UINT crystallizable;
        public UINT UNK_1;
        public MTX mesh_tex_pair;
        public UNICODE item_sound;
        public UNICODE equip_sound;
        public UINT stackable;
        public UINT family;
        public UINT grade;
    }

    public class EtcitemgrpInfo_CT1 : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT tag;
        public UINT id;
        public UINT drop_type;
        public UINT drop_anim_type;
        public UINT drop_radius;
        public UINT drop_height;
        public UINT UNK_0;
        public UNICODE drop_mesh;
        public UNICODE drop_tex;
        public UNICODE icon1;
        public UNICODE icon2;
        public UNICODE icon3;
        public UNICODE icon4;
        public UNICODE icon5;
        public UNICODE icon6;
        public UNICODE icon7;
        public UNICODE icon8;
        public UNICODE icon9;
        public INT durability;
        public UINT weight;
        public UINT material;
        public UINT crystallizable;
        public UINT UNK_1;
        public CNTINT_PAIR UNK_2;
        public UINT UNK_3;
        public UNICODE fort;
        public MTX mesh_tex_pair;
        public UNICODE item_sound;
        public UNICODE equip_sound;
        public UINT stackable;
        public UINT family;
        public UINT grade;
    }

    public class EtcitemgrpInfo_Gracia_Final : Definition
    {
        public UINT tag;
        public UINT id;
        public UINT drop_type;
        public UINT drop_anim_type;
        public UINT drop_radius;
        public UINT drop_height;
        public UINT UNK_0;

        public UNICODE drop_mesh1;
        public UNICODE drop_mesh2;
        public UNICODE drop_mesh3;

        public UNICODE drop_tex1;
        public UNICODE drop_tex2;
        public UNICODE drop_tex3;
        public UNICODE drop_extratex1;

        public INT newdata1;
        public INT newdata2;
        public INT newdata3;
        public INT newdata4;
        public INT newdata5;
        public INT newdata6;
        public INT newdata7;
        public INT newdata8;

        public UNICODE icon1;
        public UNICODE icon2;
        public UNICODE icon3;
        public UNICODE icon4;
        public UNICODE icon5;

        public INT durability;
        public UINT weight;
        public UINT material;
        public UINT crystallizable;
        public UINT UNK_1;
        public CNTINT_PAIR UNK_2;
        public UINT UNK_3;
        public UNICODE fort;
        public MTX mesh_tex_pair;
        public UNICODE item_sound;
        public UNICODE equip_sound;
        public UINT stackable;
        public UINT family;
        public UINT grade;
    }

    #endregion

    #region Parser

    public class Etcitemgrp : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
                return new EtcitemgrpInfo_Gracia_Final();
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                return new EtcitemgrpInfo_CT1();
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                return new EtcitemgrpInfo_C4();
            else
                return new EtcitemgrpInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            var ret = new Definition();

            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = new EtcitemgrpInfo_Gracia_Final();
                info.InitFieldValues();

                info = (EtcitemgrpInfo_Gracia_Final) base.ReadFieldValue(f, info, "tag", "UNK_0");
                info = (EtcitemgrpInfo_Gracia_Final) base.ReadFieldValue(f, info, "drop_mesh1", "UNK_1");
                info = (EtcitemgrpInfo_Gracia_Final) base.ReadFieldValue(f, info, "UNK_2");
                info = (EtcitemgrpInfo_Gracia_Final) base.ReadFieldValue(f, info, "UNK_3");
                info = (EtcitemgrpInfo_Gracia_Final) base.ReadFieldValue(f, info, "fort", "grade");

                ret = info;
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
            {
                var info = new EtcitemgrpInfo_CT1();
                info.InitFieldValues();
                info = (EtcitemgrpInfo_CT1) base.ReadFieldValue(f, info, "tag", "UNK_1");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                    info = (EtcitemgrpInfo_CT1) base.ReadFieldValue(f, info, "UNK_2");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                    info = (EtcitemgrpInfo_CT1) base.ReadFieldValue(f, info, "UNK_3");
                info = (EtcitemgrpInfo_CT1) base.ReadFieldValue(f, info, "fort", "grade");
                ret = info;
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
            {
                var info = new EtcitemgrpInfo_C4();
                info = (EtcitemgrpInfo_C4) base.ReadFieldValue(f, info, "tag", "grade");
                ret = info;
            }
            else
            {
                var info = new EtcitemgrpInfo();
                info = (EtcitemgrpInfo) base.ReadFieldValue(f, info, "tag", "grade");
                ret = info;
            }
            return ret;
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = (EtcitemgrpInfo_Gracia_Final) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "UNK_0");
                base.WriteFieldValue(f, info, "drop_mesh1", "UNK_1");
                base.WriteFieldValue(f, info, "UNK_2");
                base.WriteFieldValue(f, info, "UNK_3");
                base.WriteFieldValue(f, info, "fort", "grade");
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
            {
                var info = (EtcitemgrpInfo_CT1) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "UNK_1");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                    base.WriteFieldValue(f, info, "UNK_2");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                    base.WriteFieldValue(f, info, "UNK_3");
                base.WriteFieldValue(f, info, "fort", "grade");
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
            {
                var info = (EtcitemgrpInfo_C4) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "grade");
            }
            else
            {
                var info = (EtcitemgrpInfo) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "grade");
            }
        }
    }

    #endregion
}