namespace Exam.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Exam.Models;

    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromModel
        {
            get
            {
                return category => new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}