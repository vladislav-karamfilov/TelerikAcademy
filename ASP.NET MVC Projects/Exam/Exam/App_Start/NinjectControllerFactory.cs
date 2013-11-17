namespace Exam.App_Start
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Exam.Data;
    using Exam.Data.Contracts;
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
            this.ninjectKernel.Bind<IExamDbContext>().To<ExamDbContext>();
            this.ninjectKernel.Bind<IExamData>().To<ExamData>();
        }
    }
}