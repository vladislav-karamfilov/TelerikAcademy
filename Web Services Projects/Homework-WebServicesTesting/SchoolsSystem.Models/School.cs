namespace SchoolsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class School
    {
        private ICollection<Student> students;

        public School()
        {
            this.students = new HashSet<Student>();
        }

        [Key, Column("SchoolID")]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }

            set { this.students = value; }
        }
    }
}
