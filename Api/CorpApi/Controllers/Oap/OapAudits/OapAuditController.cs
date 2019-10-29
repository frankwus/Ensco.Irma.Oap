using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap;

using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.ActionResults;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol;
using Ensco.Irma.Oap.Common.Api.Controllers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap.OapAudits
{
    [RoutePrefix("oapaudits")]
    public class OapAuditController : OapApiController
    {
        public OapAuditController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapAudit>> GetAllOapAudits(string status)
        {
            return TryCatch<GetAllByStatusRequest, IEnumerable<OapAudit>>(new GetAllByStatusRequest(status));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapAudit> AddOapAudit([FromBody] OapAudit aAudit)
        {
            return TryCatch<OapAuditRequest, OapAudit>(new OapAuditRequest(aAudit));
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapAudit> GetOapAudit(int id)
        {
            return TryCatch<GetOapAuditRequest, OapAudit>(new GetOapAuditRequest(id));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateOapAudit([FromBody] OapAudit audit)
        {
            if (audit == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateOapAuditRequest, bool>(new UpdateOapAuditRequest(audit));
        }

        //Protocols To Audit 
        [HttpGet]
        [Route("getallprotocolsbyauditid/{auditId}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetAuditProtocols(int auditId)
        {
            return TryCatch<GetAuditProtocolsRequest, IEnumerable<RigOapChecklist>>(new GetAuditProtocolsRequest(auditId));
        }

        [HttpPut]
        [Route("addprotocoltoaudit/{auditId}")]
        public WebApiResult<RigOapChecklist> AddProtocolToAudit(int auditId, [FromBody] RigOapChecklist oapProtocol)
        {
            return TryCatch<AddAuditProtocolRequest, RigOapChecklist>(new AddAuditProtocolRequest(auditId, oapProtocol));
        }

        [HttpPut]
        [Route("update")]
        public WebApiResult<RigOapChecklist> UpdateRigChecklist([FromBody] RigOapChecklist rigChecklist)
        {
            return TryCatch<UpdateAuditProtocolRequest, RigOapChecklist>(new UpdateAuditProtocolRequest(rigChecklist));
        }

        [HttpGet]
        [Route("complete/{id}")]
        public WebApiResult<RigOapChecklist> GetCompleteProtocol(Guid id)
        {
            return TryCatch<GetCompleteProtocolRequest, RigOapChecklist>(new GetCompleteProtocolRequest(id));
        }

        [HttpPost]
        [Route("{id}/assessors")]
        public WebApiResult<RigOapChecklist> AddAssessor(Guid id, RigOapChecklistAssessor assessor)
        {
            return TryCatch<AddProtocolAssessorRequest, RigOapChecklist>(new AddProtocolAssessorRequest(id, assessor));
        }

        [HttpPost]
        [Route("assessors/{id}/delete")]
        public WebApiResult<bool> DeleteAssessor(Guid id)
        {
            return TryCatch<DeleteProtocolAssessorRequest, bool>(new DeleteProtocolAssessorRequest(id));
        }

        [HttpPost]
        [Route("answers/update")]
        public WebApiResult<bool> UpdateChecklistAnswers(IEnumerable<RigOapChecklistQuestionAnswer> answers)
        {
            return TryCatch<UpdateProtocolAnswerRequest, bool>(new UpdateProtocolAnswerRequest(answers));
        }

        [HttpGet]
        [Route("relatedquestion/search/all/{questionId}")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestion>> GetRelatedQuestionSearch(int questionId, DateTime formDate, DateTime toDate, string searchBy)
        {
            return TryCatch<GetRelatedQuestionSearchProtocolRequest, IEnumerable<RigOapChecklistQuestion>>(new GetRelatedQuestionSearchProtocolRequest(questionId, formDate, toDate, searchBy));
        } 

        [HttpGet]
        [Route("getchecklistsforreview")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetChecklistsForReview(int searchBy, int checklistId, DateTime fromDate, DateTime toDate)
        {
            return TryCatch<GetChecklistsForReviewRequest, IEnumerable<RigOapChecklist>>(new GetChecklistsForReviewRequest(searchBy, checklistId, fromDate, toDate));
        }

        [HttpPut]
        [Route("addprotocols/{auditId}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> AddProtocols(int auditId, [FromBody] IEnumerable<RigOapChecklist> oapProtocols)
        {
            return TryCatch<AddProtocolsRequest, IEnumerable<RigOapChecklist>>(new AddProtocolsRequest(auditId, oapProtocols));
        }

        [HttpPost]
        [Route("validate")]
        public WebApiResult<RigChecklistValidationResult> ValidateOapAudit(int aId)
        {
            return TryCatch<ValidateOapAuditRequest, RigChecklistValidationResult>(new ValidateOapAuditRequest(aId));
        }

    }
}