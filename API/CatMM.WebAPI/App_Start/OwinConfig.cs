using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.DataProtection;

namespace CatMM.WebAPI.App_Start
{
    /// <summary>
    /// Owin config
    /// </summary>
    public class OwinConfig
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        public static void Cofigure(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            app.Use((context, next) =>
            {
                context.Set("DataProtectionProvider", app.GetDataProtectionProvider());
                return next();
            });
        }
    }
}