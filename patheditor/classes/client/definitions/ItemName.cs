#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    #region ItemnameInfo lowest
    public class ItemNameInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UNICODE name;
        public UNICODE additionalname;
        public ASCF description;
        public INT popup;
        public ASCF set_ids;
        public ASCF set_bonus_desc;
        public ASCF set_extra_ids;
        public ASCF set_extra_desc;
        public ASCF UNK0_1;
        public ASCF UNK0_2;
        public UINT special_enchant_amount;
        public ASCF special_enchant_desc;
        public UINT UNK1;

        public override string ToString()
        {
            return id.ToString();
        }

        #region id
        [Description("Item Id")]
        public uint Id
        {
            get
            {
                return id.Value;
            }
            set
            {
                id.Value = value;
            }
        }
        #endregion
        #region name
        [Description("Name")]
        public String Name
        {
            get
            {
                return name.Text;
            }
            set
            {
                name.Text = value;
            }
        }
        #endregion
        #region additionalname
        [Description("Additional Name")]
        public String AdditionalName
        {
            get
            {
                return additionalname.Text;
            }
            set
            {
                additionalname.Text = value;
            }
        }
        #endregion
        #region description
        [Description("Description")]
        public String Description
        {
            get
            {
                return description.Text;
            }
            set
            {
                description.Text = value;
            }
        }
        #endregion
        #region popup
        [Description("Popup")]
        public int Popup
        {
            get
            {
                return popup.Value;
            }
            set
            {
                popup.Value = value;
            }
        }
        #endregion
        #region set_ids
        [Description("Set Ids")]
        public String SetIdsText
        {
            get
            {
                return set_ids.Text;
            }
            set
            {
                set_ids.Text = value;
            }
        }
        #endregion
        #region set_bonus_desc
        [Description("Set Bonus Descpription ")]
        public String SetBonusDescription
        {
            get
            {
                return set_bonus_desc.Text;
            }
            set
            {
                set_bonus_desc.Text = value;
            }
        }
        #endregion
        #region set_extra_ids
        [Description("Set Ids ")]
        public String ExtraIds
        {
            get
            {
                return set_extra_ids.Text;
            }
            set
            {
                set_extra_ids.Text = value;
            }
        }
        #endregion
        #region set_extra_desc
        [Description("Extra description")]
        public String ExtraDescription
        {
            get
            {
                return set_extra_desc.Text;
            }
            set
            {
                set_extra_desc.Text = value;
            }
        }
        #endregion
        #region UNK0_1
        [Description("UNK0_1")]
        public String UNK_0_1
        {
            get
            {
                return UNK0_1.Text;
            }
            set
            {
                UNK0_1.Text = value;
            }
        }
        #endregion
        #region UNK0_2
        [Description("UNK0_2")]
        public String UNK_0_2
        {
            get
            {
                return UNK0_2.Text;
            }
            set
            {
                UNK0_2.Text = value;
            }
        }
        #endregion
        #region special_enchant_amount
        [Description("Special Enchant Count")]
        public uint SpecialEnchantCount
        {
            get
            {
                return special_enchant_amount.Value;
            }
            set
            {
                special_enchant_amount.Value = value;
            }
        }
        #endregion
        #region special_enchant_desc
        [Description("Special Enchant Description")]
        public String SpecialEnchantDescription
        {
            get
            {
                return special_enchant_desc.Text;
            }
            set
            {
                special_enchant_desc.Text = value;
            }
        }
        #endregion
        #region UNK1
        [Description("UNK_1")]
        public uint UNK_1
        {
            get
            {
                return UNK1.Value;
            }
            set
            {
                UNK1.Value = value;
            }
        }
        #endregion
    }
    #endregion

    #region ItemNameInfo Gracia Final
    public class ItemNameInfo_Gracia_Final : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;//
        public UNICODE name;//
        public UNICODE additionalname;//
        public ASCF description;//
        public INT popup;//
        public UINT supercnt0;//
        public CNTTXT_PAIR set_ids;//
        public ASCF set_bonus_desc;//
        public UINT supercnt1;//
        public CNTTXT_PAIR set_extra_ids;//
        public ASCF set_extra_desc;//
        public ASCF UNK1_1;//
        public ASCF UNK1_2;//
        public ASCF UNK1_3;//
        public ASCF UNK1_4;//
        public ASCF UNK1_5;//
        public ASCF UNK1_6;//
        public ASCF UNK1_7;//
        public ASCF UNK1_8;//
        public ASCF UNK1_9;//
        public UINT special_enchant_amount;//
        public ASCF special_enchant_desc;//
        public UINT UNK2;//

        public override string ToString()
        {
            return id.ToString();
        }

        #region id
        [Description("Item Id")]
        public uint Id
        {
            get
            {
                return id.Value;
            }
            set
            {
                id.Value = value;
            }
        }
        #endregion
        #region name
        [Description("Name")]
        public String Name
        {
            get
            {
                return name.Text;
            }
            set
            {
                name.Text = value;
            }
        }
        #endregion
        #region additionalname
        [Description("Additional Name")]
        public String AdditionalName
        {
            get
            {
                return additionalname.Text;
            }
            set
            {
                additionalname.Text = value;
            }
        }
        #endregion
        #region description
        [Description("Description")]
        public String Description
        {
            get
            {
                return description.Text;
            }
            set
            {
                description.Text = value;
            }
        }
        #endregion
        #region popup
        [Description("Popup")]
        public int Popup
        {
            get
            {
                return popup.Value;
            }
            set
            {
                popup.Value = value;
            }
        }
        #endregion
        #region supercnt0
        [Description("Superctn0")]
        public uint SuperCTN0
        {
            get
            {
                return supercnt0.Value;
            }
            set
            {
                supercnt0.Value = value;
            }
        }
        #endregion
        #region set_ids
        [Description("Set Ids Length")]
        public int SetIdsLength
        {
            get
            {
                return set_ids.Length;
            }
            set
            {
                set_ids.Length = value;
            }
        }

        [Description("Set Ids Text")]
        public String SetIdsText
        {
            get
            {
                return set_ids.Text;
            }
            set
            {
                set_ids.Text = value;
            }
        }
        #endregion
        #region set_bonus_desc
        [Description("Bonus description")]
        public String BonusDescription
        {
            get
            {
                return set_bonus_desc.Text;
            }
            set
            {
                set_bonus_desc.Text = value;
            }
        }
        #endregion
        #region supercnt1
        [Description("Superctn1")]
        public uint SuperCTN1
        {
            get
            {
                return supercnt1.Value;
            }
            set
            {
                supercnt0.Value = value;
            }
        }
        #endregion
        #region set_extra_ids
        [Description("Set Extra Ids Length")]
        public int SetExtraIdsLength
        {
            get
            {
                return set_extra_ids.Length;
            }
            set
            {
                set_extra_ids.Length = value;
            }
        }

        [Description("Set Extra Ids Text")]
        public String SetExtraIdsText
        {
            get
            {
                return set_extra_ids.Text;
            }
            set
            {
                set_extra_ids.Text = value;
            }
        }
        #endregion
        #region set_extra_desc
        [Description("Extra description")]
        public String ExtraDescription
        {
            get
            {
                return set_extra_desc.Text;
            }
            set
            {
                set_extra_desc.Text = value;
            }
        }
        #endregion
        #region UNK1_1
        [Description("UNK1_1")]
        public String UNK_1_1
        {
            get
            {
                return UNK1_1.Text;
            }
            set
            {
                UNK1_1.Text = value;
            }
        }
        #endregion
        #region UNK1_2
        [Description("UNK1_2")]
        public String UNK_1_2
        {
            get
            {
                return UNK1_2.Text;
            }
            set
            {
                UNK1_2.Text = value;
            }
        }
        #endregion
        #region UNK1_3
        [Description("UNK1_3")]
        public String UNK_1_3
        {
            get
            {
                return UNK1_3.Text;
            }
            set
            {
                UNK1_3.Text = value;
            }
        }
        #endregion
        #region UNK1_4
        [Description("UNK1_4")]
        public String UNK_1_4
        {
            get
            {
                return UNK1_4.Text;
            }
            set
            {
                UNK1_4.Text = value;
            }
        }
        #endregion
        #region UNK1_5
        [Description("UNK1_5")]
        public String UNK_1_5
        {
            get
            {
                return UNK1_5.Text;
            }
            set
            {
                UNK1_5.Text = value;
            }
        }
        #endregion
        #region UNK1_6
        [Description("UNK1_6")]
        public String UNK_1_6
        {
            get
            {
                return UNK1_6.Text;
            }
            set
            {
                UNK1_6.Text = value;
            }
        }
        #endregion
        #region UNK1_7
        [Description("UNK1_7")]
        public String UNK_1_7
        {
            get
            {
                return UNK1_7.Text;
            }
            set
            {
                UNK1_7.Text = value;
            }
        }
        #endregion
        #region UNK1_8
        [Description("UNK1_8")]
        public String UNK_1_8
        {
            get
            {
                return UNK1_8.Text;
            }
            set
            {
                UNK1_8.Text = value;
            }
        }
        #endregion
        #region UNK1_9
        [Description("UNK1_9")]
        public String UNK_1_9
        {
            get
            {
                return UNK1_9.Text;
            }
            set
            {
                UNK1_9.Text = value;
            }
        }
        #endregion
        #region special_enchant_amount
        [Description("Special Enchant Count")]
        public uint SpecialEnchantCount
        {
            get
            {
                return special_enchant_amount.Value;
            }
            set
            {
                special_enchant_amount.Value = value;
            }
        }
        #endregion
        #region special_enchant_desc
        [Description("Special Enchant Description")]
        public String SpecialEnchantDescription
        {
            get
            {
                return special_enchant_desc.Text;
            }
            set
            {
                special_enchant_desc.Text = value;
            }
        }
        #endregion
        #region UNK2
        [Description("UNK_2")]
        public uint UNK_2
        {
            get
            {
                return UNK2.Value;
            }
            set
            {
                UNK2.Value = value;
            }
        }
        #endregion
    }
    #endregion

    #endregion

    #region Parser

    public class ItemName : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
                return new ItemNameInfo_Gracia_Final();
            
            return new ItemNameInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                ItemNameInfo_Gracia_Final info = new ItemNameInfo_Gracia_Final();

                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "id", "popup");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "supercnt0");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "set_ids");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "set_bonus_desc");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "supercnt1");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "set_extra_ids");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "set_extra_desc");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "UNK1_1", "UNK1_9");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "special_enchant_amount");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "special_enchant_desc");
                info = (ItemNameInfo_Gracia_Final) ReadFieldValue(f, info, "UNK2");

                String devString = " (id: " + info.id + ")";

                if(RConfig.Instance.DevelopMode && !info.Name.EndsWith(devString))
                {
                    info.Name = info.Name + devString;      
                }
                else if(!RConfig.Instance.DevelopMode && info.Name.EndsWith(devString))
                {
                    info.Name = info.Name.Replace(devString, "");
                }

                return info;
            }
            else
            {
                ItemNameInfo info = new ItemNameInfo();
                info = (ItemNameInfo) ReadFieldValue(f, info, "id", "popup");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                    info = (ItemNameInfo) ReadFieldValue(f, info, "set_ids", "special_enchant_desc");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                    info = (ItemNameInfo) ReadFieldValue(f, info, "UNK1");

                String devString = " (id: " + info.id + ")";

                if (RConfig.Instance.DevelopMode && !info.Name.EndsWith(devString))
                {
                    info.Name = info.Name + devString;
                }
                else if (!RConfig.Instance.DevelopMode && info.Name.EndsWith(devString))
                {
                    info.Name = info.Name.Replace(devString, "");
                }

                return info;
            }
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = (ItemNameInfo_Gracia_Final) infos[RecNo];

                base.WriteFieldValue(f, info, "id", "popup");
                base.WriteFieldValue(f, info, "supercnt0");
                base.WriteFieldValue(f, info, "set_ids");
                base.WriteFieldValue(f, info, "set_bonus_desc");
                base.WriteFieldValue(f, info, "supercnt1");
                base.WriteFieldValue(f, info, "set_extra_ids");
                base.WriteFieldValue(f, info, "set_extra_desc");
                base.WriteFieldValue(f, info, "UNK1_1", "UNK1_9");
                base.WriteFieldValue(f, info, "special_enchant_amount");
                base.WriteFieldValue(f, info, "special_enchant_desc");
                base.WriteFieldValue(f, info, "UNK2");
            }
            else
            {
                var info = (ItemNameInfo) infos[RecNo];
                base.WriteFieldValue(f, info, "id", "popup");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.C5)
                    base.WriteFieldValue(f, info, "set_ids", "special_enchant_desc");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                    base.WriteFieldValue(f, info, "UNK1");
            }
        }
    }

    #endregion
}