namespace Newster.DataTransferObjects
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Newster.Models;

    [DataContract]
    public class CategoryDTO
    {
        public static Expression<Func<Category, CategoryDTO>> FromModel
        {
            get
            {
                return category => new CategoryDTO()
                {
                    ID = category.ID,
                    Name = category.Name
                };
            }
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "category")]
        public string Name { get; set; }
    }
}
