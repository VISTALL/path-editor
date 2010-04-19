using System;
using System.Windows.Forms;
using com.jds.PathEditor.classes.lm;

namespace com.jds.PathEditor.classes.forms
{
    public partial class EditTextForm : Form
    {
        private bool _valid;

        public EditTextForm()
        {
            InitializeComponent();
        }

        public void setText(String t)
        {
            richTextBox1.Text = ConvertUtilities.replaceIn(t);
        }

        public String getText()
        {
            return ConvertUtilities.replaceOut(richTextBox1.Text);
        }

        public bool ShowWindow()
        {
            ShowDialog();

            return _valid;
        }

        private void _saveBtn_Click(object sender, EventArgs e)
        {
            _valid = true;

            Close();
        }
    }
}