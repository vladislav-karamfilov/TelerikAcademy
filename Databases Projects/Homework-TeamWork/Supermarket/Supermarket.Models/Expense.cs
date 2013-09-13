namespace Supermarket.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Expense
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int VendorID { get; set; }

        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }

        [Required, Column("Expense Value")]
        public decimal Value { get; set; }

        [Required, Column("Month")]
        public DateTime Month { get; set; }
    }
}