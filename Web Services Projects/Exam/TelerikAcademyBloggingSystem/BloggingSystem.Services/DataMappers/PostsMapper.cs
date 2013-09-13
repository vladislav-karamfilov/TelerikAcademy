namespace BloggingSystem.Services.DataMappers
{
    using System;
    using BloggingSystem.Data;
    using BloggingSystem.DataTransferObjects;
    using BloggingSystem.Models;

    public static class PostsMapper
    {
        private static readonly char[] WordSeparators = new char[]
        {
            '.', ' ', ',', '!', '?', '(', ')', '\"', '-', '%', '+', '\\', '|', '\''
        };

        public static PostModel ToModel(Post postEntity)
        {
            PostModel postModel = new PostModel()
            {
                ID = postEntity.ID,
                Title = postEntity.Title,
                Text = postEntity.Text,
                PostDate = postEntity.PostDate,
                Author = postEntity.Author.DisplayName
            };

            foreach (var commentEntity in postEntity.Comments)
            {
                postModel.Comments.Add(CommentsMapper.ToModel(commentEntity));
            }

            foreach (var tag in postEntity.Tags)
            {
                postModel.Tags.Add(tag.Name);
            }

            return postModel;
        }

        public static Post CreateNewEntity(PostModel postModel, User author, BloggingSystemContext context)
        {
            Post postEntity = new Post()
            {
                Title = postModel.Title,
                Author = author,
                PostDate = DateTime.Now,
                Text = postModel.Text
            };

            foreach (var tagName in postModel.Tags)
            {
                postEntity.Tags.Add(Extensions.CreateOrLoadTag(tagName.ToLower(), context));
            }

            var titleTags = postModel.Title.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var titleTagName in titleTags)
            {
                if (titleTagName.Length > 1)
                {
                    postEntity.Tags.Add(Extensions.CreateOrLoadTag(titleTagName.ToLower(), context));
                }
            }

            return postEntity;
        }

        public static PostedPost ToPostedModel(Post postEntity)
        {
            PostedPost postedPost = new PostedPost()
            {
                ID = postEntity.ID,
                Title = postEntity.Title
            };

            return postedPost;
        }
    }
}