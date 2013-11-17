namespace LaptopListingSystem.Controllers
{
    using System.Web.Mvc;
    using LaptopListingSystem.Data.Contracts;

    [Authorize(Roles = "Administrator")]
    public class AdministrationController : BaseController
    {
        public AdministrationController(ILaptopListingSystemData data)
            : base(data)
        { }
    }
}