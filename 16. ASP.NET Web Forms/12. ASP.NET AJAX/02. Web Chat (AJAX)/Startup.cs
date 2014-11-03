using Microsoft.Owin;

using WebChat;

[assembly: OwinStartup(typeof(Startup))]
namespace WebChat
{
    using Owin;

    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            this.ConfigureAuth(app);
        }
    }
}
