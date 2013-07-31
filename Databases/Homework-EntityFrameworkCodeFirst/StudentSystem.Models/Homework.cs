namespace StudentSystem.Models
{
    using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        [Key, Column("HomeworkID")]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }

        public int CourseID { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

        public int StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}
