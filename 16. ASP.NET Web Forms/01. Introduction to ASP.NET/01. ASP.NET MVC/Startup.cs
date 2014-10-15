using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01.ASP.NET_MVC.Startup))]
namespace _01.ASP.NET_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
