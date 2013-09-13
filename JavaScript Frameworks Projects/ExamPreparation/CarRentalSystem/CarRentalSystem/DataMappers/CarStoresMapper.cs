namespace CarRentalSystem.DataMappers
{
    using CarRentalSystem.DataTransferObjects;
    using CarRentalSystem.Models;

    public static class CarStoresMapper
    {
        public static CarStoreModel ToModel(CarStore carStoreEntity)
        {
            var carStoreModel = new CarStoreModel()
            {
                ID = carStoreEntity.ID,
                Name = carStoreEntity.Name,
                Latitude = carStoreEntity.Latitude,
                Longitude = carStoreEntity.Longitude
            };

            return carStoreModel;
        }
    }
}