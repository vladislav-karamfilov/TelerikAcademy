namespace CarRentalSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public int Year { get; set; }

        public int Power { get; set; }

        [Required]
        public string Engine { get; set; }

        public int CarStoreID { get; set; }

        [ForeignKey("CarStoreID")]
        public virtual CarStore CarStore { get; set; }

        public int? RentedBy { get; set; }

        [ForeignKey("RentedBy")]
        public virtual User Renter { get; set; }
    }
}
