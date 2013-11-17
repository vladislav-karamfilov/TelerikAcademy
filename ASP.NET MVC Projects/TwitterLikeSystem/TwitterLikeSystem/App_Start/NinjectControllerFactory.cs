namespace TwitterLikeSystem.App_Start
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Ninject;
    using TwitterLikeSystem.Data;
    using TwitterLikeSystem.Data.Contracts;

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
            this.ninjectKernel.Bind<ITwitterLikeSystemDbContext>().To<TwitterLikeSystemDbContext>();
            this.ninjectKernel.Bind<ITwitterLikeSystemData>().To<TwitterLikeSystemData>();
        }
    }
}