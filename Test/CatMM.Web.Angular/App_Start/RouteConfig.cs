// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="">
//   Copyright ?2015 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.CatMM.Web.Angular
{
    using System.Web.Routing;

    using App.CatMM.Web.Angular.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add("Default", new DefaultRoute());
        }
    }
}
