namespace TicketingSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    
    using TicketingSystem.Common;

    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Please enter username...")]
        [Display(Name = "Username")]
        [RegularExpression(GlobalConstants.UsernameRegEx, ErrorMessage = "Invalid username!")]
        [StringLength(GlobalConstants.UsernameMaxLength,
            ErrorMessage = "Username must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.UsernameMinLength)]
        public string UserName { get; set; }
    }
}