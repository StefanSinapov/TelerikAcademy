using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01.ASP.NET_Web_Forms.Startup))]
namespace _01.ASP.NET_Web_Forms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
