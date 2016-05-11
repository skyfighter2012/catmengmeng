using CatMM.Infrastructure.TemplateEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatMM.Web.Models;

namespace CatMM.Web.Controllers
{
    public class TemplateController : BaseController
    {
        // GET: Template
        public ActionResult Index()
        {


            List<User> list = new List<User>();
            // Template model
            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    FirstName = "huang_" + i,
                    Name = "qinglu_" + i,
                    Age = 20 + i,
                    CreateDate = DateTime.UtcNow,
                    UtcCreatedOn = DateTime.UtcNow.ToString(),
                    Object = new SubUser
                    {
                        Age = 20 + i,
                        Name = "test_" + i,
                        FirstName = "firname_" + i
                    }
                };
                list.Add(user);
            }

            TemplateModel model = new TemplateModel
            {
                Users = list
            };

            string indexPath = Server.MapPath("~/Templates/index.liquid");
            string templateText = String.Empty;
            using (StreamReader sr = new StreamReader(indexPath))
            {
                templateText = sr.ReadToEnd();
            }

            templateText = _templateEngine.Render(templateText, model);
            return Content(templateText, "text/html");
        }
    }

    public class TemplateModel
    {
        public List<User> Users { get; set; }
    }
}