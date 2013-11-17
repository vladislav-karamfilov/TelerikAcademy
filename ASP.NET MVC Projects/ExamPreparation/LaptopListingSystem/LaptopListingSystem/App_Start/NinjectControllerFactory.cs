namespace LaptopListingSystem.App_Start
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using LaptopListingSystem.Data;
    using LaptopListingSystem.Data.Contracts;
    using Ninject;

    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            this.ninjectKernel = new StandardKernel();
            this.AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (controllerType == null) ? null : (IController)this.ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            this.ninjectKernel.Bind<ILaptopListingSystemDbContext>().To<LaptopListingSystemDbContext>();
            this.ninjectKernel.Bind<ILaptopListingSystemData>().To<LaptopListingSystemData>();
        }
    }
}