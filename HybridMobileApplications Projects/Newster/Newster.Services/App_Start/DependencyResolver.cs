namespace Newster.Services.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using Newster.Data;
    using Newster.Services.Controllers;

    public class DbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            var dbContext = new NewsterDbContext();
            var data = new NewsterData(dbContext);
            if (serviceType == typeof(UsersController))
            {
                return new UsersController(data);
            }
            else if (serviceType == typeof(NewsArticlesController))
            {
                return new NewsArticlesController(data);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new object[] { };
        }

        public void Dispose()
        { }
    }
}