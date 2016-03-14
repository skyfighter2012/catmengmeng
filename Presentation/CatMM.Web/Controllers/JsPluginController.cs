using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatMM.Web.Controllers
{
    public class JsPluginController : Controller
    {
        // GET: JsPlugin
        public ActionResult Index()
        {
            return RedirectToAction("FitImage");
        }

        public ActionResult FitImage()
        {
            return View();
        }
    }
}