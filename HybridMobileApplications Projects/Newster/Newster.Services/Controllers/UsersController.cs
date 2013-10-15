namespace Newster.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using Newster.Data.Contracts;
    using Newster.DataTransferObjects;
    using Newster.Models;
    using Newster.Services.Attributes;
    using Newster.Services.Utilities;

    public class UsersController : BaseApiController
    {
        private readonly INewsterData data;

        public UsersController(INewsterData data)
        {
            this.data = data;
        }

        [HttpPost, ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody]UserRegisterDTO user)
        {
            HttpResponseMessage responseMessage = this.PerformOperation(() =>
            {
                UserValidator.ValidateAuthenticationCode(user.AuthCode);
                UserValidator.ValidateNickname(user.Nickname);
                UserValidator.ValidateUsername(user.Username);

                var exstingUserEntity = this.data.Users.All().FirstOrDefault(
                    u => u.Username == user.Username.ToLower() || u.Nickname.ToLower() == user.Nickname.ToLower());
                if (exstingUserEntity != null)
                {
                    throw new InvalidOperationException("User already exists!");
                }

                var newUserEntity = new User()
                {
                    AuthCode = user.AuthCode,
                    Nickname = user.Nickname,
                    Username = user.Username
                };

                this.data.Users.Add(newUserEntity);
                this.data.SaveChanges();

                newUserEntity.SessionKey = UserValidator.GenerateSessionKey(newUserEntity.ID);
                this.data.SaveChanges();

                var loggedUser = new LoggedUserDTO()
                {
                    Nickname = newUserEntity.Nickname,
                    SessionKey = newUserEntity.SessionKey
                };

                return this.Request.CreateResponse(HttpStatusCode.Created, loggedUser);
            });

            return responseMessage;
        }

        [HttpPost, ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody]UserLoginDTO user)
        {
            HttpResponseMessage responseMessage = this.PerformOperation(() =>
            {
                UserValidator.ValidateAuthenticationCode(user.AuthCode);
                UserValidator.ValidateUsername(user.Username);

                var userEntity = this.data.Users.All().FirstOrDefault(
                    u => u.AuthCode == user.AuthCode && u.Username == user.Username.ToLower());
                if (userEntity == null)
                {
                    throw new InvalidOperationException("User not registered!");
                }

                userEntity.SessionKey = UserValidator.GenerateSessionKey(userEntity.ID);
                this.data.SaveChanges();

                var loggedUser = new LoggedUserDTO()
                {
                    Nickname = userEntity.Nickname,
                    SessionKey = userEntity.SessionKey
                };

                return this.Request.CreateResponse(HttpStatusCode.Created, loggedUser);
            });

            return responseMessage;
        }

        [HttpPut, ActionName("logout")]
        public HttpResponseMessage LogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            HttpResponseMessage responseMessage = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var loggedUserEntity = this.data.Users.All().FirstOrDefault(u => u.SessionKey == sessionKey);
                if (loggedUserEntity == null)
                {
                    throw new InvalidOperationException("Invalid user or pasword!");
                }

                loggedUserEntity.SessionKey = null;
                this.data.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.OK);
            });

            return responseMessage;
        }
    }
}
