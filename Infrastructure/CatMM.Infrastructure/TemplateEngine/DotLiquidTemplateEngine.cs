using CatMM.Infrastructure.TemplateEngine.FileSystems;
using CatMM.Infrastructure.TemplateEngine.Filiters;
using DotLiquid;
using DotLiquid.NamingConventions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.TemplateEngine
{
    /// <summary>
    /// DotLiquid template engine
    /// </summary>
    public class DotLiquidTemplateEngine : ITemplateEngine
    {
        public DotLiquidTemplateEngine()
        {
            Template.RegisterFilter(typeof(TextFilter));
            Template.NamingConvention = new CSharpNamingConvention();
            Template.FileSystem = new TemplateSystem();
        }

        /// <summary>
        /// Render
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="templateString"></param>
        /// <param name="templateModel"></param>
        /// <returns></returns>
        public string Render<T>(string templateString, T templateModel)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(templateString));
            Template template = Template.Parse(templateString);
            return template.Render(Hash.FromAnonymousObject(templateModel));
        }
    }
}
