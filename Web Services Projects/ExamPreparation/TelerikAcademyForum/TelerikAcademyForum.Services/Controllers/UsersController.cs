namespace TelerikAcademyForum.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using TelerikAcademyForum.Data;
    using TelerikAcademyForum.DataTransferObjects;
    using TelerikAcademyForum.Models;
    using TelerikAcademyForum.Services.Attributes;
    using TelerikAcademyForum.Services.DataMappers;
    using TelerikAcademyForum.Services.Validators;

    public class UsersController : BaseApiController
    {
        [HttpPost, ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody]UserRegisterModel user)
        {
            HttpResponseMessage responseMessage = this.PerformOperation(() =>
                {
                    UserValidator.ValidateAuthenticationCode(user.AuthCode);
                    UserValidator.ValidateNickname(user.Nickname);
                    UserValidator.ValidateUsername(user.Username);

                    var context = new TelerikAcademyForumContext();
                    using (context)
                    {
                        User exstingUserEntity = context.Users.FirstOrDefault<User>(
                            u => u.Username == user.Username.ToLower() || u.Nickname.ToLower() == user.Nickname.ToLower());
                        if (exstingUserEntity != null)
                        {
                            throw new InvalidOperationException("User already exists!");
                        }

                        User newUserEntity = UsersMapper.ToEntity(user);
                        context.Users.Add(newUserEntity);
                        context.SaveChanges();

                        newUserEntity.SessionKey = UserValidator.GenerateSessionKey(newUserEntity.ID);
                        context.SaveChanges();

                        UserLoggedModel loggedUser = UsersMapper.ToUserLoggedModel(newUserEntity);
                        return this.Request.CreateResponse(HttpStatusCode.Created, loggedUser);
                    }
                });

            return responseMessage;
        }

        [HttpPost, ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody]UserLoginModel user)
        {
            HttpResponseMessage responseMessage = this.PerformOperation(() =>
            {
                UserValidator.ValidateAuthenticationCode(user.AuthCode);
                UserValidator.ValidateUsername(user.Username);

                var context = new TelerikAcademyForumContext();
                using (context)
                {
                    var userEntity = context.Users.FirstOrDefault(
                        u => u.AuthCode == user.AuthCode && u.Username == user.Username.ToLower());
                    if (userEntity == null)
                    {
                        throw new InvalidOperationException("User not registered!");
                    }

                    userEntity.SessionKey = UserValidator.GenerateSessionKey(userEntity.ID);
                    context.SaveChanges();

                    UserLoggedModel loggedUser = UsersMapper.ToUserLoggedModel(userEntity);
                    return this.Request.CreateResponse(HttpStatusCode.OK, loggedUser);
                }
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

                var context = new TelerikAcademyForumContext();
                using (context)
                {
                    var loggedUserEntity = context.Users.FirstOrDefault<User>(u => u.SessionKey == sessionKey);
                    if (loggedUserEntity == null)
                    {
                        throw new InvalidOperationException("Invalid user!");
                    }

                    loggedUserEntity.SessionKey = null;
                    context.SaveChanges();
                }

                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            });

            return responseMessage;
        }
    }
}
