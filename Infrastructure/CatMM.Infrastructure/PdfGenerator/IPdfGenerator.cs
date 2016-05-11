using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.PdfGenerator
{
    /// <summary>
    /// Pdf generator interface
    /// </summary>
    /// <summary>
    /// Pdf generator interface
    /// </summary>
    public interface IPdfGenerator
    {
        /// <summary>
        /// Initialize
        /// </summary>
        void Initialize();

        /// <summary>
        /// Generate by html
        /// </summary>
        /// <param name="pageHtmls"></param>
        /// <param name="docTitle"></param>
        /// <param name="headerHtml"></param>
        /// <returns></returns>
        byte[] GenerateByHtml(List<string> pageHtmls, string docTitle, string headerHtml = null, string footerHtml = null);

        /// <summary>
        /// Generate by html
        /// </summary>
        /// <param name="pageHtml"></param>
        /// <param name="docTitle"></param>
        /// <param name="headerHtml"></param>
        /// <returns></returns>
        byte[] GenerateByHtml(string pageHtml, string docTitle = null, string headerHtml = null, string footerHtml = null);

        /// <summary>
        /// Generate by url
        /// </summary>
        /// <param name="pageUrls"></param>
        /// <param name="docTitle"></param>
        /// <param name="headerHtml"></param>
        /// <returns></returns>
        byte[] GenerateByUrl(List<string> pageUrls, string docTitle, string headerHtml = null, string footerHtml = null);

        /// <summary>
        /// Generate by url
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <param name="docTitle"></param>
        /// <param name="headerHtml"></param>
        /// <returns></returns>
        byte[] GenerateByUrl(string pageUrl, string docTitle = null, string headerHtml = null, string footerHtml = null);
    }
}
