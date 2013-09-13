namespace BloggingSystem.Services.DataMappers
{
    using BloggingSystem.DataTransferObjects;
    using BloggingSystem.Models;

    public static class TagsMapper
    {
        public static TagModel ToModel(Tag tagEntity)
        {
            TagModel tagModel = new TagModel()
            {
                ID = tagEntity.ID,
                Name = tagEntity.Name,
                PostsCount = tagEntity.Posts.Count
            };

            return tagModel;
        }
    }
}