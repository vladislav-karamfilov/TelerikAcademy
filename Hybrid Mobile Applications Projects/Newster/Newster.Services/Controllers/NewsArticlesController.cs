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
    using Newster.Services.Attributes;
    using Newster.Services.Utilities;
    using Newster.Models;

    public class NewsArticlesController : BaseApiController
    {
        private readonly INewsterData data;

        public NewsArticlesController(INewsterData data)
        {
            this.data = data;
        }

        [HttpPost, ActionName("create")]
        public HttpResponseMessage Create(FullNewsArticleDTO newsArticle,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            HttpResponseMessage message = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var newNewsArticle = new NewsArticle()
                {
                    Author = this.data.Users.All().FirstOrDefault(u => u.SessionKey == sessionKey),
                    CategoryID = newsArticle.CategoryID,
                    Content = newsArticle.Content.Trim(),
                    Coordinates = (newsArticle.Coordinates != null) ?
                        new Coordinates() { Latitude = newsArticle.Coordinates.Latitude, Longitude = newsArticle.Coordinates.Longitude } :
                        null,
                    Date = DateTime.Now,
                    ImageUrl = newsArticle.ImageUrl.Trim(),
                    Title = newsArticle.Title.Trim()
                };

                this.data.NewsArticles.Add(newNewsArticle);
                this.data.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.Created, newsArticle);
            });

            return message;
        }

        [HttpGet, ActionName("details")]
        public FullNewsArticleDTO GetDetails(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            FullNewsArticleDTO newsArticle = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var newsArticleDto = this.data.NewsArticles.All()
                    .Where(n => n.ID == id)
                    .Select(FullNewsArticleDTO.FromModel)
                    .FirstOrDefault();

                if (newsArticleDto == null)
                {
                    throw new ArgumentException("News article was not found!", "id");
                }

                return newsArticleDto;
            });

            return newsArticle;
        }

        [HttpGet, ActionName("latest")]
        public IQueryable<NewsArticleDTO> GetLatest(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            IQueryable<NewsArticleDTO> latestNewsArticles = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var latestNewsArticleDtos = this.data.NewsArticles.All()
                    .OrderByDescending(n => n.Date)
                    .Select(NewsArticleDTO.FromModel)
                    .Take(10);
                return latestNewsArticleDtos;
            });

            return latestNewsArticles;
        }

        [HttpGet, ActionName("all")]
        public IQueryable<NewsArticleDTO> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            IQueryable<NewsArticleDTO> allNewsArticles = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var allNewsArticlesDtos = this.data.NewsArticles.All()
                    .OrderByDescending(n => n.Date)
                    .Select(NewsArticleDTO.FromModel);
                return allNewsArticlesDtos;
            });

            return allNewsArticles;
        }

        [HttpGet, ActionName("topVoted")]
        public IQueryable<NewsArticleDTO> GetTopVoted(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            IQueryable<NewsArticleDTO> topVotedNewsArticles = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var topVotedNewsArticleDtos = this.data.NewsArticles.All()
                    .OrderByDescending(n => n.Votes)
                    .Select(VotedNewsArticleDTO.FromModel)
                    .Take(15);
                return topVotedNewsArticleDtos;
            });

            return topVotedNewsArticles;
        }

        [HttpGet, ActionName("comments")]
        public IQueryable<CommentDTO> GetComments(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            IQueryable<CommentDTO> comments = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                if (!this.data.NewsArticles.All().Any(n => n.ID == id))
                {
                    throw new ArgumentException("The news article was not found!", "newsArticleId");
                }

                var commentsDtos = this.data.Comments.All()
                    .Where(c => c.NewsArticleID == id)
                    .OrderBy(c => c.Date)
                    .Select(CommentDTO.FromModel);

                return commentsDtos;
            });

            return comments;
        }

        [HttpPut, ActionName("comment")]
        public HttpResponseMessage Comment(int id, string comment,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            HttpResponseMessage message = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var newsArticle = this.data.NewsArticles.GetById(id);
                if (newsArticle == null)
                {
                    return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "The news article was not found...");
                }

                var commentAuthor = this.data.Users.All().FirstOrDefault(u => u.SessionKey == sessionKey);
                if (commentAuthor == null)
                {
                    return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "The comment author is not valid!");
                }

                comment = comment.Trim();

                var newComment = new Comment() { AuthorID = commentAuthor.ID, Content = comment, Date = DateTime.Now };
                newsArticle.Comments.Add(newComment);

                this.data.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.OK);
            });

            return message;
        }

        [HttpPut, ActionName("vote")]
        public HttpResponseMessage Vote(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            HttpResponseMessage message = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var newsArticle = this.data.NewsArticles.GetById(id);
                if (newsArticle == null)
                {
                    return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "The news article was not found...");
                }

                newsArticle.Votes++;
                this.data.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.OK);
            });

            return message;
        }
    }
}