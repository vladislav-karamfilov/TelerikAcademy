namespace Supermarket.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vendor
    {
        private ICollection<Product> products;

        private ICollection<Expense> expenses;

        public Vendor()
        {
            this.Products = new HashSet<Product>();
            this.Expenses = new HashSet<Expense>();
        }

        [Key]
        public int ID { get; set; }

        [Required, Column("Vendor Name")]
        public string VendorName { get; set; }

        public virtual ICollection<Product> Products 
        {
            get { return this.products;  }

            set { this.products = value; }
        }

        public virtual ICollection<Expense> Expenses
        {
            get { return this.expenses; }

            set { this.expenses = value; }
        }
    }
}
