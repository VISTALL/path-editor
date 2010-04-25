#region Using

using System.ComponentModel;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.client.types;
using com.jds.PathEditor.classes.services;

#endregion

/**
 * Tested:
 * - Gracia Final [WORK]
 * - Gracia Plus [WORK]
 * 
 * - Property Editor
 */

namespace com.jds.PathEditor.classes.client.definitions
{

    #region Definition

    public class ItemPrime_Info : Definition
    {
        public UINT id;
        public UINT val;

        public uint Id
        {
            get { return id.Value; }
            set { id.Value = value; }
        }

        public uint Val
        {
            get { return val.Value; }
            set { val.Value = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }

    #endregion

    #region Parser

    public class ItemPrime : DatParser
    {
        public override Definition getDefinition()
        {
            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final)
            {
                return new ItemPrime_Info();
            }
            else
                return null;
        }
    }

    #endregion
}