namespace LaptopListingSystem.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using LaptopListingSystem.Models;
    
    public class LaptopViewModel
    {
        private string model;

        public static Expression<Func<Laptop, LaptopViewModel>> FromModel
        {
            get
            {
                return laptop => new LaptopViewModel()
                {
                    Id = laptop.Id,
                    HardDiskCapacity = laptop.HardDiskCapacity,
                    ImageUrl = laptop.ImageUrl,
                    ManufacturerId = laptop.ManufacturerId,
                    Model = laptop.Model,
                    MonitorSize = laptop.MonitorSize,
                    Price = laptop.Price,
                    RamCapacity = laptop.RamCapacity
                };
            }
        }

        [Editable(false)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter model...")]
        public string Model
        {
            get { return this.model != null && this.model.Length > 20 ? (this.model.Substring(0, 17) + "...") : this.model; }
            set { this.model = value; }
        }

        [Range(1, double.MaxValue, ErrorMessage = "Please enter monitor size...")]
        public double MonitorSize { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter hard disk capacity...")]
        [Display(Name = "Hard disk (GB)")]
        public int HardDiskCapacity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter RAM capacity...")]
        [Display(Name = "RAM (GB)")]
        public double RamCapacity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter image URL...")]
        [RegularExpression(GlobalConstants.UrlRegEx, ErrorMessage = "Please enter valid URL...")]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter price...")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select manufacturer...")]
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
    }
}