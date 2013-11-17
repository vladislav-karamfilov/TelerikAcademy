namespace LaptopListingSystem.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using LaptopListingSystem.Models;
    using LaptopListingSystem.Models.Attributes;

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
                    Content = comment.Content,
                    Laptop = comment.Laptop.Manufacturer.Name + " " + comment.Laptop.Model,
                    LaptopId = comment.LaptopId
                };
            }
        }

        [Editable(false)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter comment content...")]
        [DoesNotContainEmail]
        public string Content { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string Author { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string Laptop { get; set; }

        [Editable(false)]
        public int LaptopId { get; set; }
    }
}