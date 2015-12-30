using CatMM.Infrastructure.TemplateEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CatMM.Infrastructure.Models;

namespace CatMM.Web.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestEngine()
        {
            Random ran = new Random();
            ITemplateEngineProvider provider = new DotLiquidTemplateProvider();
            ITemplateEngine engine = provider.GetTemplateEngine();
            int moduleType = ran.Next(3);
            ModuleType type = (ModuleType)moduleType;
            string path = Server.MapPath("~/content/email.html");
            string templateText = String.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                templateText = sr.ReadToEnd();
            }

            if (!String.IsNullOrWhiteSpace(templateText))
            {
                templateText = engine.Render(
                    templateText,
                    new
                    {
                        ModuleType = type,
                        User = new User
                        {
                            Name = "Huang qing lu",
                            Age = 20,
                            FirstName = "Huang"
                        }
                    });
            }
            return Content(templateText, "text/html");
        }
    }
}