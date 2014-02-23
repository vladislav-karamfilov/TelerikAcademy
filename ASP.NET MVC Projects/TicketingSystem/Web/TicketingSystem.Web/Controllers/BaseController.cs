namespace TicketingSystem.Web.Controllers
{
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    using TicketingSystem.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController(ITicketingSystemData data)
        {
            this.Data = data;
        }

        protected ITicketingSystemData Data { get; private set; }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (this.Request.IsAjaxRequest())
            {
                var exception = filterContext.Exception as HttpException;
                if (exception != null)
                {
                    this.Response.StatusCode = exception.GetHttpCode();
                    this.Response.StatusDescription = exception.Message;
                }
            }
            else
            {
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString();
                var actionName = this.ControllerContext.RouteData.Values["Action"].ToString();
                this.View("Error", new HandleErrorInfo(filterContext.Exception, controllerName, actionName)).ExecuteResult(this.ControllerContext);
            }

            filterContext.ExceptionHandled = true;
        }

        protected string GetModelStateErrors()
        {
            if (this.ModelState.IsValid)
            {
                return null;
            }

            var errors = new StringBuilder();
            foreach (var error in this.ModelState.Values.SelectMany(x => x.Errors))
            {
                errors.AppendLine(error.ErrorMessage);
            }

            return errors.ToString();
        }
    }
}