#region Using

using System.ComponentModel;
using System.Drawing.Design;
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

    public class ProductName_Info : Definition
    {
        public UINT id;
        public UNICODE name;
        public ASCF str;
        public UNICODE icon;

        public override string ToString()
        {
            return id.ToString();
        }
       
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

        [Editor(typeof(TextValueEditor), typeof(UITypeEditor))]
        public string Name
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

        [Editor(typeof(TextValueEditor), typeof(UITypeEditor))]
        public string Str
        {
            get
            {
                return str.Text;
            }
            set
            {
                str.Text = value;
            }
        }

        [Editor(typeof(TextValueEditor), typeof(UITypeEditor))]
        public string Icon
        {
            get
            {
                return icon.Text;
            }
            set
            {
                icon.Text = value;
            }
        }
    }

    #endregion

    #region Parser

    public class ProductName : DatParser
    {
        public override Definition getDefinition()
        {
            return RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_Final ? new ProductName_Info() : null;
        }
    }

    #endregion
}