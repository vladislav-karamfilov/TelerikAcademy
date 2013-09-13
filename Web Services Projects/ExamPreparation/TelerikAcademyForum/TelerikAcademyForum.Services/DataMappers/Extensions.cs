namespace TelerikAcademyForum.Services.DataMappers
{
    using System.Linq;
    using TelerikAcademyForum.Data;
    using TelerikAcademyForum.Models;

    internal static class Extensions
    {
        public static Category CreateOrLoadCategory(string category, TelerikAcademyForumContext context)
        {
            string categoryLowerCase = category.ToLower().Trim();
            Category existingCategory = context.Categories
                .FirstOrDefault<Category>(c => c.Name.ToLower() == categoryLowerCase);
            if (existingCategory != null)
            {
                return existingCategory;
            }

            Category newCategory = new Category() { Name = category };
            context.Categories.Add(newCategory);
            context.SaveChanges();

            return newCategory;
        }
    }
}