using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TelerikAcademyForum.Data;
using TelerikAcademyForum.Data.Migrations;

namespace TelerikAcademyForum.Services
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TelerikAcademyForumContext, Configuration>());
        }
    }
}