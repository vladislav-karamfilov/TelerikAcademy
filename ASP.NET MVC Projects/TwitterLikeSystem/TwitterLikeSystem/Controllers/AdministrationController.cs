namespace TwitterLikeSystem.Controllers
{
    using System.Web.Mvc;
    using TwitterLikeSystem.Data.Contracts;

    [Authorize(Roles = "Administrator")]
    public class AdministrationController : BaseController
    {
        public AdministrationController(ITwitterLikeSystemData data)
            : base(data)
        { }
    }
}