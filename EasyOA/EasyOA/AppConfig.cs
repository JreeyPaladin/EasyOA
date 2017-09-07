using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EasyOA
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
