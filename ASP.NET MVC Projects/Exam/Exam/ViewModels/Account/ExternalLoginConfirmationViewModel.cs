namespace Exam.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter user name...")]
        [Display(Name = "User name")]
        [RegularExpression(GlobalConstants.UsernameRegEx, ErrorMessage = "Invalid user name!")]
        [StringLength(GlobalConstants.UsernameMaxLength,
            ErrorMessage = "User name must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.UsernameMinLength)]
        public string UserName { get; set; }
    }
}
