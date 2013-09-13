namespace CarRentalSystem.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserRegisterModel : UserLoginModel
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
    }
}
