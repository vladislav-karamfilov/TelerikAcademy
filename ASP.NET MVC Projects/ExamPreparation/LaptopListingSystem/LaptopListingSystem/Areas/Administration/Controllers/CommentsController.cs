namespace LaptopListingSystem.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using LaptopListingSystem.Areas.Administration.ViewModels;
    using LaptopListingSystem.Controllers;
    using LaptopListingSystem.Data.Contracts;
    
    public class CommentsController : KendoGridAdministrationController
    {
        public CommentsController(ILaptopListingSystemData data)
            : base(data)
        { }

        public ActionResult Index()
        {
            return View();
        }

        public override IEnumerable GetData()
        {
            var data = this.Data.Comments.All().Select(CommentViewModel.FromModel);
            return data;
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CommentViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var commentToUpdate = this.Data.Comments.GetById(model.Id);
                if (commentToUpdate == null)
                {
                    ModelState.AddModelError(
                        "alert",
                        "An unexpected error has occurred. The comment you want to update was not found...");
                    return Json(ModelState.ToDataSourceResult());
                }

                commentToUpdate.Content = model.Content.Trim();

                this.Data.SaveChanges();
                return Json(new object());
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, CommentViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var commentToDelete = this.Data.Comments.GetById(model.Id);
                if (commentToDelete == null)
                {
                    ModelState.AddModelError(
                        "alert",
                        "An unexpected error has occurred. The comment you want to delete was not found...");
                    return Json(ModelState.ToDataSourceResult());
                }

                this.Data.Comments.Delete(commentToDelete);
                this.Data.SaveChanges();
            }

            return Json(new object());
        }
    }
}