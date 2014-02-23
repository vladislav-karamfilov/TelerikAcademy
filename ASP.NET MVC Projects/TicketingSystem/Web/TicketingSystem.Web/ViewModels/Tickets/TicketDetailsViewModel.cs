namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using TicketingSystem.Data.Models;

    public class TicketDetailsViewModel : TicketListItemViewModel
    {
        public TicketDetailsViewModel()
        {
            this.Comments = new List<TicketCommentViewModel>();
        }

        public static new Expression<Func<Ticket, TicketDetailsViewModel>> ViewModel
        {
            get
            {
                return x =>
                    new TicketDetailsViewModel
                    {
                        Id = x.Id,
                        CategoryId = x.CategoryId,
                        Category = x.Category.Name,
                        Title = x.Title,
                        Author = x.Author.UserName,
                        PriorityId = x.Priority,
                        Description = x.Description,
                        ScreenshotUrl = x.ScreenshotUrl,
                        Comments = x.Comments.AsQueryable().OrderBy(y => y.Id).Select(TicketCommentViewModel.ViewModel)
                    };
            }
        }

        public string Description { get; set; }

        public string ScreenshotUrl { get; set; }

        public IEnumerable<TicketCommentViewModel> Comments { get; set; }
    }
}