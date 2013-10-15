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
    using Newster.Models;
    using Newster.Services.Attributes;
    using Newster.Services.Utilities;

    public class CategoriesController : BaseApiController
    {
        private readonly INewsterData data;

        public CategoriesController(INewsterData data)
        {
            this.data = data;
        }

        [HttpPost, ActionName("create")]
        public HttpResponseMessage Create(string category,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            HttpResponseMessage responseMessage = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);
                if (this.data.Categories.All().Any(c => c.Name.ToLower() == category.ToLower().Trim()))
                {
                    throw new InvalidOperationException("A category with the provided name already exists!");
                }

                var newCategory = new Category()
                {
                    Name = category
                };

                this.data.Categories.Add(newCategory);
                this.data.SaveChanges();

                var createdCategory = new CategoryDTO()
                {
                    ID = newCategory.ID,
                    Name = newCategory.Name
                };

                return this.Request.CreateResponse(HttpStatusCode.Created, createdCategory);
            });

            return responseMessage;
        }

        [HttpGet, ActionName("all")]
        public IQueryable<CategoryDTO> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            IQueryable<CategoryDTO> categories = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var categoryDtos = this.data.Categories.All().Select(CategoryDTO.FromModel);
                return categoryDtos;
            });

            return categories;
        }

        [HttpGet, ActionName("news")]
        public IQueryable<NewsArticleDTO> GetNews(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            IQueryable<NewsArticleDTO> newsArticles = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var newsArticleDtos = this.data.NewsArticles.All()
                    .Where(n => n.CategoryID == id)
                    .OrderByDescending(n => n.Date)
                    .Select(NewsArticleDTO.FromModel);
                return newsArticleDtos;
            });

            return newsArticles;
        }
    }
}