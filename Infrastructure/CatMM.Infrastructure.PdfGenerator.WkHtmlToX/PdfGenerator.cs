using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuesPechkin;

namespace CatMM.Infrastructure.PdfGenerator.WkHtmlToX
{
    /// <summary>
    /// Pdf generator
    /// </summary>
    public class PdfGenerator : IPdfGenerator
    {
        private static IConverter _pdfConverter = new ThreadSafeConverter(
                new RemotingToolset<PdfToolset>(
                    new StaticDeployment(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\wkhtmltox"))));

        private static string tempFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\wkhtmltox\temp");

        /// <summary>
        /// Contructor
        /// </summary>
        static PdfGenerator()
        {
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            ClearTempFolder();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PdfGenerator()
        {
            this.Initialize();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// Generate by urls
        /// </summary>
        /// <param name="pageHtmls"></param>
        /// <param name="docTitle"></param>
        /// <param name="headerUrl"></param>
        /// <returns></returns>
        public byte[] GenerateByHtml(List<string> pageHtmls, string docTitle, string headerHtml = null, string footerHtml = null)
        {
            HtmlToPdfDocument doc = new HtmlToPdfDocument();
            doc.GlobalSettings.DocumentTitle = docTitle;
            doc.GlobalSettings.OutputFormat = GlobalSettings.DocumentOutputFormat.PDF;
            doc.GlobalSettings.PaperSize = new PechkinPaperSize("210mm", "297mm");
            string headerHtmlUrl = String.Empty;
            if (!String.IsNullOrEmpty(headerHtml))
            {
                headerHtmlUrl = CreateLocalHtmlFile(WrappperHtml(headerHtml));
            }

            string footerHtmlUrl = String.Empty;
            if (!String.IsNullOrEmpty(footerHtml))
            {
                footerHtmlUrl = CreateLocalHtmlFile(WrappperHtml(footerHtml));
            }

            foreach (string pageHtml in pageHtmls)
            {
                var objSetting = new ObjectSettings { HtmlText = WrappperHtml(pageHtml) };
                if (!String.IsNullOrEmpty(headerHtml))
                {
                    objSetting.HeaderSettings.HtmlUrl = headerHtmlUrl;
                }


                if (!String.IsNullOrEmpty(footerHtml))
                {
                    objSetting.FooterSettings.HtmlUrl = footerHtmlUrl;
                }

                objSetting.WebSettings.PrintMediaType = true;
                objSetting.WebSettings.EnablePlugins = true;
                objSetting.WebSettings.EnableIntelligentShrinking = true;
                objSetting.LoadSettings.RenderDelay = 1000;

                doc.Objects.Add(objSetting);
            }

            byte[] fileBytes = Generate(doc);
            if (!String.IsNullOrEmpty(headerHtmlUrl))
            {
                DeleteTempFile(headerHtmlUrl);
            }

            return fileBytes;
        }

        /// <summary>
        /// Generate by urls
        /// </summary>
        /// <param name="pageUrls"></param>
        /// <param name="docTitle"></param>
        /// <param name="headerUrl"></param>
        /// <returns></returns>
        public byte[] GenerateByUrl(List<string> pageUrls, string docTitle, string headerHtml = null, string footerHtml = null)
        {
            HtmlToPdfDocument doc = new HtmlToPdfDocument();
            doc.GlobalSettings.DocumentTitle = docTitle;
            string headerHtmlUrl = String.Empty;
            if (!String.IsNullOrEmpty(headerHtml))
            {
                headerHtmlUrl = CreateLocalHtmlFile(WrappperHtml(headerHtml));
            }

            string footerHtmlUrl = String.Empty;
            if (!String.IsNullOrEmpty(footerHtml))
            {
                footerHtmlUrl = CreateLocalHtmlFile(WrappperHtml(footerHtml));
            }

            foreach (string pageUrl in pageUrls)
            {
                var objSetting = new ObjectSettings { PageUrl = pageUrl };
                if (!String.IsNullOrEmpty(headerHtmlUrl))
                {
                    objSetting.HeaderSettings.HtmlUrl = headerHtmlUrl;
                }

                if (!String.IsNullOrEmpty(footerHtml))
                {
                    objSetting.FooterSettings.HtmlUrl = footerHtmlUrl;
                }

                doc.Objects.Add(objSetting);
            }

            byte[] fileBytes = Generate(doc);
            if (!String.IsNullOrEmpty(headerHtmlUrl))
            {
                DeleteTempFile(headerHtmlUrl);
            }

            return fileBytes;
        }

        /// <summary>
        /// Generate by html
        /// </summary>
        /// <param name="pageHtml"></param>
        /// <param name="docTitle"></param>
        /// <param name="headerUrl"></param>
        /// <returns></returns>
        public byte[] GenerateByHtml(string pageHtml, string docTitle = null, string headerHtml = null, string footerHtml = null)
        {
            return GenerateByHtml(new List<string> { pageHtml }, docTitle, headerHtml, footerHtml);
        }

        /// <summary>
        /// Generate by url
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <param name="docTitle"></param>
        /// <param name="headerUrl"></param>
        /// <returns></returns>
        public byte[] GenerateByUrl(string pageUrl, string docTitle = null, string headerHtml = null, string footerHtml = null)
        {
            return GenerateByUrl(new List<string> { pageUrl }, docTitle, headerHtml, footerHtml);
        }

        /// <summary>
        /// Delete temp file
        /// </summary>
        /// <param name="fullFileName"></param>
        private static void DeleteTempFile(string fullFileName)
        {
            try
            {
                File.Delete(fullFileName);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Clear temp folder
        /// </summary>
        private static void ClearTempFolder()
        {
            if (Directory.Exists(tempFolder))
            {
                string[] tempFiles = Directory.GetFiles(tempFolder, "*.*", SearchOption.AllDirectories);
                if (null != tempFiles && tempFiles.Length > 0)
                {
                    foreach (string tempFileName in tempFiles)
                    {
                        DeleteTempFile(tempFileName);
                    }
                }
            }
        }

        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private byte[] Generate(HtmlToPdfDocument document)
        {
            byte[] fileBytes = null;
            try
            {
                fileBytes = _pdfConverter.Convert(document);
            }
            catch (Exception ex)
            {
            }

            return fileBytes;
        }

        /// <summary>
        /// Wrapper html
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string WrappperHtml(string html)
        {
            return String.Format(@"<!DOCTYPE html><html><head><meta charset = ""UTF-8"" /><meta name=""renderer"" content=""webkit|ie-comp|ie-stand""><meta name=""viewport"" content=""width=device-width, height=device-height, initial-scale=1, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no""></head><body>{0}</body></html>", html);
        }

        /// <summary>
        /// Create local html file
        /// </summary>
        /// <returns></returns>
        private string CreateLocalHtmlFile(string html)
        {
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            string fullFilName = Path.Combine(tempFolder, String.Format("{0}.html", Guid.NewGuid().ToString()));
            using (FileStream stream = new FileStream(fullFilName, FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(stream, Encoding.Default))
                {
                    sw.Write(html);
                }
            }

            return fullFilName;
        }
    }
}
