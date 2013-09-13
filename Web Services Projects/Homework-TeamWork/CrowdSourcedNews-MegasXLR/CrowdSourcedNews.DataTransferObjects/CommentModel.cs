namespace CrowdSourcedNews.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    public class CommentModel
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "articleID")]
        public int ArticleID { get; set; }
    }
}
