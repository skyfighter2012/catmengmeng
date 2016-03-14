using System.Web;
using System.Web.Optimization;

namespace CatMM.Web
{
    /// <summary>
    /// Bundle config
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Register bundles
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/css/core").Include(
                "~/assets/plugins/pace/pace.css",
                "~/assets/plugins/bootstrap/css/bootstrap.css",
                "~/assets/css/text.css"
                ));

            bundles.Add(
                new ScriptBundle("~/script/core").Include(
                "~/assets/scripts/utility.js",
                "~/assets/plugins/pace/pace.min.js",
                "~/assets/plugins/jquery-1.12.0.min.js",
                "~/assets/plugins/bootstrap/js/bootstrap.js"
                ));
        }
    }
}
