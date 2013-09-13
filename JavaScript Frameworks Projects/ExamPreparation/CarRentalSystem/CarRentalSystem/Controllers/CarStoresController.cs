namespace CarRentalSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web.Http;
    using CarRentalSystem.Data;
    using CarRentalSystem.DataMappers;
    using CarRentalSystem.DataTransferObjects;
    using CarRentalSystem.Models;
    using System.Web.Http.ValueProviders;
    using CarRentalSystem.Headers;
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
        public IQueryable<CarStoreModel> All([FromUri]double latitude, [FromUri]double longitude,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var allCarStores = this.PerformOperation<IQueryable<CarStoreModel>>(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var carStoresModels = new List<CarStoreModel>();
                    var carEntities = context.Set<CarStore>()
                        .OrderBy(cst => cst.Latitude - latitude)
                        .ThenBy(cst => cst.Longitude - longitude);
                    foreach (var carStoreEntity in carEntities)
                    {
                        carStoresModels.Add(CarStoresMapper.ToModel(carStoreEntity));
                    }

                    return carStoresModels.AsQueryable<CarStoreModel>();
                }
            });

            return allCarStores;
        }

        [HttpGet, ActionName("all")]
        public CarStoreModel GetByID(int carStoreId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var carStore = this.PerformOperation<CarStoreModel>(() =>
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
        public IQueryable<CarModel> GetCars(int carStoreId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var carsModels = this.PerformOperation<IQueryable<CarModel>>(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var carStore = context.Set<CarStore>().Find(carStoreId);
                    if (carStore == null)
                    {
                        throw new InvalidOperationException("Car store with provided ID does not exist!");
                    }

                    var carModels = new List<CarModel>();
                    var carEntities = carStore.Cars;
                    foreach (var carEntity in carEntities)
                    {
                        carModels.Add(CarsMapper.ToModel(carEntity));
                    }

                    return carModels.AsQueryable<CarModel>();
                }
            });

            return carsModels;
        }
    }
}
