﻿using CatMM.Infrastructure.TemplateEngine.Filiters;
using DotLiquid;
using System.Web;
using System.Web.Mvc;

namespace CatMM.Web
{
    /// <summary>
    /// Filter config
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Register global filters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
        }
    }
}
