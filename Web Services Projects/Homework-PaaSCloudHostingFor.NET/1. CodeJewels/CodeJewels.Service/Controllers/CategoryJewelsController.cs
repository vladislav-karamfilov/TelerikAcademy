namespace CodeJewels.Service.Controllers
{
    using CodeJewels.DataLayer;
    using CodeJewels.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    public class CategoryJewelsController : ApiController
    {
        CodeJewelsContext dbContext;

        public CategoryJewelsController(CodeJewelsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<JewelCategory> Get()
        {
            return this.dbContext.JewelCategories.AsEnumerable();
        }

        public JewelCategory Get(int id)
        {
            return this.dbContext.JewelCategories.Find(id);
        }

        public JewelCategory Post(JewelCategory value)
        {
            var added = this.dbContext.JewelCategories.Add(value);
            this.dbContext.SaveChanges();

            return added;
        }
    }
}
