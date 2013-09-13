namespace SchoolsSystem.Services.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        protected HttpResponseMessage PerformOperation<T>(Func<T> operation)
        {
            try
            {
                T operationResult = operation();
                return Request.CreateResponse(HttpStatusCode.OK, operationResult);
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Message);
            }
        }

        protected HttpResponseMessage PerformAction(Action action)
        {
            try
            {
                action();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Message);
            }
        }
    }
}
