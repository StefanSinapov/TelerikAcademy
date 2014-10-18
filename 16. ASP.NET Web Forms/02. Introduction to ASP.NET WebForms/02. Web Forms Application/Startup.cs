using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.Web_Forms_Application.Startup))]
namespace _02.Web_Forms_Application
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
