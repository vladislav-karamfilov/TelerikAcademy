namespace TelerikAcademyForum.Services.DataMappers
{
    using TelerikAcademyForum.DataTransferObjects;
    using TelerikAcademyForum.Models;

    public static class UsersMapper
    {
        public static User ToEntity(UserRegisterModel userModel)
        {
            User userEntity = new User()
            {
                Username = userModel.Username.ToLower(),
                Nickname = userModel.Nickname,
                AuthCode = userModel.AuthCode
            };

            return userEntity;
        }

        public static UserLoggedModel ToUserLoggedModel(User userEntity)
        {
            UserLoggedModel userLoggedModel = new UserLoggedModel()
            {
                Nickname = userEntity.Nickname,
                SessionKey = userEntity.SessionKey
            };

            return userLoggedModel;
        }
    }
}