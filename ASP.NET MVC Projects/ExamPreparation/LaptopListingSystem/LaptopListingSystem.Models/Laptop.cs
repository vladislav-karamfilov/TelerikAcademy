namespace LaptopListingSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Laptop
    {
        private ICollection<Vote> votes;
        private ICollection<Comment> comments;

        public Laptop()
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; }

        /// <summary>
        /// Size in inches
        /// </summary>
        [Range(1, double.MaxValue)]
        public double MonitorSize { get; set; }

        /// <summary>
        /// Capacity in GB
        /// </summary>
        [Range(1, int.MaxValue)]
        public int HardDiskCapacity { get; set; }

        /// <summary>
        /// Capacity in GB
        /// </summary>
        [Range(0, double.MaxValue)]
        public double RamCapacity { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(GlobalConstants.UrlRegEx)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Price in dollars
        /// </summary>
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        /// <summary>
        /// Weight in kilograms
        /// </summary>
        [Range(1, double.MaxValue)]
        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
