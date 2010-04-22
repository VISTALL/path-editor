#region Using

using System;
using System.ComponentModel;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;

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

    public class LogongrpInfo : Definition
    {
        public FLOAT x;
        public FLOAT y;
        public FLOAT z;
        public FLOAT yaw;

        [Description("X")]
        public float X
        {
            get { return x.Value; }
            set { x.Value = value; }
        }

        [Description("Y")]
        public float Y
        {
            get { return y.Value; }
            set { y.Value = value; }
        }

        [Description("Z")]
        public float Z
        {
            get { return z.Value; }
            set { z.Value = value; }
        }

        [Description("YAW")]
        public Single YAW
        {
            get { return yaw.Value; }
            set { yaw.Value = value; }
        }

        public override String ToString()
        {
            return x.ToString();
        }
    }

    #endregion

    #region Parser

    public class Logongrp : DatParser
    {
        private const int COUNT = 8;

        public override Definition getDefinition()
        {
            return new LogongrpInfo();
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