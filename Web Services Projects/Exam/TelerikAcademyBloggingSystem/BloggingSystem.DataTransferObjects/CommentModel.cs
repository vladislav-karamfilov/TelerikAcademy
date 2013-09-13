namespace BloggingSystem.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class CommentModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "commentedBy")]
        public string Author { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }
    }
}
