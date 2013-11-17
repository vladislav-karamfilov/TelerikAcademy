namespace LaptopListingSystem.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using LaptopListingSystem.Models;

    public class FullLaptopViewModel : LaptopViewModel
    {
        public new static Expression<Func<Laptop, FullLaptopViewModel>> FromModel
        {
            get
            {
                return laptop => new FullLaptopViewModel()
                {
                    Id = laptop.Id,
                    AdditionalParts = laptop.AdditionalParts,
                    Comments = laptop.Comments.AsQueryable().Select(CommentViewModel.FromModel),
                    VotesCount = laptop.Votes.Count,
                    Description = laptop.Description,
                    HardDiskCapacity = laptop.HardDiskCapacity,
                    ImageUrl = laptop.ImageUrl,
                    Manufacturer = laptop.Manufacturer.Name,
                    Model = laptop.Model,
                    MonitorSize = laptop.MonitorSize,
                    Price = laptop.Price,
                    RamCapacity = laptop.RamCapacity,
                    Weight = laptop.Weight
                };
            }
        }

        [Range(1, double.MaxValue)]
        public double MonitorSize { get; set; }

        [Range(1, int.MaxValue)]
        public int HardDiskCapacity { get; set; }

        [Range(0, double.MaxValue)]
        public double RamCapacity { get; set; }

        [Range(1, double.MaxValue)]
        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}