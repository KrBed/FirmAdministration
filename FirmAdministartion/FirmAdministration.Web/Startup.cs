using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirmAdministration.Web.Startup))]
namespace FirmAdministration.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
