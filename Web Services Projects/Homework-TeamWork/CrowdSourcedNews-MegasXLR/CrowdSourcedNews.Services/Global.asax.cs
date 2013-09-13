using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CrowdSourcedNews.Data;
using CrowdSourcedNews.Services.DependencyResolvers;
using System.Data.Entity;
using CrowdSourcedNews.Data.Migrations;

namespace CrowdSourcedNews.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CrowdSourcedNewsContext context = new CrowdSourcedNewsContext();
            
            GlobalConfiguration.Configuration.DependencyResolver = new DbDependencyResolver(context);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CrowdSourcedNewsContext, Configuration>());
            context.Users.Add(new Models.User()
            {
                Nickname = "Doncho Minkov",
                AuthCode = "96b828b4cc79f50bf8faef6e7b4a1dcfb356dea6",
                Username = "Dodo"
            });
            context.SaveChanges();
        }
    }
}