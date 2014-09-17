using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Ninject;
using System.Reflection;
using StudentSystem.Data;

[assembly: OwinStartup(typeof(StudentSystem.WebAPI.Startup))]

namespace StudentSystem.WebAPI
{
    using Data.Contracts;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IStudentSystemData>().To<StudentSystemData>()
                .WithConstructorArgument("context",
                    c => new StudentSystemContext());
        }
    }
}
