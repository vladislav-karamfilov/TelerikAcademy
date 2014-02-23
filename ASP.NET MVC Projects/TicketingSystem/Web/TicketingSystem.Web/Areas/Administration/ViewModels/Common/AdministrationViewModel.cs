namespace TicketingSystem.Web.Areas.Administration.ViewModels.Common
{
    public abstract class AdministrationViewModel<T> where T : class, new()
    {
        public abstract T ConvertToDatabaseEntity(T model);

        public virtual T GetEntityModel(T model = null)
        {
            model = model ?? new T();
            return this.ConvertToDatabaseEntity(model);
        }
    }
}