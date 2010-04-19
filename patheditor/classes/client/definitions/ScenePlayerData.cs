#region Using

using System;
using System.ComponentModel;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;

#endregion

/**
 * Tested:
 * - Gracia Final [WORK]
 * - Gracia Plus [WORK]
 * 
 * - Propery Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class ScenePlayerData_Info : Definition
    {
        /*
        Info from l2asm-disasm
        */
        public FLOAT dat;
        public UINT id;
        public UNICODE str;

        [Description("Id")]
        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        [Description("String")]
        public String Str
        {
            get { return str.Text; }
            set { str.Text = value; }
        }

        [Description("Dat")]
        public float Dat
        {
            get { return dat.Value; }
            set { dat.Value = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class ScenePlayerData : DatParser
    {
        public override Definition getDefinition()
        {
            return new ScenePlayerData_Info();
        }
    }

    #endregion
}