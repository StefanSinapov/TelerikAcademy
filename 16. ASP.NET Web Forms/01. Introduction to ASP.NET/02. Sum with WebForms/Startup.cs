using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.Sum_with_WebForms.Startup))]
namespace _02.Sum_with_WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
