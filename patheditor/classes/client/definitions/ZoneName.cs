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

    public class ZoneNameInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public FLOAT UNK_1;
        public FLOAT bottom_z;
        public INT coords1;
        public INT coords2;
        public INT coords3;
        public INT coords4;
        public INT coords5;
        public INT coords6;
        public ASCF map;
        public UINT nbr;
        public FLOAT top_z;
        public UINT x_world_grid;
        public UINT y_world_grid;
        public UINT zone_color_id;
        public ASCF zone_name;
    }

    public class ZoneNameInfo_Gracia_Final : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public FLOAT UNK_1;
        public UINT UNK_2;
        public FLOAT bottom_z;
        public INT coords1;
        public INT coords2;
        public INT coords3;
        public INT coords4;
        public INT coords5;
        public INT coords6;
        public ASCF map;
        public UINT nbr;
        public FLOAT top_z;
        public UINT x_world_grid;
        public UINT y_world_grid;
        public UINT zone_color_id;
        public ASCF zone_name;
    }

    #endregion

    #region Parser

    public class ZoneName : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
                return new ZoneNameInfo_Gracia_Final();
            else
                return new ZoneNameInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            var info = new Definition();

            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var dat = new ZoneNameInfo_Gracia_Final();
                dat = (ZoneNameInfo_Gracia_Final) base.ReadFieldValue(f, dat, "nbr", "zone_name");
                dat = (ZoneNameInfo_Gracia_Final) base.ReadFieldValue(f, dat, "coords1", "UNK_2");
                info = dat;
            }
            else
            {
                var dat = new ZoneNameInfo();
                dat = (ZoneNameInfo) base.ReadFieldValue(f, dat, "nbr", "zone_name");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude)
                    dat = (ZoneNameInfo) base.ReadFieldValue(f, dat, "coords1", "map");
                info = dat;
            }
            return info;
        }

        public override void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                var info = (ZoneNameInfo_Gracia_Final) infos[RecNo];
                base.WriteFieldValue(f, info, "nbr", "zone_name");
                base.WriteFieldValue(f, info, "coords1", "UNK_2");
            }
            else
            {
                var info = (ZoneNameInfo) infos[RecNo];
                base.WriteFieldValue(f, info, "nbr", "zone_name");
                if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Interlude)
                    base.WriteFieldValue(f, info, "coords1", "map");
            }
        }
    }

    #endregion
}