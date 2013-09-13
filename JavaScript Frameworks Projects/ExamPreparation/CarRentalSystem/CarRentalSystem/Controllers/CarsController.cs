namespace CarRentalSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using CarRentalSystem.Data;
    using CarRentalSystem.DataMappers;
    using CarRentalSystem.DataTransferObjects;
    using CarRentalSystem.Headers;
    using CarRentalSystem.Models;
    using CarRentalSystem.Validators;

    public class CarsController : BaseApiController
    {
        public CarsController()
            : this(new CarRentalSystemContextFactory())
        { }

        public CarsController(IDbContextFactory<DbContext> contextFactory)
            : base(contextFactory)
        { }

        [HttpGet, ActionName("all")]
        public IQueryable<CarModel> GetAll()
        {
            var allCars = this.PerformOperation<IQueryable<CarModel>>(() =>
            {
                using (var context = this.ContextFactory.Create())
                {
                    var carModels = new List<CarModel>();
                    var carEntities = context.Set<Car>().Include("Renter").OrderBy(c => c.Make).ThenBy(c => c.Model);
                    foreach (var carEntity in carEntities)
                    {
                        carModels.Add(CarsMapper.ToModel(carEntity));
                    }

                    return carModels.AsQueryable<CarModel>();
                }
            });

            return allCars;
        }

        [HttpGet, ActionName("all")]
        public CarModel GetByID(int carId)
        {
            var carModel = this.GetAll().FirstOrDefault(c => c.ID == carId);
            if (carModel == null)
            {
                var errorResponse = this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "Car with provided ID does not exist!");
                throw new HttpResponseException(errorResponse);
            }

            return carModel;
        }

        [HttpPut, ActionName("rent")]
        public HttpResponseMessage RentCar(int carId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var loggedUserEntity = context.Set<User>().FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (loggedUserEntity == null)
                    {
                        throw new InvalidOperationException("Invalid username or pasword!");
                    }

                    var carEntity = context.Set<Car>().Find(carId);
                    if (carEntity == null)
                    {
                        throw new InvalidOperationException("Car with provided ID does not exist!");
                    }

                    carEntity.Renter = loggedUserEntity;
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                    return response;
                }
            });

            return responseMessage;
        }

        [HttpPut, ActionName("return")]
        public HttpResponseMessage ReturnCar(int carId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var loggedUserEntity = context.Set<User>().FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (loggedUserEntity == null)
                    {
                        throw new InvalidOperationException("Invalid username or pasword!");
                    }

                    var carEntity = context.Set<Car>().Find(carId);
                    if (carEntity == null)
                    {
                        throw new InvalidOperationException("Car with provided ID does not exist!");
                    }

                    carEntity.Renter = null;
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                    return response;
                }
            });

            return responseMessage;
        }

        [HttpGet]
        public IQueryable<CarModel> GetCarsPage([FromUri]int page, [FromUri]int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            UserValidator.ValidateSessionKey(sessionKey);

            return this.GetAll().Skip(page * count).Take(count);
        }

        [HttpGet, ActionName("rented")]
        public IQueryable<CarModel> GetMyRentedCars(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var rentedCars = this.PerformOperation<IQueryable<CarModel>>(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var user = context.Set<User>().FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password!");
                    }

                    var rentedCarModels = new List<CarModel>();
                    var rentedCarEntities = context.Set<Car>().Where(c => c.Renter.DisplayName == user.DisplayName);
                    foreach (var carEntity in rentedCarEntities)
                    {
                        rentedCarModels.Add(CarsMapper.ToModel(carEntity));
                    }

                    return rentedCarModels.AsQueryable<CarModel>();
                }
            });

            return rentedCars;
        }
    }
}
