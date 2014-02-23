namespace TicketingSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    
    using TicketingSystem.Common;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter username...")]
        [Display(Name = "Username")]
        [RegularExpression(GlobalConstants.UsernameRegEx, ErrorMessage = "Invalid username!")]
        [StringLength(GlobalConstants.UsernameMaxLength,
            ErrorMessage = "Username must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.UsernameMinLength)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password...")]
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