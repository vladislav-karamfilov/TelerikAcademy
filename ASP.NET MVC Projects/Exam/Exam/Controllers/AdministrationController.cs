namespace Exam.Controllers
{
    using System.Web.Mvc;
    using Exam.Data.Contracts;

    // [Authorize(Roles = "Administrator")]
    public class AdministrationController : BaseController
    {
        public AdministrationController(IExamData data)
            : base(data)
        { }
    }
}