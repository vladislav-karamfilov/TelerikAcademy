namespace LaptopListingSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual UserProfile Author { get; set; }

        public int LaptopId { get; set; }

        [ForeignKey("LaptopId")]
        public virtual Laptop Laptop { get; set; }
    }
}
