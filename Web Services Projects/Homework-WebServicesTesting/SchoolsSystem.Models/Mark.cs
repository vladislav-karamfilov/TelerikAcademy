namespace SchoolsSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Mark
    {
        [Key, Column("MarkID")]
        public int ID { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public double Value { get; set; }

        public int StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}
