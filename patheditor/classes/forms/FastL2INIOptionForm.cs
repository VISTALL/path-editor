using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using com.jds.PathEditor.classes.parser;
using com.jds.PathEditor.classes.services;
using log4net;

namespace com.jds.PathEditor.classes.forms
{
    public partial class FastL2INIOptionForm : Form
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof (FastL2INIOptionForm));

        public FastL2INIOptionForm()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            REfBtn_Click(sender, e);
            string dst_fname = Path.Combine(RConfig.Instance.LineageDirectory, "l2.ini");
            if (RConfig.Instance.SaveBakFiles)
            {
                try
                {
                    File.Move(dst_fname, Path.ChangeExtension(dst_fname, ".bak"));
                }
                catch
                {
                }
            }
            L2Edit.SaveFile(dst_fname, RichTextBoxStreamType.PlainText);

            L2EncDec.Encrypt("l2.ini", 413);
            Close();
        }

        private void REfBtn_Click(object sender, EventArgs e)
        {
            upHost();
            upPort();
            upNetLog();
            upTSecWindow();
            upTestServer();
        }

        #region load

        private void FastL2INIOptionForm_Load(object sender, EventArgs e)
        {
            Localizate.load();
            try
            {
                BinaryReader f = L2EncDec.Decrypt("l2.ini", Encoding.Default);
                if (f == null)
                    return;
                char[] IniText = f.ReadChars((int) f.BaseStream.Length);
                f.Close();
                L2Edit.Text = new String(IniText);


                for (int i = 0; i < L2Edit.Lines.Length; i++)
                {
                    if (L2Edit.Lines[i].StartsWith("ServerAddr="))
                    {
                        String s = L2Edit.Lines[i];
                        char p = '=';
                        String[] ss = s.Split(p);
                        HostText.Text = ss[1];
                    }
                    if (L2Edit.Lines[i].StartsWith("Port="))
                    {
                        String s = L2Edit.Lines[i];
                        char p = '=';
                        String[] ss = s.Split(p);
                        PortText.Text = ss[1];
                    }
                    if (L2Edit.Lines[i].StartsWith("IsL2NetLog="))
                    {
                        String s = L2Edit.Lines[i];
                        char p = '=';
                        String[] ss = s.Split(p);
                        NetLog.Checked = Boolean.Parse(ss[1]);
                    }
                    if (L2Edit.Lines[i].StartsWith("L2TestServer="))
                    {
                        String s = L2Edit.Lines[i];
                        char p = '=';
                        String[] ss = s.Split(p);
                        TestServer.Checked = Boolean.Parse(ss[1]);
                    }
                    if (L2Edit.Lines[i].StartsWith("EnableSecondWindow="))
                    {
                        String s = L2Edit.Lines[i];
                        char p = '=';
                        String[] ss = s.Split(p);
                        SeccondWind.Checked = Boolean.Parse(ss[1]);
                    }
                }

                // локализация
                Text = Localizate.getMessage(Word.MENU_SERVICE_FAST_SETTINGS) + " : " + "l2.ini";
                InetGrop.Text = Localizate.getMessage(Word.INTERNET_GROUP);
                OtherGroup.Text = Localizate.getMessage(Word.OTHER_GROUP);
                SeccondWind.Text = Localizate.getMessage(Word.SECOND_CLIENT);
                TestServer.Text = Localizate.getMessage(Word.TEST_SERVER);
                NetLog.Text = Localizate.getMessage(Word.NETWORK_LOG);
                Host.Text = Localizate.getMessage(Word.HOST);
                Port.Text = Localizate.getMessage(Word.PORT);
                REfBtn.Text = Localizate.getMessage(Word.REFRESH);
                SaveBtn.Text = Localizate.getMessage(Word.SAVE_BUTTON);
            }
            catch (Exception ex)
            {
                _log.Info("Exception: " + ex, ex);
            }
        }

        #endregion

        #region Refresh methods

        public void upHost()
        {
            String text = L2Edit.Text;
            char k = '\n';
            String[] st = text.Split(k);
            for (int j = 0; j < st.Length; j++)
            {
                if (st[j].StartsWith("ServerAddr"))
                {
                    st[j] = "ServerAddr=" + HostText.Text;
                }
            }

            String tx = "";
            for (int l = 0; l < st.Length; l++)
            {
                tx = tx + st[l] + "\n";
            }

            L2Edit.Clear();
            L2Edit.Text = tx;

            L2Edit.Refresh();
        }

        public void upPort()
        {
            String text = L2Edit.Text;
            char k = '\n';
            String[] st = text.Split(k);
            for (int j = 0; j < st.Length; j++)
            {
                if (st[j].StartsWith("Port"))
                {
                    st[j] = "Port=" + PortText.Text;
                }
            }

            String tx = "";
            for (int l = 0; l < st.Length; l++)
            {
                tx = tx + st[l] + "\n";
            }

            L2Edit.Clear();
            L2Edit.Text = tx;

            L2Edit.Refresh();
        }

        public void upNetLog()
        {
            String text = L2Edit.Text;
            char k = '\n';
            String[] st = text.Split(k);
            Boolean update = false;

            for (int j = 0; j < st.Length; j++)
            {
                if (st[j].StartsWith("IsL2NetLog"))
                {
                    st[j] = "IsL2NetLog=" + NetLog.Checked;
                    update = true;
                }
            }

            String tx = "";
            for (int l = 0; l < st.Length; l++)
            {
                tx = tx + st[l] + "\n";
            }

            if (!update)
            {
                tx = tx + "IsL2NetLog=" + NetLog.Checked;
            }

            L2Edit.Clear();
            L2Edit.Text = tx;

            L2Edit.Refresh();
        }

        public void upTestServer()
        {
            String text = L2Edit.Text;
            char k = '\n';
            String[] st = text.Split(k);

            for (int j = 0; j < st.Length; j++)
            {
                if (st[j].StartsWith("L2TestServer"))
                {
                    st[j] = "L2TestServer=" + TestServer.Checked;
                }
            }

            String tx = "";
            for (int l = 0; l < st.Length; l++)
            {
                tx = tx + st[l] + "\n";
            }

            L2Edit.Clear();
            L2Edit.Text = tx;

            L2Edit.Refresh();
        }

        public void upTSecWindow()
        {
            String text = L2Edit.Text;
            char k = '\n';
            String[] st = text.Split(k);

            for (int j = 0; j < st.Length; j++)
            {
                if (st[j].StartsWith("EnableSecondWindow"))
                {
                    st[j] = "EnableSecondWindow=" + SeccondWind.Checked;
                }
            }

            String tx = "";
            for (int l = 0; l < st.Length; l++)
            {
                tx = tx + st[l] + "\n";
            }

            L2Edit.Clear();
            L2Edit.Text = tx;

            L2Edit.Refresh();
        }

        #endregion
    }
}