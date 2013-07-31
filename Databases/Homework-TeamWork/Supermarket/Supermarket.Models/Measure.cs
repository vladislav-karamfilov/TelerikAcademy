namespace Supermarket.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Measure
    {
        private ICollection<Product> products;

        public Measure()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int ID { get; set; }

        [Required, Column("Measure Name")]
        public string MeasureName { get; set; }

        public virtual ICollection<Product> Products 
        {
            get { return this.products;  }

            set { this.products = value; }
        }
    }
}
