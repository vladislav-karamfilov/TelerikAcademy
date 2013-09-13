namespace TelerikAcademyForum.Services.DataMappers
{
    using System.Linq;
    using TelerikAcademyForum.DataTransferObjects;
    using TelerikAcademyForum.Models;

    public static class PostsMapper
    {
        public static PostModel ToModel(Post postEntity)
        {
            PostModel postModel = new PostModel()
            {
                Author = postEntity.Author.Nickname,
                Content = postEntity.Content,
                PostDate = postEntity.PostDate,
                Rating = string.Format(
                    "{0}/5",
                    postEntity.Votes.Count > 0 ? (int)postEntity.Votes.Average(v => v.Value) : 0)
            };

            foreach (var comment in postEntity.Comments)
            {
                postModel.Comments.Add(comment.Content);
            }

            return postModel;
        }
    }
}