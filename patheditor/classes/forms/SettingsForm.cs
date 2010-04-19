#region Using directives

using System;
using System.Windows.Forms;
using com.jds.PathEditor.classes.services;

#endregion

namespace com.jds.PathEditor.classes.forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            _settingsGid.SelectedObject = RConfig.Instance;
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            Text = Localizate.getMessage(Word.MENU_SERVICE_SETTINGS);
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            RConfig.Instance.save();

            Localizate.load();

            Close();
        }
    }
}