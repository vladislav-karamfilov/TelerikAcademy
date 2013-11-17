namespace LaptopListingSystem.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using LaptopListingSystem.Models.Attributes;

    public class PostCommentViewModel
    {
        [DoesNotContainEmail(ErrorMessage = "Comment cannot contain e-mail!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a comment...")]
        public string Content { get; set; }
    }
}