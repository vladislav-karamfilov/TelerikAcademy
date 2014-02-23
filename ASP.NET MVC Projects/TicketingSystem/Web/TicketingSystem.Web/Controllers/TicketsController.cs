namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using TicketingSystem.Common.Extensions;
    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.ViewModels.Shared;
    using TicketingSystem.Web.ViewModels.Tickets;

    [Authorize]
    public class TicketsController : BaseController
    {
        public TicketsController(ITicketingSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult List()
        {
            this.ViewBag.CategoriesData = this.Data.Categories
                .All()
                .OrderBy(x => x.Id)
                .Select(x => new DropDownItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return this.View();
        }

        [HttpGet]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var allTickets = this.Data.Tickets
                .All()
                .OrderBy(x => x.Id)
                .Select(TicketListItemViewModel.ViewModel);

            return this.Json(allTickets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var ticket = this.Data.Tickets
                .All()
                .Select(TicketDetailsViewModel.ViewModel)
                .FirstOrDefault(x => x.Id == id);
            if (ticket == null)
            {
                return this.HttpNotFound();
            }

            return this.View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(TicketCommentInputViewModel model)
        {
            if (!this.Request.IsAjaxRequest())
            {
                return this.View("PageNotFound");
            }

            if (model != null && this.ModelState.IsValid)
            {
                model.AuthordId = this.User.Identity.GetUserId();

                var commentEntity = model.Entity;
                this.Data.Comments.Add(commentEntity);
                this.Data.SaveChanges();

                return this.PartialView(
                    "DisplayTemplates/TicketCommentViewModel",
                    new TicketCommentViewModel { Author = this.User.Identity.GetUserName(), Content = commentEntity.Content });
            }

            var errorMessage = this.GetModelStateErrors() ?? "Something went wrong...";
            return this.Json(new { errorMessage = errorMessage });
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.InitializeDropDownLists();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketInputViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                model.AuthorId = this.User.Identity.GetUserId();
                var newTicketEntity = model.Entity;
                this.Data.Tickets.Add(newTicketEntity);

                var currentUserId = this.User.Identity.GetUserId();
                var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);
                currentUser.Points++;

                this.Data.SaveChanges();

                this.TempData["CreateSuccessful"] = true;
                return this.RedirectToAction("CreateSuccessful", "Tickets", new { area = string.Empty });
            }

            this.InitializeDropDownLists();
            return this.View(model);
        }

        [HttpGet]
        public ActionResult CreateSuccessful()
        {
            if (this.TempData["CreateSuccessful"] == null)
            {
                return this.HttpNotFound("PageNotFound");
            }

            return this.View();
        }

        private void InitializeDropDownLists()
        {
            this.ViewData["CategoryIdData"] = this.Data.Categories
                .All()
                .Select(x => new DropDownItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            this.ViewData["PriorityIdData"] = Enum.GetValues(typeof(Priority)).Cast<Priority>()
                .Select(x => new DropDownItemViewModel
                {
                    Id = (int)x,
                    Name = x.GetDescription()
                });
        }
    }
}