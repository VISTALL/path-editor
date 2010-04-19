using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using com.jds.PathEditor.classes.client;
using com.jds.PathEditor.classes.forms;
using com.jds.PathEditor.classes.lm;

namespace com.jds.PathEditor.classes.services
{

    #region Dat Version Editor

    public class DatVersionEditor : UITypeEditor
    {
        private IWindowsFormsEditorService fes;

        public override bool IsDropDownResizable
        {
            get { return false; }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            fes = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
            if (fes == null)
                return value;

            var lb = new ListBox();
            lb.Sorted = true;
            lb.SelectionMode = SelectionMode.One;
            lb.HorizontalScrollbar = true;


            String[] vals = Enum.GetNames(typeof (DatVersion));
            int index = 0;
            foreach (String val in vals)
            {
                String v = val.Replace("__", "/").Replace("_", " ");

                if (v.Equals(RConfig.Instance.DatVersion))
                {
                    index = lb.Items.Add(v);
                }
                else
                {
                    lb.Items.Add(v);
                }
            }

            lb.SelectedIndex = index;

            if (value != null)
            {
                index = lb.Items.IndexOf(value);
                if (index > 0)
                    lb.SelectedIndex = index;
            }

            lb.SelectedIndexChanged += lb_SelectedIndexChanged;
            fes.DropDownControl(lb);

            if (lb.SelectedItem == null)
                return value;

            return lb.SelectedItem.ToString();
        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            fes.CloseDropDown();
        }
    }

    #endregion

    #region Encoding Editor

    public class EncodingEditor : UITypeEditor
    {
        private IWindowsFormsEditorService fes;

        public override bool IsDropDownResizable
        {
            get { return false; }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            fes = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
            if (fes == null)
                return value;

            var lb = new ListBox();
            lb.Sorted = true;
            lb.SelectionMode = SelectionMode.One;
            lb.HorizontalScrollbar = true;


            foreach (EncodingInfo info in Encoding.GetEncodings())
            {
                if (!lb.Items.Contains(info.Name.ToLower()))
                    lb.Items.Add(info.Name.ToLower());
            }

            lb.SelectedIndex = lb.Items.IndexOf(RConfig.Instance.TextEncoding);

            if (value != null)
            {
                int index = lb.Items.IndexOf(value);
                if (index > 0)
                    lb.SelectedIndex = index;
            }

            lb.SelectedIndexChanged += lb_SelectedIndexChanged;
            fes.DropDownControl(lb);

            if (lb.SelectedItem == null)
                return value;

            return lb.SelectedItem.ToString();
        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            fes.CloseDropDown();
        }
    }

    #endregion

    #region Directory Browser

    internal class LineageDirectoryFolderBrowserEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            MainForm.Instance.DirectoryDialog.SelectedPath = value.ToString();

            if (MainForm.Instance.DirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                RConfig.Instance.LineageDirectory = MainForm.Instance.DirectoryDialog.SelectedPath;
                return MainForm.Instance.DirectoryDialog.SelectedPath;
            }

            return value;
        }
    }

    #endregion

    #region File Browser

    internal class LineageFileBrowserEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            MainForm.Instance.FileDialog.InitialDirectory = value.ToString();

            if (MainForm.Instance.FileDialog.ShowDialog() == DialogResult.OK)
            {
                RConfig.Instance.LineageFileToRun = MainForm.Instance.FileDialog.FileName;
                MainForm.Instance.FileDialog.Dispose();
                return RConfig.Instance.LineageFileToRun;
            }

            return value;
        }
    }

    #endregion

    #region Color Editor

    public class ColorValueEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            //MainForm.Instance.ColorDialog.Color = (Color)value;
            Color co = ConvertUtilities.HtmlColorToColor(value.ToString());
            MainForm.Instance.ColorDialog.Color = co;

            if (MainForm.Instance.ColorDialog.ShowDialog() == DialogResult.OK)
            {
                return ConvertUtilities.ColorToHtmlColor(MainForm.Instance.ColorDialog.Color);
            }

            return value;
        }
    }

    #endregion

    #region Text Editor

    public class TextValueEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            String co = value.ToString();
            var fo = new EditTextForm();
            fo.setText(co);

            if (fo.ShowWindow())
            {
                return fo.getText();
            }

            return value;
        }
    }

    #endregion

    #region Localization Editor

    public class LocalizationEditor : UITypeEditor
    {
        private IWindowsFormsEditorService fes;

        public override bool IsDropDownResizable
        {
            get { return false; }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            fes = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
            if (fes == null)
                return value;

            var lb = new ListBox();
            lb.Sorted = true;
            lb.SelectionMode = SelectionMode.One;
            lb.HorizontalScrollbar = true;

            if (Directory.Exists(Localizate.DIR + "\\localization"))
            {
                var current = new DirectoryInfo(Localizate.DIR + "\\localization\\");

                foreach (FileInfo info in current.GetFiles("*.xml"))
                {
                    lb.Items.Add(info.Name);
                }
            }
            else
            {
                throw new Exception("Can't find localization dir.");
            }

            int index = lb.Items.IndexOf(RConfig.Instance.Localization);

            lb.SelectedIndex = index == -1 ? 0 : index;

            if (value != null)
            {
                index = lb.Items.IndexOf(value);
                if (index > 0)
                    lb.SelectedIndex = index;
            }

            lb.SelectedIndexChanged += lb_SelectedIndexChanged;
            fes.DropDownControl(lb);

            if (lb.SelectedItem == null)
                return value;

            return lb.SelectedItem.ToString();
        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            fes.CloseDropDown();
        }
    }

    #endregion
}