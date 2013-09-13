namespace TelerikAcademyForum.Services.DataMappers
{
    using System;
    using System.Linq;
    using TelerikAcademyForum.Data;
    using TelerikAcademyForum.DataTransferObjects;
    using TelerikAcademyForum.Models;

    public static class ThreadsMapper
    {
        public static Thread ToEntity(
            ThreadModel threadModel,
            string sessionKey,
            TelerikAcademyForumContext context)
        {
            Thread threadEntity = new Thread()
            {
                Title = threadModel.Title,
                Content = threadModel.Content,
                DateCreated = DateTime.Now,
                Author = context.Users.FirstOrDefault<User>(u => u.SessionKey == sessionKey)
            };

            foreach (var category in threadModel.Categories)
            {
                threadEntity.Categories.Add(Extensions.CreateOrLoadCategory(category, context));
            }

            return threadEntity;
        }

        public static ThreadModel ToModel(Thread threadEntity)
        {
            ThreadModel threadModel = new ThreadModel()
            {
                ID = threadEntity.ID,
                Author = threadEntity.Author.Nickname,
                Title = threadEntity.Title,
                Content = threadEntity.Content,
                DateCreated = threadEntity.DateCreated
            };

            foreach (var category in threadEntity.Categories)
            {
                threadModel.Categories.Add(category.Name);
            }

            foreach (var post in threadEntity.Posts)
            {
                threadModel.Posts.Add(PostsMapper.ToModel(post));
            }

            return threadModel;
        }
    }
}