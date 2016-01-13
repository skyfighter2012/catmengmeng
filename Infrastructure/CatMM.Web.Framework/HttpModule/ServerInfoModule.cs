using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CatMM.Web.Framework.HttpModule
{
    /// <summary>
    /// Server info module
    /// </summary>
    public class ServerInfoModule : IHttpModule
    {
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Init 
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.EndRequest += EndRequest;
            context.PreSendRequestHeaders += context_PreSendRequestHeaders;
        }

        void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            var response = application.Response;
            string[] removeHeaders = { "X-AspNet-Version", "X-AspNetMvc-Version", "X-HTML-Minification-Powered-By", "X-Powered-By" };
            response.Headers["Server"] = "unknown";
            removeHeaders.All(c => { response.Headers.Remove(c); return true; });
        }

        /// <summary>
        /// End request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            var response = application.Response;
            
        }
    }
}
