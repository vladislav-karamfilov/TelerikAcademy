namespace TwitterLikeSystem.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
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

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter first name...")]
        [Display(Name = "First name")]
        [StringLength(GlobalConstants.NameMaxLength,
            ErrorMessage = "User's first name must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.NameMinLength)]
        [RegularExpression(GlobalConstants.NameRegEx)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter last name...")]
        [StringLength(GlobalConstants.NameMaxLength,
            ErrorMessage = "User's last name must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.NameMinLength)]
        [RegularExpression(GlobalConstants.NameRegEx)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter e-mail...")]
        [Display(Name = "E-mail")]
        [RegularExpression(GlobalConstants.EmailRegEx)]
        [StringLength(GlobalConstants.EmailMaxLength,
            ErrorMessage = "User's e-mail cannot be more than {1} characters long!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}