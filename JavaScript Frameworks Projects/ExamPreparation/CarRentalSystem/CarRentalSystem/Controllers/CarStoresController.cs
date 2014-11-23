namespace CarRentalSystem.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;

    using CarRentalSystem.Data;
    using CarRentalSystem.DataMappers;
    using CarRentalSystem.DataTransferObjects;
    using CarRentalSystem.Headers;
    using CarRentalSystem.Models;
    using CarRentalSystem.Validators;

    public class CarStoresController : BaseApiController
    {
        public CarStoresController()
            : this(new CarRentalSystemContextFactory())
        { }

        public CarStoresController(IDbContextFactory<DbContext> contextFactory)
            : base(contextFactory)
        { }

        [HttpGet, ActionName("all")]
        public IQueryable<CarStoreModel> All(
            [FromUri]double latitude, 
            [FromUri]double longitude,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var allCarStores = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var carEntities = context.Set<CarStore>()
                        .OrderBy(cst => cst.Latitude - latitude)
                        .ThenBy(cst => cst.Longitude - longitude)
                        .ToList();
                    var carStoresModels = carEntities.Select(CarStoresMapper.ToModel).AsQueryable();

                    return carStoresModels;
                }
            });

            return allCarStores;
        }

        [HttpGet, ActionName("all")]
        public CarStoreModel GetByID(
            int carStoreId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var carStore = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var carStoreEntity = context.Set<CarStore>().Find(carStoreId);
                    if (carStoreEntity == null)
                    {
                        throw new InvalidOperationException("A car store with provided ID does not exist!");
                    }

                    var carStoreModel = CarStoresMapper.ToModel(carStoreEntity);
                    return carStoreModel;
                }
            });

            return carStore;
        }

        [HttpGet, ActionName("cars")]
        public IQueryable<CarModel> GetCars(
            int carStoreId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var carsModels = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var carStore = context.Set<CarStore>().Find(carStoreId);
                    if (carStore == null)
                    {
                        throw new InvalidOperationException("Car store with provided ID does not exist!");
                    }

                    var carModels = carStore.Cars.Select(CarsMapper.ToModel).AsQueryable();

                    return carModels;
                }
            });

            return carsModels;
        }
    }
}
