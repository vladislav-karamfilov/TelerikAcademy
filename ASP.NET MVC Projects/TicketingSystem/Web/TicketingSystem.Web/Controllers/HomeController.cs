namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private const int TicketsToShowCount = 6;
        private const int HoursToCache = 1;
        private const string CachedTickets = "MostCommentedTickets";

        public HomeController(ITicketingSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (this.HttpContext.Cache[CachedTickets] == null)
            {
                var mostCommentedTicketsViewModel = this.Data.Tickets
                    .All()
                    .OrderByDescending(t => t.Comments.Count)
                    .Take(TicketsToShowCount)
                    .Select(DisplayTicketViewModel.ViewModel)
                    .ToList();

                this.HttpContext.Cache.Add(
                    CachedTickets,
                    mostCommentedTicketsViewModel,
                    null,
                    DateTime.Now.AddHours(HoursToCache),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return this.View(this.HttpContext.Cache[CachedTickets]);
        }
    }
}