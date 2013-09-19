using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterLikeWebChat.Startup))]
namespace TwitterLikeWebChat
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
