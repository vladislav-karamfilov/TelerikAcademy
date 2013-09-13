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
    using TelerikAcademyForum.Services.Attributes;
    using TelerikAcademyForum.Services.DataMappers;
    using TelerikAcademyForum.Services.Validators;

    public class ThreadsController : BaseApiController
    {
        [HttpPost, ActionName("create")]
        public HttpResponseMessage Add([FromBody]ThreadModel thread,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            HttpResponseMessage httpResponse = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var context = new TelerikAcademyForumContext();
                using (context)
                {
                    var newThreadEntity = ThreadsMapper.ToEntity(thread, sessionKey, context);
                    context.Threads.Add(newThreadEntity);
                    context.SaveChanges();

                    thread.ID = newThreadEntity.ID;
                }

                var response = this.Request.CreateResponse(HttpStatusCode.Created, thread);
                return response;
            });

            return httpResponse;
        }

        [HttpGet]
        public IQueryable<ThreadModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            IQueryable<ThreadModel> allThreadModels = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var threadModels = new List<ThreadModel>();
                using (var context = new TelerikAcademyForumContext())
                {
                    var threadEntities = context.Threads
                        .Include("Categories").Include("Posts").Include("Author")
                        .OrderByDescending(thr => thr.DateCreated);
                    foreach (var threadEntity in threadEntities.ToList())
                    {
                        threadModels.Add(ThreadsMapper.ToModel(threadEntity));
                    }
                }

                return threadModels.AsQueryable<ThreadModel>();
            });

            return allThreadModels;
        }

        [HttpGet]
        public IQueryable<ThreadModel> GetByCategory(string category,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var threadsByCategory = this.GetAll(sessionKey)
                .Where(thr => thr.Categories.Contains(category));

            return threadsByCategory;
        }

        [HttpGet]
        public IQueryable<ThreadModel> GetPage(int page, int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var threadsOnPage = this.GetAll(sessionKey).Skip((page - 1) * count).Take(count);

            return threadsOnPage;
        }

        [HttpGet, ActionName("posts")]
        public IQueryable<PostModel> GetThreadPosts(int threadID,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var thread = this.GetAll(sessionKey).FirstOrDefault<ThreadModel>(thr => thr.ID == threadID);
            if (thread == null)
            {
                var httpErrorResponse = this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "Thread with provided ID not found!");
                throw new HttpResponseException(httpErrorResponse);
            }

            return thread.Posts.AsQueryable<PostModel>();
        }
    }
}
