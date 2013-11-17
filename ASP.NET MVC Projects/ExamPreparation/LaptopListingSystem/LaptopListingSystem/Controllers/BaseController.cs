namespace LaptopListingSystem.Controllers
{
    using System.Web.Mvc;
    using LaptopListingSystem.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController(ILaptopListingSystemData data)
        {
            this.Data = data;
        }

        protected ILaptopListingSystemData Data { get; private set; }
    }
}