using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NAA.Web.Startup))]
namespace NAA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
