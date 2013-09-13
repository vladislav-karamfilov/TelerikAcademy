namespace CrowdSourcedNews.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using CrowdSourcedNews.DataTransferObjects;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;
    using CrowdSourcedNews.Mappers;
    using CrowdSourcedNews.Services;
    using CrowdSourcedNews.Services.Utilities;

    public class UsersController : ApiController
    {
        private DbUsersRepository usersRepository;
        private IRepository<NewsArticle> newsArticlesRepository;
        private IRepository<Comment> commentsRepository;

        public UsersController(
            DbUsersRepository repository,
            IRepository<NewsArticle> newsArticlesRepository,
            IRepository<Comment> commentsRepository)
        {
            this.usersRepository = repository;
            this.newsArticlesRepository = newsArticlesRepository;
            this.commentsRepository = commentsRepository;
        }

        [HttpPost, ActionName("register")]
        public HttpResponseMessage RegisterUser(UserRegisterModel userToRegister)
        {
            UserValidator.ValidateAuthCode(userToRegister.AuthCode);
            UserValidator.ValidateNickname(userToRegister.Nickname);
            UserValidator.ValidateUsername(userToRegister.Username);

            User newUser = null;
            try
            {
                newUser = UsersMapper.ToUserEntity(userToRegister);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid user register model provided!");
            }

            usersRepository.Add(newUser);

            User inDbUser = this.usersRepository.GetByUsernameAndAuthCode(newUser.Username, newUser.AuthCode);
            inDbUser.SessionKey = UserValidator.GenerateSessionKey(inDbUser.ID);
            this.usersRepository.Update(inDbUser.ID, inDbUser);
            UserLoggedModel loggedUser = new UserLoggedModel()
                {
                    Nickname = inDbUser.Nickname,
                    SessionKey = inDbUser.SessionKey
                };

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, loggedUser);
            response.Headers.Location = new Uri(Url.Link("NewsApi", new { sessionKey = loggedUser.SessionKey }));
            return response;
        }

        [HttpPost, ActionName("login")]
        public HttpResponseMessage LoginUser(UserLoginModel userToLogin)
        {
            UserValidator.ValidateAuthCode(userToLogin.AuthCode);
            UserValidator.ValidateUsername(userToLogin.Username);

            User user = null;
            try
            {
                user = this.usersRepository.GetByUsernameAndAuthCode(userToLogin.Username, userToLogin.AuthCode);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid username or password!");
            }

            user.SessionKey = UserValidator.GenerateSessionKey(user.ID);
            this.usersRepository.Update(user.ID, user);

            UserLoggedModel loggedUser = new UserLoggedModel()
                {
                    Nickname = user.Nickname,
                    SessionKey = user.SessionKey
                };

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loggedUser);
            return response;
        }

        [HttpGet, ActionName("logout")]
        public HttpResponseMessage LogoutUser(string sessionKey)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid session key provided!");
            }

            user.SessionKey = null;
            this.usersRepository.Update(user.ID, user);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet, ActionName("newsArticles")]
        public HttpResponseMessage GetNewsArticles(string sessionKey)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid session key provided!");
            }

            ICollection<NewsArticleModel> newsArticlesModels = new List<NewsArticleModel>();

            IEnumerable<NewsArticle> newsArticles = this.newsArticlesRepository
                .GetAll().Where(n => n.AuthorID == user.ID).ToList();
            foreach (NewsArticle newsArticle in newsArticles)
            {
                newsArticlesModels.Add(NewsArticlesMapper.ToNewsArticleModel(newsArticle));
            }

            return Request.CreateResponse(HttpStatusCode.OK, newsArticlesModels);
        }

        [HttpGet, ActionName("comments")]
        public HttpResponseMessage GetComments(string sessionKey)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid session key provided!");
            }

            ICollection<CommentModel> commentModels = new List<CommentModel>();

            IEnumerable<Comment> comments = this.commentsRepository
                .GetAll().Where(c => c.AuthorID == user.ID).ToList();
            foreach (Comment comment in comments)
            {
                commentModels.Add(CommentsMapper.ToCommentModel(comment));
            }

            return Request.CreateResponse(HttpStatusCode.OK, commentModels);
        }
    }
}
