namespace Newster.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Coordinates
    {
        [Key]
        public int ID { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
