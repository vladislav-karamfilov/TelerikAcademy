namespace LaptopListingSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LaptopListingSystem.Models.Attributes;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DoesNotContainEmail]
        public string Content { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual UserProfile Author { get; set; }

        public int LaptopId { get; set; }

        [ForeignKey("LaptopId")]
        public virtual Laptop Laptop { get; set; }
    }
}
