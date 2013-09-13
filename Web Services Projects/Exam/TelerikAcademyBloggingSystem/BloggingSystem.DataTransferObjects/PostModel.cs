namespace BloggingSystem.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PostModel
    {
        public PostModel()
        {
            this.Comments = new HashSet<CommentModel>();
            this.Tags = new HashSet<string>();
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "postedBy")]
        public string Author { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "tags")]
        public ICollection<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public ICollection<CommentModel> Comments { get; set; }
    }
}
