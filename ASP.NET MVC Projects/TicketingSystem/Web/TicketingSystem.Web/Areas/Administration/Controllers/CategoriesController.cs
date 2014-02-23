namespace TicketingSystem.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.Areas.Administration.ViewModels.Categories;
    using TicketingSystem.Web.Controllers;

    public class CategoriesController : KendoGridAdministrationController
    {
        public CategoriesController(ITicketingSystemData data)
            : base(data)
        {
        }

        public override IEnumerable GetData()
        {
            return this.Data.Categories
                .All()
                .Select(GridCategoryViewModel.ViewModel);
        }

        public override object GetById(object id)
        {
            return this.Data.Categories
                .All()
                .FirstOrDefault(x => x.Id == (int)id);
        }

        public override string GetEntityKeyName()
        {
            return this.GetEntityKeyNameByType(typeof(Category));
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, GridCategoryViewModel model)
        {
            var categoryEntity = model.GetEntityModel();
            model.Id = (int)this.BaseCreate(categoryEntity);
            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, GridCategoryViewModel model)
        {
            var categoryEntity = this.GetById(model.Id) as Category;
            this.BaseUpdate(model.GetEntityModel(categoryEntity));
            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, GridCategoryViewModel model)
        {
            var categoryEntity = this.Data.Categories
                .All()
                .Include("Tickets")
                .Include("Tickets.Comments")
                .FirstOrDefault(x => x.Id == model.Id);
            if (categoryEntity != null)
            {
                foreach (var ticket in categoryEntity.Tickets.ToList())
                {
                    foreach (var comment in ticket.Comments.ToList())
                    {
                        this.Data.Comments.Delete(comment);
                    }

                    this.Data.Tickets.Delete(ticket);
                }
            }

            this.Data.Categories.Delete(categoryEntity);
            this.Data.SaveChanges();
            
            return this.GridOperation(request, model);
        }
    }
}