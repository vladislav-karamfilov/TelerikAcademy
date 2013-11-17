namespace LaptopListingSystem.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using LaptopListingSystem.Controllers;
    using LaptopListingSystem.Data.Contracts;
    using LaptopListingSystem.Models;
    using LaptopListingSystem.ViewModels;

    public class ManufacturersController : KendoGridAdministrationController
    {
        public ManufacturersController(ILaptopListingSystemData data)
            : base(data)
        { }

        public override IEnumerable GetData()
        {
            var data = this.Data.Manufacturers.All().Select(ManufacturerViewModel.FromModel);
            return data;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ManufacturerViewModel model)
        {
            var results = new List<ManufacturerViewModel>();
            if (model != null && ModelState.IsValid)
            {
                var manufacturerNameLowerCase = model.Name.Trim().ToLower();
                if (this.Data.Manufacturers.All().Any(m => m.Name.ToLower() == manufacturerNameLowerCase))
                {
                    ModelState.AddModelError("Name", "There's already a manufacturer with this name!");
                    return Json(ModelState.ToDataSourceResult());
                }

                var newManufacturer = new Manufacturer() { Name = model.Name.Trim() };
                this.Data.Manufacturers.Add(newManufacturer);
                this.Data.SaveChanges();

                model.Id = newManufacturer.Id;
                results.Add(model);
            }

            return Json(results.ToDataSourceResult(request));
        }

        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ManufacturerViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var manufacturerToUpdate = this.Data.Manufacturers.GetById(model.Id);
                if (manufacturerToUpdate == null)
                {
                    ModelState.AddModelError(
                        "alert",
                        "An unexpected error has occurred. The manufacturer you want to update was not found...");
                    return Json(ModelState.ToDataSourceResult());
                }

                var manufacturerNameLowerCase = model.Name.Trim().ToLower();
                if (manufacturerToUpdate.Name.ToLower() != manufacturerNameLowerCase)
                {
                    if (this.Data.Manufacturers.All().Any(m => m.Name.ToLower() == manufacturerNameLowerCase))
                    {
                        ModelState.AddModelError("Name", "There's already a manufacturer with this name!");
                    }
                    else
                    {
                        manufacturerToUpdate.Name = model.Name.Trim();
                        this.Data.SaveChanges();
                    }
                }

                if (ModelState.IsValid)
                {
                    return Json(new object());
                }
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ManufacturerViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var manufacturerToDelete = this.Data.Manufacturers.GetById(model.Id);
                if (manufacturerToDelete == null)
                {
                    ModelState.AddModelError(
                        "alert",
                        "An unexpected error has occurred. The manufacturer you want to delet was not found...");
                    return Json(ModelState.ToDataSourceResult());
                }

                foreach (var laptop in manufacturerToDelete.Laptops.ToList())
                {
                    foreach (var vote in laptop.Votes.ToList())
                    {
                        this.Data.Votes.Delete(vote);
                    }

                    foreach (var comment in laptop.Comments.ToList())
                    {
                        this.Data.Comments.Delete(comment);
                    }

                    this.Data.Laptops.Delete(laptop);
                }

                this.Data.Manufacturers.Delete(manufacturerToDelete);
                this.Data.SaveChanges();
            }

            return Json(new object());
        }
    }
}
