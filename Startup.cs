using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EB.Startup))]
namespace EB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
