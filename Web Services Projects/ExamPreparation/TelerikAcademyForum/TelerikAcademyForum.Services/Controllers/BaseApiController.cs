namespace TelerikAcademyForum.Services.Controllers
{
    using System;
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
            catch (Exception exc)
            {
                var errorResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, exc.Message);
                throw new HttpResponseException(errorResponse);
            }
        }
    }
}
