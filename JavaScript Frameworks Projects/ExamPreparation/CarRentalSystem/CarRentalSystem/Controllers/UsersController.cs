namespace CarRentalSystem.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using CarRentalSystem.Data;
    using CarRentalSystem.DataMappers;
    using CarRentalSystem.DataTransferObjects;
    using CarRentalSystem.Headers;
    using CarRentalSystem.Models;
    using CarRentalSystem.Validators;

    public class UsersController : BaseApiController
    {
        public UsersController()
            : this(new CarRentalSystemContextFactory())
        { }

        public UsersController(IDbContextFactory<DbContext> contextFactory)
            : base(contextFactory)
        { }

        [HttpPost, ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody]UserRegisterModel user)
        {
            HttpResponseMessage responseMessage = this.PerformOperation(() =>
            {
                UserValidator.ValidateUsername(user.Username);
                UserValidator.ValidateDisplayName(user.DisplayName);
                UserValidator.ValidateAuthenticationCode(user.AuthCode);

                using (var context = this.ContextFactory.Create())
                {
                    User exstingUserEntity = context.Set<User>().FirstOrDefault(
                        u => u.Username == user.Username.ToLower() || u.DisplayName.ToLower() == user.DisplayName.ToLower());
                    if (exstingUserEntity != null)
                    {
                        throw new InvalidOperationException("User already exists!");
                    }

                    User newUserEntity = UsersMapper.ToEntity(user);
                    context.Set<User>().Add(newUserEntity);
                    context.SaveChanges();

                    newUserEntity.SessionKey = UserValidator.GenerateSessionKey(newUserEntity.ID);
                    context.SaveChanges();

                    UserLoggedModel loggedUser = UsersMapper.ToModel(newUserEntity);
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
                UserValidator.ValidateUsername(user.Username);
                UserValidator.ValidateAuthenticationCode(user.AuthCode);

                using (var context = this.ContextFactory.Create())
                {
                    var userEntity = context.Set<User>().FirstOrDefault(
                        u => u.AuthCode == user.AuthCode && u.Username == user.Username.ToLower());
                    if (userEntity == null)
                    {
                        throw new InvalidOperationException("User not registered!");
                    }

                    userEntity.SessionKey = UserValidator.GenerateSessionKey(userEntity.ID);
                    context.SaveChanges();

                    UserLoggedModel loggedUser = UsersMapper.ToModel(userEntity);
                    return this.Request.CreateResponse(HttpStatusCode.Created, loggedUser);
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

                using (var context = this.ContextFactory.Create())
                using (context)
                {
                    var loggedUserEntity = context.Set<User>().FirstOrDefault<User>(u => u.SessionKey == sessionKey);
                    if (loggedUserEntity == null)
                    {
                        throw new InvalidOperationException("Invalid username or pasword!");
                    }

                    loggedUserEntity.SessionKey = null;
                    context.SaveChanges();
                }

                return this.Request.CreateResponse(HttpStatusCode.OK);
            });

            return responseMessage;
        }
    }
}
