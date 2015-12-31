using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatMM.Web.Tests.Startup))]
namespace CatMM.Web.Tests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
