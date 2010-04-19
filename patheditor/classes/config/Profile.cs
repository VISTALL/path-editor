using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using engine.classes.client;
using Microsoft.Win32;
using engine;
using log4net;
using System.Drawing;
using engine.classes.lm;
using engine.config;
using System.Drawing.Design;
using engine.parser;

namespace com.jds.patheditor.classes.config
{
    public class Profile
    {        
        private Dictionary<String, Dictionary<String, int>> _columnSize = new Dictionary<String, Dictionary<String, int>>();
        private readonly String _name;

        public Profile(String name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name.ToString();
        }

        #region Load Method
        public bool load()
        {
            RegistryKey registryKey = Registry.CurrentUser;
            registryKey = registryKey.OpenSubKey(RConfig.KEY + "\\Profiles\\" + Name);

            if (registryKey == null)
                return false;

            try
            {
                TextEncoding = (String)registryKey.GetValue("TextEncoding", "UTF-8");
                DatVersionAsEnum = (DatVersion)Enum.Parse(typeof(DatVersion), (String)registryKey.GetValue("DatVersion", "Interlude"));
                LineageDirectory = (String)registryKey.GetValue("LineageDirectory", "");
                LineageFile = (String)registryKey.GetValue("LineageFile", "");
                EditorColor = ConvertUtilities.HtmlColorToColor((String)registryKey.GetValue("EditorColor", "646464"));

                registryKey = registryKey.OpenSubKey(RConfig.KEY + "\\Profiles\\" + Name + "\\Columns");
               
                if (registryKey == null)
                    return true;
                
                String[] subKeys = registryKey.GetSubKeyNames();

                foreach (String subkey in subKeys)
                {
                    RegistryKey sub = Registry.CurrentUser;
                    sub = sub.OpenSubKey(RConfig.KEY + "\\Profiles\\" + Name + "\\Columns\\" + subkey);

                    if (sub != null)
                    {
                        if (!_columnSize.ContainsKey(subkey))
                        {
                            _columnSize[subkey] = new Dictionary<string, int>();
                        }

                        foreach (String value in sub.GetValueNames())
                        {
                            _columnSize[subkey].Add(value, (int)sub.GetValue(value, 0));
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                //DEBUG
                LogManager.GetLogger(typeof(Profile)).Info(e.StackTrace, e);

                return false;
            }
        }

        #endregion

        #region Save Method
        public void save()
        {
            RegistryKey registryKey = Registry.CurrentUser;
            registryKey = registryKey.CreateSubKey(RConfig.KEY + "\\Profiles\\" + Name);
            registryKey.SetValue("TextEncoding", TextEncoding);
            registryKey.SetValue("DatVersion", DatVersionAsEnum.ToString());
            registryKey.SetValue("LineageDirectory", LineageDirectory);
            registryKey.SetValue("LineageFile", LineageFile);
            registryKey.SetValue("EditorColor", ConvertUtilities.ColorToHtmlColor(EditorColor));

            registryKey = registryKey.CreateSubKey("Columns");

            foreach (String keys in _columnSize.Keys)
            {
                RegistryKey subkey = registryKey.CreateSubKey(keys);

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

        #region Propertyes
        [Browsable(false)]
        public String Name
        {
            get
            {
                return _name;
            }
        }

        [Description("Version of Lineage II Client"), Category("Lineage II"), DefaultValue("Interlude"), Editor(typeof(DatVersionEditor), typeof(UITypeEditor))]
        public String DatVersion
        {
            get
            {
                return DatVersionAsEnum.ToString().Replace("__", "/").Replace("_", " ");
            }
            set
            {
                DatVersionAsEnum = (DatVersion)Enum.Parse(typeof(DatVersion), value.Replace("/", "__").Replace(" ", "_"));
            }
        }

        [Browsable(false)]
        public DatVersion DatVersionAsEnum
        {
            get;
            set;
        }

        [DisplayName("Text Encoding"), Description("Encoding of read and written text file"), Category("Global"), DefaultValue("utf-8"), Editor(typeof(EncodingEditor), typeof(UITypeEditor))]
        public String TextEncoding
        {
            get;
            set;
        }

        [Description("Directory where Lineage || installed"), Category("Lineage II"), DefaultValue(""), Editor(typeof(LineageDirectoryFolderBrowserEditor), typeof(UITypeEditor))]
        public String LineageDirectory
        {
            get;
            set;
        }
       
        [Description("File to run for button L2"), Category("Lineage II"), DefaultValue(""), Editor(typeof(LineageFileBrowserEditor), typeof(UITypeEditor))]
        public String LineageFile
        {
            get;
            set;
        }

        [Description("Editor Back Color"), Category("Editor"), Editor(typeof(ColorValueEditor), typeof(UITypeEditor))]
        public Color EditorColor
        {
            get;
            set;
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
    }
}
