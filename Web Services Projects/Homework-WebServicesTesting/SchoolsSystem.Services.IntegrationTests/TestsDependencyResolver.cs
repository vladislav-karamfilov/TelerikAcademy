namespace SchoolsSystem.Services.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using SchoolsSystem.Repositories;
    using SchoolsSystem.Services.Controllers;

    class TestsDependencyResolver<T> : IDependencyResolver where T : class
    {
        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get { return this.unitOfWork; }

            set { this.unitOfWork = value; }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(this.unitOfWork);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(this.unitOfWork);
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
