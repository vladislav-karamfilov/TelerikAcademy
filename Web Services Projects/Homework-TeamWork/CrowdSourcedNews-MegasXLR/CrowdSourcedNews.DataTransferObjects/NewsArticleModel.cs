namespace CrowdSourcedNews.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class NewsArticleModel : NewsArticleDetails
    {
        public NewsArticleModel()
        {
            this.Comments = new List<CommentModel>();
        }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "image")]
        public string ImageUrl { get; set; }

        [DataMember(Name = "comments")]
        public IList<CommentModel> Comments { get; set; }
    }
}
