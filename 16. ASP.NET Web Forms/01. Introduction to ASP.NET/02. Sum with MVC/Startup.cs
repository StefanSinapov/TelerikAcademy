using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.Sum_with_MVC.Startup))]
namespace _02.Sum_with_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
