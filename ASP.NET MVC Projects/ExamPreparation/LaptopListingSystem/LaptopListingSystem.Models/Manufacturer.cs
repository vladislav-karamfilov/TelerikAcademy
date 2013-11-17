namespace LaptopListingSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        private ICollection<Laptop> laptops;

        public Manufacturer()
        {
            this.laptops = new HashSet<Laptop>();
        }

        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops
        {
            get { return this.laptops; }
            set { this.laptops = value; }
        }
    }
}
