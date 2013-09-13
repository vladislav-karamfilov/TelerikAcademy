namespace CarRentalSystem.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController(IDbContextFactory<DbContext> contextFactory)
        {
            this.ContextFactory = contextFactory;
        }

        public IDbContextFactory<DbContext> ContextFactory { get; protected set; }

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
