using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CatMM.Infrastructure.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// To absolute url
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToAbsoluteUrl(this string path)
        {
            var url = path;
            if (null != HttpContext.Current&&!url.StartsWith("http"))
            {
                var uri = HttpContext.Current.Request.Url;
                url = String.Format("{0}://{1}/{2}", uri.Scheme, uri.Host, path.TrimStart('~', '/'));
            }
            return url;
        }
    }
}
