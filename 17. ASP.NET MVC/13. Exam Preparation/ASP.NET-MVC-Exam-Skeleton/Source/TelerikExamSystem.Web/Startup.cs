using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelerikExamSystem.Web.Startup))]

namespace TelerikExamSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
