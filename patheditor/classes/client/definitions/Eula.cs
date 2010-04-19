#region Using

using System;
using System.ComponentModel;
using System.Drawing.Design;
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

    public class EulaInfo : Definition
    {
        /*
            Info from l2asm-disasm
        */
        public ASCF fin0;
        public ASCF fin1;
        public ASCF fin2;

        [Editor(typeof (TextValueEditor), typeof (UITypeEditor))]
        public String Fin0
        {
            get { return fin0.Text; }
            set { fin0.Text = value; }
        }

        [Editor(typeof (TextValueEditor), typeof (UITypeEditor))]
        public String Fin1
        {
            get { return fin1.Text; }
            set { fin1.Text = value; }
        }

        [Editor(typeof (TextValueEditor), typeof (UITypeEditor))]
        public String Fin2
        {
            get { return fin2.Text; }
            set { fin2.Text = value; }
        }

        public override string ToString()
        {
            return fin0.ToString();
        }
    }

    #endregion

    #region Parser

    public class Eula : DatParser
    {
        public override Definition getDefinition()
        {
            return new EulaInfo();
        }

        public override int readCount(BinaryReader f)
        {
            return 1;
        }

        public override void writeCount(BinaryWriter f, int i)
        {
        }
    }

    #endregion
}