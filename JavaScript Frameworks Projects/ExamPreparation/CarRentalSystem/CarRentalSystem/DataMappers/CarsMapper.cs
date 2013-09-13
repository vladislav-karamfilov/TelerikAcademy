namespace CarRentalSystem.DataMappers
{
    using CarRentalSystem.DataTransferObjects;
    using CarRentalSystem.Models;

    public static class CarsMapper
    {
        public static CarModel ToModel(Car carEntity)
        {
            var carModel = new CarModel()
            {
                ID = carEntity.ID,
                Make = carEntity.Make,
                Model = carEntity.Model,
                Year = carEntity.Year,
                Engine = carEntity.Engine,
                Power = carEntity.Power,
                Renter = (carEntity.Renter != null) ? carEntity.Renter.DisplayName : null
            };

            return carModel;
        }
    }
}