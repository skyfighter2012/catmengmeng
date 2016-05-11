using CatMM.Infrastructure.TemplateEngine;
using CatMM.Infrastructure.Utilities;
using DotLiquid;
using DotLiquid.NamingConventions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using CatMM.Infrastructure.PdfGenerator;
using CatMM.Infrastructure.PdfGenerator.WkHtmlToX;

namespace CatMM.Web.Controllers
{
    public class PdfController : BaseController
    {
        private IPdfGenerator generator = new PdfGenerator();

        // GET: Pdf
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Generate()
        {


            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\wkhtmltox");

            ITemplateEngineProvider provider = new DotLiquidTemplateProvider();
            ITemplateEngine engine = provider.GetTemplateEngine();
            string path = Server.MapPath("~/Views/pdf/pdftemplate.html");
            string headerPath = Server.MapPath("~/Views/Pdf/pdfheader.html");
            string footerPath = Server.MapPath("~/Views/Pdf/pdffooter.html");
            string templateText = String.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                templateText = sr.ReadToEnd();
            }

            if (!String.IsNullOrWhiteSpace(templateText))
            {
                Template.NamingConvention = new CSharpNamingConvention();
                var template = Template.Parse(templateText);
                templateText = template.Render();
            }

            string headerHtml = String.Empty;
            using (StreamReader sr = new StreamReader(headerPath))
            {
                headerHtml = sr.ReadToEnd();
            }

            string footerHtml = String.Empty;
            using (StreamReader sr = new StreamReader(footerPath))
            {
                footerHtml = sr.ReadToEnd();
            }


            byte[] exportFileBytes = generator.GenerateByHtml(templateText, "title");
            string exportFileName = "generate.pdf";
            string contentType = IOUtility.GetContentType(exportFileName);

            return File(exportFileBytes, contentType);
        }



        //public ActionResult GenerateFromUrl(string url)
        //{
        //    string headerHtml = RenderPartialViewToString("Index");
        //    var doc = new HtmlToPdfDocument();
        //    doc.GlobalSettings = new GlobalSettings
        //    {
        //        Margins = new MarginSettings
        //        {
        //            Left = 0,
        //            Right = 0
        //        },
        //        DocumentTitle = "doctitle"
        //    };
        //    doc.Objects.Add(new ObjectSettings
        //    {
        //        PageUrl = url,
        //        HeaderSettings = new HeaderSettings
        //       {
        //           HtmlUrl = @"D:\Github\catmengmeng\Presentation\CatMM.Web\Views\Pdf\pdfheader.html"
        //       },
        //        WebSettings = new WebSettings
        //        {
        //            EnableIntelligentShrinking = false,
        //            EnableJavascript = true
        //        }
        //    });

        //    doc.Objects.Add(new ObjectSettings
        //    {
        //        PageUrl = "www.baidu.com"
        //    });
        //    byte[] result = null;

        //    try
        //    {
        //        result = converter.Convert(doc);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return File(result, "application/pdf");
        //}

        public ActionResult Header()
        {
            return PartialView();
        }
    }
}