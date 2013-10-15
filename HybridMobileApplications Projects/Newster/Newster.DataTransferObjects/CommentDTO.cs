namespace Newster.DataTransferObjects
{
    using System;
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
                    Author = comment.Author.Nickname
                };
            }
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }
    }
}
