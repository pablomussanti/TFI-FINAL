using Microsoft.Owin;
using Owin;
using Decopack.IoC.App_Start;
using WebActivatorEx;

[assembly: OwinStartupAttribute(typeof(Decopack.Web.Startup))]
[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace Decopack.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
