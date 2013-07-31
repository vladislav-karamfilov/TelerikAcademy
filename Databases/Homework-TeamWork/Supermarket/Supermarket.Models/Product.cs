namespace Supermarket.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int VendorID { get; set; }

        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }

        [Required, Column("Product Name")]
        public string Name { get; set; }

        [Required]
        public int MeasureID { get; set; }

        [ForeignKey("MeasureID")]
        public Measure Measure { get; set; }

        [Required]
        public decimal BasePrice { get; set; }
    }
}
