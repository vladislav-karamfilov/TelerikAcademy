namespace SchoolsSystem.DataTransferObjects
{
    using System.Collections.Generic;

    public class SchoolModel : SchoolDetails
    {
        public SchoolModel()
        { 
            this.Students = new HashSet<StudentModel>();
        }

        public ICollection<StudentModel> Students { get; set; }
    }
}
