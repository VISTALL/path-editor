using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using com.jds.PathEditor.classes.forms;
using com.jds.PathEditor.classes.windows;
using MS.WindowsAPICodePack.Internal;

namespace com.jds.PathEditor.classes.gui
{
    public class GlassLabel : Label
    {
        public GlassLabel() : base()
        {
               
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);    
        }
    }
}
