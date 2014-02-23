namespace TicketingSystem.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.Areas.Administration.ViewModels.Comments;
    using TicketingSystem.Web.Controllers;

    public class CommentsController : KendoGridAdministrationController
    {
        public CommentsController(ITicketingSystemData data)
            : base(data)
        {
        }

        public override IEnumerable GetData()
        {
            return this.Data.Comments
                .All()
                .Select(GridCommentViewModel.ViewModel);
        }

        public override object GetById(object id)
        {
            return this.Data.Comments
                .All()
                .FirstOrDefault(x => x.Id == (int)id);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, GridCommentViewModel model)
        {
            var categoryEntity = this.GetById(model.Id) as Comment;
            this.BaseUpdate(model.GetEntityModel(categoryEntity));
            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, GridCommentViewModel model)
        {
            this.BaseDestroy(model.Id);
            return this.GridOperation(request, model);
        }
    }
}