namespace CrowdSourcedNews.Mappers
{
    using CrowdSourcedNews.DataTransferObjects;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;

    internal static class Extensions
    {
        public static Comment CreateOrLoadComment(
            CommentModel comment,
            IRepository<Comment> commentRepository,
            DbUsersRepository usersRepository,
            IRepository<NewsArticle> newsArticlesRepository)
        {
            Comment commentEntity = commentRepository.Get(comment.ID);
            if (commentEntity != null)
            {
                return commentEntity;
            }

            Comment newComment = 
                CommentsMapper.ToCommentEntity(comment, usersRepository, newsArticlesRepository);

            return newComment;
        }
    }
}
