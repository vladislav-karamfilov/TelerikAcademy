namespace LaptopListingSystem.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using LaptopListingSystem.Data.Contracts;
    using LaptopListingSystem.ViewModels;

    public class HomeController : BaseController
    {
        private const string LaptopsViewModel = "LaptopsViewModel";

        public HomeController(ILaptopListingSystemData data)
            : base(data)
        { }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache[LaptopsViewModel] == null)
            {
                var laptopsViewModel = this.Data.Laptops
                    .GetTopLaptopsByTotalVotes(6)
                    .Select(LaptopViewModel.FromModel)
                    .ToList();

                this.HttpContext.Cache.Add(
                    LaptopsViewModel,
                    laptopsViewModel,
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return View(this.HttpContext.Cache[LaptopsViewModel]);
        }
    }
}