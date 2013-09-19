using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PollSystem.Startup))]
namespace PollSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
