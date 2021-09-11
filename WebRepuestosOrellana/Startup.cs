using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRepuestosOrellana.Startup))]
namespace WebRepuestosOrellana
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
