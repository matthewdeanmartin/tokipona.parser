using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoSite.Startup))]
namespace DemoSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
