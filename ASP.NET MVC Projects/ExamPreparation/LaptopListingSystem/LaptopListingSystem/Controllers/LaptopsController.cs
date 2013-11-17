namespace LaptopListingSystem.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using Microsoft.AspNet.Identity;
    using LaptopListingSystem.Data.Contracts;
    using LaptopListingSystem.ViewModels;
    using LaptopListingSystem.Models;
    using System.Text;

    public class LaptopsController : BaseController
    {
        public LaptopsController(ILaptopListingSystemData data)
            : base(data)
        { }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public JsonResult ReadLaptops([DataSourceRequest]DataSourceRequest request)
        {
            var laptopsViewModel = this.Data.Laptops.All().Select(LaptopViewModel.FromModel);
            return Json(laptopsViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var laptopViewModel = this.Data.Laptops.All()
                .Where(l => l.Id == id)
                .Select(FullLaptopViewModel.FromModel)
                .FirstOrDefault();
            if (laptopViewModel == null)
            {
                return HttpNotFound("Laptop not found...");
            }

            var currentUserId = this.User.Identity.GetUserId();
            ViewBag.UserCanVote = !this.Data.Votes.All().Any(v => v.LaptopId == id && v.AuthorId == currentUserId);

            return View("Laptop", laptopViewModel);
        }

        [Authorize]
        public ActionResult Vote(int id)
        {
            var laptop = this.Data.Laptops.GetById(id);
            if (laptop == null)
            {
                return HttpNotFound("Laptop not found...");
            }

            var newVote = new Vote() { AuthorId = this.User.Identity.GetUserId() };
            laptop.Votes.Add(newVote);
            this.Data.SaveChanges();

            var laptopVotesCount = laptop.Votes.Count;
            return Content(laptopVotesCount.ToString());
        }

        [Authorize, ValidateAntiForgeryToken]
        public ActionResult Comment(int id, PostCommentViewModel newPostComment)
        {
            if (newPostComment != null && ModelState.IsValid)
            {
                var laptop = this.Data.Laptops.GetById(id);
                if (laptop == null)
                {
                    return HttpNotFound("Laptop not found...");
                }

                var currentUserId = this.User.Identity.GetUserId();
                var newCommentContent = newPostComment.Content.Trim();
                var newCommentEntity = new Comment() { Content = newCommentContent, AuthorId = currentUserId };
                laptop.Comments.Add(newCommentEntity);
                this.Data.SaveChanges();

                var currentUserUserName = this.User.Identity.GetUserName();
                var newCommentViewModel = new CommentViewModel() { Content = newCommentContent, Author = currentUserUserName };
                return PartialView("_Comment", newCommentViewModel);
            }

            var errorMessages = this.GetErrors(ModelState);
            return PartialView("_Error", errorMessages);
        }

        [Authorize]
        public JsonResult ReadLaptopModels(string text)
        {
            text = text.Trim().ToLower();
            var laptopModels = this.Data.Laptops.All()
                .Where(l => l.Model.ToLower().Contains(text))
                .Select(l => new
                {
                    Model = l.Model
                });

            return Json(laptopModels, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult ReadLaptopManufacturers()
        {
            var laptopManufacturers = this.Data.Manufacturers.All()
                .Select(ManufacturerViewModel.FromModel);

            return Json(laptopManufacturers, JsonRequestBehavior.AllowGet);
        }

        [Authorize, ValidateAntiForgeryToken, ActionName("Search")]
        public ActionResult SearchLaptops([DataSourceRequest]DataSourceRequest request, SubmitSearchViewModel searchViewModel)
        {
            var foundLaptopEntities = this.Data.Laptops.All();
            if (!string.IsNullOrWhiteSpace(searchViewModel.ModelSearch))
            {
                var modelToSearch = searchViewModel.ModelSearch.Trim().ToLower();
                foundLaptopEntities = foundLaptopEntities.Where(l => l.Model.ToLower().Contains(modelToSearch));
            }

            if (searchViewModel.ManufacturerSearch != 0)
            {
                foundLaptopEntities = foundLaptopEntities.Where(l => l.ManufacturerId == searchViewModel.ManufacturerSearch);
            }

            if (searchViewModel.PriceSearch != 0)
            {
                foundLaptopEntities = foundLaptopEntities.Where(l => l.Price <= searchViewModel.PriceSearch);
            }

            var foundLaptopsViewModel = foundLaptopEntities.Select(LaptopViewModel.FromModel).ToList();
            return View(foundLaptopsViewModel);
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