namespace BloggingSystem.Services.Controllers
{
    using BloggingSystem.Data;
    using BloggingSystem.DataTransferObjects;
    using BloggingSystem.Models;
    using BloggingSystem.Services.Attributes;
    using BloggingSystem.Services.DataMappers;
    using BloggingSystem.Services.Validators;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;

    public class TagsController : BaseApiController
    {
        [HttpGet]
        public IEnumerable<TagModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var allTagModels = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var context = new BloggingSystemContext();
                using (context)
                {
                    var loggedUserEntity = context.Users.FirstOrDefault<User>(u => u.SessionKey == sessionKey);
                    if (loggedUserEntity == null)
                    {
                        throw new InvalidOperationException("Invalid user or pasword!");
                    }

                    var tagModels = new List<TagModel>();
                    var tagEntities = context.Tags.Include("Posts").OrderBy(t => t.Name);
                    foreach (var tagEntity in tagEntities)
                    {
                        tagModels.Add(TagsMapper.ToModel(tagEntity));
                    }

                    return tagModels;
                }
            });

            return allTagModels;
        }

        [HttpGet, ActionName("posts")]
        public IEnumerable<PostModel> GetPosts(int tagID,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var tagPosts = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var context = new BloggingSystemContext();
                using (context)
                {
                    var loggedUserEntity = context.Users.FirstOrDefault<User>(u => u.SessionKey == sessionKey);
                    if (loggedUserEntity == null)
                    {
                        throw new InvalidOperationException("Invalid user or pasword!");
                    }

                    var tagEntity = context.Tags.Find(tagID);
                    if (tagEntity == null)
                    {
                        var errorResponse = this.Request.CreateErrorResponse(
                            HttpStatusCode.NotFound, "Tag with provided ID not found!");
                        throw new HttpResponseException(errorResponse);
                    }

                    var tagPostModels = new List<PostModel>();
                    var tagPostEntities = tagEntity.Posts.OrderByDescending(p => p.PostDate);
                    foreach (var tagPostEntity in tagPostEntities)
                    {
                        tagPostModels.Add(PostsMapper.ToModel(tagPostEntity));
                    }

                    return tagPostModels;
                }
            });

            return tagPosts;
        }
    }
}
