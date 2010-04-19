using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.ComponentModel;
using engine.config;
using engine.parser;
using engine.classes.client.types;
using engine.classes.client;
using System.Drawing.Design;
using System.Drawing;
using engine.classes.lm;
using com.jds.patheditor.classes.config;

namespace engine
{
    public class RConfig
    {
        public static readonly String KEY = "Software\\J Develop Station\\Path Editor";
        private static RConfig _instance;        

        private String _language = "english.xml";
        private bool _useTray = false;
        private bool _miniOnStart = false;
        private bool _saveBakFile = true;

        private Dictionary<String, Profile> _profiles = new Dictionary<string, Profile>();

        #region Instance & Constructor
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

        RConfig()
        {

        }
        #endregion

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
                _language = (String)key.GetValue("Language", "english.xml");
                _useTray = Boolean.Parse((String)key.GetValue("UseTray", "false"));
                _miniOnStart = Boolean.Parse((String)key.GetValue("MinimizeOnStart", "false"));              
                _saveBakFile = Boolean.Parse((String)key.GetValue("SaveBakFile", "true"));
                ActiveProfile = (String)key.GetValue("ActiveProfile", null);
                
                key = key.OpenSubKey(KEY + "\\Profiles");
                if (key == null)
                    return;

                String[] profiles = key.GetSubKeyNames();

                foreach (String profileName in profiles)
                {
                    Profile profile = new Profile(profileName);

                    if (profile.load())
                    {
                        //TODO add
                    }
                }
            }   
        }

        public void save()
        {
            RegistryKey key = Registry.CurrentUser;
            key = key.CreateSubKey(KEY);
           
            key.SetValue("Language", _language);        
            key.SetValue("UseTray", _useTray);
            key.SetValue("MinimizeOnStart", _miniOnStart);            
            key.SetValue("SaveBakFile", _saveBakFile);
            key.SetValue("ActiveProfile", ActiveProfile);

            foreach (Profile profile in _profiles.Values)
            {
                profile.save();
            }
            
        }
        #endregion


        #region Properties
        [Browsable(false)]
        public String ActiveProfile
        {
            get;
            set;
        }
        
        [Browsable(false)]
        public Profile Profile
        {
            get
            {
                return _profiles[ActiveProfile];
            }
            set
            {
                ActiveProfile = value.Name;
            }
        }

        public Dictionary<String, Profile> Profiles
        {
            get
            {
                return _profiles;
            }
        }
        #endregion

        #region Language
        [DisplayName("Language"), Description("Language of program"), Category("Global"), DefaultValue("english.xml"), Editor(typeof(LocalizationEditor), typeof(UITypeEditor))]
        public String Localization
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }
        #endregion    

        #region UseTray
        [DisplayName("Use Tray"), Description("Use tray"), Category("Global"), DefaultValue(true)]
        public bool UseTray
        {
            get
            {
                return _useTray;
            }
            set
            {
                _useTray = value;
            }
        }
        #endregion

        #region MiniOnStart
        [DisplayName("MinimizeOnStart"), Description("Minimize on Start"), Category("Global"), DefaultValue(true)]
        public bool MiniOnStart
        {
            get
            {
                return _miniOnStart;
            }
            set
            {
                _miniOnStart = value;
            }
        }

        #endregion

        #region Save Bak File
        [DisplayName("Save BAK files"), Description("Set to 'True' if you want program to save bak-files on each save"), Category("Global"), DefaultValue(true)]
        public bool SaveBakFiles
        {
            get
            {
                return _saveBakFile;
            }
            set
            {
                _saveBakFile = value;
            }
        }
        #endregion

    }
}
