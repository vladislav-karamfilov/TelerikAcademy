namespace Exam.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Exam.Data.Contracts;
    using Exam.Models;
    using Exam.ViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    // [Authorize(Roles = "Administrator")]
    public class CategoriesAdministrationController : KendoGridAdministrationController
    {
        public CategoriesAdministrationController(IExamData data)
            : base(data)
        { }

        public override IEnumerable GetData()
        {
            var categories = this.Data.Categories.All().Select(CategoryViewModel.FromModel);
            return categories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            var results = new List<CategoryViewModel>();
            if (model != null && ModelState.IsValid)
            {
                var newCategory = new Category() { Name = model.Name.Trim() };
                this.Data.Categories.Add(newCategory);
                this.Data.SaveChanges();

                model.Id = newCategory.Id;
                results.Add(model);
            }

            return Json(results.ToDataSourceResult(request));
        }

        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var categoryToUpdate = this.Data.Categories.GetById(model.Id);
                if (categoryToUpdate == null)
                {
                    ModelState.AddModelError(
                        "alert",
                        "An unexpected error has occurred. The category you want to update was not found...");
                    return Json(ModelState.ToDataSourceResult());
                }

                categoryToUpdate.Name = model.Name;
                this.Data.SaveChanges();

                if (ModelState.IsValid)
                {
                    return Json(new object());
                }
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var categoryToDelete = this.Data.Categories.GetById(model.Id);
                if (categoryToDelete == null)
                {
                    ModelState.AddModelError(
                        "alert",
                        "An unexpected error has occurred. The category you want to delet was not found...");
                    return Json(ModelState.ToDataSourceResult());
                }

                foreach (var ticket in categoryToDelete.Tickets.ToList())
                {
                    foreach (var comment in ticket.Comments.ToList())
                    {
                        this.Data.Comments.Delete(comment);
                    }

                    this.Data.Tickets.Delete(ticket);
                }

                this.Data.Categories.Delete(categoryToDelete);
                this.Data.SaveChanges();
            }

            return Json(new object());
        }
    }
}