using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Swashbuckle.Application;
using CatMM.WebAPI;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CatMM.WebAPI
{
    /// <summary>
    /// Swagger config
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Register
        /// </summary>
        public static void Register()
        {
            GlobalConfiguration.Configuration
            .EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Cat mengmeng");
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.DescribeAllEnumsAsStrings();
            })
            .EnableSwaggerUi(c => { });
        }

        /// <summary>
        /// Get xml comments path
        /// </summary>
        /// <returns></returns>
        private static string GetXmlCommentsPath()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            string commentsFile = String.Format("{0}/bin/{1}", baseDirectory, commentsFileName);

            return commentsFile;
        }
    }
}