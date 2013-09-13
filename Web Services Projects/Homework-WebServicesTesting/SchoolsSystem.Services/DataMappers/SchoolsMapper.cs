namespace SchoolsSystem.Services.DataMappers
{
    using SchoolsSystem.DataTransferObjects;
    using SchoolsSystem.Models;
    using SchoolsSystem.Repositories;

    public static class SchoolsMapper
    {
        public static School ToSchoolEntity(SchoolModel schoolModel, IUnitOfWork unitOfWork)
        {
            School school = new School()
                {
                    Name = schoolModel.Name,
                    Location = schoolModel.Location
                };

            foreach (StudentModel student in schoolModel.Students)
            {
                school.Students.Add(Extensions.CreateOrLoadStudent(student, unitOfWork));
            }

            return school;
        }

        public static SchoolModel ToSchoolModel(School schoolEntity)
        {
            SchoolModel school = new SchoolModel()
                {
                    ID = schoolEntity.ID,
                    Name = schoolEntity.Name,
                    Location = schoolEntity.Location
                };

            foreach (Student student in schoolEntity.Students)
            {
                school.Students.Add(StudentsMapper.ToStudentModel(student));
            }

            return school;
        }
    }
}