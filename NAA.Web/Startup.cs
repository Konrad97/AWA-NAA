using Microsoft.Owin;
using NAA.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace NAA.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}