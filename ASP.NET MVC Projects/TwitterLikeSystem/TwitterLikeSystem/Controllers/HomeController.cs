namespace TwitterLikeSystem.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using TwitterLikeSystem.Data.Contracts;
    using TwitterLikeSystem.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(ITwitterLikeSystemData data)
            : base(data)
        { }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadTweets([DataSourceRequest]DataSourceRequest request)
        {
            var tweets = this.Data.Tweets.All()
                .OrderByDescending(t => t.DatePubished)
                .Select(TweetViewModel.FromModel);
            return Json(tweets.ToDataSourceResult(request));
        }
    }
}