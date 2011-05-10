using com.jds.PathEditor.classes.gui;

namespace com.jds.PathEditor.classes.forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

       protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ExportDialog = new System.Windows.Forms.SaveFileDialog();
            this.ImportDialog = new System.Windows.Forms.OpenFileDialog();
            this.HideIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.HideMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AbuotForm = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitForm = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.lastFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuService = new System.Windows.Forms.ToolStripMenuItem();
            this.fastST = new System.Windows.Forms.ToolStripMenuItem();
            this.l2ini = new System.Windows.Forms.ToolStripMenuItem();
            this.pathSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusProgress = new System.Windows.Forms.ProgressBar();
            this.RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CutR = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyR = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.path = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ChLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ChronicleInfo = new System.Windows.Forms.Label();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.IniTab = new System.Windows.Forms.TabPage();
            this.NumLines = new System.Windows.Forms.Label();
            this.Counts = new System.Windows.Forms.Label();
            this.EncText = new System.Windows.Forms.Label();
            this.EnCod = new System.Windows.Forms.Label();
            this.FileIniComboName = new System.Windows.Forms.ComboBox();
            this.clearl2ini = new System.Windows.Forms.Button();
            this.savel2ini = new System.Windows.Forms.Button();
            this.IniTextBox = new System.Windows.Forms.RichTextBox();
            this.OpenL2iniText = new System.Windows.Forms.Button();
            this.DatTab = new System.Windows.Forms.TabPage();
            this._mergeButton = new com.jds.PathEditor.classes.gui.JButton();
            this.lockBtn = new System.Windows.Forms.CheckBox();
            this.editorBtn = new com.jds.PathEditor.classes.gui.JButton();
            this.startBtn2 = new com.jds.PathEditor.classes.gui.JButton();
            this.exportBtn2 = new com.jds.PathEditor.classes.gui.JButton();
            this.importBtn2 = new com.jds.PathEditor.classes.gui.JButton();
            this.SaveBtn2 = new com.jds.PathEditor.classes.gui.JButton();
            this.LoadBtn2 = new com.jds.PathEditor.classes.gui.JButton();
            this.FileNameCombo = new System.Windows.Forms.ListBox();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.HideMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.RightClick.SuspendLayout();
            this.IniTab.SuspendLayout();
            this.DatTab.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectoryDialog
            // 
            this.DirectoryDialog.Description = "Choose directory where LineageII System.";
            this.DirectoryDialog.ShowNewFolderButton = false;
            // 
            // HideIcon
            // 
            this.HideIcon.ContextMenuStrip = this.HideMenu;
            this.HideIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("HideIcon.Icon")));
            this.HideIcon.Tag = "Path Editor";
            this.HideIcon.Text = "Path Editor";
            this.HideIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HideIcon_MouseDoubleClick);
            // 
            // HideMenu
            // 
            this.HideMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowForm,
            this.toolStripSeparator4,
            this.AbuotForm,
            this.ExitForm});
            this.HideMenu.Name = "HideMenu";
            this.HideMenu.Size = new System.Drawing.Size(108, 76);
            this.HideMenu.Text = "HideMenu";
            // 
            // ShowForm
            // 
            this.ShowForm.Name = "ShowForm";
            this.ShowForm.Size = new System.Drawing.Size(107, 22);
            this.ShowForm.Text = "Show";
            this.ShowForm.Click += new System.EventHandler(this.ShowForm_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(104, 6);
            // 
            // AbuotForm
            // 
            this.AbuotForm.Name = "AbuotForm";
            this.AbuotForm.Size = new System.Drawing.Size(107, 22);
            this.AbuotForm.Text = "About";
            this.AbuotForm.Click += new System.EventHandler(this.AbuotForm_Click);
            // 
            // ExitForm
            // 
            this.ExitForm.Name = "ExitForm";
            this.ExitForm.Size = new System.Drawing.Size(107, 22);
            this.ExitForm.Text = "Exit";
            this.ExitForm.Click += new System.EventHandler(this.ExitForm_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuService,
            this.MenuAbout});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(521, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFolder,
            this.lastFoldersToolStripMenuItem,
            this.toolStripSeparator1,
            this.exit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(37, 20);
            this.MenuFile.Text = "File";
            // 
            // OpenFolder
            // 
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(136, 22);
            this.OpenFolder.Text = "OpenFolder";
            this.OpenFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // lastFoldersToolStripMenuItem
            // 
            this.lastFoldersToolStripMenuItem.Name = "lastFoldersToolStripMenuItem";
            this.lastFoldersToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.lastFoldersToolStripMenuItem.Text = "Last Folders";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(136, 22);
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // MenuService
            // 
            this.MenuService.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastST,
            this.pathSystem,
            this.toolStripSeparator3,
            this.Settings});
            this.MenuService.Name = "MenuService";
            this.MenuService.Size = new System.Drawing.Size(56, 20);
            this.MenuService.Text = "Service";
            // 
            // fastST
            // 
            this.fastST.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.l2ini});
            this.fastST.Name = "fastST";
            this.fastST.Size = new System.Drawing.Size(140, 22);
            this.fastST.Text = "Fast Settings";
            // 
            // l2ini
            // 
            this.l2ini.Name = "l2ini";
            this.l2ini.Size = new System.Drawing.Size(99, 22);
            this.l2ini.Text = "l2.ini";
            this.l2ini.Click += new System.EventHandler(this.l2ini_Click);
            // 
            // pathSystem
            // 
            this.pathSystem.Name = "pathSystem";
            this.pathSystem.Size = new System.Drawing.Size(140, 22);
            this.pathSystem.Text = "Path system";
            this.pathSystem.Click += new System.EventHandler(this.pathSystem_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(137, 6);
            // 
            // Settings
            // 
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(140, 22);
            this.Settings.Text = "Settings";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // MenuAbout
            // 
            this.MenuAbout.Name = "MenuAbout";
            this.MenuAbout.Size = new System.Drawing.Size(24, 20);
            this.MenuAbout.Text = "?";
            this.MenuAbout.Click += new System.EventHandler(this.MenuAbout_Click_1);
            // 
            // StatusProgress
            // 
            this.StatusProgress.Location = new System.Drawing.Point(366, 643);
            this.StatusProgress.Name = "StatusProgress";
            this.StatusProgress.Size = new System.Drawing.Size(139, 16);
            this.StatusProgress.TabIndex = 3;
            // 
            // RightClick
            // 
            this.RightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CutR,
            this.CopyR,
            this.PasteR,
            this.toolStripSeparator2,
            this.SelectAll});
            this.RightClick.Name = "RightClick";
            this.RightClick.Size = new System.Drawing.Size(123, 98);
            this.RightClick.Text = "Right";
            // 
            // CutR
            // 
            this.CutR.Name = "CutR";
            this.CutR.Size = new System.Drawing.Size(122, 22);
            this.CutR.Text = "Cut";
            this.CutR.Click += new System.EventHandler(this.CutR_Click);
            // 
            // CopyR
            // 
            this.CopyR.Name = "CopyR";
            this.CopyR.Size = new System.Drawing.Size(122, 22);
            this.CopyR.Text = "Copy";
            this.CopyR.Click += new System.EventHandler(this.CopyR_Click);
            // 
            // PasteR
            // 
            this.PasteR.Name = "PasteR";
            this.PasteR.Size = new System.Drawing.Size(122, 22);
            this.PasteR.Text = "Paste";
            this.PasteR.Click += new System.EventHandler(this.PasteR_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // SelectAll
            // 
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(122, 22);
            this.SelectAll.Text = "Select All";
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.BackColor = System.Drawing.Color.Transparent;
            this.path.Location = new System.Drawing.Point(12, 619);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(32, 14);
            this.path.TabIndex = 9;
            this.path.Text = "Path";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(13, 646);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(70, 14);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "StatusLabel";
            // 
            // ChLabel
            // 
            this.ChLabel.AutoSize = true;
            this.ChLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ChLabel.Location = new System.Drawing.Point(370, 4);
            this.ChLabel.Name = "ChLabel";
            this.ChLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChLabel.Size = new System.Drawing.Size(39, 14);
            this.ChLabel.TabIndex = 6;
            this.ChLabel.Text = "NONE";
            this.ChLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ChLabel.Click += new System.EventHandler(this.ChLabel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 641);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(521, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ChronicleInfo
            // 
            this.ChronicleInfo.AutoSize = true;
            this.ChronicleInfo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ChronicleInfo.Location = new System.Drawing.Point(311, 4);
            this.ChronicleInfo.Name = "ChronicleInfo";
            this.ChronicleInfo.Size = new System.Drawing.Size(60, 14);
            this.ChronicleInfo.TabIndex = 11;
            this.ChronicleInfo.Text = "Chronicle:";
            // 
            // FileDialog
            // 
            this.FileDialog.Filter = "Binary file|*.exe";
            // 
            // ColorDialog
            // 
            this.ColorDialog.FullOpen = true;
            // 
            // IniTab
            // 
            this.IniTab.Controls.Add(this.NumLines);
            this.IniTab.Controls.Add(this.Counts);
            this.IniTab.Controls.Add(this.EncText);
            this.IniTab.Controls.Add(this.EnCod);
            this.IniTab.Controls.Add(this.FileIniComboName);
            this.IniTab.Controls.Add(this.clearl2ini);
            this.IniTab.Controls.Add(this.savel2ini);
            this.IniTab.Controls.Add(this.IniTextBox);
            this.IniTab.Controls.Add(this.OpenL2iniText);
            this.IniTab.Location = new System.Drawing.Point(4, 23);
            this.IniTab.Name = "IniTab";
            this.IniTab.Padding = new System.Windows.Forms.Padding(3);
            this.IniTab.Size = new System.Drawing.Size(489, 552);
            this.IniTab.TabIndex = 1;
            this.IniTab.Text = "ini/int Files";
            this.IniTab.UseVisualStyleBackColor = true;
            // 
            // NumLines
            // 
            this.NumLines.AutoSize = true;
            this.NumLines.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumLines.Location = new System.Drawing.Point(347, 215);
            this.NumLines.Name = "NumLines";
            this.NumLines.Size = new System.Drawing.Size(97, 13);
            this.NumLines.TabIndex = 11;
            this.NumLines.Text = "Number of lines:";
            // 
            // Counts
            // 
            this.Counts.AutoSize = true;
            this.Counts.Location = new System.Drawing.Point(461, 214);
            this.Counts.Name = "Counts";
            this.Counts.Size = new System.Drawing.Size(14, 14);
            this.Counts.TabIndex = 10;
            this.Counts.Text = "0";
            // 
            // EncText
            // 
            this.EncText.AutoSize = true;
            this.EncText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncText.Location = new System.Drawing.Point(347, 185);
            this.EncText.Name = "EncText";
            this.EncText.Size = new System.Drawing.Size(60, 13);
            this.EncText.TabIndex = 9;
            this.EncText.Text = "Encoding:";
            // 
            // EnCod
            // 
            this.EnCod.AutoSize = true;
            this.EnCod.Location = new System.Drawing.Point(422, 185);
            this.EnCod.Name = "EnCod";
            this.EnCod.Size = new System.Drawing.Size(14, 14);
            this.EnCod.TabIndex = 8;
            this.EnCod.Text = "0";
            // 
            // FileIniComboName
            // 
            this.FileIniComboName.Cursor = System.Windows.Forms.Cursors.Default;
            this.FileIniComboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileIniComboName.Location = new System.Drawing.Point(355, 17);
            this.FileIniComboName.Name = "FileIniComboName";
            this.FileIniComboName.Size = new System.Drawing.Size(128, 22);
            this.FileIniComboName.TabIndex = 5;
            this.FileIniComboName.SelectedIndexChanged += new System.EventHandler(this.FileIniComboName_SelectedIndexChanged);
            // 
            // clearl2ini
            // 
            this.clearl2ini.Location = new System.Drawing.Point(352, 130);
            this.clearl2ini.Name = "clearl2ini";
            this.clearl2ini.Size = new System.Drawing.Size(131, 30);
            this.clearl2ini.TabIndex = 3;
            this.clearl2ini.Text = "Clear";
            this.clearl2ini.UseVisualStyleBackColor = true;
            this.clearl2ini.Click += new System.EventHandler(this.clearl2ini_Click);
            // 
            // savel2ini
            // 
            this.savel2ini.Location = new System.Drawing.Point(352, 94);
            this.savel2ini.Name = "savel2ini";
            this.savel2ini.Size = new System.Drawing.Size(131, 30);
            this.savel2ini.TabIndex = 4;
            this.savel2ini.Text = "Save";
            this.savel2ini.UseVisualStyleBackColor = true;
            this.savel2ini.Click += new System.EventHandler(this.savel2ini_Click);
            // 
            // IniTextBox
            // 
            this.IniTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IniTextBox.ContextMenuStrip = this.RightClick;
            this.IniTextBox.Enabled = false;
            this.IniTextBox.Location = new System.Drawing.Point(18, 17);
            this.IniTextBox.Name = "IniTextBox";
            this.IniTextBox.Size = new System.Drawing.Size(328, 529);
            this.IniTextBox.TabIndex = 2;
            this.IniTextBox.Text = "";
            // 
            // OpenL2iniText
            // 
            this.OpenL2iniText.Location = new System.Drawing.Point(352, 58);
            this.OpenL2iniText.Name = "OpenL2iniText";
            this.OpenL2iniText.Size = new System.Drawing.Size(131, 30);
            this.OpenL2iniText.TabIndex = 0;
            this.OpenL2iniText.Text = "Open";
            this.OpenL2iniText.UseVisualStyleBackColor = true;
            this.OpenL2iniText.Click += new System.EventHandler(this.OpenIniButton_Click);
            // 
            // DatTab
            // 
            this.DatTab.Controls.Add(this._mergeButton);
            this.DatTab.Controls.Add(this.lockBtn);
            this.DatTab.Controls.Add(this.editorBtn);
            this.DatTab.Controls.Add(this.startBtn2);
            this.DatTab.Controls.Add(this.exportBtn2);
            this.DatTab.Controls.Add(this.importBtn2);
            this.DatTab.Controls.Add(this.SaveBtn2);
            this.DatTab.Controls.Add(this.LoadBtn2);
            this.DatTab.Controls.Add(this.FileNameCombo);
            this.DatTab.Location = new System.Drawing.Point(4, 23);
            this.DatTab.Name = "DatTab";
            this.DatTab.Padding = new System.Windows.Forms.Padding(3);
            this.DatTab.Size = new System.Drawing.Size(489, 552);
            this.DatTab.TabIndex = 0;
            this.DatTab.Text = "dat Files";
            this.DatTab.UseVisualStyleBackColor = true;
            // 
            // _mergeButton
            // 
            this._mergeButton.DescriptionText = "";
            this._mergeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._mergeButton.HeaderText = "Merge";
            this._mergeButton.Image = global::com.jds.PathEditor.Resources.MERGE;
            this._mergeButton.ImageScalingSize = new System.Drawing.Size(16, 16);
            this._mergeButton.Location = new System.Drawing.Point(361, 256);
            this._mergeButton.Name = "_mergeButton";
            this._mergeButton.Size = new System.Drawing.Size(122, 50);
            this._mergeButton.TabIndex = 9;
            this._mergeButton.Click += new System.EventHandler(this._mergeButton_Click);
            // 
            // lockBtn
            // 
            this.lockBtn.AutoSize = true;
            this.lockBtn.Location = new System.Drawing.Point(364, 380);
            this.lockBtn.Name = "lockBtn";
            this.lockBtn.Size = new System.Drawing.Size(57, 18);
            this.lockBtn.TabIndex = 8;
            this.lockBtn.Text = "Lock?";
            this.lockBtn.UseVisualStyleBackColor = true;
            this.lockBtn.CheckedChanged += new System.EventHandler(this.lockBtn_CheckedChanged);
            // 
            // editorBtn
            // 
            this.editorBtn.DescriptionText = "";
            this.editorBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editorBtn.HeaderText = "Editor";
            this.editorBtn.Image = global::com.jds.PathEditor.Resources.editor;
            this.editorBtn.ImageScalingSize = new System.Drawing.Size(16, 16);
            this.editorBtn.Location = new System.Drawing.Point(361, 312);
            this.editorBtn.Name = "editorBtn";
            this.editorBtn.Size = new System.Drawing.Size(122, 50);
            this.editorBtn.TabIndex = 8;
            this.editorBtn.Click += new System.EventHandler(this.expToWindow_Click);
            // 
            // startBtn2
            // 
            this.startBtn2.DescriptionText = "";
            this.startBtn2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn2.HeaderText = "Start L2";
            this.startBtn2.Image = global::com.jds.PathEditor.Resources.START;
            this.startBtn2.ImageScalingSize = new System.Drawing.Size(16, 16);
            this.startBtn2.Location = new System.Drawing.Point(361, 493);
            this.startBtn2.Name = "startBtn2";
            this.startBtn2.Size = new System.Drawing.Size(122, 50);
            this.startBtn2.TabIndex = 8;
            this.startBtn2.Click += new System.EventHandler(this.StartL2_Click);
            // 
            // exportBtn2
            // 
            this.exportBtn2.DescriptionText = "";
            this.exportBtn2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn2.HeaderText = "Export";
            this.exportBtn2.Image = global::com.jds.PathEditor.Resources.EXPORT;
            this.exportBtn2.ImageScalingSize = new System.Drawing.Size(16, 16);
            this.exportBtn2.Location = new System.Drawing.Point(361, 200);
            this.exportBtn2.Name = "exportBtn2";
            this.exportBtn2.Size = new System.Drawing.Size(122, 50);
            this.exportBtn2.TabIndex = 8;
            this.exportBtn2.Click += new System.EventHandler(this.ExpBtn_Click);
            // 
            // importBtn2
            // 
            this.importBtn2.DescriptionText = "";
            this.importBtn2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn2.HeaderText = "Import";
            this.importBtn2.Image = global::com.jds.PathEditor.Resources.IMPORT;
            this.importBtn2.ImageScalingSize = new System.Drawing.Size(16, 16);
            this.importBtn2.Location = new System.Drawing.Point(361, 140);
            this.importBtn2.Name = "importBtn2";
            this.importBtn2.Size = new System.Drawing.Size(122, 50);
            this.importBtn2.TabIndex = 8;
            this.importBtn2.Click += new System.EventHandler(this.ImpBtn_Click);
            // 
            // SaveBtn2
            // 
            this.SaveBtn2.DescriptionText = "";
            this.SaveBtn2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveBtn2.HeaderText = "Save";
            this.SaveBtn2.Image = global::com.jds.PathEditor.Resources.SAVE;
            this.SaveBtn2.ImageScalingSize = new System.Drawing.Size(16, 16);
            this.SaveBtn2.Location = new System.Drawing.Point(361, 80);
            this.SaveBtn2.Name = "SaveBtn2";
            this.SaveBtn2.Size = new System.Drawing.Size(122, 50);
            this.SaveBtn2.TabIndex = 8;
            this.SaveBtn2.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // LoadBtn2
            // 
            this.LoadBtn2.DescriptionText = "";
            this.LoadBtn2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadBtn2.HeaderText = "Load";
            this.LoadBtn2.Image = global::com.jds.PathEditor.Resources.LOAD;
            this.LoadBtn2.ImageScalingSize = new System.Drawing.Size(16, 16);
            this.LoadBtn2.Location = new System.Drawing.Point(361, 20);
            this.LoadBtn2.Name = "LoadBtn2";
            this.LoadBtn2.Size = new System.Drawing.Size(122, 50);
            this.LoadBtn2.TabIndex = 8;
            this.LoadBtn2.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // FileNameCombo
            // 
            this.FileNameCombo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileNameCombo.FormattingEnabled = true;
            this.FileNameCombo.ItemHeight = 14;
            this.FileNameCombo.Location = new System.Drawing.Point(23, 21);
            this.FileNameCombo.Name = "FileNameCombo";
            this.FileNameCombo.Size = new System.Drawing.Size(332, 522);
            this.FileNameCombo.TabIndex = 5;
            this.FileNameCombo.SelectedIndexChanged += new System.EventHandler(this.FileNameCombo_SelectedIndexChanged);
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.DatTab);
            this.Tabs.Controls.Add(this.IniTab);
            this.Tabs.Location = new System.Drawing.Point(12, 37);
            this.Tabs.Multiline = true;
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(497, 579);
            this.Tabs.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 663);
            this.Controls.Add(this.StatusProgress);
            this.Controls.Add(this.path);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.ChronicleInfo);
            this.Controls.Add(this.ChLabel);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Path Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.HideMenu.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.RightClick.ResumeLayout(false);
            this.IniTab.ResumeLayout(false);
            this.IniTab.PerformLayout();
            this.DatTab.ResumeLayout(false);
            this.DatTab.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog ExportDialog;
        private System.Windows.Forms.OpenFileDialog ImportDialog;
        private System.Windows.Forms.ContextMenuStrip HideMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowForm;
        private System.Windows.Forms.ToolStripMenuItem ExitForm;
        private System.Windows.Forms.NotifyIcon HideIcon;
        private System.Windows.Forms.ToolStripMenuItem AbuotForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.MenuStrip MainMenu;
        public System.Windows.Forms.ProgressBar StatusProgress;
        public System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label ChLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem OpenFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuService;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.ToolStripMenuItem MenuAbout;
        private System.Windows.Forms.Label ChronicleInfo;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ContextMenuStrip RightClick;
        private System.Windows.Forms.ToolStripMenuItem CutR;
        private System.Windows.Forms.ToolStripMenuItem CopyR;
        private System.Windows.Forms.ToolStripMenuItem PasteR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SelectAll;
        private System.Windows.Forms.ToolStripMenuItem pathSystem;
        private System.Windows.Forms.ToolStripMenuItem fastST;
        private System.Windows.Forms.ToolStripMenuItem l2ini;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.FolderBrowserDialog DirectoryDialog;
		public System.Windows.Forms.OpenFileDialog FileDialog;
		public System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.TabPage IniTab;
        private System.Windows.Forms.Label NumLines;
        private System.Windows.Forms.Label Counts;
        private System.Windows.Forms.Label EncText;
        private System.Windows.Forms.Label EnCod;
        public System.Windows.Forms.ComboBox FileIniComboName;
        private System.Windows.Forms.Button clearl2ini;
        private System.Windows.Forms.Button savel2ini;
        public System.Windows.Forms.RichTextBox IniTextBox;
        public System.Windows.Forms.Button OpenL2iniText;
        private System.Windows.Forms.TabPage DatTab;
        private System.Windows.Forms.CheckBox lockBtn;
        private JButton editorBtn;
        private JButton startBtn2;
        private JButton exportBtn2;
        private JButton importBtn2;
        private JButton SaveBtn2;
        private JButton LoadBtn2;
        private System.Windows.Forms.ListBox FileNameCombo;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.ToolStripMenuItem lastFoldersToolStripMenuItem;
        private JButton _mergeButton;
    }
}

