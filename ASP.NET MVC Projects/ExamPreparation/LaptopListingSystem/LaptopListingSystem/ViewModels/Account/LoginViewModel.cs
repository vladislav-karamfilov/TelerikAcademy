namespace LaptopListingSystem.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using LaptopListingSystem;

    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter user name...")]
        [Display(Name = "User name")]
        [RegularExpression(GlobalConstants.UsernameRegEx)]
        [StringLength(GlobalConstants.UsernameMaxLength,
            ErrorMessage = "User name must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.UsernameMinLength)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(GlobalConstants.PasswordMaxLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.PasswordMinLength)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}