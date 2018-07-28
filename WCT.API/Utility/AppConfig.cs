using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WCT.API.Utility
{
    public class AppConfig
    {
        static AppConfig()
        {
            NameValueCollection nameValue = ConfigurationManager.AppSettings;
            if (nameValue[AppConstant.DBConnection] != null)
            {
                DBConnection = Convert.ToString(nameValue[AppConstant.DBConnection]);
            }
            else
            {
                throw new Exception("Key WebAPIURL does not exists in App config file");
            }
        }
        public static string DBConnection
        {
            get;
            set;
        }
    }
}