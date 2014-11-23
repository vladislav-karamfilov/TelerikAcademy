namespace CarRentalSystem.Controllers
{
    using System;
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
            var allCars = this.PerformOperation(() =>
            {
                using (var context = this.ContextFactory.Create())
                {
                    var carEntities = context.Set<Car>().Include("Renter").OrderBy(c => c.Make).ThenBy(c => c.Model).ToList();
                    var carModels = carEntities.Select(CarsMapper.ToModel).AsQueryable();

                    return carModels;
                }
            });

            return allCars;
        }

        [HttpGet, ActionName("all")]
        public CarModel GetByID(int carId)
        {
            using (var context = this.ContextFactory.Create())
            {
                var carEntity = context.Set<Car>().Find(carId);
                if (carEntity == null)
                {
                    var errorResponse = this.Request.CreateErrorResponse(
                        HttpStatusCode.NotFound, "Car with provided ID does not exist!");
                    throw new HttpResponseException(errorResponse);
                }

                return CarsMapper.ToModel(carEntity);
            }
        }

        [HttpPut, ActionName("rent")]
        public HttpResponseMessage RentCar(
            int carId,
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
        public HttpResponseMessage ReturnCar(
            int carId,
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
        public IQueryable<CarModel> GetCarsPage(
            [FromUri]int page,
            [FromUri]int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var cars = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var carEntities = context.Set<Car>().OrderBy(x => x.Make).Skip(page * count).Take(count).ToList();
                    var carModels = carEntities.Select(CarsMapper.ToModel).AsQueryable();
                    return carModels;
                }
            });

            return cars;
        }

        [HttpGet, ActionName("rented")]
        public IQueryable<CarModel> GetMyRentedCars(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]string sessionKey)
        {
            var rentedCars = this.PerformOperation(() =>
            {
                UserValidator.ValidateSessionKey(sessionKey);

                using (var context = this.ContextFactory.Create())
                {
                    var user = context.Set<User>().FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password!");
                    }

                    var rentedCarEntities = context.Set<Car>().Where(c => c.Renter.DisplayName == user.DisplayName).ToList();
                    var rentedCarModels = rentedCarEntities.Select(CarsMapper.ToModel).AsQueryable();

                    return rentedCarModels;
                }
            });

            return rentedCars;
        }
    }
}
