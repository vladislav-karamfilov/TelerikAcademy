namespace SchoolsSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using SchoolsSystem.DataTransferObjects;
    using SchoolsSystem.Repositories;
    using SchoolsSystem.Services.DataMappers;
    using System.Net;

    public class StudentsController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var httpResponse = this.PerformOperation(() =>
                {
                    var studentEntities = this.unitOfWork.StudentsRepository.GetAll().ToList();
                    var studentModels = new HashSet<StudentModel>();
                    foreach (var studentEntity in studentEntities)
                    {
                        studentModels.Add(StudentsMapper.ToStudentModel(studentEntity));
                    }

                    return studentModels.AsQueryable<StudentModel>();
                });

            return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var httpResponse = this.PerformOperation(() =>
            {
                var studentEntity = this.unitOfWork.StudentsRepository.Get(id);
                if (studentEntity != null)
                {
                    return StudentsMapper.ToStudentModel(studentEntity);
                }
                else
                {
                    throw new HttpResponseException(
                        Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with provided id not found!"));
                }
            });

            return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage Get(string subject, double value)
        {
            var httpResponse = this.PerformOperation(() =>
                {
                    var studentEntities = this.unitOfWork.StudentsRepository
                        .GetBySubjectAndMark(subject, value).ToList();
                    var studentModels = new HashSet<StudentModel>();
                    foreach (var studentEntity in studentEntities)
                    {
                        studentModels.Add(StudentsMapper.ToStudentModel(studentEntity));
                    }

                    return studentModels.AsQueryable<StudentModel>();
                });

            return httpResponse;
        }

        [HttpPost]
        public HttpResponseMessage Add(StudentModel studentModel)
        {
            var httpResponse = this.PerformOperation(() =>
            {
                var studentEntity = StudentsMapper.ToStudentEntity(studentModel, unitOfWork);

                this.unitOfWork.StudentsRepository.Add(studentEntity);
                this.unitOfWork.Save();

                studentModel.ID = studentEntity.ID;
                return studentModel;
            });

            return httpResponse;
        }
    }
}
