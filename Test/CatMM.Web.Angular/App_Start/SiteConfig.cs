using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace App.CatMM.Web.Angular
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
    }
}