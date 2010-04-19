using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.jds.patheditor.classes.forms;
using MS.WindowsAPICodePack.Internal;
using Microsoft.WindowsAPICodePack.Shell;

namespace engine.classes.forms
{
    public partial class ProfileSelector : Form
    {
        private static ProfileSelector _instance;

        public static ProfileSelector Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProfileSelector();
                }

                return _instance;
            }
        }
       
        private ProfileSelector()
        {
            InitializeComponent();

            _profilesList.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(_profilesList_RetrieveVirtualItem);
        }

        void _profilesList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
           // e.Item = RConfig.Instance.Profiles.Values.ToList()[e.ItemIndex];
        }

        private void _addButton_Click(object sender, EventArgs e)
        {
            EnterNameForm form = new EnterNameForm();
            if (form.Show(this))
            {

            }
        }

        private void _profilesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
