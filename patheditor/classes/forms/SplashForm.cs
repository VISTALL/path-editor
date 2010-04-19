using System;
using System.Drawing;
using System.Windows.Forms;

namespace com.jds.PathEditor.classes.forms
{
    public partial class SplashForm : Form
    {
        private static SplashForm _instance;

        private SplashForm()
        {
            InitializeComponent();

            Image img = Resources.Fire;

            Width = img.Width;
            Height = img.Height;
            BackgroundImage = img;

            Update();
        }

        public static SplashForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SplashForm();
                return _instance;
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
        }
    }
}