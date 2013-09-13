namespace SchoolsSystem.Services.DataMappers
{
    using System.Linq;
    using SchoolsSystem.DataTransferObjects;
    using SchoolsSystem.Models;
    using SchoolsSystem.Repositories;

    public static class StudentsMapper
    {
        public static StudentModel ToStudentModel(Student studentEntity)
        {
            StudentModel studentModel = new StudentModel();
            studentModel.ID = studentEntity.ID;
            studentModel.FirstName = studentEntity.FirstName;
            studentModel.LastName = studentEntity.LastName;
            studentModel.Age = studentEntity.Age;
            studentModel.Grade = studentEntity.Grade;
            
            studentModel.School = new SchoolDetails()
            {
                ID = studentEntity.School.ID,
                Name = studentEntity.School.Name,
                Location = studentEntity.School.Location
            };

            foreach (Mark mark in studentEntity.Marks)
            {
                studentModel.Marks.Add(new MarkModel()
                    {
                        ID = mark.ID,
                        Subject = mark.Subject,
                        Value = mark.Value
                    });
            }

            return studentModel;
        }

        public static Student ToStudentEntity(StudentModel studentModel, IUnitOfWork unitOfWork)
        {
            Student student = new Student();
            student.Age = studentModel.Age;
            student.FirstName = studentModel.FirstName;
            student.LastName = studentModel.LastName;
            student.Grade = studentModel.Grade;
            
            student.School = Extensions.CreateOrLoadSchool(studentModel.School, unitOfWork);
            
            foreach (MarkModel mark in studentModel.Marks)
            {
                student.Marks.Add(new Mark() { Subject = mark.Subject, Value = mark.Value });
            }

            return student;
        }
    }
}