namespace TelerikAcademyForum.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ThreadModel
    {
        public ThreadModel()
        {
            this.Categories = new List<string>();
            this.Posts = new List<PostModel>();
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "createdBy")]
        public string Author { get; set; }

        [DataMember(Name = "categories")]
        public ICollection<string> Categories { get; set; }

        [DataMember(Name = "posts")]
        public ICollection<PostModel> Posts { get; set; }
    }
}
