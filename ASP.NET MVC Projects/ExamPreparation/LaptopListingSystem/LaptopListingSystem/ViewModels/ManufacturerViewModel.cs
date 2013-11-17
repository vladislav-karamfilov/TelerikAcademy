namespace LaptopListingSystem.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using LaptopListingSystem.Models;
    using System.Web.Mvc;

    public class ManufacturerViewModel
    {
        public static Expression<Func<Manufacturer, ManufacturerViewModel>> FromModel
        {
            get
            {
                return manufacturer => new ManufacturerViewModel()
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name
                };
            }
        }

        public int Id { get; set; }

        [AllowHtml]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter manufacturer name...")]
        [Display(Name = "Manufacturer")]
        public string Name { get; set; }
    }
}