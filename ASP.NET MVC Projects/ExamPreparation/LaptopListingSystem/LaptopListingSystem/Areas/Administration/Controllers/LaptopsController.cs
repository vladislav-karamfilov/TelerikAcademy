namespace LaptopListingSystem.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using LaptopListingSystem.Areas.Administration.ViewModels;
    using LaptopListingSystem.Controllers;
    using LaptopListingSystem.Data.Contracts;
    using LaptopListingSystem.Models;

    public class LaptopsController : KendoGridAdministrationController
    {
        public LaptopsController(ILaptopListingSystemData data)
            : base(data)
        { }

        public override IEnumerable GetData()
        {
            var data = this.Data.Laptops.All().Select(LaptopViewModel.FromModel);
            return data;
        }

        public ActionResult Index()
        {
            this.ViewBag.Manufacturers = this.Data.Manufacturers.All()
                .Select(LaptopListingSystem.ViewModels.ManufacturerViewModel.FromModel)
                .ToList();

            return View();
        }

        public ActionResult Create([DataSourceRequest]DataSourceRequest request, LaptopViewModel laptop)
        {
            var results = new List<LaptopViewModel>();
            if (laptop != null && ModelState.IsValid)
            {
                var newLaptop = new Laptop()
                {
                    Model = laptop.Model.Trim(),
                    HardDiskCapacity = laptop.HardDiskCapacity,
                    ImageUrl = laptop.ImageUrl,
                    ManufacturerId = laptop.ManufacturerId,
                    MonitorSize = laptop.MonitorSize,
                    Price = laptop.Price,
                    RamCapacity = laptop.RamCapacity
                };

                this.Data.Laptops.Add(newLaptop);
                this.Data.SaveChanges();

                results.Add(laptop);
            }

            return Json(results.ToDataSourceResult(request));
        }

        public ActionResult Update([DataSourceRequest]DataSourceRequest request, LaptopViewModel laptop)
        {
            if (laptop != null && ModelState.IsValid)
            {
                var laptopToUpdate = this.Data.Laptops.GetById(laptop.Id);
                if (laptopToUpdate == null)
                {
                    ModelState.AddModelError(
                        "alert",
                        "An unexpected error has occurred. The laptop you want to update was not found...");
                    return Json(ModelState.ToDataSourceResult());
                }

                laptopToUpdate.Model = laptop.Model.Trim();
                laptopToUpdate.HardDiskCapacity = laptop.HardDiskCapacity;
                laptopToUpdate.ImageUrl = laptop.ImageUrl;
                laptopToUpdate.ManufacturerId = laptop.ManufacturerId;
                laptopToUpdate.MonitorSize = laptop.MonitorSize;
                laptopToUpdate.Price = laptop.Price;
                laptopToUpdate.RamCapacity = laptop.RamCapacity;

                this.Data.SaveChanges();
                return Json(new object());
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, LaptopViewModel laptop)
        {
            if (laptop != null && ModelState.IsValid)
            {
                var laptopToDelete = this.Data.Laptops.GetById(laptop.Id);
                if (laptopToDelete == null)
                {
                    ModelState.AddModelError(
                        "alert",
                        "An unexpected error has occurred. The laptop you want to delete was not found...");
                    return Json(ModelState.ToDataSourceResult());
                }

                foreach (var vote in laptopToDelete.Votes.ToList())
                {
                    this.Data.Votes.Delete(vote);
                }

                foreach (var comment in laptopToDelete.Comments.ToList())
                {
                    this.Data.Comments.Delete(comment);
                }

                this.Data.Laptops.Delete(laptopToDelete);
                this.Data.SaveChanges();
            }

            return Json(new object());
        }
    }
}