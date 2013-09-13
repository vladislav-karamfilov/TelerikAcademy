namespace SchoolsSystem.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolsSystem.DataTransferObjects;
    using SchoolsSystem.Models;
    using SchoolsSystem.Repositories;
    using SchoolsSystem.Services.Controllers;
    using Telerik.JustMock;

    [TestClass]
    public class StudentsControllerTests
    {
        private static void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("controller", "students");
            routeData.Values.Add("id", RouteParameter.Optional);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/students");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void AddValidStudent_ShouldBeAddedCorrectly()
        {
            var unitOfWork = Mock.Create<IUnitOfWork>();

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
            Mock.Arrange(() => unitOfWork.SchoolsRepository.Get(Arg.IsAny<int>()))
                .Returns(school);

            Mock.Arrange(() => unitOfWork.StudentsRepository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(studentEntity);

            var studentsController = new StudentsController(unitOfWork);
            SetupController(studentsController);

            StudentModel studentModel = new StudentModel()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = new SchoolDetails() { Location = school.Location, Name = school.Name },
                Marks = new List<MarkModel>() { new MarkModel() { Subject = "math", Value = 6 } }
            };
            studentsController.Add(studentModel);

            Assert.IsTrue(isItemAdded);
        }

        [TestMethod]
        public void AddStudentWithoutSchool_ShouldNotBeAdded()
        {
            var unitOfWork = Mock.Create<IUnitOfWork>();

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            bool isItemAdded = false;
            Mock.Arrange(() => unitOfWork.StudentsRepository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(studentEntity);

            var studentsController = new StudentsController(unitOfWork);
            SetupController(studentsController);

            StudentModel studentModel = new StudentModel()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                Marks = new List<MarkModel>() { new MarkModel() { Subject = "math", Value = 6 } }
            };
            studentsController.Add(studentModel);

            Assert.IsFalse(isItemAdded);
        }

        [TestMethod]
        public void GetAllStudentsFromEmptyRepo_ShoulReturnZeroStudents()
        {
            var unitOfWork = Mock.Create<IUnitOfWork>();

            IList<Student> studentEntities = new List<Student>();

            Mock.Arrange(() => unitOfWork.StudentsRepository.GetAll())
                .Returns(() => studentEntities.AsQueryable<Student>());

            var studentsController = new StudentsController(unitOfWork);
            SetupController(studentsController);

            var httpResponseWithStudentModels = studentsController.GetAll();
            var studentModels = httpResponseWithStudentModels.Content.ReadAsAsync<IQueryable<StudentModel>>().Result;

            Assert.AreEqual(0, studentModels.Count());
        }

        [TestMethod]
        public void GetAllFromACollectionOfOne_ShouldSingleStudent()
        {
            var unitOfWork = Mock.Create<IUnitOfWork>();

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

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            Mock.Arrange(() => unitOfWork.StudentsRepository.GetAll())
                .Returns(() => studentEntities.AsQueryable<Student>());

            var studentsController = new StudentsController(unitOfWork);
            SetupController(studentsController);

            var httpResponseWithStudentModels = studentsController.GetAll();
            var studentModels = httpResponseWithStudentModels.Content.ReadAsAsync<IQueryable<StudentModel>>().Result;

            // Check count
            Assert.AreEqual(1, studentModels.Count());

            // Check personal information
            Assert.AreEqual(studentEntity.FirstName, studentModels.First().FirstName);
            Assert.AreEqual(studentEntity.LastName, studentModels.First().LastName);
            Assert.AreEqual(studentEntity.Age, studentModels.First().Age);
            Assert.AreEqual(studentEntity.Grade, studentModels.First().Grade);

            Assert.AreEqual(school.Name, studentModels.First().School.Name);
            Assert.AreEqual(school.Location, studentModels.First().School.Location);

            // Check marks
            Assert.AreEqual(studentEntity.Marks.First().Subject, studentModels.First().Marks.First().Subject);
            Assert.AreEqual(studentEntity.Marks.First().Value, studentModels.First().Marks.First().Value);
        }

        [TestMethod]
        public void GetAllFromACollectionWithMultipleStudents_ShouldReturnMultipleStudents()
        {
            var unitOfWork = Mock.Create<IUnitOfWork>();

            School school = new School() { Location = "Location", Name = "Name" };

            Student studentEntity1 = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = school,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            Student studentEntity2 = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 16,
                Grade = 10,
                School = school,
                Marks = new List<Mark>() { new Mark() { Subject = "math", Value = 6 } }
            };

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentEntity1);
            studentEntities.Add(studentEntity2);

            Mock.Arrange(() => unitOfWork.StudentsRepository.GetAll())
                .Returns(() => studentEntities.AsQueryable<Student>());

            var studentsController = new StudentsController(unitOfWork);
            SetupController(studentsController);

            var httpResponseWithStudentModels = studentsController.GetAll();
            var studentModels = httpResponseWithStudentModels.Content.ReadAsAsync<IQueryable<StudentModel>>().Result;

            Assert.AreEqual(2, studentModels.Count());
        }

        [TestMethod]
        public void GetByInvalidId_ShoulReturnInternalServerErrorResponse()
        {
            var unitOfWork = Mock.Create<IUnitOfWork>();

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

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            int id = -1; // Database IDs starts with 1
            id--;
            Mock.Arrange(() => unitOfWork.StudentsRepository.Get(id))
                .Returns(() => id >= 0 ? studentEntities[id] : null);

            var studentsController = new StudentsController(unitOfWork);
            SetupController(studentsController);

            var httpResponseWithStudentModels = studentsController.Get(id);

            Assert.AreEqual(httpResponseWithStudentModels.StatusCode, HttpStatusCode.InternalServerError);
        }

        [TestMethod]
        public void GetByValidID_ShouldReturnCorrectStudent()
        {
            var unitOfWork = Mock.Create<IUnitOfWork>();

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

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            int id = 1; // Database IDs starts with 1
            id--;
            Mock.Arrange(() => unitOfWork.StudentsRepository.Get(id))
                .Returns(() => id >= 0 ? studentEntities[id] : null);

            var studentsController = new StudentsController(unitOfWork);
            SetupController(studentsController);

            var httpResponseWithStudentModels = studentsController.Get(id);
            var studentModel = httpResponseWithStudentModels.Content.ReadAsAsync<StudentModel>().Result;

            Assert.AreEqual(httpResponseWithStudentModels.StatusCode, HttpStatusCode.OK);
            // Check personal information
            Assert.AreEqual(studentEntity.FirstName, studentModel.FirstName);
            Assert.AreEqual(studentEntity.LastName, studentModel.LastName);
            Assert.AreEqual(studentEntity.Age, studentModel.Age);
            Assert.AreEqual(studentEntity.Grade, studentModel.Grade);

            Assert.AreEqual(school.Name, studentModel.School.Name);
            Assert.AreEqual(school.Location, studentModel.School.Location);

            // Check marks
            Assert.AreEqual(studentEntity.Marks.First().Subject, studentModel.Marks.First().Subject);
            Assert.AreEqual(studentEntity.Marks.First().Value, studentModel.Marks.First().Value);
        }

        [TestMethod]
        public void GetBySubjectAndMark_WithSingleStudent_ShouldReturnCorrectStudent()
        {
            var unitOfWork = Mock.Create<IUnitOfWork>();

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

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            string subject = "math";
            double mark = 5.9;
            Mock.Arrange(() => unitOfWork.StudentsRepository.GetBySubjectAndMark(subject, mark))
                .Returns(() => studentEntities
                    .Where(st => st.Marks.Any(m => m.Subject == subject && m.Value > mark))
                    .AsQueryable<Student>());

            var studentsController = new StudentsController(unitOfWork);
            SetupController(studentsController);

            var httpResponseWithStudentModels = studentsController.Get(subject, mark);
            var studentModel = httpResponseWithStudentModels.Content
                .ReadAsAsync<IQueryable<StudentModel>>().Result.First();

            Assert.AreEqual(httpResponseWithStudentModels.StatusCode, HttpStatusCode.OK);
            // Check personal information
            Assert.AreEqual(studentEntity.FirstName, studentModel.FirstName);
            Assert.AreEqual(studentEntity.LastName, studentModel.LastName);
            Assert.AreEqual(studentEntity.Age, studentModel.Age);
            Assert.AreEqual(studentEntity.Grade, studentModel.Grade);

            Assert.AreEqual(school.Name, studentModel.School.Name);
            Assert.AreEqual(school.Location, studentModel.School.Location);

            // Check marks
            Assert.AreEqual(studentEntity.Marks.First().Subject, studentModel.Marks.First().Subject);
            Assert.AreEqual(studentEntity.Marks.First().Value, studentModel.Marks.First().Value);
        }

        [TestMethod]
        public void GetBySubjectAndMark_WithMarkValueAboveThanExisting_ShouldReturnEmptyCollection()
        {
            var unitOfWork = Mock.Create<IUnitOfWork>();

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

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            string subject = "math";
            double mark = 6.2;
            Mock.Arrange(() => unitOfWork.StudentsRepository.GetBySubjectAndMark(subject, mark))
                .Returns(() => studentEntities
                    .Where(st => st.Marks.Any(m => m.Subject == subject && m.Value > mark))
                    .AsQueryable<Student>());

            var studentsController = new StudentsController(unitOfWork);
            SetupController(studentsController);

            var httpResponseWithStudentModels = studentsController.Get(subject, mark);
            var studentModels = httpResponseWithStudentModels.Content
                .ReadAsAsync<IQueryable<StudentModel>>().Result;

            Assert.AreEqual(httpResponseWithStudentModels.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(0, studentModels.Count());
        }
    }
}