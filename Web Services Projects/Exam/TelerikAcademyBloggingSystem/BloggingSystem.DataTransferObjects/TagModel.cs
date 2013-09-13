namespace BloggingSystem.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TagModel
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "posts")]
        public int PostsCount { get; set; }
    }
}
