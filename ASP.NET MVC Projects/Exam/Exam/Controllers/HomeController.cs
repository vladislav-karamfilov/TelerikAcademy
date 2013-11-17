namespace Exam.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using Exam.Data.Contracts;
    using Exam.ViewModels;

    public class HomeController : BaseController
    {
        private const int TicketsToShowCount = 6;
        private const int HoursToCache = 1;
        private const string CachedTickets = "MostCommentedTickets";

        public HomeController(IExamData data)
            : base(data)
        { }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache[CachedTickets] == null)
            {
                var mostCommentedTicketsViewModel = this.Data.Tickets.All()
                    .OrderByDescending(t => t.Comments.Count)
                    .Take(TicketsToShowCount)
                    .Select(TicketViewModel.FromModel)
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

            return View(this.HttpContext.Cache[CachedTickets]);
        }
    }
}