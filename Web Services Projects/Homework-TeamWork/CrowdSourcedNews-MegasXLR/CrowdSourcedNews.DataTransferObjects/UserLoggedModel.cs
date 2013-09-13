namespace CrowdSourcedNews.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserLoggedModel
    {
        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
    }
}
