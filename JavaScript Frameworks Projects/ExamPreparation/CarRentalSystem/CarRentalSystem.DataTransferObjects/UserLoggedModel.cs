namespace CarRentalSystem.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserLoggedModel
    {
        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
    }
}
