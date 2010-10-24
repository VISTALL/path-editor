#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using com.jds.PathEditor.classes.client;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.parser;
using com.jds.PathEditor.classes.services;
using com.jds.PathEditor.classes.windows;
using log4net;
using com.jds.PathEditor.classes.windows.windows7;


#endregion

namespace com.jds.PathEditor.classes.forms
{
    public partial class MainForm : Form
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof (MainForm));
        private static MainForm _instance;

        internal List<Definition> DatDatas;
        public DatParser DatInfo;

        internal string selectedComboName = "";
        internal DatFiles SelectedFiles;
        private string selectedIniComboName = "";
        private object selectedIniIntFile;

        public static MainForm Instance
        {
            get { return _instance ?? (_instance = new MainForm()); }
        }

        #region Config

        public void Config_Load()
        {
            DirectoryDialog.Description = Localizate.getMessage(Word.PLEASE_SELECT_SYSTEM_FOLDER);

            // Check DatFile Directory
            if (!Directory.Exists(RConfig.Instance.LineageDirectory))
            {
                new MessageBox(Localizate.getMessage(Word.SYSTEM_FOLDER_IS_EMPTY), true);

                DirectoryDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (DirectoryDialog.ShowDialog() == DialogResult.OK)
                {
                    RConfig.Instance.LineageDirectory = DirectoryDialog.SelectedPath;
                    RConfig.Instance.save();
                }
            }
        }

        #endregion

        #region Control Events

        private MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            SuspendLayout();

            try
            {
                Config_Load();
                Forms_Init(true, true);
                Forms_Update();
            }
            catch (Exception ex)
            {
                _log.Info("Exception: " + ex, ex);
            }
            finally
            {
                Visible = true;
                ResumeLayout();
                Show();
                BringToFront();
                Activate();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enabled = false;
            RConfig.Instance.save();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (RConfig.Instance.UseTray)
            {
                if (FormWindowState.Minimized == WindowState)
                {
                    Hide();
                    HideIcon.Visible = true;
                }
            }
        }

        private void HideIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            HideIcon.Visible = false;
        }

        private void FileNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FileNameCombo.SelectedIndex == -1)
                return;

            selectedComboName = FileNameCombo.Items[FileNameCombo.SelectedIndex].ToString();
            String[] TmpStr = Enum.GetNames(typeof (DatFiles));

            for (int i = 0; i < TmpStr.Length; i++)
            {
                if (selectedComboName.StartsWith(TmpStr[i].ToLower()))
                {
                    SelectedFiles = (DatFiles) i;
                    break;
                }
            }

            /*	if (selectedComboName.StartsWith("eula"))
			{
				SaveBtn2.Enabled = false;
				importBtn2.Enabled = false;
				exportBtn2.Enabled = false;
				LoadBtn2.Enabled = true;
				editorBtn.Enabled = false;
				return;
			}*/

            Forms_Init(false, false);
            LoadBtn2.Enabled = true;
            importBtn2.Enabled = true;
            //ExpToWindow.Enabled = true;
            OpenL2iniText.Enabled = false;
            Forms_Update();
        }

        private void Forms_Init(bool isReload, bool start)
        {
            if (isReload)
            {
                // Чистил списки
                //*.dat
                FileNameCombo.Items.Clear();
                FileIniComboName.Items.Clear();
                
                if (Directory.Exists(RConfig.Instance.LineageDirectory))
                {
                    DirectoryInfo current = new DirectoryInfo(RConfig.Instance.LineageDirectory);
                    
                    // Грузим *.dat
                    foreach (FileInfo info in current.GetFiles("*.dat"))
                    {
                        foreach (String name in Enum.GetNames(typeof (DatFiles)))
                        {
                            String FileName = Path.GetFileNameWithoutExtension(info.FullName);
                            if (FileName.ToLower().StartsWith(name.ToLower()))
                            {
                                FileNameCombo.Items.Add(info.Name.ToLower());
                                break;
                            }
                        }
                    }

                   
                    // Грузим *.ini
                    foreach (FileInfo info in current.GetFiles("*.ini"))
                    {
                        foreach (String name in Enum.GetNames(typeof(IniFiles)))
                        {
                            String FileName = Path.GetFileNameWithoutExtension(info.FullName);
                            if (FileName.ToLower().StartsWith(name.ToLower()))
                            {
                                FileIniComboName.Items.Add(info.Name.ToLower());
                                break;
                            }
                        }
                    }

                    // Грузим *.int
                    foreach (FileInfo info in current.GetFiles("*.int"))
                    {
                        foreach (String name in Enum.GetNames(typeof(IntFiles)))
                        {
                            String FileName = Path.GetFileNameWithoutExtension(info.FullName);
                            if (FileName.ToLower().StartsWith(name.ToLower()))
                            {
                                FileIniComboName.Items.Add(info.Name.ToLower());
                                break;
                            }
                        }
                    }
                }
            }

            // отключаем кнопки
            importBtn2.Enabled = false;
            exportBtn2.Enabled = false;
            LoadBtn2.Enabled = false;
            SaveBtn2.Enabled = false;

            OpenL2iniText.Enabled = false;
            savel2ini.Enabled = false;
            clearl2ini.Enabled = false;
            editorBtn.Enabled = false;

            // заполняем информацию
            ChLabel.Text = RConfig.Instance.DatVersionAsEnum.ToString().Replace("__", "/").Replace("_", " ");

            StatusProgress.Minimum = 0;
            StatusProgress.Maximum = 100;
            StatusProgress.Value = 0;
            StatusProgress.Visible = false;
            StatusLabel.Text = "";

            // Set Datas
            DatInfo_init();
        }

        private void Forms_Update()
        {
            // Localizate.load();
            path.Text = RConfig.Instance.LineageDirectory;


            if (!Directory.Exists(RConfig.Instance.LineageDirectory))
            {
                startBtn2.Enabled = false;
                OpenL2iniText.Enabled = false;
                savel2ini.Enabled = false;
                clearl2ini.Enabled = false;
            }
            else
            {
                startBtn2.Enabled = true;
            }

            // Локализация
            //  LoadBtn.Text = Message.getMessage("LOAD_BUTTON");
            //SaveBtn.Text = Message.getMessage("SAVE_BUTTON"); 

            //new
            LoadBtn2.HeaderText = Localizate.getMessage(Word.LOAD_BUTTON);
            SaveBtn2.HeaderText = Localizate.getMessage(Word.SAVE_BUTTON);
            importBtn2.HeaderText = Localizate.getMessage(Word.IMPORT_BUTTON);
            exportBtn2.HeaderText = Localizate.getMessage(Word.EXPORT_BUTTON);
            startBtn2.HeaderText = Localizate.getMessage(Word.START_BUTTON);
            editorBtn.HeaderText = Localizate.getMessage(Word.EDITOR);

            //SaveBtn2.HeaderText = Message.getMessage("IMPORT_BUTTON");
            //ExpBtn.Text = Message.getMessage("EXPORT_BUTTON");
            startBtn2.HeaderText = Localizate.getMessage(Word.START_BUTTON);

            savel2ini.Text = Localizate.getMessage(Word.SAVE_BUTTON);
            OpenL2iniText.Text = Localizate.getMessage(Word.OPEN_BUTTON);
            clearl2ini.Text = Localizate.getMessage(Word.CLEAR_BUTTON);
            DatTab.Text = Localizate.getMessage(Word.DAT_TAB);
            IniTab.Text = Localizate.getMessage(Word.INI_TAB);
            MenuFile.Text = Localizate.getMessage(Word.MENU_FILE);
            MenuService.Text = Localizate.getMessage(Word.MENU_SERVICE);
            exit.Text = Localizate.getMessage(Word.MENU_FILE_QUIT);
            pathSystem.Text = Localizate.getMessage(Word.MENU_SERVICE_PATH_SYSTEM);
            OpenFolder.Text = Localizate.getMessage(Word.MENU_FILE_OPEN_FOLDER);
            Settings.Text = Localizate.getMessage(Word.MENU_SERVICE_SETTINGS);
            fastST.Text = Localizate.getMessage(Word.MENU_SERVICE_FAST_SETTINGS);
            ChronicleInfo.Text = Localizate.getMessage(Word.CHRONICLE);
            ShowForm.Text = Localizate.getMessage(Word.HIDE_MENU_SHOW);
            AbuotForm.Text = String.Format(Localizate.getMessage(Word.HIDE_MENU_ABOUT), "Path Editor");
            ExitForm.Text = Localizate.getMessage(Word.MENU_FILE_QUIT);
            CutR.Text = Localizate.getMessage(Word.RIGHT_CLICK_CUT);
            CopyR.Text = Localizate.getMessage(Word.RIGHT_CLICK_COPY);
            PasteR.Text = Localizate.getMessage(Word.RIGHT_CLICK_PUT);
            SelectAll.Text = Localizate.getMessage(Word.RIGHT_CLICK_SELECT_ALL);
            EncText.Text = Localizate.getMessage(Word.TEXT_ENCODING);
            NumLines.Text = Localizate.getMessage(Word.NUMBER_OF_LINES);
            //eulaPage.Text = Localizate.getMessage(Word.LICENSE);
            lockBtn.Text = Localizate.getMessage(Word.LOCK);
        }

        private void DatInfo_init()
        {
            try
            {
                Type t = Type.GetType("com.jds.PathEditor.classes.client.definitions." + SelectedFiles);

                object instance = t.InvokeMember(null, BindingFlags.CreateInstance, null,
                                                 null,
                                                 new object[] {});
                if (instance != null)
                    DatInfo = (DatParser) instance;
                else
                    DatInfo = new DatParser();
                DatDatas = new List<Definition>();
            }
            catch (Exception e)
            {
               _log.Info(e.StackTrace, e);
            }
        }

        #endregion

        #region LoadBtn Action

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StatusLabel.Text = Localizate.getMessage(Word.PLEASE_WAIT);
                FileNameCombo.Enabled = false;
                Enabled = false;

                DatInfo_init();
                if (DatInfo == null)
                {
                    return;
                }

                if (!File.Exists(Path.Combine(RConfig.Instance.LineageDirectory, selectedComboName)))
                {
                    StatusLabel.Text = Localizate.getMessage(Word.ERROR) + " " +
                                       Localizate.getMessage(Word.FILE_NOT_FOUND);
                    return;
                }

                BinaryReader f = L2EncDec.Decrypt(selectedComboName, Encoding.Default);
                if (f == null)
                    return;

                DatDatas = DatInfo.Parse(f);

                f.Close();

                importBtn2.Enabled = true;
                exportBtn2.Enabled = true;
                SaveBtn2.Enabled = true;
                editorBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                _log.Info("Exception" + ex, ex);
            }
            finally
            {
                Enabled = true;
                FileNameCombo.Enabled = true;

                onEnd();

                Forms_Update();
            }
            StatusLabel.Text = Localizate.getMessage(Word.COMPLETE) +
                               String.Format(Localizate.getMessage(Word.LOADED_DATA), DatDatas.Count);
        }

        #endregion

        #region SaveBtn Action

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StatusLabel.Text = Localizate.getMessage(Word.PLEASE_WAIT);
                FileNameCombo.Enabled = false;
                Enabled = false;

                if (DatDatas.Count == 0)
                {
                    StatusLabel.Text = Localizate.getMessage(Word.ERROR) +
                                       Localizate.getMessage(Word.SYSTEM_FOLDER_IS_EMPTY);
                    return;
                }
                string fname = Path.Combine(RConfig.Instance.LineageDirectory, selectedComboName);
                if (RConfig.Instance.SaveBakFiles)
                {
                    try
                    {
                        if (File.Exists(Path.ChangeExtension(fname, ".bak")))
                        {
                            File.Delete(Path.ChangeExtension(fname, ".bak"));
                        }

                        File.Move(fname, Path.ChangeExtension(fname, ".bak"));
                    }
                    catch (Exception)
                    {
                    }
                }
                var f = new BinaryWriter(File.OpenWrite(fname), Encoding.Default);
                if (f == null)
                    return;

                DatInfo.Compile(f, DatDatas);
                f.Close();

                L2EncDec.Encrypt(selectedComboName, 413);
            }
            catch (Exception ex)
            {
                _log.Info("Exception: " + ex, ex);
            }
            finally
            {
                Enabled = true;
                FileNameCombo.Enabled = true;

                onEnd();
            }
            StatusLabel.Text = Localizate.getMessage(Word.COMPLETE) +
                               String.Format(Localizate.getMessage(Word.SAVED_DATA), DatDatas.Count);
        }

        #endregion

        #region ImpBtn Action

        private void ImpBtn_Click(object sender, EventArgs e)
        {
            String FName = "";
            String FValue = "";
            long RecNo = 1;
            try
            {
                StatusLabel.Text = Localizate.getMessage(Word.PLEASE_WAIT);
                FileNameCombo.Enabled = false;
                Enabled = false;

                ImportDialog.InitialDirectory = Application.StartupPath;
                ImportDialog.FileName = selectedComboName.Substring(0, selectedComboName.LastIndexOf("."));
                ImportDialog.Filter = "Tab-SeparatedValues files (*.tsv)|*.tsv";
                ImportDialog.FilterIndex = 1;
                ImportDialog.RestoreDirectory = true;

                if (ImportDialog.ShowDialog() == DialogResult.OK)
                {
                    DatInfo_init();
                    string line = "";
                    Encoding enc = Encoding.GetEncoding(RConfig.Instance.TextEncoding);
                    var sr = new StreamReader(ImportDialog.FileName, enc);

                    onStart((int) sr.BaseStream.Length);

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("#"))
                            continue;

                        String[] TmpStr = line.Split(new[] {'\t'});

                        for (int i = 0; i < TmpStr.Length; i++)
                        {
                            TmpStr[i] = TmpStr[i].Trim(new[] {'"'});
                        }

                        Definition item = DatInfo.getDefinition();

                        for (int i = 0, j = 0; i < DatInfo.getFieldNames().Count; i++, j++)
                        {
                            FName = DatInfo.getFieldNames()[i];
                            FValue = TmpStr[j];
                            FieldInfo FType = DatInfo.getDefinition().GetType().GetField(FName);

                            if (FType == null)
                            {
                                continue;
                            }

                            Type type = FType.FieldType;
                            Object obj = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

                            if (obj is IType)
                            {
                                var format = (IType) obj;

                                format.parse(TmpStr[j], TmpStr, j, out j);

                                FType.SetValue(item, format);
                            }
                            else
                            {
                                throw new NotImplementedException("Type " + obj.GetType().Name +
                                                                  " is not implement IType");
                            }
                        }

                        DatDatas.Add(item);
                        setValue((int) sr.BaseStream.Length);
                        RecNo++;
                    }
                    sr.Close();

                    SaveBtn2.Enabled = true;
                    exportBtn2.Enabled = true;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                _log.Info("Exception: " + ex, ex);
            }
            finally
            {
                Enabled = true;
                FileNameCombo.Enabled = true;

                onEnd();

                Forms_Update();
            }
            StatusLabel.Text = Localizate.getMessage(Word.COMPLETE) +
                               String.Format(Localizate.getMessage(Word.IMPORTED_DATA), DatDatas.Count);
        }

        #endregion

        #region ExpBtn Action

        private void ExpBtn_Click(object sender, EventArgs e)
        {
            String FName = "";
            long RecNo = 1;

            try
            {
                StatusLabel.Text = Localizate.getMessage(Word.PLEASE_WAIT);
                FileNameCombo.Enabled = false;
                Enabled = false;

                if (DatDatas.Count == 0)
                {
                    StatusLabel.Text = Localizate.getMessage(Word.ERROR) +
                                       Localizate.getMessage(Word.SYSTEM_FOLDER_IS_EMPTY);
                    return;
                }

                ExportDialog.InitialDirectory = Application.StartupPath;
                ExportDialog.FileName = selectedComboName.Substring(0, selectedComboName.LastIndexOf("."));

                ExportDialog.Filter = "Tab-SeparatedValues files (*.tsv)|*.tsv";
                ExportDialog.FilterIndex = 1;

                ExportDialog.RestoreDirectory = true;

                if (ExportDialog.ShowDialog() == DialogResult.OK)
                {
                    Encoding enc = Encoding.GetEncoding(RConfig.Instance.TextEncoding);
                    var sr = new StreamWriter(ExportDialog.FileName, false, enc);

                    // Write Headers
                    sr.Write("# ");
                    for (int i = 0; i < DatInfo.getFieldNames().Count; i++)
                    {
                        Definition info = DatDatas[0];
                        FName = DatInfo.getFieldNames()[i];
                        FieldInfo FType = DatInfo.getDefinition().GetType().GetField(FName);

                        if (FType == null)
                            continue;

                        Object obj = FType.GetValue(info);
                        if (obj == null)
                            continue;

                        if (obj is IType)
                        {
                            var type = (IType) obj;

                            type.writeHeader(FName, sr);
                        }
                        else
                        {
                            throw new NotImplementedException("Type " + obj.GetType().Name + " is not implement IType");
                        }
                    }
                    sr.Write("\r\n");

                    onStart(DatDatas.Count);

                    // Write Datas
                    for (int i = 0; i < DatDatas.Count; i++)
                    {
                        Definition info = DatDatas[i];
                        for (int j = 0; j < DatInfo.getFieldNames().Count; j++)
                        {
                            FName = DatInfo.getFieldNames()[j];
                            FieldInfo FType = DatInfo.getDefinition().GetType().GetField(FName);
                            if (FType == null) continue;
                            String TmpStr = "";

                            if (FType.GetValue(info) != null)
                            {
                                Object obj = FType.GetValue(info);

                                if (obj is IType)
                                {
                                    var type = (IType) obj;
                                    TmpStr = type.ToString();
                                }
                                else
                                {
                                    throw new NotImplementedException("Type " + obj.GetType().Name +
                                                                      " is not implement IType");
                                }

                                sr.Write(TmpStr);

                                if (j < DatInfo.getFieldNames().Count - 1)
                                    sr.Write('\t');
                            }
                        }

                        sr.Write("\r\n");

                        setValue(i);

                        RecNo++;
                    }
                    sr.Close();
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                _log.Info("Exception: " + ex, ex);
            }
            finally
            {
                Enabled = true;
                FileNameCombo.Enabled = true;

                onEnd();
            }

            StatusLabel.Text = Localizate.getMessage(Word.COMPLETE) +
                               String.Format(Localizate.getMessage(Word.EXPORTED_DATA), DatDatas.Count);
        }

        #endregion

        #region Status Progress Windows 7

        public void onStart(int max)
        {
            StatusProgress.Minimum = 0;
            StatusProgress.Maximum = max;
            StatusProgress.Visible = true;

            Windows7Taskbar.SetProgressState(Handle, ThumbnailProgressState.Normal);
        }

        public void onEnd()
        {
            StatusProgress.Minimum = 0;
            StatusProgress.Maximum = 100;
            StatusProgress.Value = 0;
            StatusProgress.Visible = false;

            Windows7Taskbar.SetProgressState(Handle, ThumbnailProgressState.NoProgress);
        }

        public void setValue(int v)
        {
            StatusProgress.Value = v;

            Windows7Taskbar.SetProgressValue(Handle, v, StatusProgress.Maximum);
        }

        #endregion

        #region Open Ini File

        private void OpenIniButton_Click(object sender, EventArgs e)
        {
            if (selectedIniComboName == null || selectedIniIntFile == null)
                return;

            Lineage2Ver ver = (Lineage2Ver)selectedIniIntFile.GetType().GetField(selectedIniIntFile.ToString()).GetCustomAttributes(typeof(Lineage2Ver), true)[0];

            // пожалуста подождите
            StatusLabel.Text = Localizate.getMessage(Word.PLEASE_WAIT);

            if (!File.Exists(Path.Combine(RConfig.Instance.LineageDirectory, selectedIniComboName)))
            {
                StatusLabel.Text = Localizate.getMessage(Word.ERROR) + " " + Localizate.getMessage(Word.FILE_NOT_FOUND);
                return;
            }

            try
            {
                BinaryReader f = L2EncDec.Decrypt(selectedIniComboName, Encoding.Default);
                if (f == null)
                    return;
                char[] IniText = f.ReadChars((int) f.BaseStream.Length);
                f.Close();
                IniTextBox.Text = new String(IniText);
            }
            catch (Exception ex)
            {
                _log.Info("Exception: " + ex, ex);
            }
            finally
            {
                Enabled = true;
                FileNameCombo.Enabled = true;
                savel2ini.Enabled = true;
                clearl2ini.Enabled = true;
                IniTextBox.Enabled = true;
                EnCod.Text = ver.Ver.ToString();
                Char c = '\n';
                String[] st = IniTextBox.Text.Split(c);
                Counts.Text = st.Length.ToString();
                IniTextBox.Update();
            }
            StatusLabel.Text = "";
        }

        private void clearl2ini_Click(object sender, EventArgs e)
        {
            IniTextBox.Clear();
            savel2ini.Enabled = false;
            IniTextBox.Enabled = false;
            clearl2ini.Enabled = false;
            OpenL2iniText.Enabled = false;
            Counts.Text = "0";
            EnCod.Text = "0";
            selectedIniComboName = null;
            try
            {
                FileIniComboName.SelectedIndex = -1;
            }
            catch
            {
            }
        }

        private void savel2ini_Click(object sender, EventArgs e)
        {
            if (selectedIniComboName == null || selectedIniIntFile == null)
                return;

            Lineage2Ver ver = (Lineage2Ver)selectedIniIntFile.GetType().GetField(selectedIniIntFile.ToString()).GetCustomAttributes(typeof(Lineage2Ver), true)[0];

            string dst_fname = Path.Combine(RConfig.Instance.LineageDirectory, selectedIniComboName);

            if (RConfig.Instance.SaveBakFiles)
            {
                try
                {
                    if (File.Exists(Path.ChangeExtension(dst_fname, ".bak")))
                        File.Delete(Path.ChangeExtension(dst_fname, ".bak"));

                    File.Move(dst_fname, Path.ChangeExtension(dst_fname, ".bak"));
                }
                catch
                {
                }
            }

            IniTextBox.SaveFile(dst_fname, RichTextBoxStreamType.PlainText);

            L2EncDec.Encrypt(selectedIniComboName, ver.Ver);

            clearl2ini_Click(sender, e);
        }

        #endregion

        #region About

        private void MenuAbout_Click_1(object sender, EventArgs e)
        {
            var form = new AboutForm(false);
            form.ShowDialog();
        }

        #endregion

        #region Start l2

        // кнопка для запуска л2.
        private void StartL2_Click(object sender, EventArgs e)
        {
            if (RConfig.Instance.MiniOnStart)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
                HideIcon.Visible = true;
            }

            if (!File.Exists(RConfig.Instance.LineageFileToRun))
            {
                var msg = new MSG(Localizate.getMessage(Word.ERROR), Localizate.getMessage(Word.FILE_NOT_FOUND));
                msg.ShowDialog();
                return;
            }

            Process.Start(RConfig.Instance.LineageFileToRun);
        }

        #endregion

        #region Choose File

        private void FileIniComboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FileIniComboName.SelectedIndex == -1)
                return;

            selectedIniComboName = FileIniComboName.Items[FileIniComboName.SelectedIndex].ToString();
            if(selectedIniComboName.EndsWith(".ini"))
            {
                String[] TmpStr = Enum.GetNames(typeof (IniFiles));

                for (int i = 0; i < TmpStr.Length; i++)
                {
                    if (selectedIniComboName.StartsWith(TmpStr[i].ToLower()))
                    {
                        selectedIniIntFile = (IniFiles) i;
                        break;
                    }
                }
            }
            else if (selectedIniComboName.EndsWith(".int"))
            {
                String[] TmpStr = Enum.GetNames(typeof(IntFiles));

                for (int i = 0; i < TmpStr.Length; i++)
                {
                    if (selectedIniComboName.StartsWith(TmpStr[i].ToLower()))
                    {
                        selectedIniIntFile = (IntFiles)i;
                        break;
                    }
                }
            }

            if(selectedIniIntFile == null)
            {
                return;
            }

            Forms_Init(false, false);
            Forms_Update();

            OpenL2iniText.Enabled = true;
        }

        #endregion

        #region File

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            DirectoryDialog.SelectedPath = RConfig.Instance.LineageDirectory;

            if (DirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                RConfig.Instance.LineageDirectory = DirectoryDialog.SelectedPath;
                RConfig.Instance.save();
                Forms_Init(true, false);
                Forms_Update();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Service

        private void Settings_Click(object sender, EventArgs e)
        {
            var dlg = new SettingsForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Forms_Init(true, false);
                Forms_Update();
            }
        }

        private void l2ini_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = Localizate.getMessage(Word.PLEASE_WAIT);
            var form = new FastL2INIOptionForm();

            form.ShowDialog();
        }

        private void pathSystem_Click_1(object sender, EventArgs e)
        {
            try
            {
                StatusLabel.Text = Localizate.getMessage(Word.PLEASE_WAIT);
                FileNameCombo.Enabled = false;
                Enabled = false;

                L2EncDec.SystemPatcher();
            }
            catch (Exception ex)
            {
                _log.Info("Exception: " + ex, ex);
            }
            finally
            {
                Enabled = true;
                FileNameCombo.Enabled = true;
                StatusProgress.Visible = false;
            }
            StatusLabel.Text = Localizate.getMessage(Word.COMPLETE) +
                               Localizate.getMessage(Word.COMPLETE_PATH_SYSTEM_FOLDER);
        }

        #endregion

        #region Else

        public void showMSG()
        {
            Show();
            WindowState = FormWindowState.Normal;
            HideIcon.Visible = false;
        }

        private void ChLabel_Click(object sender, EventArgs e)
        {
            var arg = (MouseEventArgs) e;
            if (arg.Button == MouseButtons.Left)
            {
                var dlg = new SettingsForm();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Forms_Init(true, false);
                    Forms_Update();
                }
            }
        }

        #endregion

        #region Hide Menu

        private void ShowForm_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            HideIcon.Visible = false;
        }


        private void ExitForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AbuotForm_Click(object sender, EventArgs e)
        {
            var dlg = new AboutForm(false);
            dlg.ShowDialog();
        }

        #endregion

        #region Ini Text Box

        private void CutR_Click(object sender, EventArgs e)
        {
            IniTextBox.Cut();
        }

        private void CopyR_Click(object sender, EventArgs e)
        {
            IniTextBox.Copy();
        }

        private void PasteR_Click(object sender, EventArgs e)
        {
            IniTextBox.Paste();
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            IniTextBox.SelectAll();
        }

        #endregion

        #region Editor Tab

        private void expToWindow_Click(object sender, EventArgs e)
        {
            var form = new EditForm(selectedComboName, DatInfo);
            StatusLabel.Text = "";

            onStart(DatDatas.Count - 1);

            for (int i = 0; i < DatDatas.Count; i++)
            {
                Definition info = DatDatas[i];

                form.write(info);

                setValue(i);
            }

            onEnd();

            form.refresh();
            form.ShowDialog();
        }

        #endregion

        #region Lock

        private void lockBtn_CheckedChanged(object sender, EventArgs e)
        {
            FileNameCombo.Enabled = !lockBtn.Checked;
        }

        #endregion
    }
}