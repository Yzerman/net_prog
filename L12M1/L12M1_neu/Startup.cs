using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(L12M1_neu.Startup))]
namespace L12M1_neu
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
