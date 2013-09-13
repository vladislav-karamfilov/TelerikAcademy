namespace CarRentalSystem.DataMappers
{
    using CarRentalSystem.DataTransferObjects;
    using CarRentalSystem.Models;

    public static class UsersMapper
    {
        public static User ToEntity(UserRegisterModel userModel)
        {
            User userEntity = new User()
            {
                Username = userModel.Username.ToLower(),
                DisplayName = userModel.DisplayName,
                AuthCode = userModel.AuthCode
            };

            return userEntity;
        }

        public static UserLoggedModel ToModel(User userEntity)
        {
            UserLoggedModel userLoggedModel = new UserLoggedModel()
            {
                DisplayName = userEntity.DisplayName,
                SessionKey = userEntity.SessionKey
            };

            return userLoggedModel;
        }
    }
}