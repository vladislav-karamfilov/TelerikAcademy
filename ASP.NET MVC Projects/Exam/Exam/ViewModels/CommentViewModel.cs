namespace Exam.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Exam.Models;

    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> FromModel
        {
            get
            {
                return comment => new CommentViewModel()
                {
                    Id = comment.Id,
                    Author = comment.Author.UserName,
                    Content = comment.Content
                };
            }
        }

        public int Id { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }
    }
}
