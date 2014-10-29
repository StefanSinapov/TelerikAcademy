using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamSkeleton.Web.Startup))]
namespace ExamSkeleton.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
