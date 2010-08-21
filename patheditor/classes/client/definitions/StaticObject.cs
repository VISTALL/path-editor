#region Using

using System;
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

    public class StaticObjectInfo : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public UINT id;
        public UNICODE name;

        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        public String Name
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class StaticObject : DatParser
    {
        public override Definition getDefinition()
        {
            return new StaticObjectInfo();
        }

        public override Definition ParseMain(BinaryReader f, int RecNo)
        {
            StaticObjectInfo info = (StaticObjectInfo)base.ParseMain(f, RecNo);
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

    #endregion
}