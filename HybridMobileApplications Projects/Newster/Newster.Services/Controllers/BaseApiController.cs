namespace Newster.Services.Controllers
{
    using System;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        protected T PerformOperation<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (DbEntityValidationException dbValidationException)
            {
                var errorMessages = dbValidationException.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
                var errorResponse = this.Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, errorMessages));
                throw new HttpResponseException(errorResponse);

            }
            catch (Exception exc)
            {
                var errorResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, exc.Message);
                throw new HttpResponseException(errorResponse);
            }
        }
    }
}
