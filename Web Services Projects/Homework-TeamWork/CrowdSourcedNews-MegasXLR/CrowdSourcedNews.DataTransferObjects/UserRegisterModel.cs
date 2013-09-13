namespace CrowdSourcedNews.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserRegisterModel : UserLoginModel
    {
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
    }
}
