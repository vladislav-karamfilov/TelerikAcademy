using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaptopListingSystem.Startup))]
namespace LaptopListingSystem
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
