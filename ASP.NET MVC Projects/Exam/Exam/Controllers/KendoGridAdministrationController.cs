namespace Exam.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using Exam.Data.Contracts;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Newtonsoft.Json;

    public abstract class KendoGridAdministrationController : BaseController
    {
        protected KendoGridAdministrationController(IExamData data)
            : base(data)
        { }

        public abstract IEnumerable GetData();

        [HttpPost]
        public virtual ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.GetData();
            var serializationSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var json = JsonConvert.SerializeObject(data.ToDataSourceResult(request), Formatting.None, serializationSettings);
            return this.Content(json, "application/json"); // Json(data.ToDataSourceResult(request));
        }
    }
}