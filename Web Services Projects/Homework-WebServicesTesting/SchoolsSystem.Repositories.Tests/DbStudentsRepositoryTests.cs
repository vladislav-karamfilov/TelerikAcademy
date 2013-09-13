namespace SchoolsSystem.Repositories.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolsSystem.Models;

    [TestClass]
    public class DbStudentsRepositoryTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IStudentsRepository studentsRepository;
        private TransactionScope transactionScope;

        public DbStudentsRepositoryTests()
        {
            this.unitOfWork = new DbUnitOfWork();
            this.studentsRepository = this.unitOfWork.StudentsRepository;
        }

        [TestInitialize]
        public void InitializeTransactionScope()
        {
            this.transactionScope = new TransactionScope();
        }

        [TestCleanup]
        public void DisposeTransactionScope()
        {
            this.transactionScope.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullStudent_ShouldThrowArgumentNullException()
        {
            Student student = null;
            this.studentsRepository.Add(student);
        }

        [TestMethod]
        public void AddStudentWithSchoolAndNoMarks_ShouldAddTheStudentCorrectly()
        {
            Student student = new Student()
                {
                    FirstName = "Pesho",
                    LastName = "Peshov",
                    Age = 16,
                    Grade = 10,
                    School = new School() { Name = "Name", Location = "Location" }
                };

            Student studentEntity = this.studentsRepository.Add(student);
            this.unitOfWork.Save();

            // Check entity
            Assert.IsNotNull(studentEntity);
            Assert.IsTrue(studentEntity.ID > 0);

            // Check entity info
            Assert.AreEqual(student.FirstName, studentEntity.FirstName);
            Assert.AreEqual(student.LastName, studentEntity.LastName);
            Assert.AreEqual(student.Age, studentEntity.Age);
            Assert.AreEqual(student.Grade, studentEntity.Grade);

            // Check entity school
            Assert.IsNotNull(studentEntity.School);
            Assert.AreEqual(student.School.Name, studentEntity.School.Name);
            Assert.AreEqual(student.School.Location, studentEntity.School.Location);

            // Check entity marks
            Assert.IsNotNull(studentEntity.Marks);
            Assert.IsTrue(studentEntity.Marks.Count == 0);
        }

        [TestMethod]
        public void AddStudentWithSchoolAndMarks_ShouldAddStudentCorrectly()
        {
            Student student = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = new School { Name = "Name", Location = "Location" },
                Marks = new List<Mark>() 
                { 
                    new Mark() { Value = 5.5, Subject = "math" }, 
                    new Mark() { Value = 4.9, Subject = "Biology" }
                }
            };

            Student studentEntity = this.studentsRepository.Add(student);
            this.unitOfWork.Save();

            // Check entity
            Assert.IsNotNull(studentEntity);
            Assert.IsTrue(studentEntity.ID > 0);

            // Check entity info
            Assert.AreEqual(student.FirstName, studentEntity.FirstName);
            Assert.AreEqual(student.LastName, studentEntity.LastName);
            Assert.AreEqual(student.Age, studentEntity.Age);
            Assert.AreEqual(student.Grade, studentEntity.Grade);
            
            // Check entity school
            Assert.IsNotNull(studentEntity.School);
            Assert.AreEqual(student.School.Name, studentEntity.School.Name);
            Assert.AreEqual(student.School.Location, studentEntity.School.Location);
            
            // Check entity marks
            Assert.IsNotNull(studentEntity.Marks);
            Assert.IsTrue(studentEntity.Marks.Count == 2);
            Assert.AreEqual(student.Marks.First().Subject, studentEntity.Marks.First().Subject);
            Assert.AreEqual(student.Marks.First().Value, studentEntity.Marks.First().Value);
            Assert.AreEqual(student.Marks.Skip(1).First().Subject, studentEntity.Marks.Skip(1).First().Subject);
            Assert.AreEqual(student.Marks.Skip(1).First().Value, studentEntity.Marks.Skip(1).First().Value);
        }

        [TestMethod]
        public void GetStudentWithNegativeID_ShouldReturnNullStudent()
        {
            int id = -1;
            Student studentEntity = this.studentsRepository.Get(id);
            Assert.IsNull(studentEntity);
        }

        [TestMethod]
        public void GetStudentWithExistingID_ShouldReturnCorrectStudent()
        {
            Student student = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = new School { Name = "Name", Location = "Location" },
                Marks = new List<Mark>() 
                { 
                    new Mark() { Value = 5.5, Subject = "math" }, 
                    new Mark() { Value = 4.9, Subject = "Biology" }
                }
            };

            Student addedStudentEntity = this.studentsRepository.Add(student);
            this.unitOfWork.Save();

            Student studentEntity = this.studentsRepository.Get(addedStudentEntity.ID);

            // Check entity
            Assert.IsNotNull(studentEntity);
            Assert.IsTrue(studentEntity.ID > 0);

            // Check entity info
            Assert.AreEqual(student.FirstName, studentEntity.FirstName);
            Assert.AreEqual(student.LastName, studentEntity.LastName);
            Assert.AreEqual(student.Age, studentEntity.Age);
            Assert.AreEqual(student.Grade, studentEntity.Grade);

            // Check entity school
            Assert.IsNotNull(studentEntity.School);
            Assert.AreEqual(student.School.Name, studentEntity.School.Name);
            Assert.AreEqual(student.School.Location, studentEntity.School.Location);

            // Check entity marks
            Assert.IsNotNull(studentEntity.Marks);
            Assert.IsTrue(studentEntity.Marks.Count == 2);
            Assert.AreEqual(student.Marks.First().Subject, studentEntity.Marks.First().Subject);
            Assert.AreEqual(student.Marks.First().Value, studentEntity.Marks.First().Value);
            Assert.AreEqual(student.Marks.Skip(1).First().Subject, studentEntity.Marks.Skip(1).First().Subject);
            Assert.AreEqual(student.Marks.Skip(1).First().Value, studentEntity.Marks.Skip(1).First().Value);
        }

        [TestMethod]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            Student firstStudentToAdd = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = new School { Name = "Name", Location = "Location" },
                Marks = new List<Mark>() 
                { 
                    new Mark() { Value = 5.5, Subject = "math" }, 
                    new Mark() { Value = 4.9, Subject = "Biology" }
                }
            };

            Student secondStudentToAdd = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = new School { Name = "Name", Location = "Location" }
            };

            this.studentsRepository.Add(firstStudentToAdd);
            this.studentsRepository.Add(secondStudentToAdd);
            this.unitOfWork.Save();

            foreach (Student studentEntity in this.studentsRepository.GetAll())
            {
                Assert.IsTrue(studentEntity.ID > 0);
            }
        }

        [TestMethod]
        public void GetStudentsWithMarkAboveValueOnASubject_ShouldReturnMoreThanZeroStudents()
        {
            Student firstStudentToAdd = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = new School { Name = "Name", Location = "Location" },
                Marks = new List<Mark>() 
                { 
                    new Mark() { Value = 5.5, Subject = "math" }, 
                    new Mark() { Value = 4.9, Subject = "Biology" }
                }
            };

            this.studentsRepository.Add(firstStudentToAdd);
            this.unitOfWork.Save();

            var students = this.studentsRepository.GetBySubjectAndMark("math", 5.3);

            Assert.IsTrue(students.Count() > 0);

            foreach (Student student in students.ToList())
            {
                Assert.IsTrue(student.Marks.Single(m => m.Subject == "math").Value > 5.3);
            }
        }

        [TestMethod]
        public void GetStudentsWithMarkAboveValueOnASubject_ShouldReturnZeroStudents()
        {
            Student firstStudentToAdd = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = new School { Name = "Name", Location = "Location" },
                Marks = new List<Mark>() 
                { 
                    new Mark() { Value = 5.5, Subject = "math" }, 
                    new Mark() { Value = 4.9, Subject = "Biology" }
                }
            };

            this.studentsRepository.Add(firstStudentToAdd);
            this.unitOfWork.Save();

            var students = this.studentsRepository.GetBySubjectAndMark("math", 6);

            Assert.IsTrue(students.Count() == 0);
        }
    }
}
