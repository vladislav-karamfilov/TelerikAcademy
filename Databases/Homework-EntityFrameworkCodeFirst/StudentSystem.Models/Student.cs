namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        [Key, Column("StudentID")]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FacultyNumber { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }

            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }

            set { this.homeworks = value; }
        }
    }
}
