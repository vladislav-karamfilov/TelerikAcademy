namespace TicketingSystem.Web.Areas.Administration.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using TicketingSystem.Common;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.Areas.Administration.ViewModels.Common;

    public class GridCommentViewModel : AdministrationViewModel<Comment>
    {
        public static Expression<Func<Comment, GridCommentViewModel>> ViewModel
        {
            get
            {
                return x =>
                    new GridCommentViewModel
                    {
                        Id = x.Id,
                        Author = x.Author.UserName,
                        Ticket = x.Ticket.Title,
                        Content = x.Content
                    };
            }
        }

        [Display(Name = "Id")]
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Author")]
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public string Author { get; set; }

        [Display(Name = "Ticket")]
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public string Ticket { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "Please enter comment content.")]
        [StringLength(GlobalConstants.CommentMaxLength,
            MinimumLength = GlobalConstants.CommentMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        [AllowHtml]
        [UIHint("MultiLineText")]
        public string Content { get; set; }

        public override Comment ConvertToDatabaseEntity(Comment model)
        {
            model.Content = this.Content.Trim();
            return model;
        }
    }
}