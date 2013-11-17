namespace LaptopListingSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UserProfile : User
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(GlobalConstants.EmailMaxLength)]
        [RegularExpression(GlobalConstants.EmailRegEx)]
        public string Email { get; set; }
    }
}
