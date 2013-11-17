using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exam.Startup))]
namespace Exam
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
