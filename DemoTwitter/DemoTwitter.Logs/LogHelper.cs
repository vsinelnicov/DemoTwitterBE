using System.Runtime.CompilerServices;

[assembly: log4net.Config.XmlConfigurator(ConfigFileExtension = "log4net", Watch = true)]

namespace DemoTwitter.Helpers
{
    public class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath] string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}