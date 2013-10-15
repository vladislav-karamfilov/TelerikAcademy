namespace Newster.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserLoginDTO
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }
    }
}
