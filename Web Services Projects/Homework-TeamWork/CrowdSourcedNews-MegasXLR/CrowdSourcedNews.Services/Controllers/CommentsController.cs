namespace CrowdSourcedNews.Services.Controllers
{
    using System.Web.Http;
    using CrowdSourcedNews.Repositories;
    using CrowdSourcedNews.Models;
    using System.Net.Http;
    using CrowdSourcedNews.DataTransferObjects;
    using System;
    using System.Net;
    using CrowdSourcedNews.Mappers;
    using System.Collections.Generic;
    using System.Linq;

    public class CommentsController : ApiController
    {
        private IRepository<NewsArticle> newsArticlesRepository;
        private DbUsersRepository usersRepository;
        private IRepository<Comment> commentsRepository;

        public CommentsController(
            IRepository<Comment> commentsRepository,
            IRepository<NewsArticle> newsArticlesRepository,
            DbUsersRepository usersRepository)
        {
            this.newsArticlesRepository = newsArticlesRepository;
            this.usersRepository = usersRepository;
            this.commentsRepository = commentsRepository;
        }

        [HttpPost, ActionName("add")]
        public HttpResponseMessage AddComment(string sessionKey, CommentModel comment)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid user!");
            }

            comment.Author = user.Nickname;

            Comment commentEntity = null;
            try
            {
                commentEntity = 
                    CommentsMapper.ToCommentEntity(comment, usersRepository, newsArticlesRepository);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid news article model provided!");
            }

            comment.ID = commentEntity.ID;

            this.commentsRepository.Add(commentEntity);

            return Request.CreateResponse(HttpStatusCode.Created, comment);
        }

        [HttpGet, ActionName("get")]
        public HttpResponseMessage GetAll(string sessionKey)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid user!");
            }

            ICollection<CommentModel> comments = new List<CommentModel>();
            IEnumerable<Comment> commentEntities = this.commentsRepository.GetAll().ToList();
            foreach (var comment in commentEntities)
            {
                comments.Add(CommentsMapper.ToCommentModel(comment));
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, comments);
            return response;
        }

        [HttpPut, ActionName("edit")]
        public HttpResponseMessage EditComment(string sessionKey, int id, CommentModel comment)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid user!");
            }

            if (id != comment.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Comment updatedComment = null;
            try
            {
                updatedComment =
                    CommentsMapper.ToCommentEntity(comment, usersRepository, newsArticlesRepository);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid comment model provided!");
            }

            this.commentsRepository.Update(id, updatedComment);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete, ActionName("remove")]
        public HttpResponseMessage RemoveComment(string sessionKey, int id)
        {
            User user = null;
            try
            {
                user = this.usersRepository.GetBySessionKey(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid user!");
            }

            if (this.commentsRepository.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Comment not found!");
            }
        }
    }
}
