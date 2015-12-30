using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.TemplateEngine
{
    /// <summary>
    /// Dot liquid template provider 
    /// </summary>
    public class DotLiquidTemplateProvider : ITemplateEngineProvider
    {
        public ITemplateEngine GetTemplateEngine()
        {
            return new DotLiquidTemplateEngine();
        }
    }
}
