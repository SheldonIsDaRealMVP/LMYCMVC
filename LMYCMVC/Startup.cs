using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMYCMVC.Startup))]
namespace LMYCMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
