namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Newtonsoft.Json;
    
    using TicketingSystem.Common;
    using TicketingSystem.Common.DataAnnotations;
    using TicketingSystem.Common.ValidationAttributes;
    using TicketingSystem.Data.Models;

    public class TicketInputViewModel
    {
        [JsonIgnore]
        public Ticket Entity
        {
            get
            {
                return new Ticket
                {
                    AuthorId = this.AuthorId,
                    Title = this.Title.Trim(),
                    CategoryId = this.CategoryId,
                    ScreenshotUrl = string.IsNullOrWhiteSpace(this.ScreenshotUrl) ? null : this.ScreenshotUrl.Trim(),
                    Priority = (Priority)this.PriorityId,
                    Description = string.IsNullOrWhiteSpace(this.Description) ? null : this.Description.Trim()
                };
            }
        }

        [HiddenInput]
        public string AuthorId { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select category.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select category.")]
        [Placeholder("Select category")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }

        [Display(Name = "Title")]
        [DoesNotContainBugWord(ErrorMessage = "{0} cannot contain the word 'bug'.")]
        [Required(ErrorMessage = "Please enter title.")]
        [StringLength(GlobalConstants.TicketTitleMaxLength,
            MinimumLength = GlobalConstants.TicketTitleMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        [Placeholder("Enter title")]
        [UIHint("SingleLineText")]
        [AllowHtml]
        public string Title { get; set; }

        [Display(Name = "Priority")]
        [Required(ErrorMessage = "Please select a priority.")]
        [Range(1, 3, ErrorMessage = "Please select a priority.")]
        [Placeholder("Select priority")]
        [UIHint("DropDownList")]
        public int PriorityId { get; set; }

        [Display(Name = "Screenshot URL")]
        [RegularExpression(GlobalConstants.UrlRegEx, ErrorMessage = "Invalid URL.")]
        [Placeholder("Enter screenshot URL")]
        [UIHint("SingleLineText")]
        public string ScreenshotUrl { get; set; }

        [Display(Name = "Description")]
        [StringLength(GlobalConstants.TicketDescriptionMaxLength,
            MinimumLength = GlobalConstants.TicketDescriptionMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        [Placeholder("Enter description")]
        [UIHint("MultiLineText")]
        [AllowHtml]
        public string Description { get; set; }
    }
}