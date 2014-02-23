namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.Collections;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Newtonsoft.Json;

    using TicketingSystem.Data.Contracts;

    public abstract class KendoGridAdministrationController : BaseController
    {
        protected KendoGridAdministrationController(ITicketingSystemData data)
            : base(data)
        {
        }

        [NonAction]
        public abstract IEnumerable GetData();

        [NonAction]
        public abstract object GetById(object id);

        [NonAction]
        public virtual string GetEntityKeyName()
        {
            throw new InvalidOperationException("GetEntityKeyName method required but not implemented in derived controller.");
        }

        [HttpPost]
        public virtual ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.GetData();
            var serializationSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var json = JsonConvert.SerializeObject(data.ToDataSourceResult(request), Formatting.None, serializationSettings);
            return this.Content(json, "application/json");
        }

        protected object BaseCreate(object model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var itemForAdding = this.Data.Context.Entry(model);
                itemForAdding.State = EntityState.Added;
                this.Data.SaveChanges();
                var databaseValues = itemForAdding.GetDatabaseValues();
                return databaseValues[this.GetEntityKeyName()];
            }

            return null;
        }

        protected void BaseUpdate(object model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var itemForUpdating = this.Data.Context.Entry(model);
                itemForUpdating.State = EntityState.Modified;
                this.Data.SaveChanges();
            }
        }

        protected void BaseDestroy(object id)
        {
            var model = this.GetById(id);
            if (model != null)
            {
                var itemForDeletion = this.Data.Context.Entry(model);
                if (itemForDeletion != null)
                {
                    itemForDeletion.State = EntityState.Deleted;
                    this.Data.SaveChanges();
                }
            }
        }

        protected JsonResult GridOperation([DataSourceRequest]DataSourceRequest request, object model)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        protected string GetEntityKeyNameByType(Type type)
        {
            var keyProperty = type.GetProperties()
                .FirstOrDefault(pr => pr.GetCustomAttributes(typeof(KeyAttribute), true).Any());
            if (keyProperty == null)
            {
                throw new ArgumentException("Provided type does not have a Key property.", "type");
            }

            return keyProperty.Name;
        }
    }
}