using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormelOne.Startup))]
namespace FormelOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
