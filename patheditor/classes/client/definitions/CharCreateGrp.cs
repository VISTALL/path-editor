#region Using

using System.ComponentModel;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;

#endregion

/**
 * Tested:
 * - Gracia Plus [WORK]
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class CharCreategrpInfo : Definition
    {
        /**
		 * by VISTALL
		 */
        public UINT unknown;
        public FLOAT x;
        public FLOAT y;
        public FLOAT z;
        public UINT wear1;
        public UINT wear2;
        public UINT wear3;
        public UINT wear4;
        public UINT wear5;
        public UINT wear6;

        [Description("Unknown")]
        public uint Unknown
        {
            get { return unknown.Value; }
            set { unknown.Value = value; }
        }

        [Description("Start X")]
        public float X
        {
            get { return x.Value; }
            set { x.Value = value; }
        }

        [Description("Start Y")]
        public float Y
        {
            get { return y.Value; }
            set { y.Value = value; }
        }

        [Description("Start Z")]
        public float Z
        {
            get { return z.Value; }
            set { z.Value = value; }
        }

        [Description("Wear item id 1")]
        public uint Wear1
        {
            get { return wear1.Value; }
            set { wear1.Value = value; }
        }

        [Description("Wear item id 2")]
        public uint Wear2
        {
            get { return wear2.Value; }
            set { wear2.Value = value; }
        }

        [Description("Wear item id 3")]
        public uint Wear3
        {
            get { return wear3.Value; }
            set { wear3.Value = value; }
        }

        [Description("Wear item id 4")]
        public uint Wear4
        {
            get { return wear4.Value; }
            set { wear4.Value = value; }
        }

        [Description("Wear item id 5")]
        public uint Wear5
        {
            get { return wear5.Value; }
            set { wear5.Value = value; }
        }

        [Description("Wear item id 6")]
        public uint Wear6
        {
            get { return wear6.Value; }
            set { wear6.Value = value; }
        }

        public override string ToString()
        {
            return unknown.ToString();
        }
    }

    #endregion

    #region Parser

    public class CharCreategrp : DatParser
    {
        private const int COUNT = 20;

        public override Definition getDefinition()
        {
            return new CharCreategrpInfo();
        }

        public override int readCount(BinaryReader f)
        {
            return COUNT;
        }

        public override void writeCount(BinaryWriter f, int i)
        {
            //
        }
    }

    #endregion
}