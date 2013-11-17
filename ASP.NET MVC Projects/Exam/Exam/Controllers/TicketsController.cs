namespace Exam.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using Exam.Data.Contracts;
    using Exam.Models;
    using Exam.ViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;

    public class TicketsController : BaseController
    {
        public TicketsController(IExamData data)
            : base(data)
        { }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize, HttpGet]
        public ActionResult Create()
        {
            var categories = new List<CategoryViewModel>();
            categories.Add(new CategoryViewModel() { Id = 0, Name = "Select category" });
            categories.AddRange(this.Data.Categories.All()
                .OrderBy(c => c.Id)
                .Select(CategoryViewModel.FromModel)
                .ToList());

            this.ViewData["categories"] = categories;

            this.ViewData["priorities"] = new[]
            {
                new { Id = 0, Name = "Select priority" },
                new { Id = 1, Name = "Low" },
                new { Id = 2, Name = "Medium" },
                new { Id = 3, Name = "High" }
            };

            return View();
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateTicket(FullTicketViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                if (model.PriorityId <= 0 || model.PriorityId > 3)
                {
                    ModelState.AddModelError("PriorityId", "Invalid priority!");
                }

                if (!string.IsNullOrWhiteSpace(model.ScreenshotUrl) && !Regex.IsMatch(model.ScreenshotUrl, GlobalConstants.UrlRegEx))
                {
                    ModelState.AddModelError("ScreenshotUrl", "Invalid URL!");
                }

                var category = this.Data.Categories.GetById(model.CategoryId);
                if (category == null)
                {
                    ModelState.AddModelError("CategoryId", "Category was not found!");
                }

                if (ModelState.IsValid)
                {
                    var userId = this.User.Identity.GetUserId();
                    var newTicket = new Ticket()
                    {
                        AuthorId = userId,
                        Category = category,
                        Description = model.Description,
                        Priority = (Priority)(model.PriorityId - 1),
                        ScreenshotUrl = model.ScreenshotUrl,
                        Title = model.Title
                    };

                    var user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);
                    user.Points++;
                    this.Data.Tickets.Add(newTicket);
                    this.Data.SaveChanges();

                    return RedirectToAction("SuccessfullCreation", "Tickets");
                }
            }

            return RedirectToAction("Create", "Tickets");
        }

        [Authorize]
        public ActionResult SuccessfullCreation()
        {
            return View();
        }

        [Authorize]
        public ActionResult List()
        {
            var categories = new List<CategoryViewModel>();
            categories.Add(new CategoryViewModel() { Id = 0, Name = "Select category" });
            categories.AddRange(this.Data.Categories.All()
                .OrderBy(c => c.Id)
                .Select(CategoryViewModel.FromModel)
                .ToList());

            this.ViewData["categories"] = categories;

            return View();
        }

        [Authorize]
        public JsonResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var ticketsViewModel = this.Data.Tickets.All()
                .OrderBy(t => t.Id)
                .Select(TicketForListViewModel.FromModel);
            return Json(ticketsViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpNotFoundResult("No ticket id provided!");
            }

            var ticket = this.Data.Tickets.All()
                .Where(t => t.Id == id)
                .Select(FullTicketViewModel.FromModel)
                .FirstOrDefault();
            if (ticket == null)
            {
                return new HttpNotFoundResult(
                    "An unexpected error has occurred. The ticket you want to view was not found...");
            }

            return View(ticket);
        }

        [Authorize, ValidateAntiForgeryToken]
        public ActionResult Comment(int id, string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                ModelState.AddModelError("comment", "Comment cannot be empty!");
            }

            if (comment != null && ModelState.IsValid)
            {
                var ticket = this.Data.Tickets.GetById(id);
                if (ticket == null)
                {
                    return new HttpNotFoundResult("Laptop not found...");
                }

                var currentUserId = this.User.Identity.GetUserId();
                var newCommentContent = comment.Trim();
                var newCommentEntity = new Comment() { Content = newCommentContent, AuthorId = currentUserId };
                ticket.Comments.Add(newCommentEntity);
                this.Data.SaveChanges();

                var currentUserUserName = this.User.Identity.GetUserName();
                var newCommentViewModel = new CommentViewModel() { Content = newCommentContent, Author = currentUserUserName };
                return PartialView("_Comment", newCommentViewModel);
            }

            var errorMessages = this.GetErrors(ModelState);
            return PartialView("_Error", errorMessages);
        }

        private string GetErrors(ModelStateDictionary modelState)
        {
            var errorMessages = new StringBuilder();
            foreach (var value in modelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    errorMessages.AppendLine(error.ErrorMessage);
                }
            }

            return errorMessages.ToString();
        }
    }
}