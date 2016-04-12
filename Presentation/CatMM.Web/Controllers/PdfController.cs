using CatMM.Infrastructure.TemplateEngine;
using CatMM.Infrastructure.Utilities;
using DotLiquid;
using DotLiquid.NamingConventions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using TuesPechkin;

namespace CatMM.Web.Controllers
{
    public class PdfController : Controller
    {
        // GET: Pdf
        public ActionResult Index()
        {
            string path = Server.MapPath("~/Views/pdf/pdftemplate.html");
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

            return Content(templateText, MimeMapping.GetMimeMapping("tt.html"));
        }

        public ActionResult Generate()
        {
            ITemplateEngineProvider provider = new DotLiquidTemplateProvider();
            ITemplateEngine engine = provider.GetTemplateEngine();
            string path = Server.MapPath("~/Views/pdf/pdftemplate.html");
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
            byte[] exportFileBytes = PdfUtility.GeneratePdf(templateText);
            string exportFileName = "generate.pdf";
            string contentType = IOUtility.GetContentType(exportFileName);

            return File(exportFileBytes, contentType);
        }

        private static IConverter converter =
            new ThreadSafeConverter(
                new RemotingToolset<PdfToolset>(
                    new Win64EmbeddedDeployment(
                        new TempFolderDeployment())));

        public ActionResult GenerateFromUrl(string url)
        {
            var doc = new HtmlToPdfDocument();
            doc.GlobalSettings.DocumentTitle = "document title";
            string path = Server.MapPath("~/Views/pdf/pdftemplate.html");
            string templateText = String.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                templateText = sr.ReadToEnd();
            }

            doc.Objects.Add(new ObjectSettings
            {
                HtmlText = templateText
            });

            byte[] result = converter.Convert(doc);
            return File(result, "application/pdf");
        }
    }
}