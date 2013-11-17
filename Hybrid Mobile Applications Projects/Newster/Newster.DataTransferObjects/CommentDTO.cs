namespace Newster.DataTransferObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Newster.Models;

    [DataContract]
    public class CommentDTO
    {
        public static Expression<Func<Comment, CommentDTO>> FromModel
        {
            get
            {
                return comment => new CommentDTO()
                {
                    ID = comment.ID,
                    Content = comment.Content,
                    Author = comment.Author.Nickname,
                    Date = comment.Date
                };
            }
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "content")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(500, ErrorMessage = "Comment must be less than 500 characters long!")]
        public string Content { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }
    }
}
