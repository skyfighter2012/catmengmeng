using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Shared
{
    public static class SiteConfig
    {
        private static string _domain = ConfigurationManager.AppSettings["Domain"];

        public static string Domain
        {
            get
            {
                return _domain;
            }
        }

        private static string _googleApiKey = ConfigurationManager.AppSettings["GoogleApiKey"];

        /// <summary>
        /// Google api key
        /// </summary>
        public static string GoogleApiKey
        {
            get
            {
                return _googleApiKey;
            }
        }

        private static string _designAbsolutePath = ConfigurationManager.AppSettings["DesignAbsolutePath"];

        public static string DesignAbsolutePath
        {
            get
            {
                return _designAbsolutePath;
            }
        }

        private static string _designDomain = ConfigurationManager.AppSettings["DesignDomain"];

        public static string DesignDomain
        {
            get
            {
                return _designDomain;
            }
        }
    }
}
