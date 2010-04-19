using System;
using System.Windows.Forms;
using com.jds.PathEditor.classes.services;

namespace com.jds.PathEditor.classes.forms
{
    public partial class MSG : Form
    {
        public MSG(String title, String msg)
        {
            InitializeComponent();
            Name = title;
            TextError.Text = msg;
            Text = title;
            CloseBtn.Text = Localizate.getMessage(Word.MENU_FILE_QUIT);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            MainForm.Instance.showMSG();
        }
    }
}