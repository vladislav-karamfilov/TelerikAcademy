namespace TelerikAcademyForum.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using TelerikAcademyForum.Data;
    using TelerikAcademyForum.Services.Attributes;
    using TelerikAcademyForum.Services.Validators;

    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        public IQueryable<string> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var categoryModels = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                var context = new TelerikAcademyForumContext();
                var categories =
                        from category in context.Categories
                        select category.Name;

                return categories;
            });

            return categoryModels;
        }
    }
}
