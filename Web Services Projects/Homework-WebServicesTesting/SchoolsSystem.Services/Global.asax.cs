namespace SchoolsSystem.Services
{
    using SchoolsSystem.Data;
    using SchoolsSystem.Data.Migrations;
    using SchoolsSystem.Services.DependencyResolvers;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.DependencyResolver = new DbDependencyResolver();

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SchoolsSystemContext, Configuration>());
        }
    }
}