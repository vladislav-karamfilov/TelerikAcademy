namespace TwitterLikeSystem.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter user name...")]
        [Display(Name = "User name")]
        [RegularExpression(GlobalConstants.UsernameRegEx)]
        [StringLength(GlobalConstants.UsernameMaxLength,
            ErrorMessage = "User name must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.UsernameMinLength)]
        public string UserName { get; set; }
    }
}
