using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.TemplateEngine
{
    /// <summary>
    /// Template engine
    /// </summary>
    public interface ITemplateEngine
    {
        /// <summary>
        /// Render
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="templateString"></param>
        /// <param name="templateModel"></param>
        /// <returns></returns>
        string Render<T>(string templateString, T templateModel);
    }
}
