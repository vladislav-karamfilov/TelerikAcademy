namespace Newster.DataTransferObjects
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Newster.Models;

    [DataContract]
    public class LoggedUserDTO
    {
        public static Expression<Func<User, LoggedUserDTO>> FromModel
        {
            get
            {
                return user => new LoggedUserDTO()
                {
                    SessionKey = user.SessionKey,
                    Nickname = user.Nickname
                };
            }
        }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
    }
}
