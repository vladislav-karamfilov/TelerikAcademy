namespace TelerikAcademyForum.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PostModel
    {
        public PostModel()
        {
            this.Comments = new List<string>();
        }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "rating")]
        public string Rating { get; set; }

        [DataMember(Name = "postedBy")]
        public string Author { get; set; }

        [DataMember(Name = "comments")]
        public ICollection<string> Comments { get; set; }
    }
}
