using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Xml;

namespace com.jds.PathEditor.classes.services
{
    public enum Word
    {
        LOAD_BUTTON,
        SAVE_BUTTON,
        IMPORT_BUTTON,
        EXPORT_BUTTON,
        START_BUTTON,
        OPEN_BUTTON,
        CLEAR_BUTTON,
        MERGE_BUTTON,
        DAT_TAB,
        INI_TAB,
        MENU_FILE,
        MENU_SERVICE,
        MENU_FILE_OPEN_FOLDER,
        MENU_FILE_QUIT,
        MENU_SERVICE_PATH_SYSTEM,
        MENU_SERVICE_SETTINGS,
        MENU_SERVICE_FAST_SETTINGS,
        CHRONICLE,
        HIDE_MENU_SHOW,
        HIDE_MENU_ABOUT,
        RIGHT_CLICK_CUT,
        RIGHT_CLICK_COPY,
        RIGHT_CLICK_PUT,
        RIGHT_CLICK_SELECT_ALL,
        DESCRIPTION,
        PRODUCT_NAME,
        VERSION,
        COMPANY,
        COPYRIGHT,
        AUTHOR,
        INFO,
        LANGUAGE,
        TEXT_ENCODING,
        USE_TRAY,
        SAVE_BAK_FILES,
        FILE_TO_RUN,
        NUMBER_OF_LINES,
        PORT,
        INTERNET_GROUP,
        OTHER_GROUP,
        SECOND_CLIENT,
        TEST_SERVER,
        NETWORK_LOG,
        HOST,
        REFRESH,
        COMPLETE,
        PLEASE_WAIT,
        LOADED_DATA,
        SAVED_DATA,
        IMPORTED_DATA,
        EXPORTED_DATA,
        ERROR,
        SYSTEM_FOLDER_IS_EMPTY,
        PLEASE_SELECT_SYSTEM_FOLDER,
        COMPLETE_PATH_SYSTEM_FOLDER,
        FILE_NOT_FOUND,
        MINIMIZED_ON_START_L2,
        LICENSE,
        EDITOR,
        LOCK,
        EMPTY,
        LAST_FOLDERS
    }

    public class Localizate
    {
        private static readonly Dictionary<String, String> _message = new Dictionary<String, String>();

        private static List<String> msg = new List<string>();
        public static readonly String DIR = Directory.GetCurrentDirectory();

        public static void load()
        {
            _message.Clear();

            var doc = new XmlDocument();
            doc.Load(DIR + "\\localization\\" + RConfig.Instance.Localization);

            XmlNode xNode = doc.GetElementsByTagName("localization").Item(0);
            IConfigurationSectionHandler csh = new NameValueSectionHandler();
            var nvc = (NameValueCollection) csh.Create(null, null, xNode);

            String[] msg = Enum.GetNames(typeof (Word));

            foreach (String st in msg)
            {
                _message.Add(st, get(nvc, st));
            }
        }

        private static String get(NameValueCollection nvc, String value)
        {
            if (nvc.Get(value) == null)
                return "NONE";
            return nvc.Get(value);
        }

        public static String getMessage(Word word)
        {
            String type = Enum.GetName(typeof (Word), word);
            if (!_message.ContainsKey(type))
                return "NONE";

            return _message[type];
        }
    }
}