namespace CrowdSourcedNews.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class NewsArticleDetails
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }
    }
}
