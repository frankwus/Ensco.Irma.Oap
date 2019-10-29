using System;
using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Models.Domain.IRMA;

    [RoutePrefix("finding")]
    public class OapChecklistFindingController : OapApiController
    {
        public OapChecklistFindingController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<RigOapChecklistQuestionFinding> Get(Guid id)
        {
            return TryCatch<GetOapChecklistQuestionFindingRequest, RigOapChecklistQuestionFinding>(new GetOapChecklistQuestionFindingRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestionFinding>> GetAll()
        {
            return TryCatch<GetAllOapChecklistQuestionFindingRequest, IEnumerable<RigOapChecklistQuestionFinding>>(new GetAllOapChecklistQuestionFindingRequest());
        }

        [HttpPost]
        [Route("question/{rigQuestionId}")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestionFinding>> GetAllFindingsForQuestion(Guid rigQuestionId)
        {
            return TryCatch<GetAllOapChecklistFindingsForQuestionRequest, IEnumerable<RigOapChecklistQuestionFinding>>(new GetAllOapChecklistFindingsForQuestionRequest(rigQuestionId));
        }

        [HttpPost]
        [Route("checklist/{rigChecklistId}")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestionFinding>> GetAllFindingsForChecklist(Guid rigChecklistId)
        {
            return TryCatch<GetAllOapChecklistFindingsForChecklistRequest, IEnumerable<RigOapChecklistQuestionFinding>>(new GetAllOapChecklistFindingsForChecklistRequest(rigChecklistId));
        }

        [HttpPost]
        [Route("previous/{rigQuestionId}")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestionFinding>> GetAllQuestionPreviousFindings(Guid rigQuestionId)
        {
            return TryCatch<GetAllPreviousOapChecklistQuestionFindingRequest, IEnumerable<RigOapChecklistQuestionFinding>>(new GetAllPreviousOapChecklistQuestionFindingRequest(rigQuestionId));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<RigOapChecklistQuestionFinding> AddFinding([FromBody] RigOapChecklistQuestionFinding finding)
        {
            return TryCatch<AddOapChecklistQuestionFindingRequest, RigOapChecklistQuestionFinding>(new AddOapChecklistQuestionFindingRequest(finding));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateFinding([FromBody] RigOapChecklistQuestionFinding finding)
        {
            return TryCatch<UpdateOapChecklistQuestionFindingRequest, bool>(new UpdateOapChecklistQuestionFindingRequest(finding));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteFinding(Guid id)
        {
            return TryCatch<DeleteOapChecklistQuestionFindingRequest, bool>(new DeleteOapChecklistQuestionFindingRequest(id));
        }

        [HttpGet]
        [Route("capa/{capaId}")]
        public WebApiResult<IrmaCapa> GetCAPAsByFindingId(int capaId)
        {
            return TryCatch<GetCAPAByIdRequest, IrmaCapa>(new GetCAPAByIdRequest(capaId));
        }

        [HttpGet]
        [Route("capa/checklistId/{checklistId}")]
        public WebApiResult<IEnumerable<IrmaCapa>> GetCAPAsByChecklistId(Guid checklistId)
        {
            return TryCatch<GetCAPAsByChecklistIdRequest, IEnumerable<IrmaCapa>>(new GetCAPAsByChecklistIdRequest(checklistId));
        }
    }
}
