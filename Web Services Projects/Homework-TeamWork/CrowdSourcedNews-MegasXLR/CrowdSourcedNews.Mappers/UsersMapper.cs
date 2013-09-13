namespace CrowdSourcedNews.Mappers
{
    using CrowdSourcedNews.DataTransferObjects;
    using CrowdSourcedNews.Models;

    public static class UsersMapper
    {
        public static UserModel ToUserModel(User userEntity)
        {
            UserModel userModel = new UserModel()
            {
                ID = userEntity.ID,
                Nickname = userEntity.Nickname
            };

            foreach (NewsArticle newsArticle in userEntity.NewsArticles)
            {
                NewsArticleModel newsArticleModel = NewsArticlesMapper.ToNewsArticleModel(newsArticle);
                userModel.NewsArticles.Add(newsArticleModel);
            }

            return userModel;
        }

        public static User ToUserEntity(UserRegisterModel userModel)
        {
            User userEntity = new User()
                {
                    Username = userModel.Username.ToLower(),
                    AuthCode = userModel.AuthCode,
                    Nickname = userModel.Nickname
                };

            return userEntity;
        }
    }
}
