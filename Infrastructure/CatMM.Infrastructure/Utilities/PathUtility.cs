using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CatMM.Infrastructure.Utilities
{
    /// <summary>
    /// Path utility
    /// </summary>
    public class PathUtility
    {
        /// <summary>
        /// Map path
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public static string MapPath(string virtualPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(virtualPath);
            }
            else
            {
                return ToPhysicalPath(virtualPath);
            }
        }

        /// <summary>
        /// To physical path
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public static string ToPhysicalPath(string virtualPath)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            string path = virtualPath.TrimStart('~', '/');
            path = path.Replace('/', '\\');
            return Path.Combine(basePath, path);
        }
    }
}
