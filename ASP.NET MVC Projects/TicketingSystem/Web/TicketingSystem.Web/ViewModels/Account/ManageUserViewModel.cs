namespace TicketingSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    
    using TicketingSystem.Common;

    public class ManageUserViewModel
    {
        [Required(ErrorMessage = "Please enter password...")]
        [DataType(DataType.Password)]
        [StringLength(GlobalConstants.PasswordMaxLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.PasswordMinLength)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter password...")]
        [StringLength(GlobalConstants.PasswordMaxLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long!",
            MinimumLength = GlobalConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}