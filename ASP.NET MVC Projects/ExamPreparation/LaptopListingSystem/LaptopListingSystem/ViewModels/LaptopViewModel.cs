namespace LaptopListingSystem.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using LaptopListingSystem.Models;

    public class LaptopViewModel
    {
        public static Expression<Func<Laptop, LaptopViewModel>> FromModel
        {
            get
            {
                return laptop => new LaptopViewModel()
                {
                    Id = laptop.Id,
                    ImageUrl = laptop.ImageUrl,
                    Manufacturer = laptop.Manufacturer.Name,
                    Model = laptop.Model,
                    Price = laptop.Price
                };
            }
        }

        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string Model { get; set; }

        [DataType(DataType.Text)]
        public string Manufacturer { get; set; }

        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}