using System.IO;
using log4net.Config;

namespace com.jds.PathEditor.classes.services
{
    /**
     * Author: VISTALL
     * Company: J Develop Station
     * Time: 16:37 /1.03.2010
     */

    public class LogService
    {
        public static void init()
        {
            if (!File.Exists("log4net.xml"))
                return;
            XmlConfigurator.Configure(new FileInfo("log4net.xml"));
        }
    }
}