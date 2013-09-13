namespace CarRentalSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarStore
    {
        public CarStore()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
