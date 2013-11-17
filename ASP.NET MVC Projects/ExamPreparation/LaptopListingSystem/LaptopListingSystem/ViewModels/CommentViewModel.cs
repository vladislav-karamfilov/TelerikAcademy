namespace LaptopListingSystem.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using LaptopListingSystem.Models;

    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> FromModel
        {
            get
            {
                return comment => new CommentViewModel()
                {
                    Author = comment.Author.UserName,
                    Content = comment.Content
                };
            }
        }

        public string Author { get; set; }

        public string Content { get; set; }
    }
}