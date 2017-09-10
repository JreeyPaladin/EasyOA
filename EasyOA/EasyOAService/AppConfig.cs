using System.Configuration;

namespace EasyOAService
{
    public class AppConfig
    {
        public static string IP;
        public static int Port;
        static AppConfig() {
            Refresh();
        }
        public static void Refresh()
        {
            IP = ConfigurationManager.AppSettings["IP"];
            Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
        }
    }
}
