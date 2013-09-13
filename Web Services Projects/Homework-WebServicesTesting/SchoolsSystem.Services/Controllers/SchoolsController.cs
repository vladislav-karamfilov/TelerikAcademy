namespace SchoolsSystem.Services.Controllers
{
    using SchoolsSystem.DataTransferObjects;
    using SchoolsSystem.Repositories;
    using SchoolsSystem.Services.DataMappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class SchoolsController : BaseApiController
    {
        private IUnitOfWork unitOfWork;

        public SchoolsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var httpResponse = this.PerformOperation(() =>
                {
                    var schoolEntities = this.unitOfWork.SchoolsRepository.GetAll().ToList();
                    var schoolModels = new HashSet<SchoolModel>();
                    foreach (var schoolEntity in schoolEntities)
                    {
                        schoolModels.Add(SchoolsMapper.ToSchoolModel(schoolEntity));
                    }

                    return schoolModels.AsQueryable<SchoolModel>();
                });

            return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var httpResponse = this.PerformOperation(() =>
                {
                    var schoolEntity = this.unitOfWork.SchoolsRepository.Get(id);
                    if (schoolEntity != null)
                    {
                        return SchoolsMapper.ToSchoolModel(schoolEntity);
                    }
                    else
                    {
                        throw new HttpResponseException(
                            Request.CreateErrorResponse(HttpStatusCode.NotFound, "School with provided id not found!"));
                    }
                });

            return httpResponse;
        }

        [HttpPost]
        public HttpResponseMessage Add(SchoolModel schoolModel)
        {
            var httpResponse = this.PerformOperation(() =>
                {
                    var schoolEntity = SchoolsMapper.ToSchoolEntity(schoolModel, unitOfWork);

                    this.unitOfWork.SchoolsRepository.Add(schoolEntity);
                    this.unitOfWork.Save();

                    schoolModel.ID = schoolEntity.ID;
                    return schoolModel;
                });

            return httpResponse;
        }
    }
}
