using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediApp.Startup))]
namespace MediApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
