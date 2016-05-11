using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatMM.Web.Controllers
{
    public class GoogleController : Controller
    {
        private static string GoogleApiKey = ConfigurationManager.AppSettings["GoogleApiKey"];

        public ActionResult StaticMap()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}