namespace BloggingSystem.IntegrationTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Transactions;
    using System.Web.Http;
    using BloggingSystem.DataTransferObjects;
    using BloggingSystem.Services.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PostsControllerIntegrationTests
    {
        private static TransactionScope transactionScope;
        private InMemoryHttpServer httpServer;
        IDictionary<string, string> sessionKeyHeader;

        [TestInitialize]
        public void TestInitialize()
        {
            // Needed to load the assemlies of Services project
            PostsController postsController = new PostsController();

            transactionScope = new TransactionScope();

            var routes = new List<Route>()
            {
                new Route(
                    "PostsApi",
                    "api/posts/{postID}/{action}",
                    new 
                    { 
                        controller = "posts",
                        postID = RouteParameter.Optional,
                        action = RouteParameter.Optional 
                    }),
                new Route(
                    "UsersApi",
                    "api/users/{action}",
                    new { controller = "users" })
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);

            // Register a user and user his session key for tests
            var testUser = new UserRegisterModel()
            {
                DisplayName = "Pesho Peshov",
                Username = "Peshov",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var httpResponse = this.httpServer.Post("api/users/register", testUser);
            var loggedUserModel = httpResponse.Content.ReadAsAsync<UserLoggedModel>().Result;
            this.sessionKeyHeader = new Dictionary<string, string>();
            this.sessionKeyHeader["X-sessionKey"] = loggedUserModel.SessionKey;
        }

        [TestCleanup]
        public void TestTearDown()
        {
            transactionScope.Dispose();
        }

        [TestMethod]
        public void Create_WhenValidPostWithTags_ShouldReturn201CodeAndPostedPost()
        {
            PostModel newPost = new PostModel()
            {
                Title = "Peshov post",
                Text = "Pesho posted a new post!!!",
                Tags = new List<string>() { "tag" }
            };

            var httpResponse = this.httpServer.Post("api/posts", newPost, this.sessionKeyHeader);
            var postedPost = httpResponse.Content.ReadAsAsync<PostedPost>().Result;

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.IsNotNull(httpResponse.Content);
            Assert.AreEqual(newPost.Title, postedPost.Title);
        }

        [TestMethod]
        public void Create_WhenValidPostWithoutTags_ShouldReturn201CodeAndNotNullContent()
        {
            PostModel newPost = new PostModel()
            {
                Title = "Peshov post",
                Text = "Pesho posted a new post!!!"
            };

            var httpResponse = this.httpServer.Post("api/posts", newPost, this.sessionKeyHeader);
            var postedPost = httpResponse.Content.ReadAsAsync<PostedPost>().Result;

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.IsNotNull(postedPost);
            Assert.AreEqual(newPost.Title, postedPost.Title);
        }

        [TestMethod]
        public void Create_WhenNullPost_ShouldReturn400ErrorResponse()
        {
            var httpResponse = this.httpServer.Post("api/posts", null, this.sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void Create_WhenPostWithoutTitle_ShouldReturn400ErrorResponse()
        {
            PostModel newPost = new PostModel()
            {
                Text = "Pesho posted a new post!!!"
            };

            var httpResponse = this.httpServer.Post("api/posts", newPost, this.sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void GetByTags_WhenPostContainsSearchedTags_ShouldReturn200CodeAndCollectionOfOne()
        {
            var posts = new List<PostModel>()
            {
                new PostModel()
                {
                    Title = "post",
                    Text = "Pesho posted a new post 1!!!"
                },
                new PostModel()
                {
                    Title = "post new yeah",
                    Text = "Pesho posted a new post 2!!!",
                    Tags = new List<string>() { "new" }
                },
                new PostModel()
                {
                    Title = "post new and oldy",
                    Text = "Pesho posted a new post 3!!!",
                    Tags = new List<string>() { "taggy", "old" }
                }
            };

            // Add some tags
            foreach (var postModel in posts)
            {
                this.httpServer.Post("api/posts", postModel, this.sessionKeyHeader);
            }

            var httpResponse = this.httpServer.Get("api/posts?tags=post,old,new", this.sessionKeyHeader);
            var postsWithTags = httpResponse.Content.ReadAsAsync<IEnumerable<PostModel>>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.IsNotNull(postsWithTags);
            Assert.AreEqual(1, postsWithTags.Count());
        }

        [TestMethod]
        public void GetByTags_WhenNoPostContainsSearchedTags_ShouldReturn200CodeAndEmptyCollection()
        {
            var posts = new List<PostModel>()
            {
                new PostModel()
                {
                    Title = "post",
                    Text = "Pesho posted a new post 1!!!"
                },
                new PostModel()
                {
                    Title = "post new yeah",
                    Text = "Pesho posted a new post 2!!!",
                    Tags = new List<string>() { "new" }
                },
                new PostModel()
                {
                    Title = "post new and oldy",
                    Text = "Pesho posted a new post 3!!!",
                    Tags = new List<string>() { "taggy", "old" }
                }
            };

            // Add some tags
            foreach (var postModel in posts)
            {
                this.httpServer.Post("api/posts", postModel, this.sessionKeyHeader);
            }

            var httpResponse = this.httpServer.Get("api/posts?tags=post,old,new,pesho", this.sessionKeyHeader);
            var postsWithTags = httpResponse.Content.ReadAsAsync<IEnumerable<PostModel>>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.IsNotNull(postsWithTags);
            Assert.AreEqual(0, postsWithTags.Count());
        }

        [TestMethod]
        public void GetByTags_WhenNoTagsAreSearched_ShouldReturn400Response()
        {
            var posts = new List<PostModel>()
            {
                new PostModel()
                {
                    Title = "post",
                    Text = "Pesho posted a new post 1!!!"
                },
                new PostModel()
                {
                    Title = "post new yeah",
                    Text = "Pesho posted a new post 2!!!",
                    Tags = new List<string>() { "new" }
                },
                new PostModel()
                {
                    Title = "post new and oldy",
                    Text = "Pesho posted a new post 3!!!",
                    Tags = new List<string>() { "taggy", "old" }
                }
            };

            // Add some tags
            foreach (var postModel in posts)
            {
                this.httpServer.Post("api/posts", postModel, this.sessionKeyHeader);
            }

            var httpResponse = this.httpServer.Get("api/posts?tags=", this.sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void GetByTags_WhenMultiplePostContainsSearchedTags_ShouldReturn200CodeAndCollection()
        {
            var posts = new List<PostModel>()
            {
                new PostModel()
                {
                    Title = "postting post",
                    Text = "Pesho posted a new post 1!!!"
                },
                new PostModel()
                {
                    Title = "post postting yeah",
                    Text = "Pesho posted a new post 2!!!",
                    Tags = new List<string>() { "new" }
                },
                new PostModel()
                {
                    Title = "post new and oldy",
                    Text = "Pesho posted a new post 3!!!",
                    Tags = new List<string>() { "taggy", "old" }
                }
            };

            // Add some tags
            foreach (var postModel in posts)
            {
                this.httpServer.Post("api/posts", postModel, this.sessionKeyHeader);
            }

            var httpResponse = this.httpServer.Get("api/posts?tags=post,postting", this.sessionKeyHeader);
            var postsWithTags = httpResponse.Content.ReadAsAsync<IEnumerable<PostModel>>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.IsNotNull(postsWithTags);
            Assert.AreEqual(2, postsWithTags.Count());
        }

        [TestMethod]
        public void Comment_WhenPostExists_ShouldReturn201CodeAndEmptyContent()
        {
            // Add a post to test
            PostModel newPost = new PostModel()
            {
                Title = "Peshov post",
                Text = "Pesho posted a new post!!!"
            };

            var createPostResponse = this.httpServer.Post("api/posts", newPost, this.sessionKeyHeader);
            var postedPost = createPostResponse.Content.ReadAsAsync<PostedPost>().Result;

            CommentModel testComment = new CommentModel()
            {
                Text = "Test comment!"
            };
            
            var postID = postedPost.ID;
            var httpResponse = this.httpServer.Put("api/posts/" + postID + "/comment", testComment, this.sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.IsNull(httpResponse.Content);
        }

        [TestMethod]
        public void Comment_WhenPostNotExists_ShouldReturn404ErrorResponse()
        {
            CommentModel testComment = new CommentModel()
            {
                Text = "Test comment!"
            };

            var httpResponse = this.httpServer.Put("api/posts/" + 11898712 + "/comment", testComment, this.sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [TestMethod]
        public void Comment_WhenInvalidComment_ShouldReturn400ErrorResponse()
        {
            // Add a post to test
            PostModel newPost = new PostModel()
            {
                Title = "Peshov post",
                Text = "Pesho posted a new post!!!"
            };

            var createPostResponse = this.httpServer.Post("api/posts", newPost, this.sessionKeyHeader);
            var postedPost = createPostResponse.Content.ReadAsAsync<PostedPost>().Result;

            CommentModel testComment = new CommentModel();

            var postID = postedPost.ID;
            var httpResponse = this.httpServer.Put("api/posts/" + postID + "/comment", testComment, this.sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void Comment_WhenNullComment_ShouldReturn400ErrorResponse()
        {
            // Add a post to test
            PostModel newPost = new PostModel()
            {
                Title = "Peshov post",
                Text = "Pesho posted a new post!!!"
            };

            var createPostResponse = this.httpServer.Post("api/posts", newPost, this.sessionKeyHeader);
            var postedPost = createPostResponse.Content.ReadAsAsync<PostedPost>().Result;

            var postID = postedPost.ID;
            var httpResponse = this.httpServer.Put("api/posts/" + postID + "/comment", null, this.sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
    }
}
