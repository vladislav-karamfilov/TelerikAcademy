namespace BloggingSystem.Services.DataMappers
{
    using BloggingSystem.DataTransferObjects;
    using BloggingSystem.Models;
    using System;

    public static class CommentsMapper
    {
        public static CommentModel ToModel(Comment commentEntity)
        {
            CommentModel commentModel = new CommentModel()
            {
                Author = commentEntity.Author.DisplayName,
                PostDate = commentEntity.PostDate,
                Text = commentEntity.Text
            };

            return commentModel;
        }

        public static Comment ToEntity(CommentModel commentModel, User author)
        {
            Comment commentEntity = new Comment()
            {
                Author = author,
                PostDate = DateTime.Now,
                Text = commentModel.Text
            };

            return commentEntity;
        }
    }
}