using System;
using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionDataType;

    [RoutePrefix("oapquestiondatatype")]
    public class OapChecklistQuestionDataTypeController : OapApiController
    {
        public OapChecklistQuestionDataTypeController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklistQuestionDataType> Get(int id)
        {
            return TryCatch<GetQuestionDataTypeRequest, OapChecklistQuestionDataType>(new GetQuestionDataTypeRequest(id));
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistQuestionDataType>> GetAll()
        {
            return TryCatch<GetAllQuestionDataTypeRequest, IEnumerable<OapChecklistQuestionDataType>>(new GetAllQuestionDataTypeRequest());
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistQuestionDataType> AddQuestionDataType([FromBody] OapChecklistQuestionDataType list)
        {
            return TryCatch<AddQuestionDataTypeRequest, OapChecklistQuestionDataType>(new AddQuestionDataTypeRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateQuestionDataType([FromBody] OapChecklistQuestionDataType list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateQuestionDataTypeRequest, bool>(new UpdateQuestionDataTypeRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteQuestionDataType(int id)
        {
            return TryCatch<DeleteQuestionDataTypeRequest, bool>(new DeleteQuestionDataTypeRequest(id));
        }
    }
}
