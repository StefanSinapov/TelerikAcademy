﻿using Articles.Web;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Articles.Web
{
    using Owin;

    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            this.ConfigureAuth(app);
        }
    }
}
