namespace CrowdSourcedNews.Mappers
{
    using CrowdSourcedNews.DataTransferObjects;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;

    public static class CommentsMapper
    {
        public static Comment ToCommentEntity(
            CommentModel commentModel, 
            DbUsersRepository usersRepository, 
            IRepository<NewsArticle> newsArticlesRepository)
        {
            Comment commentEntity = new Comment()
                {
                    Content = commentModel.Content,
                    Date = commentModel.Date,
                    Author = usersRepository.GetByNickname(commentModel.Author)
                };

            NewsArticle newsArticle = newsArticlesRepository.Get(commentModel.ArticleID);
            newsArticle.Comments.Add(commentEntity);

            return commentEntity;
        }

        public static CommentModel ToCommentModel(Comment commentEntity)
        {
            CommentModel commentModel = new CommentModel()
                {
                    ID = commentEntity.ID,
                    Author = commentEntity.Author.Nickname,
                    Content = commentEntity.Content,
                    Date = commentEntity.Date
                };

            return commentModel;
        }
    }
}
