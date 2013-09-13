namespace BloggingSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using BloggingSystem.Data;
    using BloggingSystem.DataTransferObjects;
    using BloggingSystem.Models;
    using BloggingSystem.Services.Attributes;
    using BloggingSystem.Services.DataMappers;
    using BloggingSystem.Services.Validators;

    public class PostsController : BaseApiController
    {
        private static readonly char[] WordSeparators = new char[]
        {
            '.', ' ', ',', '!', '?', '(', ')', '\"', '-', '%', '+', '\\', '|', '\''
        };

        private static readonly char[] TagSeparators = new char[] { ',' };

        [HttpGet]
        public IQueryable<PostModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            IQueryable<PostModel> allPostModels = this.PerformOperation(() =>
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

                    var postModels = new List<PostModel>();

                    var postEntities = context.Posts
                        .Include("Comments").Include("Tags")
                        .OrderByDescending(p => p.PostDate);
                    foreach (var postEntity in postEntities.ToList())
                    {
                        postModels.Add(PostsMapper.ToModel(postEntity));
                    }

                    return postModels.AsQueryable<PostModel>();
                }
            });

            return allPostModels;
        }

        [HttpGet]
        public IEnumerable<PostModel> GetPage([FromUri]int page, [FromUri]int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var postsOnPage = this.GetAll(sessionKey).Skip(page * count).Take(count);

            return postsOnPage;
        }

        [HttpGet]
        public IEnumerable<PostModel> GetByKeyword([FromUri]string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            if (keyword == null)
            {
                var errorResponse = this.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Keyword to search is not provided!");
                throw new HttpResponseException(errorResponse);
            }

            var allPostModels = this.GetAll(sessionKey);

            var keywordLowerCase = keyword.ToLower();
            var allPostsByKeyword = new List<PostModel>();
            foreach (var post in allPostModels)
            {
                var titleWords = post.Title.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var titleWord in titleWords)
                {
                    if (titleWord.ToLower() == keywordLowerCase)
                    {
                        allPostsByKeyword.Add(post);
                        break;
                    }
                }
            }

            return allPostsByKeyword;
        }

        [HttpGet]
        public IEnumerable<PostModel> GetByTags([FromUri]string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            if (tags == null)
            {
                var errorResponse = this.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Tags to search are not provided!");
                throw new HttpResponseException(errorResponse);
            }

            var allPostModels = this.GetAll(sessionKey);

            var tagsToSearch = tags.Split(TagSeparators, StringSplitOptions.RemoveEmptyEntries);

            var postsWithTags = new List<PostModel>();
            foreach (var postModel in allPostModels)
            {
                if (PostContainsAllTags(postModel, tagsToSearch))
                {
                    postsWithTags.Add(postModel);
                }
            }

            return postsWithTags;
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody]PostModel post,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            HttpResponseMessage httpResponse = this.PerformOperation(() =>
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

                    var newPostEntity = PostsMapper.CreateNewEntity(post, loggedUserEntity, context);
                    context.Posts.Add(newPostEntity);
                    context.SaveChanges();

                    var postedPost = PostsMapper.ToPostedModel(newPostEntity);
                    var response = this.Request.CreateResponse(HttpStatusCode.Created, postedPost);
                    return response;
                }

            });

            return httpResponse;
        }

        [HttpPut, ActionName("comment")]
        public HttpResponseMessage Comment(int postID, [FromBody]CommentModel comment,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            HttpResponseMessage httpResponse = this.PerformOperation(() =>
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

                    var existingPostEntity = context.Posts.Find(postID);
                    if (existingPostEntity == null)
                    {
                        return this.Request.CreateErrorResponse(
                            HttpStatusCode.NotFound, "Post with provided ID not found!");
                    }

                    existingPostEntity.Comments.Add(CommentsMapper.ToEntity(comment, loggedUserEntity));
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            });

            return httpResponse;
        }

        private static bool PostContainsAllTags(PostModel postModel, string[] tagsToSearch)
        {
            foreach (var tagToSearch in tagsToSearch)
            {
                if (!postModel.Tags.Contains(tagToSearch.ToLower()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
