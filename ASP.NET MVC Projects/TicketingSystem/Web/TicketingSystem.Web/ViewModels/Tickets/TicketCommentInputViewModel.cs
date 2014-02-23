namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using TicketingSystem.Common;
    using TicketingSystem.Data.Models;

    public class TicketCommentInputViewModel
    {
        [HiddenInput]
        public int TicketId { get; set; }

        [HiddenInput]
        [JsonIgnore]
        public string AuthordId { get; set; }

        [Required(ErrorMessage = "Please enter comment text.")]
        [StringLength(GlobalConstants.CommentMaxLength,
            MinimumLength = GlobalConstants.CommentMinLength,
            ErrorMessage = "Comment must be between {2} and {1} characters long.")]
        [AllowHtml]
        public string Content { get; set; }

        [JsonIgnore]
        public Comment Entity
        {
            get
            {
                return new Comment
                {
                    AuthorId = this.AuthordId,
                    TicketId = this.TicketId,
                    Content = this.Content.Trim()
                };
            }
        }
    }
}