namespace Exam.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using Exam.Models;
    using Exam.Models.ValidationAttributes;

    public class FullTicketViewModel
    {
        private int priorityToShowId = 1;

        public static Expression<Func<Ticket, FullTicketViewModel>> FromModel
        {
            get
            {
                return ticket => new FullTicketViewModel()
                {
                    Id = ticket.Id,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Description = ticket.Description,
                    priorityToShowId = (int)ticket.Priority,
                    ScreenshotUrl = ticket.ScreenshotUrl,
                    Title = ticket.Title,
                    CategoryId = ticket.CategoryId,
                    Comments = ticket.Comments.AsQueryable().Select(CommentViewModel.FromModel)
                };
            }
        }

        public int Id { get; set; }

        public string Author { get; set; }

        [DoesNotContainBugWord(ErrorMessage = "The word 'bug' should not be used in the title!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter title...")]
        public string Title { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select category...")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string Category { get; set; }


        [Display(Name = "Screenshot URL")]
        [RegularExpression(GlobalConstants.UrlRegEx, ErrorMessage = "Invalid URL!")]
        public string ScreenshotUrl { get; set; }

        [Range(1, 3, ErrorMessage = "Please select a priority...")]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }

        public string Priority
        {
            get { return Enum.GetName(typeof(Priority), this.priorityToShowId); }
        }

        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}