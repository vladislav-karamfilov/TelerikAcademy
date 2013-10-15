namespace Newster.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Newster.Data.Contracts;
    using Newster.DataTransferObjects;
    using System.Web.Http.ValueProviders;
    using Newster.Services.Attributes;
    using Newster.Services.Utilities;

    public class NewsArticlesController : BaseApiController
    {
        private readonly INewsterData data;

        public NewsArticlesController(INewsterData data)
        {
            this.data = data;
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
                    .Select(NewsArticleDTO.FromModel)
                    .Take(15);
                return topVotedNewsArticleDtos;
            });

            return topVotedNewsArticles;
        }

        [HttpGet, ActionName("mostRecent")]
        public IQueryable<NewsArticleDTO> GetTopVoted(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            IQueryable<NewsArticleDTO> mostRecentNewsArticles = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var mostRecentNewsArticleDtos = this.data.NewsArticles.All()
                    .OrderByDescending(n => n.Date)
                    .Select(NewsArticleDTO.FromModel)
                    .Take(10);
                return mostRecentNewsArticleDtos;
            });

            return mostRecentNewsArticles;
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
    }
}