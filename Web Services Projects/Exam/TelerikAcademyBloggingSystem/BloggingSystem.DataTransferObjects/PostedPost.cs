namespace BloggingSystem.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PostedPost
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}
