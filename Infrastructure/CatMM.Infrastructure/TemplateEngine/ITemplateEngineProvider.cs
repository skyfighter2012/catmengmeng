using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.TemplateEngine
{
    /// <summary>
    /// Template engine provider
    /// </summary>
    public interface ITemplateEngineProvider
    {
        /// <summary>
        /// Get template engine
        /// </summary>
        /// <returns></returns>
        ITemplateEngine GetTemplateEngine();
    }
}
