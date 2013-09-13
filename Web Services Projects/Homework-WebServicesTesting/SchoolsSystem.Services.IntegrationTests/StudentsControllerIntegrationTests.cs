namespace SchoolsSystem.Services.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolsSystem.Models;
    using SchoolsSystem.Repositories;
    using Telerik.JustMock;
    using SchoolsSystem.DataTransferObjects;

    [TestClass]
    public class StudentsControllerIntegrationTests
    {
        [TestMethod]
        public void Add_Valid_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockUnitOfWork = Mock.Create<IUnitOfWork>();

            School school = new School() { Location = "Location", Name = "Name" };

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = school,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            bool isItemAdded = false;
            Mock.Arrange(() => mockUnitOfWork.SchoolsRepository.Get(Arg.IsAny<int>()))
                .Returns(school);

            Mock.Arrange(() => mockUnitOfWork.StudentsRepository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(studentEntity);

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockUnitOfWork);

            var response = server.CreatePostRequest("api/students", studentEntity);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(isItemAdded);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Add_StudentWithoutSchool_ShouldReturnStatusCode500()
        {
            var mockUnitOfWork = Mock.Create<IUnitOfWork>();

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            Mock.Arrange(() => mockUnitOfWork.StudentsRepository
                .Add(Arg.Matches<Student>(st => st.School == null)))
                .Throws<ArgumentNullException>();

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockUnitOfWork);

            var response = server.CreatePostRequest("api/students", studentEntity);

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void GetAll_WhenOneStudent_ShouldReturnStatusCode200AndCorrectStudent()
        {
            var mockUnitOfWork = Mock.Create<IUnitOfWork>();

            School school = new School() { Location = "Location", Name = "Name" };

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = school,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            var studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            Mock.Arrange(() => mockUnitOfWork.StudentsRepository.GetAll())
                .Returns(() => studentEntities.AsQueryable<Student>());

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockUnitOfWork);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // Check personal information
            Assert.AreEqual(studentEntity.FirstName, studentEntity.FirstName);
            Assert.AreEqual(studentEntity.LastName, studentEntity.LastName);
            Assert.AreEqual(studentEntity.Age, studentEntity.Age);
            Assert.AreEqual(studentEntity.Grade, studentEntity.Grade);

            Assert.AreEqual(school.Name, studentEntity.School.Name);
            Assert.AreEqual(school.Location, studentEntity.School.Location);

            // Check marks
            Assert.AreEqual(studentEntity.Marks.First().Subject, studentEntity.Marks.First().Subject);
            Assert.AreEqual(studentEntity.Marks.First().Value, studentEntity.Marks.First().Value);
        }

        [TestMethod]
        public void GetAll_WhenMultipleStudents_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockUnitOfWork = Mock.Create<IUnitOfWork>();

            School school = new School() { Location = "Location", Name = "Name" };

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = school,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            var studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            Mock.Arrange(() => mockUnitOfWork.StudentsRepository.GetAll())
                .Returns(() => studentEntities.AsQueryable<Student>());

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockUnitOfWork);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetByID_WithInvalidID_ShouldReturnStatusCode500()
        {
            var mockUnitOfWork = Mock.Create<IUnitOfWork>();

            School school = new School() { Location = "Location", Name = "Name" };

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = school,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            var studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            int id = -1;
            id--; // Database IDs starts with 1
            Mock.Arrange(() => mockUnitOfWork.StudentsRepository.Get(id))
                .Returns(() => id >= 0 ? studentEntities[id] : null);

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockUnitOfWork);

            var response = server.CreateGetRequest("api/students/" + id);

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void GetByID_WithValidID_ShouldReturnStatusCode200AndCorrectStudent()
        {
            var mockUnitOfWork = Mock.Create<IUnitOfWork>();

            School school = new School() { Location = "Location", Name = "Name" };

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = school,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            var studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            int id = 1;
            id--; // Database IDs starts with 1
            Mock.Arrange(() => mockUnitOfWork.StudentsRepository.Get(id))
                .Returns(() => id >= 0 ? studentEntities[id] : null);

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockUnitOfWork);

            var response = server.CreateGetRequest("api/students/" + id);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // Check personal information
            Assert.AreEqual(studentEntity.FirstName, studentEntity.FirstName);
            Assert.AreEqual(studentEntity.LastName, studentEntity.LastName);
            Assert.AreEqual(studentEntity.Age, studentEntity.Age);
            Assert.AreEqual(studentEntity.Grade, studentEntity.Grade);

            Assert.AreEqual(school.Name, studentEntity.School.Name);
            Assert.AreEqual(school.Location, studentEntity.School.Location);

            // Check marks
            Assert.AreEqual(studentEntity.Marks.First().Subject, studentEntity.Marks.First().Subject);
            Assert.AreEqual(studentEntity.Marks.First().Value, studentEntity.Marks.First().Value);
        }

        [TestMethod]
        public void GetBySubjectAndMark_WithSingleStudent_ShoulReturn200AndNotNullContent()
        {
            var mockUnitOfWork = Mock.Create<IUnitOfWork>();

            School school = new School() { Location = "Location", Name = "Name" };

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = school,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            var studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            string subject = "math";
            double mark = 5.9;
            Mock.Arrange(() => mockUnitOfWork.StudentsRepository.GetBySubjectAndMark(subject, mark))
                .Returns(() => studentEntities
                    .Where(st => st.Marks.Any(m => m.Subject == subject && m.Value > mark))
                    .AsQueryable<Student>());

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockUnitOfWork);

            var response = server.CreateGetRequest("api/students?subject=" + subject + "&value=" + mark);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetBySubjectAndMark_WithMarkValueAboveExisting_ShoulReturn200()
        {
            var mockUnitOfWork = Mock.Create<IUnitOfWork>();

            School school = new School() { Location = "Location", Name = "Name" };

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = school,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            var studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            string subject = "math";
            double mark = 6.2;
            Mock.Arrange(() => mockUnitOfWork.StudentsRepository.GetBySubjectAndMark(subject, mark))
                .Returns(() => studentEntities
                    .Where(st => st.Marks.Any(m => m.Subject == subject && m.Value > mark))
                    .AsQueryable<Student>());

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockUnitOfWork);

            var response = server.CreateGetRequest("api/students?subject=" + subject + "&value=" + mark);
            var studentModels = response.Content
                .ReadAsAsync<IQueryable<StudentModel>>().Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(0, studentModels.Count());
        }
    }
}
