using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(L12M2.Startup))]
namespace L12M2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
