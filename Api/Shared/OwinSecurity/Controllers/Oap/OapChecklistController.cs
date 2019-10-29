using System;
using System.Collections.Generic;
using System.Web.Http;

using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Api.Common.Models;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.NoAnswer;

    [RoutePrefix("oapchecklists")] 
    public class OapChecklistController : OapApiController
    {

        public OapChecklistController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklist> Get(int id)
        {
            return TryCatch<GetChecklistRequest, OapChecklist>(new GetChecklistRequest(id));
        }

        [HttpGet]
        [Route("search/{name}")]
        public WebApiResult<OapChecklist> GetByName(string name)
        {
            return TryCatch<GetChecklistByTitleRequest, OapChecklist>(new GetChecklistByTitleRequest(name));
        }

        [HttpGet]
        [Route("search/typename/{typeName}")]
        public WebApiResult<IEnumerable<OapChecklist>> GetByTypeName(string typeName)
        {
            return TryCatch<GetChecklistsByTypeNameRequest, IEnumerable<OapChecklist>>(new GetChecklistsByTypeNameRequest(typeName));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklist>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllChecklistRequest,IEnumerable<OapChecklist>>(new GetAllChecklistRequest(model.StartDate, model.EndDate)); 
        }

        [HttpGet]
        [Route("all/{typeName}/{subTypeName}")]
        public WebApiResult<IEnumerable<OapChecklist>> GetAllByTypeSubType(string typeName, string subTypeName)
        {
            return TryCatch<GetChecklistByTypeSubTypeRequest, IEnumerable<OapChecklist>>(new GetChecklistByTypeSubTypeRequest(typeName, subTypeName));
        }

        [HttpGet]
        [Route("all/Code/{typeCode}/{subTypeCode}")]
        public WebApiResult<IEnumerable<OapChecklist>> GetAllByTypeSubTypeCode(string typeCode, string subTypeCode)
        {
            return TryCatch<GetChecklistByTypeSubTypeCodeRequest, IEnumerable<OapChecklist>>(new GetChecklistByTypeSubTypeCodeRequest(typeCode, subTypeCode));
        }

        [HttpGet]
        [Route("all/{typeName}/{subTypeName}/{formType}")]
        public WebApiResult<IEnumerable<OapChecklist>> GetAllByTypeSubTypeFormType(string typeName, string subTypeName, string formType)
        {
            return TryCatch<GetChecklistByTypeSubTypeFormTypeRequest, IEnumerable<OapChecklist>>(new GetChecklistByTypeSubTypeFormTypeRequest(typeName, subTypeName, formType));
        }

        [HttpGet]
        [Route("all/Code/{typeCode}/{subTypeCode}/{formType}")]
        public WebApiResult<IEnumerable<OapChecklist>> GetAllByTypeSubTypeFormTypeCode(string typeCode, string subTypeCode, string formType)
        {
            return TryCatch<GetChecklistByTypeSubTypeCodeFormTypeRequest, IEnumerable<OapChecklist>>(new GetChecklistByTypeSubTypeCodeFormTypeRequest(typeCode, subTypeCode, formType));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklist> AddOapChecklist([FromBody] OapChecklist list)
        {
            return TryCatch<AddChecklistRequest, OapChecklist>(new AddChecklistRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateOapChecklist([FromBody] OapChecklist list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistRequest, bool>(new UpdateChecklistRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteOapChecklist( int id)
        {
            return TryCatch<DeleteChecklistRequest, bool>(new DeleteChecklistRequest(id));
        }

        [HttpGet]
        [Route("questions/{oapChecklistQuestionId}/noanswers")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestionNoAnswerComment>> GetAllQuestionNoAnswers(int oapChecklistId, int oapChecklistQuestionId)
        {
            return TryCatch<GetAllQuestionNoAnswersRequest, IEnumerable<RigOapChecklistQuestionNoAnswerComment>>(new GetAllQuestionNoAnswersRequest(oapChecklistId, oapChecklistQuestionId));
        }

        [HttpGet]
        [Route("{oapChecklistId}/questions/{oapChecklistQuestionId}/noanswers/open")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestionNoAnswerComment>> GetAllQuestionOpenNoAnswers(int oapChecklistId, int oapChecklistQuestionId)
        {
            return TryCatch<GetAllQuestionOpenNoAnswersRequest, IEnumerable<RigOapChecklistQuestionNoAnswerComment>>(new GetAllQuestionOpenNoAnswersRequest(oapChecklistId, oapChecklistQuestionId));
        }

        [HttpGet]
        [Route("{oapChecklistId}/questions/{oapChecklistQuestionId}/noanswers/first")]
        public WebApiResult<RigOapChecklistQuestionNoAnswerComment> GetFirstQuestionOpenNoAnswers(int oapChecklistId, int oapChecklistQuestionId)
        {
            return TryCatch<GetFirstQuestionOpenNoAnswersRequest, RigOapChecklistQuestionNoAnswerComment>(new GetFirstQuestionOpenNoAnswersRequest(oapChecklistId, oapChecklistQuestionId));
        }

        [HttpGet]
        [Route("noanswers/{id}")]
        public WebApiResult<RigOapChecklistQuestionNoAnswerComment> GetNoAnswerById(Guid id)
        {
            return TryCatch<GetNoAnswerByIdRequest, RigOapChecklistQuestionNoAnswerComment>(new GetNoAnswerByIdRequest(id));
        }

        [HttpPost]
        [Route("{oapChecklistId}/questions/{oapChecklistQuestionId}/noanswers")]
        public WebApiResult<RigOapChecklistQuestionNoAnswerComment> AddQuestionNoAnswer(int oapChecklistId, int oapChecklistQuestionId, Guid rigOapChecklistId, int userId)
        {
            return TryCatch<AddQuestionNoAnswerRequest, RigOapChecklistQuestionNoAnswerComment>(new AddQuestionNoAnswerRequest(oapChecklistId, oapChecklistQuestionId, rigOapChecklistId, userId));
        }

        [HttpPost]
        [Route("noanswers/update")]
        public WebApiResult<RigOapChecklistQuestionNoAnswerComment> UpdateNoAnswer(RigOapChecklistQuestionNoAnswerComment model)
        {
            return TryCatch<UpdateQuestionNoAnswerRequest, RigOapChecklistQuestionNoAnswerComment>(new UpdateQuestionNoAnswerRequest(model));
        }

        //Get Checklist of type OP, CAV and LS for Audit
        [HttpGet]
        [Route("allauditprotocols")]
        public WebApiResult<IEnumerable<OapChecklist>> GetAllAuditProtocols()
        {
            return TryCatch<GetAllAuditProtocolsRequest, IEnumerable<OapChecklist>>(new GetAllAuditProtocolsRequest());
        }

    }
}
