namespace BloggingSystem.Services.DataMappers
{
    using System.Linq;
    using BloggingSystem.Data;
    using BloggingSystem.Models;

    internal static class Extensions
    {
        public static Tag CreateOrLoadTag(string tagName, BloggingSystemContext context)
        {
            Tag exstingTag = context.Tags.FirstOrDefault<Tag>(t => t.Name == tagName);
            if (exstingTag != null)
            {
                return exstingTag;
            }

            Tag newTag = new Tag() { Name = tagName };
            context.Tags.Add(newTag);
            context.SaveChanges();

            return newTag;
        }
    }
}