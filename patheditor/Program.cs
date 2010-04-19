using System;
using System.Windows.Forms;
using com.jds.PathEditor.classes.forms;
using com.jds.PathEditor.classes.services;
using log4net;
using MessageBox = com.jds.PathEditor.classes.forms.MessageBox;

namespace com.jds.PathEditor
{
    internal static class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof (Program));

        [STAThread]
        private static void Main()
        {
            LogService.init();
            RConfig.Instance.load();
            Localizate.load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashForm.Instance.Show();

            //Thread.Sleep(2000);

            _log.Info("Program started");

            MessageBox.parentForm = MainForm.Instance;

            SplashForm.Instance.Close();
            try
            {
                Application.Run(MainForm.Instance);
                _log.Info("Quit program");
            }
            catch (Exception e)
            {
                _log.Info("Exception: Program.Main(): " + e, e);
            }
        }
    }
}