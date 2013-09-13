namespace SchoolsSystem.Services.DependencyResolvers
{
    using SchoolsSystem.Repositories;
    using SchoolsSystem.Services.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    public class DbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            IUnitOfWork unitOfWork = null;
            if (serviceType == typeof(StudentsController))
            {
                unitOfWork = new DbUnitOfWork();
                return new StudentsController(unitOfWork);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                unitOfWork = new DbUnitOfWork();
                return new SchoolsController(unitOfWork);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose() { }
    }
}