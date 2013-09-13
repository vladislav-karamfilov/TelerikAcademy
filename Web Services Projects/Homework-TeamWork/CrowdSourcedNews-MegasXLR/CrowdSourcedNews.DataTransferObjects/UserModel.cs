namespace CrowdSourcedNews.DataTransferObjects
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserModel
    {
        public UserModel()
        {
            this.NewsArticles = new HashSet<NewsArticleModel>();
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "newsArticles")]
        public ICollection<NewsArticleModel> NewsArticles { get; set; }

        [DataMember(Name = "comments")]
        public ICollection<CommentModel> Comments { get; set; }
    }
}
