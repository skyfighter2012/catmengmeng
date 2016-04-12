using CatMM.Infrastructure.TemplateEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CatMM.Web.Models;
using DotLiquid;
using DotLiquid.NamingConventions;
using CatMM.Infrastructure.TemplateEngine.Filiters;

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

        public ActionResult Jquery()
        {
            return View();
        }

        public ActionResult TestEngine()
        {
            Random ran = new Random();
            ITemplateEngineProvider provider = new DotLiquidTemplateProvider();
            ITemplateEngine engine = provider.GetTemplateEngine();
            int moduleType = ran.Next(3);
            string path = Server.MapPath("~/content/email.html");
            Template.RegisterFilter(typeof(TextFilter));
            string templateText = String.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                templateText = sr.ReadToEnd();
            }

            if (!String.IsNullOrWhiteSpace(templateText))
            {
                //templateText = engine.Render(
                //    templateText,
                //    new User
                //    {
                //        Age = null,
                //        FirstName = "Huang",
                //        Name = "Huangqinglu"
                //    }
                //    );
                Template.NamingConvention = new CSharpNamingConvention();
                var template = Template.Parse(templateText);
                List<User> list = new List<User>();

                for (int i = 0; i < 10; i++)
                {
                    var user = new User
                    {
                        FirstName = "huang_" + i,
                        Name = "qinglu_" + i,
                        Age = 20 + i,
                        CreateDate = DateTime.UtcNow,
                        UtcCreatedOn=DateTime.UtcNow.ToString(),
                        Object = new SubUser
                        {
                            Age = 20 + i,
                            Name = "test_" + i,
                            FirstName = "firname_" + i
                        }
                    };
                    list.Add(user);
                }
                templateText = template.Render(Hash.FromAnonymousObject(new
                {
                    Objects = list
                }));
            }
            return Content(templateText, "text/html");
        }

        public ActionResult Scroll()
        {
            return View();
        }
    }

}