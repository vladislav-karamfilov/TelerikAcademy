namespace SchoolsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        private ICollection<Mark> marks;

        public Student()
        {
            this.marks = new HashSet<Mark>();
        }

        [Key, Column("StudentID")]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public byte Age { get; set; }

        [Required]
        public byte Grade { get; set; }

        public int SchoolID { get; set; }

        [ForeignKey("SchoolID")]
        public virtual School School { get; set; }

        public virtual ICollection<Mark> Marks
        {
            get { return this.marks; }

            set { this.marks = value; }
        }
    }
}
