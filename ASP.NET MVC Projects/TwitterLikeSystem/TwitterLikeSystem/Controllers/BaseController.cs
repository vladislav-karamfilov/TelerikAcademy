namespace TwitterLikeSystem.Controllers
{
    using System.Web.Mvc;
    using TwitterLikeSystem.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController(ITwitterLikeSystemData data)
        {
            this.Data = data;
        }

        protected ITwitterLikeSystemData Data { get; private set; }
    }
}