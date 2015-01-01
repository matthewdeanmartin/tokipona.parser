using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EsperantoTools.Startup))]
namespace EsperantoTools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
