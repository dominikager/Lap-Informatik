using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lagerverwaltung.Startup))]
namespace Lagerverwaltung
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
