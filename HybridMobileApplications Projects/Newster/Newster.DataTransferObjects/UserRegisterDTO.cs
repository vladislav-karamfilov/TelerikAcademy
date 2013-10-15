namespace Newster.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserRegisterDTO : UserLoginDTO
    {
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
    }
}
