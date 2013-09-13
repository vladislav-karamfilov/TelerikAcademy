namespace SchoolsSystem.Services.DataMappers
{
    using SchoolsSystem.DataTransferObjects;
    using SchoolsSystem.Models;
    using SchoolsSystem.Repositories;

    public static class Extensions
    {
        public static School CreateOrLoadSchool(SchoolDetails schoolDetails, IUnitOfWork unitOfWork)
        {
            School school = unitOfWork.SchoolsRepository.Get(schoolDetails.ID);
            if (school != null)
            {
                return school;
            }

            School newSchool = new School()
                {
                    Name = schoolDetails.Name,
                    Location = schoolDetails.Location
                };

            unitOfWork.SchoolsRepository.Add(newSchool);
            unitOfWork.Save();

            return newSchool;
        }


        public static Student CreateOrLoadStudent(StudentModel studentModel, IUnitOfWork unitOfWork)
        {
            Student student = unitOfWork.StudentsRepository.Get(studentModel.ID);
            if (student != null)
            {
                return student;
            }

            Student newStudent = new Student()
                {
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    Age = studentModel.Age,
                    Grade = studentModel.Grade,
                    School = CreateOrLoadSchool(studentModel.School, unitOfWork)
                };

            foreach (MarkModel mark in studentModel.Marks)
            {
                newStudent.Marks.Add(MarksMapper.ToMarkEntity(mark));
            }

            unitOfWork.StudentsRepository.Add(newStudent);
            unitOfWork.Save();

            return newStudent;
        }
    }
}