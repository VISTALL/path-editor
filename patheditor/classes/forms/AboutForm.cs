using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using com.jds.PathEditor.classes.services;

namespace com.jds.PathEditor.classes.forms
{
    public partial class AboutForm : Form
    {
        private readonly bool _splash;

        public AboutForm(bool splash)
        {
            _splash = splash;
            //pictureBox2.Image = Resources.logo;
            InitializeComponent();
            pictureBox2.Image = Resources.Fire;
            // Титул
            Text = String.Format(Localizate.getMessage(Word.HIDE_MENU_ABOUT), "Path Editor");
            // Имя продукта
            labelProductName.Text = AssemblyProduct;
            // Версия продукта
            labelVersion.Text = AssemblyVersion;
            // компания
            labelCompanyName.Text = AssemblyCompany;
            // информация
            // this.textBoxDescription.BackColor = Color.Black;
            textBoxDescription.Text = Localizate.getMessage(Word.DESCRIPTION);

            //локализация
            Pname.Text = Localizate.getMessage(Word.PRODUCT_NAME);
            Version.Text = Localizate.getMessage(Word.VERSION);
            Company.Text = Localizate.getMessage(Word.COMPANY);
            Author.Text = Localizate.getMessage(Word.AUTHOR);
            Info.Text = Localizate.getMessage(Word.INFO);
        }

        #region Assembly Attibute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute) attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }

        #endregion

        private void mouseUp(object sender, MouseEventArgs e)
        {
            if (!_splash)
                Close();
        }
    }
}