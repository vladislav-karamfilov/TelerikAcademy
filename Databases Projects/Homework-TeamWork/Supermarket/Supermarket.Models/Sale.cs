namespace Supermarket.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Sale
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int SupermarketID { get; set; }

        [ForeignKey("SupermarketID")]
        public virtual SupermarketBranch Supermarket { get; set; }

        [Required]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
