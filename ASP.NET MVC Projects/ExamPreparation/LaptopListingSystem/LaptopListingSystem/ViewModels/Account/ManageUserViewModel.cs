namespace LaptopListingSystem.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ManageUserViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter password...")]
        [DataType(DataType.Password)]
        [StringLength(GlobalConstants.PasswordMaxLength,
            ErrorMessage = "The {0} must be at least {2} characters long.",
            MinimumLength = GlobalConstants.PasswordMinLength)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter password...")]
        [StringLength(GlobalConstants.PasswordMaxLength,
            ErrorMessage = "The {0} must be at least {2} characters long.",
            MinimumLength = GlobalConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter e-mail...")]
        [Display(Name = "Confirm new e-mail")]
        [RegularExpression(GlobalConstants.EmailRegEx, ErrorMessage = "Invalid e-mail!")]
        [StringLength(GlobalConstants.EmailMaxLength,
            ErrorMessage = "User's e-mail cannot be more than {1} characters long!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}