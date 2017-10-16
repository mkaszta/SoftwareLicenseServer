using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoftwareLicenseServer.Startup))]
namespace SoftwareLicenseServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
