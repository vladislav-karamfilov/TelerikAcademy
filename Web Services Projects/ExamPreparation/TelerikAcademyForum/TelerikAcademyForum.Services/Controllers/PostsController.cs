namespace TelerikAcademyForum.Services.Controllers
{
    using System;
    using System.Collections.Generic;
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

    public class PostsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<PostModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var allPostModels = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var context = new TelerikAcademyForumContext();
                using (context)
                {
                    var postModels = new List<PostModel>();
                    var postEntities = context.Posts
                        .Include("Author").Include("Thread").Include("Votes").Include("Comments")
                        .OrderByDescending(p => p.PostDate);
                    foreach (var postEntity in postEntities)
                    {
                        postModels.Add(PostsMapper.ToModel(postEntity));
                    }

                    return postModels.AsQueryable<PostModel>();
                }
            });

            return allPostModels;
        }

        [HttpGet]
        public IQueryable<PostModel> GetPage(int page, int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var postModelsPage = this.GetAll(sessionKey).Skip((page - 1) * count).Take(count);

            return postModelsPage;
        }

        [HttpPost]
        public HttpResponseMessage Add([FromBody]PostModel post,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            throw new NotImplementedException();
        }

        [HttpPost, ActionName("vote")]
        public HttpResponseMessage VotePost(int postID, [FromBody]int vote,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var httpResponse = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                if (vote < 0 || vote > 5)
                {
                    throw new ArgumentOutOfRangeException("vote", "Vote cannot be less than 0 and more than 5!");
                }

                var context = new TelerikAcademyForumContext();
                using (context)
                {
                    var post = context.Posts.Find(postID);
                    if (post == null)
                    {
                        var httpErrorResponse = this.Request.CreateErrorResponse(
                            HttpStatusCode.NotFound, "Post with provided ID not found!");
                        throw new HttpResponseException(httpErrorResponse);
                    }

                    post.Votes.Add(new Vote()
                        {
                            User = context.Users.FirstOrDefault<User>(u => u.SessionKey == sessionKey),
                            Value = vote
                        });

                    context.SaveChanges();
                }

                return this.Request.CreateResponse(HttpStatusCode.Created, vote);
            });

            return httpResponse;
        }

        [HttpPost, ActionName("comment")]
        public HttpResponseMessage CommentPost(int postID, [FromBody]string comment,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var httpResponse = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                if (comment == null)
                {
                    throw new ArgumentNullException("comment", "Comment cannot be null!");
                }

                var context = new TelerikAcademyForumContext();
                using (context)
                {
                    var post = context.Posts.Find(postID);
                    if (post == null)
                    {
                        var httpErrorResponse = this.Request.CreateErrorResponse(
                            HttpStatusCode.NotFound, "Post with provided ID not found!");
                        throw new HttpResponseException(httpErrorResponse);
                    }

                    post.Comments.Add(new Comment()
                    {
                        Author = context.Users.FirstOrDefault<User>(u => u.SessionKey == sessionKey),
                        CommentDate = DateTime.Now,
                        Content = comment
                    });

                    context.SaveChanges();
                }

                return this.Request.CreateResponse(HttpStatusCode.Created, comment);
            });

            return httpResponse;
        }
    }
}
