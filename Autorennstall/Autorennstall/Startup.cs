using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autorennstall.Startup))]
namespace Autorennstall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
