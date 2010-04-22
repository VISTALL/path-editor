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

    #region  Definition

    public class WeapongrpInfo : Definition
    {
        public UINT tag;
        public UINT id;
        public UINT drop_type;
        public UINT drop_anim_type;
        public UINT drop_radius;
        public UINT drop_height;
        public UINT UNK_0;
        public UNICODE drop_meshtex1;
        public UNICODE drop_meshtex2;
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
        public UNICODE timetab;
        public UINT body_part;
        public UINT handness;
        public CNTTXT_PAIR wpn_mesh;
        public CNTTXT_PAIR wpn_tex;
        //public MTX mt_pair;
        public CNTTXT_PAIR item_sound;
        public UNICODE drop_sound;
        public UNICODE equip_sound;
        public UNICODE effect;
        public UINT random_damage;
        public UINT patt;
        public UINT matt;
        public UINT weapon_type;
        public UINT crystal_type;
        public UINT critical;
        public INT hit_mod;
        public INT avoid_mod;
        public UINT shield_pdef;
        public UINT shield_rate;
        public UINT speed;
        public UINT mp_consume;
        public UINT SS_count;
        public UINT SPS_count;
        public UINT curvature;
        public UINT UNK_4;
        public INT is_hero;
        public UINT UNK_5;
        public UNICODE effA;
        public UNICODE effB;
        public UNICODE rangeA;
        public UNICODE rangeB;
        public FLOAT junk1A_1;
        public FLOAT junk1A_2;
        public FLOAT junk1A_3;
        public FLOAT junk1A_4;
        public FLOAT junk1A_5;
        public FLOAT junk1B_1;
        public FLOAT junk1B_2;
        public FLOAT junk1B_3;
        public FLOAT junk1B_4;
        public FLOAT junk1B_5;
        public FLOAT junk2A_1;
        public FLOAT junk2A_2;
        public FLOAT junk2A_3;
        public FLOAT junk2A_4;
        public FLOAT junk2A_5;
        public FLOAT junk2A_6;
        public FLOAT junk2B_1;
        public FLOAT junk2B_2;
        public FLOAT junk2B_3;
        public FLOAT junk2B_4;
        public FLOAT junk2B_5;
        public FLOAT junk2B_6;
        public INT junk3_1;
        public INT junk3_2;
        public INT junk3_3;
        public INT junk3_4;
        public UNICODE icons1;
        public UNICODE icons2;
        public UNICODE icons3;
        public UNICODE icons4;
    }

    public class WeapongrpInfo_Gracia_Final : Definition
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

        public UINT newdata_1;
        public UINT newdata_2;
        public UINT newdata_3;
        public UINT newdata_4;
        public UINT newdata_5;
        public UINT newdata_6;
        public UINT newdata_7;
        public UINT newdata_8;

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
        public UNICODE timetab;
        public UINT body_part;
        public UINT handness;
        public CNTTXT_THIRD wpn_mesh;
        public CNTTXT_PAIR wpn_tex;
        //public MTX mt_pair;
        public CNTTXT_PAIR item_sound;
        public UNICODE drop_sound;
        public UNICODE equip_sound;
        public UNICODE effect;
        public UINT random_damage;
        public UINT patt;
        public UINT matt;
        public UINT weapon_type;
        public UINT crystal_type;
        public UINT critical;
        public INT hit_mod;
        public INT avoid_mod;
        public UINT shield_pdef;
        public UINT shield_rate;
        public UINT speed;
        public UINT mp_consume;
        public UINT SS_count;
        public UINT SPS_count;
        public UINT curvature;
        public UINT UNK_4;
        public INT is_hero;
        public UINT UNK_5;
        public UNICODE effA;
        public UNICODE effB;
        public UNICODE rangeA;
        public UNICODE rangeB;
        public FLOAT junk1A_1;
        public FLOAT junk1A_2;
        public FLOAT junk1A_3;
        public FLOAT junk1A_4;
        public FLOAT junk1A_5;
        public FLOAT junk1B_1;
        public FLOAT junk1B_2;
        public FLOAT junk1B_3;
        public FLOAT junk1B_4;
        public FLOAT junk1B_5;
        public FLOAT junk2A_1;
        public FLOAT junk2A_2;
        public FLOAT junk2A_3;
        public FLOAT junk2A_4;
        public FLOAT junk2A_5;
        public FLOAT junk2A_6;
        public FLOAT junk2B_1;
        public FLOAT junk2B_2;
        public FLOAT junk2B_3;
        public FLOAT junk2B_4;
        public FLOAT junk2B_5;
        public FLOAT junk2B_6;
        public INT junk3_1;
        public INT junk3_2;
        public INT junk3_3;
        public INT junk3_4;
        public UNICODE icons1;
        public UNICODE icons2;
        public UNICODE icons3;
        public UNICODE icons4;
    }

    public class WeapongrpInfo_Gracia_Plus : Definition
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

        public UINT newdata_1;
        public UINT newdata_2;
        public UINT newdata_3;
        public UINT newdata_4;
        public UINT newdata_5;
        public UINT newdata_6;
        public UINT newdata_7;
        public UINT newdata_8;

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
        public UNICODE timetab;
        public UINT body_part;
        public UINT handness;
        public CNTTXT_THIRD wpn_mesh;
        public CNTTXT_PAIR wpn_tex;
        //public MTX mt_pair;
        public CNTTXT_PAIR item_sound;
        public UNICODE drop_sound;
        public UNICODE equip_sound;
        public UNICODE effect;
        public UINT random_damage;
        public UINT patt;
        public UINT matt;
        public UINT weapon_type;
        public UINT crystal_type;
        public UINT critical;
        public INT hit_mod;
        public INT avoid_mod;
        public UINT shield_pdef;
        public UINT shield_rate;
        public UINT speed;
        public UINT mp_consume;
        public UINT SS_count;
        public UINT SPS_count;
        public UINT curvature;
        public UINT UNK_4;
        public INT is_hero;
        public UINT UNK_5;
        public UNICODE effA;
        public UNICODE effB;
        public UNICODE rangeA;
        public UNICODE rangeB;
        public FLOAT junk1A_1;
        public FLOAT junk1A_2;
        public FLOAT junk1A_3;
        public FLOAT junk1A_4;
        public FLOAT junk1A_5;
        public FLOAT junk1B_1;
        public FLOAT junk1B_2;
        public FLOAT junk1B_3;
        public FLOAT junk1B_4;
        public FLOAT junk1B_5;
        public FLOAT junk2A_1;
        public FLOAT junk2A_2;
        public FLOAT junk2A_3;
        public FLOAT junk2A_4;
        public FLOAT junk2A_5;
        public FLOAT junk2A_6;
        public FLOAT junk2B_1;
        public FLOAT junk2B_2;
        public FLOAT junk2B_3;
        public FLOAT junk2B_4;
        public FLOAT junk2B_5;
        public FLOAT junk2B_6;
        public INT junk3_1;
        public INT junk3_2;
        public INT junk3_3;
        public INT junk3_4;
        public INT junk3_5;
        public INT junk3_6;
        public UNICODE icons1;
        public UNICODE icons2;
        public UNICODE icons3;
        public UNICODE icons4;
    }
    #endregion

    #region Parser

    public class Weapongrp : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
            {
                return new WeapongrpInfo_Gracia_Plus();
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                return new WeapongrpInfo_Gracia_Final();
            }
            else
            {
                return new WeapongrpInfo();
            }
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
            {
                var def = new WeapongrpInfo_Gracia_Plus();
                def.InitFieldValues();

                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "tag", "UNK_0");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "drop_mesh1");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "drop_mesh2");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "drop_mesh3");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "drop_tex1");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "drop_tex2");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "drop_tex3");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "drop_extratex1");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "newdata_1", "newdata_8");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "icon1", "icon5");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "durability", "UNK_1");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "UNK_2");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "UNK_3", "handness");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "wpn_mesh");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "wpn_tex", "item_sound");
                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "drop_sound", "UNK_5");

                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "effA");
                if ((def.body_part.Value == 7 &&
                     (def.handness.Value == 3 || def.handness.Value == 10 || def.handness.Value == 7)))
                {
                    def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "effB");
                }

                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "junk1A_1", "junk1A_5");
                if (def.body_part.Value == 7 &&
                    (def.handness.Value == 3 || def.handness.Value == 10 || def.handness.Value == 7))
                {
                    def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "junk1B_1", "junk1B_5");
                }

                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "rangeA");
                if (def.body_part.Value == 7 &&
                    (def.handness.Value == 3 || def.handness.Value == 10 || def.handness.Value == 7))
                {
                    def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "rangeB");
                }

                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "junk2A_1", "junk2A_6");
                if (def.body_part.Value == 7 &&
                    (def.handness.Value == 3 || def.handness.Value == 10 || def.handness.Value == 7))
                {
                    def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "junk2B_1", "junk2B_6");
                }

                def = (WeapongrpInfo_Gracia_Plus) base.ReadFieldValue(f, def, "junk3_1", "icons4");
                return def;
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var def = new WeapongrpInfo_Gracia_Final();
                def.InitFieldValues();

                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "tag", "UNK_0");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "drop_mesh1");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "drop_mesh2");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "drop_mesh3");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "drop_tex1");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "drop_tex2");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "drop_tex3");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "drop_extratex1");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "newdata_1", "newdata_8");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "icon1", "icon5");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "durability", "UNK_1");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "UNK_2");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "UNK_3", "handness");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "wpn_mesh");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "wpn_tex", "item_sound");
                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "drop_sound", "UNK_5");

                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "effA");
                if ((def.body_part.Value == 7 &&
                     (def.handness.Value == 3 || def.handness.Value == 10 || def.handness.Value == 7)))
                {
                    def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "effB");
                }

                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "junk1A_1", "junk1A_5");
                if (def.body_part.Value == 7 &&
                    (def.handness.Value == 3 || def.handness.Value == 10 || def.handness.Value == 7))
                {
                    def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "junk1B_1", "junk1B_5");
                }

                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "rangeA");
                if (def.body_part.Value == 7 &&
                    (def.handness.Value == 3 || def.handness.Value == 10 || def.handness.Value == 7))
                {
                    def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "rangeB");
                }

                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "junk2A_1", "junk2A_6");
                if (def.body_part.Value == 7 &&
                    (def.handness.Value == 3 || def.handness.Value == 10 || def.handness.Value == 7))
                {
                    def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "junk2B_1", "junk2B_6");
                }

                def = (WeapongrpInfo_Gracia_Final) base.ReadFieldValue(f, def, "junk3_1", "icons4");
                return def;
            }
            else
            {
                var info = new WeapongrpInfo();
                info.InitFieldValues();

                info = (WeapongrpInfo) base.ReadFieldValue(f, info, "tag", "icon5");

                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "icon6", "icon9");
                }
                info = (WeapongrpInfo) base.ReadFieldValue(f, info, "durability", "UNK_1");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "UNK_2");
                }
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "UNK_3");
                }
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "timetab");
                }
                info = (WeapongrpInfo) base.ReadFieldValue(f, info, "body_part", "curvature");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "UNK_4", "UNK_5");
                }
                info = (WeapongrpInfo) base.ReadFieldValue(f, info, "effA");
                if ((RConfig.Instance.DatVersionAsEnum <= DatVersion.C5 &&
                     (info.weapon_type.Value == 5 || info.weapon_type.Value == 8) ||
                     (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude && info.body_part.Value == 14 &&
                      (info.handness.Value == 3 || info.handness.Value == 7))))
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "effB");
                }
                info = (WeapongrpInfo) base.ReadFieldValue(f, info, "junk1A_1", "junk1A_5");
                if ((RConfig.Instance.DatVersionAsEnum <= DatVersion.C5 &&
                     (info.weapon_type.Value == 5 || info.weapon_type.Value == 8) ||
                     (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude && info.body_part.Value == 14 &&
                      (info.handness.Value == 3 || info.handness.Value == 7))))
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "junk1B_1", "junk1B_5");
                }
                info = (WeapongrpInfo) base.ReadFieldValue(f, info, "rangeA");
                if ((RConfig.Instance.DatVersionAsEnum <= DatVersion.C5 &&
                     (info.weapon_type.Value == 5 || info.weapon_type.Value == 8) ||
                     (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude && info.body_part.Value == 14 &&
                      (info.handness.Value == 3 || info.handness.Value == 7))))
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "rangeB");
                }
                info = (WeapongrpInfo) base.ReadFieldValue(f, info, "junk2A_1", "junk2A_6");
                if ((RConfig.Instance.DatVersionAsEnum <= DatVersion.C5 &&
                     (info.weapon_type.Value == 5 || info.weapon_type.Value == 8) ||
                     (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude && info.body_part.Value == 14 &&
                      (info.handness.Value == 3 || info.handness.Value == 7))))
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "junk2B_1", "junk2B_6");
                }
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude)
                {
                    info = (WeapongrpInfo) base.ReadFieldValue(f, info, "junk3_1", "icons4");
                }
                return info;
            }
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
            {
                var info = (WeapongrpInfo_Gracia_Plus) infos[RecNo];
                //info.InitFieldValues();

                base.WriteFieldValue(f, info, "tag", "UNK_0");
                base.WriteFieldValue(f, info, "drop_mesh1");
                base.WriteFieldValue(f, info, "drop_mesh2");
                base.WriteFieldValue(f, info, "drop_mesh3");
                base.WriteFieldValue(f, info, "drop_tex1");
                base.WriteFieldValue(f, info, "drop_tex2");
                base.WriteFieldValue(f, info, "drop_tex3");
                base.WriteFieldValue(f, info, "drop_extratex1");
                base.WriteFieldValue(f, info, "newdata_1", "newdata_8");
                base.WriteFieldValue(f, info, "icon1", "icon5");
                base.WriteFieldValue(f, info, "durability", "UNK_1");
                base.WriteFieldValue(f, info, "UNK_2");
                base.WriteFieldValue(f, info, "UNK_3", "handness");
                base.WriteFieldValue(f, info, "wpn_mesh");
                base.WriteFieldValue(f, info, "wpn_tex", "item_sound");
                base.WriteFieldValue(f, info, "drop_sound", "UNK_5");

                base.WriteFieldValue(f, info, "effA");
                if ((info.body_part.Value == 7 &&
                     (info.handness.Value == 3 || info.handness.Value == 10 || info.handness.Value == 7)))
                {
                    base.WriteFieldValue(f, info, "effB");
                }

                base.WriteFieldValue(f, info, "junk1A_1", "junk1A_5");
                if (info.body_part.Value == 7 &&
                    (info.handness.Value == 3 || info.handness.Value == 10 || info.handness.Value == 7))
                {
                    base.WriteFieldValue(f, info, "junk1B_1", "junk1B_5");
                }

                base.WriteFieldValue(f, info, "rangeA");
                if (info.body_part.Value == 7 &&
                    (info.handness.Value == 3 || info.handness.Value == 10 || info.handness.Value == 7))
                {
                    base.WriteFieldValue(f, info, "rangeB");
                }

                base.WriteFieldValue(f, info, "junk2A_1", "junk2A_6");
                if (info.body_part.Value == 7 &&
                    (info.handness.Value == 3 || info.handness.Value == 10 || info.handness.Value == 7))
                {
                    base.WriteFieldValue(f, info, "junk2B_1", "junk2B_6");
                }

                base.WriteFieldValue(f, info, "junk3_1", "icons4");
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = (WeapongrpInfo_Gracia_Final) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "UNK_0");
                base.WriteFieldValue(f, info, "drop_mesh1");
                base.WriteFieldValue(f, info, "drop_mesh2");
                base.WriteFieldValue(f, info, "drop_mesh3");
                base.WriteFieldValue(f, info, "drop_tex1");
                base.WriteFieldValue(f, info, "drop_tex2");
                base.WriteFieldValue(f, info, "drop_tex3");
                base.WriteFieldValue(f, info, "drop_extratex1");
                base.WriteFieldValue(f, info, "newdata_1", "newdata_8");
                base.WriteFieldValue(f, info, "icon1", "icon5");
                base.WriteFieldValue(f, info, "durability", "UNK_1");
                base.WriteFieldValue(f, info, "UNK_2");
                base.WriteFieldValue(f, info, "UNK_3", "handness");
                base.WriteFieldValue(f, info, "wpn_mesh");
                base.WriteFieldValue(f, info, "wpn_tex", "item_sound");
                base.WriteFieldValue(f, info, "drop_sound", "UNK_5");

                base.WriteFieldValue(f, info, "effA");
                if ((info.body_part.Value == 7 &&
                     (info.handness.Value == 3 || info.handness.Value == 10 || info.handness.Value == 7)))
                {
                    base.WriteFieldValue(f, info, "effB");
                }

                base.WriteFieldValue(f, info, "junk1A_1", "junk1A_5");
                if (info.body_part.Value == 7 &&
                    (info.handness.Value == 3 || info.handness.Value == 10 || info.handness.Value == 7))
                {
                    base.WriteFieldValue(f, info, "junk1B_1", "junk1B_5");
                }

                base.WriteFieldValue(f, info, "rangeA");
                if (info.body_part.Value == 7 &&
                    (info.handness.Value == 3 || info.handness.Value == 10 || info.handness.Value == 7))
                {
                    base.WriteFieldValue(f, info, "rangeB");
                }

                base.WriteFieldValue(f, info, "junk2A_1", "junk2A_6");
                if (info.body_part.Value == 7 &&
                    (info.handness.Value == 3 || info.handness.Value == 10 || info.handness.Value == 7))
                {
                    base.WriteFieldValue(f, info, "junk2B_1", "junk2B_6");
                }

                base.WriteFieldValue(f, info, "junk3_1", "icons4");
            }
            else
            {
                var info = (WeapongrpInfo) infos[RecNo];
                base.WriteFieldValue(f, info, "tag", "icon5");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                {
                    base.WriteFieldValue(f, info, "icon6", "icon9");
                }
                base.WriteFieldValue(f, info, "durability", "UNK_1");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.HellBound)
                {
                    base.WriteFieldValue(f, info, "UNK_2");
                }
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                {
                    base.WriteFieldValue(f, info, "UNK_3");
                }
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                {
                    base.WriteFieldValue(f, info, "timetab");
                }
                base.WriteFieldValue(f, info, "body_part", "curvature");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C4)
                {
                    base.WriteFieldValue(f, info, "UNK_4", "UNK_5");
                }
                base.WriteFieldValue(f, info, "effA");
                if ((RConfig.Instance.DatVersionAsEnum <= DatVersion.C5 &&
                     (info.weapon_type.Value == 5 || info.weapon_type.Value == 8) ||
                     (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude && info.body_part.Value == 14 &&
                      (info.handness.Value == 3 || info.handness.Value == 7))))
                {
                    base.WriteFieldValue(f, info, "effB");
                }
                base.WriteFieldValue(f, info, "junk1A_1", "junk1A_5");
                if ((RConfig.Instance.DatVersionAsEnum <= DatVersion.C5 &&
                     (info.weapon_type.Value == 5 || info.weapon_type.Value == 8) ||
                     (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude && info.body_part.Value == 14 &&
                      (info.handness.Value == 3 || info.handness.Value == 7))))
                {
                    base.WriteFieldValue(f, info, "junk1B_1", "junk1B_5");
                }
                base.WriteFieldValue(f, info, "rangeA");
                if ((RConfig.Instance.DatVersionAsEnum <= DatVersion.C5 &&
                     (info.weapon_type.Value == 5 || info.weapon_type.Value == 8) ||
                     (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude && info.body_part.Value == 14 &&
                      (info.handness.Value == 3 || info.handness.Value == 7))))
                {
                    base.WriteFieldValue(f, info, "rangeB");
                }
                base.WriteFieldValue(f, info, "junk2A_1", "junk2A_6");
                if ((RConfig.Instance.DatVersionAsEnum <= DatVersion.C5 &&
                     (info.weapon_type.Value == 5 || info.weapon_type.Value == 8) ||
                     (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude && info.body_part.Value == 14 &&
                      (info.handness.Value == 3 || info.handness.Value == 7))))
                {
                    base.WriteFieldValue(f, info, "junk2B_1", "junk2B_6");
                }
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude)
                {
                    base.WriteFieldValue(f, info, "junk3_1", "icons4");
                }
            }
        }
    }

    #endregion
}