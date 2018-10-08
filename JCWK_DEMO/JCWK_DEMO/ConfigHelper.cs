using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCWK_DEMO
{
    public class ConfigHelper
    {
        public static string SendTxtPath { get; set; }
        public static string ReceiveTxtPath { get; set; }

        public ConfigHelper()
        {
            SendTxtPath = ConfigurationManager.AppSettings["SendTxtPath"];
            ReceiveTxtPath = ConfigurationManager.AppSettings["ReceiveTxtPath"];
        }
    }
}
