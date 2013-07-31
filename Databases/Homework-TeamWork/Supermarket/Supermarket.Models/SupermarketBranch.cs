namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SupermarketBranch
    {
        [Key]
        public int ID { get; set; }

        [Required, Column("Supermarket Name")]
        public string Name { get; set; }
    }
}
