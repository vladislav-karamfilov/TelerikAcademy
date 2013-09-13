namespace CarRentalSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.RentedCars = new HashSet<Car>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string AuthCode { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public string SessionKey { get; set; }

        public ICollection<Car> RentedCars { get; set; }
    }
}
