using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using engine.classes.forms;

namespace com.jds.patheditor.classes.forms
{
    public partial class EnterNameForm : Form
    {
        private bool _ok;

        public EnterNameForm()
        {
            InitializeComponent();
        }

        public bool Show(ProfileSelector f)
        {
            ShowDialog(f);
            return _ok;
        }

        public String ProfileName
        {
            get
            {
                return _profileName.Text;
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            _ok = true;
            Close();
        }
    }
}
