namespace Exam.Controllers
{
    using System.Web.Mvc;
    using Exam.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController(IExamData data)
        {
            this.Data = data;
        }

        protected IExamData Data { get; private set; }
    }
}