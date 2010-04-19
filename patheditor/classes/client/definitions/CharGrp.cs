#region Using

using System;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.parser;
using com.jds.PathEditor.classes.services;

#endregion

/**
 * thx janiii
 * 
 * Tested:
 * - Interlude [MAYBE WORK] 
 * - Hellbound [NOT WORK]
 * - Gracia 2 [NOT WORK]
 * - Gracia Final [NOT WORK]
 * - Gracia Plus [NOT WORK]
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition 

    public class ChargrpInfo_CT1 : Definition
    {
        /*
        Info from l2asm-disasm
        */
    }

    public class ChargrpInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UNICODE attack_eff;
        public UNICODE body_mesh1;
        public UNICODE body_mesh2;
        public UNICODE body_mesh3;
        public UNICODE body_mesh4;
        public UNICODE body_tex1;
        public UNICODE body_tex2;
        public UNICODE body_tex3;
        public UNICODE body_tex4;
        public UInt32 cnt_att;
        public UInt32 cnt_def;
        public UInt32 cnt_dmg;
        public UInt32 cnt_fm;
        public UInt32 cnt_ft;
        public UInt32 cnt_hm;
        public UInt32 cnt_ht;
        public UNICODE face_icon;
        public UNICODE face_mesh; //[cnt_fm]
        public UNICODE face_tex; //[cnt_ft]
        public UNICODE hair_mesh; //[cnt_hm]
        public UNICODE hair_tex; //[cnt_ht]
        public UNICODE snd_att; //[cnt_att]
        public UNICODE snd_def; //[cnt_def]
        public UNICODE snd_dmg; //[cnt_dmg]
        public CNTTXT_PAIR voice_snd_1hs;
        public CNTTXT_PAIR voice_snd_2hs;
        public CNTTXT_PAIR voice_snd_bow;
        public CNTTXT_PAIR voice_snd_dual;
        public CNTTXT_PAIR voice_snd_fist;
        public CNTTXT_PAIR voice_snd_hand;
        public CNTTXT_PAIR voice_snd_pole;
        public CNTTXT_PAIR voice_snd_unknown;
        public UInt32 walkanimframe;
    }

    public class ChargrpInfo_Gracia_Plus : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public Int32 UNK1;
        public Int32 UNK2;
        public Int32 UNK3;
        public UNICODE attack_eff;
        public CNTTXT_PAIR boot_mesh;
        public CNTTXT_PAIR boot_mesh_add;
        public CNTRINT_PAIR boot_tab; //UCHAR
        public CNTRINT_PAIR boot_tab2; //UCHAR
        public CNTTXT_PAIR boot_tex;
        public CNTTXT_PAIR boot_tex_add;
        public UInt32 cnt_att;
        public UInt32 cnt_def;
        public UInt32 cnt_dmg;
        public CNTTXT_PAIR face_mesh;
        public CNTTXT_PAIR face_tex;
        public FILLER_360 filler_360;
        public FILLER_90 filler_90;
        public UInt32 final1;
        public UInt32 final2;
        public CNTTXT_PAIR glove_mesh;
        public CNTTXT_PAIR glove_mesh_add;
        public CNTRINT_PAIR glove_tab; //UCHAR
        public CNTRINT_PAIR glove_tab2; //UCHAR
        public CNTTXT_PAIR glove_tex;
        public CNTTXT_PAIR glove_tex_add;
        public UNICODE hair_tab; //[300]
        public CNTTXT_PAIR lower_mesh;
        public CNTTXT_PAIR lower_mesh_add;
        public CNTRINT_PAIR lower_tab; //UCHAR
        public CNTRINT_PAIR lower_tab2; //UCHAR
        public CNTTXT_PAIR lower_tex;
        public CNTTXT_PAIR lower_tex_add;
        public ASCF name;
        public CNTTXT_PAIR p1;
        public CNTTXT_PAIR p2;
        public UNICODE snd_att; //[cnt_att]
        public UNICODE snd_def; //[cnt_def]
        public UNICODE snd_dmg; //[cnt_dmg]
        public CNTTXT_PAIR upper_mesh;
        public CNTTXT_PAIR upper_mesh_add;
        public CNTRINT_PAIR upper_tab; //UCHAR
        public CNTRINT_PAIR upper_tab2; //UCHAR
        public CNTTXT_PAIR upper_tex;
        public CNTTXT_PAIR upper_tex_add;
        public CNTTXT_PAIR voice_snd_1hs;
        public CNTTXT_PAIR voice_snd_2hs;
        public CNTTXT_PAIR voice_snd_bow;
        public CNTTXT_PAIR voice_snd_dual;
        public CNTTXT_PAIR voice_snd_fist;
        public CNTTXT_PAIR voice_snd_hand;
        public CNTTXT_PAIR voice_snd_pole;
        public CNTTXT_PAIR voice_snd_unknown;
        public CNTTXT_PAIR voice_snd_unknown2;
        public CNTTXT_PAIR voice_snd_unknown3;
        public UInt32 walkanimframe;
    }

    #endregion

    #region Parser

    public class Chargrp : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
                return new ChargrpInfo_Gracia_Plus();
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                return new ChargrpInfo_CT1();
            else
                return new ChargrpInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            var ret = new Definition();
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Plus__Epilogue)
            {
                var info = new ChargrpInfo_Gracia_Plus();
                int count = 300;
                info.hair_tab = new UNICODE();
                for (int i = 0; i < count; i++)
                {
                    info.hair_tab.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < count - 1)
                        info.hair_tab.Text += ",";
                }
                info = (ChargrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "face_mesh", "cnt_dmg");
                info.snd_att = new UNICODE();
                for (int i = 0; i < info.cnt_att; i++)
                {
                    info.snd_att.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_att - 1)
                        info.snd_att.Text += ",";
                }
                info.snd_def = new UNICODE();
                for (int i = 0; i < info.cnt_def; i++)
                {
                    info.snd_def.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_def - 1)
                        info.snd_def.Text += ",";
                }
                info.snd_dmg = new UNICODE();
                for (int i = 0; i < info.cnt_dmg; i++)
                {
                    info.snd_dmg.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_dmg - 1)
                        info.snd_dmg.Text += ",";
                }
                info = (ChargrpInfo_Gracia_Plus) base.ReadFieldValue(f, info, "voice_snd_hand", "p2");
                ret = info;
            }
            else if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
            {
                var info = new ChargrpInfo_CT1();
                ret = info;
            }
            else
            {
                var info = new ChargrpInfo();
                info = (ChargrpInfo) base.ReadFieldValue(f, info, "face_icon", "cnt_ft");
                info.hair_mesh = new UNICODE();
                for (int i = 0; i < info.cnt_hm; i++)
                {
                    info.hair_mesh.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_hm - 1)
                        info.hair_mesh.Text += ",";
                }
                info.hair_tex = new UNICODE();
                for (int i = 0; i < info.cnt_ht; i++)
                {
                    info.hair_tex.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_ht - 1)
                        info.hair_tex.Text += ",";
                }
                info.face_mesh = new UNICODE();
                for (int i = 0; i < info.cnt_fm; i++)
                {
                    info.face_mesh.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_fm - 1)
                        info.face_mesh.Text += ",";
                }
                info.face_tex = new UNICODE();
                for (int i = 0; i < info.cnt_ft; i++)
                {
                    info.face_tex.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_ft - 1)
                        info.face_tex.Text += ",";
                }
                info = (ChargrpInfo) base.ReadFieldValue(f, info, "body_mesh1", "cnt_dmg");
                info.snd_att = new UNICODE();
                for (int i = 0; i < info.cnt_att; i++)
                {
                    info.snd_att.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_att - 1)
                        info.snd_att.Text += ",";
                }
                info.snd_def = new UNICODE();
                for (int i = 0; i < info.cnt_def; i++)
                {
                    info.snd_def.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_def - 1)
                        info.snd_def.Text += ",";
                }
                info.snd_dmg = new UNICODE();
                for (int i = 0; i < info.cnt_dmg; i++)
                {
                    info.snd_dmg.Text += DatTool.ReadStringSimple_UnicodeInt32Length(f);
                    if (i < info.cnt_dmg - 1)
                        info.snd_dmg.Text += ",";
                }
                info = (ChargrpInfo) base.ReadFieldValue(f, info, "voice_snd_hand", "voice_snd_fist");
                ret = info;
            }
            return ret;
        }

        public override int readCount(BinaryReader f)
        {
            return 14;
        }
    }

    #endregion
}