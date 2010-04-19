﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using com.jds.PathEditor.classes.client;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.lm;
using Microsoft.Win32;

namespace com.jds.PathEditor.classes.services
{
    public class RConfig
    {
        private static RConfig _instance;
        private static readonly String KEY = "Software\\J Develop Station\\Path Editor";

        private readonly Dictionary<String, Dictionary<String, int>> _columnSize =
            new Dictionary<String, Dictionary<String, int>>();

        private Color _colorEditor = Color.FromArgb(64, 64, 64);

        private DatVersion _datVersion = (DatVersion) Enum.Parse(typeof (DatVersion), "Interlude");
        private String _fileToRun = "";
        private String _language = "english.xml";
        private String _lineageDirectory = "";
        private bool _miniOnStart;
        private bool _saveBakFile = true;
        private String _textEncoding = "UTF-8";
        private bool _useTray;

        private RConfig()
        {
        }

        #region Загрузка Сохранения в реестр

        public void load()
        {
            RegistryKey key = Registry.CurrentUser;
            key = key.OpenSubKey(KEY);
            if (key == null)
            {
                key = Registry.CurrentUser;
                key = key.CreateSubKey(KEY);
            }
            else
            {
                _textEncoding = (String) key.GetValue("TextEncoding", "UTF-8");
                _language = (String) key.GetValue("Language", "english.xml");
                _datVersion =
                    (DatVersion) Enum.Parse(typeof (DatVersion), (String) key.GetValue("DatVersion", "Interlude"));
                _useTray = Boolean.Parse((String) key.GetValue("UseTray", "false"));
                _miniOnStart = Boolean.Parse((String) key.GetValue("MinimizeOnStart", "false"));
                _lineageDirectory = (String) key.GetValue("LineageDirectory", "");
                _saveBakFile = Boolean.Parse((String) key.GetValue("SaveBakFile", "true"));
                _fileToRun = (String) key.GetValue("FileToRun", "");
                _colorEditor = Color.FromArgb(int.Parse((String) key.GetValue("ListR", "64")),
                                              int.Parse((String) key.GetValue("ListG", "64")),
                                              int.Parse((String) key.GetValue("ListB", "64")));

                String[] subs = key.GetSubKeyNames();

                foreach (String subkey in subs)
                {
                    if (subkey == null)
                        return;

                    RegistryKey sub = Registry.CurrentUser;
                    sub = sub.OpenSubKey(KEY + "\\" + subkey);

                    if (sub != null)
                    {
                        if (!_columnSize.ContainsKey(subkey))
                        {
                            _columnSize[subkey] = new Dictionary<string, int>();
                        }

                        foreach (String value in sub.GetValueNames())
                        {
                            _columnSize[subkey].Add(value, (int) sub.GetValue(value, 0));
                        }
                    }
                }
            }
        }

        public void save()
        {
            RegistryKey key = Registry.CurrentUser;
            key = key.CreateSubKey(KEY);

            key.SetValue("TextEncoding", _textEncoding);
            key.SetValue("Language", _language);
            key.SetValue("DatVersion", _datVersion.ToString());
            key.SetValue("UseTray", _useTray);
            key.SetValue("MinimizeOnStart", _miniOnStart);
            key.SetValue("LineageDirectory", _lineageDirectory);
            key.SetValue("SaveBakFile", _saveBakFile);
            key.SetValue("FileToRun", _fileToRun);
            key.SetValue("ListR", _colorEditor.R);
            key.SetValue("ListG", _colorEditor.G);
            key.SetValue("ListB", _colorEditor.B);

            foreach (String keys in _columnSize.Keys)
            {
                RegistryKey subkey = key.CreateSubKey(keys);

                if (_columnSize.ContainsKey(keys))
                {
                    foreach (String key2 in _columnSize[keys].Keys)
                    {
                        subkey.SetValue(key2, _columnSize[keys][key2]);
                    }
                }
            }
        }

        #endregion

        #region Размеры столбов

        public void setColumnSize(Definition def, String columnName, int size)
        {
            String defName = def.GetType().Name;

            if (!_columnSize.ContainsKey(defName))
            {
                _columnSize[defName] = new Dictionary<string, int>();
            }

            if (_columnSize[defName].ContainsKey(columnName))
                _columnSize[defName].Remove(columnName);

            _columnSize[defName].Add(columnName, size);
        }

        public int getColumnSize(Definition def, String columnName)
        {
            String defName = def.GetType().Name;

            if (_columnSize.ContainsKey(defName))
            {
                if (_columnSize[defName].ContainsKey(columnName))
                {
                    return _columnSize[defName][columnName];
                }
            }

            return 60;
        }

        #endregion

        #region Text Encoding

        [DisplayName("Text Encoding"), Description("Encoding of read and written text file"), Category("Global"),
         DefaultValue("utf-8"), Editor(typeof (EncodingEditor), typeof (UITypeEditor))]
        public string TextEncoding
        {
            get { return _textEncoding; }
            set { _textEncoding = value; }
        }

        #endregion

        #region Language

        [DisplayName("Language"), Description("Language of program"), Category("Global"), DefaultValue("english.xml"),
         Editor(typeof (LocalizationEditor), typeof (UITypeEditor))]
        public String Localization
        {
            get { return _language; }
            set { _language = value; }
        }

        #endregion

        #region DatVersion

        [DisplayName("Dat Version"), Description("Version of Lineage II Client"), Category("Lineage II"),
         DefaultValue("Interlude"), Editor(typeof (DatVersionEditor), typeof (UITypeEditor))]
        public String DatVersion
        {
            get { return _datVersion.ToString().Replace("__", "/").Replace("_", " "); }
            set { _datVersion = (DatVersion) Enum.Parse(typeof (DatVersion), value.Replace("/", "__").Replace(" ", "_")); }
        }

        [Browsable(false)]
        public DatVersion DatVersionAsEnum
        {
            get { return _datVersion; }
            set { _datVersion = value; }
        }

        #endregion

        #region UseTray

        [DisplayName("Use Tray"), Description("Use tray"), Category("Global"), DefaultValue(true)]
        public bool UseTray
        {
            get { return _useTray; }
            set { _useTray = value; }
        }

        #endregion

        #region MiniOnStart

        [DisplayName("MinimizeOnStart"), Description("Minimize on Start"), Category("Global"), DefaultValue(true)]
        public bool MiniOnStart
        {
            get { return _miniOnStart; }
            set { _miniOnStart = value; }
        }

        #endregion

        #region Lineage Directory

        [DisplayName("Lineage directory"), Description("Directory where Lineage || installed"), Category("Lineage II"),
         DefaultValue(""), Editor(typeof (LineageDirectoryFolderBrowserEditor), typeof (UITypeEditor))]
        public string LineageDirectory
        {
            get { return _lineageDirectory; }
            set { _lineageDirectory = value; }
        }

        #endregion

        #region Save Bak File

        [DisplayName("Save BAK files"), Description("Set to 'True' if you want program to save bak-files on each save"),
         Category("Global"), DefaultValue(true)]
        public bool SaveBakFiles
        {
            get { return _saveBakFile; }
            set { _saveBakFile = value; }
        }

        #endregion

        #region Lineage File To Run

        [DisplayName("L2 Run File"), Description("File to run for button L2"), Category("Lineage II"), DefaultValue(""),
         Editor(typeof (LineageFileBrowserEditor), typeof (UITypeEditor))]
        public string LineageFileToRun
        {
            get { return _fileToRun; }
            set { _fileToRun = value; }
        }

        #endregion

        #region Editor Back Color

        [DisplayName("BackColor"), Description("Editor Back Color"), Category("Editor"),
         Editor(typeof (ColorValueEditor), typeof (UITypeEditor))]
        public String EditorBackColor
        {
            get { return ConvertUtilities.ColorToHtmlColor(_colorEditor); }
            set { _colorEditor = ConvertUtilities.HtmlColorToColor(value); }
        }

        #endregion

        public static RConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RConfig();
                }

                return _instance;
            }
        }
    }
}