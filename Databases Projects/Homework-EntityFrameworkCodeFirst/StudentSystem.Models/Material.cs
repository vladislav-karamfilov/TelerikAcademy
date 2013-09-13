namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Material
    {
        [Key, Column("MaterialID")]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Content { get; set; }

        public int CourseID { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
    }
}
