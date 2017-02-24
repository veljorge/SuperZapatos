using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperZapatosSln.Startup))]
namespace SuperZapatosSln
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
