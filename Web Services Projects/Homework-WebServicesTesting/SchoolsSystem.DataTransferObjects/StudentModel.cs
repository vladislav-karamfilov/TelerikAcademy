namespace SchoolsSystem.DataTransferObjects
{
    using System.Collections.Generic;

    public class StudentModel
    {
        public StudentModel()
        {
            this.Marks = new HashSet<MarkModel>();
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte Age { get; set; }

        public byte Grade { get; set; }

        public ICollection<MarkModel> Marks { get; set; }

        public SchoolDetails School { get; set; }
    }
}
