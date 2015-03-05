using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(appProyectoFinal.Startup))]
namespace appProyectoFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
