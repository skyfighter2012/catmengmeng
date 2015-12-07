using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatMM.Web.Startup))]
namespace CatMM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
