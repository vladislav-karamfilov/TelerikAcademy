namespace TicketingSystem.Web.Areas.Administration.ViewModels.Categories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using TicketingSystem.Common;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.Areas.Administration.ViewModels.Common;

    public class GridCategoryViewModel : AdministrationViewModel<Category>
    {
        public static Expression<Func<Category, GridCategoryViewModel>> ViewModel
        {
            get
            {
                return x =>
                    new GridCategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    };
            }
        }

        [Display(Name = "Id")]
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter name.")]
        [StringLength(GlobalConstants.CategoryNameMaxLength,
            MinimumLength = GlobalConstants.CategoryNameMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        [AllowHtml]
        [UIHint("SingleLineText")]
        public string Name { get; set; }

        public override Category ConvertToDatabaseEntity(Category model)
        {
            model.Name = this.Name.Trim();
            return model;
        }
    }
}