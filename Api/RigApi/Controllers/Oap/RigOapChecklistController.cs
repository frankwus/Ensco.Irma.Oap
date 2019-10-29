using System;
using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Api.Common.Models;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
    using Ensco.Irma.Oap.Api.Rig.Commands.FsoChecklist;
    using Ensco.Irma.Models.Domain.Oap.Checklist.Lifesaver;    
    using Ensco.Irma.Interfaces.Data.Repositories;
    using System.Linq;
    using Ensco.Irma.Models.Domain.Oap;

    [RoutePrefix("rigoapchecklists")] 
    public class RigOapChecklistController : OapApiController
    {
        public IAdminCustomRepository AdminCustomRepository { get; }

        public RigOapChecklistController(IMediator mediator, ILog logger, IAdminCustomRepository adminCustomRepository) : base(mediator, logger)
        {
            AdminCustomRepository = adminCustomRepository;
        }
 
        [HttpGet]
        [Route("{id}")]
        public WebApiResult<RigOapChecklist> Get(Guid id)
        {
            return TryCatch<GetRigOapChecklistRequest, RigOapChecklist>(new GetRigOapChecklistRequest(id));
        }

        [HttpGet]
        [Route("unique/{id:int}")]
        public WebApiResult<RigOapChecklist> GetByUniqueId(int id)
        {
            return TryCatch<GetByUniqueIdRequest, RigOapChecklist>(new GetByUniqueIdRequest(id));
        }


        [HttpGet]
        [Route("complete/{id}")]
        public WebApiResult<RigOapChecklist> GetCompleteChecklist(Guid id)
        {
            return TryCatch<GetRigOapCompleteChecklistRequest, RigOapChecklist>(new GetRigOapCompleteChecklistRequest(id));
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<RigOapChecklist> GetAll()
        {
            var result = new WebApiResult<RigOapChecklist>();
            RigOapChecklist r = new RigOapChecklist(); 
           // r.RigId
            result.Data =r;
            return result; 
            //return TryCatch<GetAllRigOapChecklistRequest, IEnumerable<RigOapChecklist>>(new GetAllRigOapChecklistRequest(string.Empty));
        }

        [HttpGet]
        [Route("all/{status}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetAllByStatus(string status)
        {
            return TryCatch<GetAllRigOapChecklistRequest, IEnumerable<RigOapChecklist>>(new GetAllRigOapChecklistRequest(status)); 
        }

        [HttpGet]
        [Route("all/{typeName}/{status}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetAllByTypeStatus(string typeName, string status)
        {
            return TryCatch<GetAllByTypeStatusRigOapChecklistRequest, IEnumerable<RigOapChecklist>>(new GetAllByTypeStatusRigOapChecklistRequest(typeName, status));
        }

        [HttpGet]
        [Route("all/{typeName}/{subTypeName}/{status}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetAllByTypeSubTypeStatus(string typeName, string subTypeName, string status)
        {
            return TryCatch<GetAllTypeSubTypeRigOapChecklistRequest, IEnumerable<RigOapChecklist>>(new GetAllTypeSubTypeRigOapChecklistRequest(typeName, subTypeName, status));
        }

        [HttpGet]
        [Route("all/Code/{typeCode}/{subTypeCode}/{status}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetAllByTypeSubTypeCodeStatus(string typeCode, string subTypeCode, string status)
        {
            return TryCatch<GetAllTypeSubTypeCodeRigOapChecklistRequest, IEnumerable<RigOapChecklist>>(new GetAllTypeSubTypeCodeRigOapChecklistRequest(typeCode, subTypeCode, status));
        }


        [HttpGet]
        [Route("all/{typeName}/{subTypeName}/{formType}/{status}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetAllByTypeSubTypeFormTypeStatus(string typeName, string subTypeName, string formType, string status)
        {
            return TryCatch<GetAllTypeSubTypeFormTypeRigOapChecklistRequest, IEnumerable<RigOapChecklist>>(new GetAllTypeSubTypeFormTypeRigOapChecklistRequest(typeName, subTypeName, formType, status));
        }

        [HttpGet]
        [Route("all/Code/{typeCode}/{subTypeCode}/{formType}/{status}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetAllByTypeSubTypeCodeFormTypeStatus(string typeCode, string subTypeCode, string formType, string status)
        {
            return TryCatch<GetAllTypeSubTypeCodeFormTypeRigOapChecklistRequest, IEnumerable<RigOapChecklist>>(new GetAllTypeSubTypeCodeFormTypeRigOapChecklistRequest(typeCode, subTypeCode, formType, status));
        }
               
        [HttpGet]
        [Route("all/inworkflow/{typeCode}/{subTypeCode}/{status}/{verifierRole}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetAllInWorkflowByTypeSubTypeCodeStatus(string typeCode, string subTypeCode, string status, string verifierRole)
        {
            return TryCatch<GetAllInWorkflowByTypeSubTypeCodeVerifierRoleRigOapChecklistRequest, IEnumerable<RigOapChecklist>>(new GetAllInWorkflowByTypeSubTypeCodeVerifierRoleRigOapChecklistRequest(typeCode, subTypeCode, status, verifierRole));
        }

        [HttpGet]
        [Route("relatedquestion/search/all/{questionId}")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestion>> GetRelatedQuestionSearch(int questionId, DateTime formDate, DateTime toDate, string searchBy)
        {
            return TryCatch<GetRelatedQuestionSearchChecklistRequest, IEnumerable<RigOapChecklistQuestion>>(new GetRelatedQuestionSearchChecklistRequest(questionId, formDate, toDate, searchBy));
        }      

        [HttpPut]
        [Route("add")]
        public WebApiResult<RigOapChecklist> AddRigChecklist([FromBody] RigOapChecklist rigChecklist)
        {
            return TryCatch<AddRigOapChecklistRequest, RigOapChecklist>(new AddRigOapChecklistRequest(rigChecklist));
        }

        [HttpPut]
        [Route("update")]
        public WebApiResult<RigOapChecklist> UpdateRigChecklist([FromBody] RigOapChecklist rigChecklist)
        {
            return TryCatch<UpdateRigOapChecklistRequest, RigOapChecklist>(new UpdateRigOapChecklistRequest(rigChecklist));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteRigOapChecklist(Guid id)
        {
            return TryCatch<DeleteRigOapChecklistRequest, bool>(new DeleteRigOapChecklistRequest(id));
        }

        [HttpGet]
        [Route("fso/open/{fsoChecklistId}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetOpenFsoChecklists(int fsoChecklistId)
        {
            return TryCatch<GetOpenFsoChecklistRequest, IEnumerable<RigOapChecklist>>(new GetOpenFsoChecklistRequest(fsoChecklistId));
        }

        [HttpPut]
        [Route("fso/update")]
        public WebApiResult<RigOapChecklist> UpdateRigFsoChecklist([FromBody] RigOapChecklist rigChecklist)
        {
            return TryCatch<UpdateRigOapChecklistRequest, RigOapChecklist>(new UpdateRigOapChecklistRequest(rigChecklist));
        }

        [HttpGet]
        [Route("fso/getbymindate/{minDate}")]
        public WebApiResult<IEnumerable<RigOapChecklist>> GetFsoChecklistByMinDate(DateTime minDate, int oapChecklistId)
        {
            return TryCatch<GetFsoChecklistByMinDateRequest, IEnumerable<RigOapChecklist>>(new GetFsoChecklistByMinDateRequest(minDate, oapChecklistId));
        }

        [HttpGet]
        [Route("lifesaver/compliance")]
        public WebApiResult<LifesaverCompliance> GetLifesaverCompliance()
        {
            return TryCatch<GetLifesaverComplianceRequest, LifesaverCompliance>(new GetLifesaverComplianceRequest());
        }

        [HttpPost]
        [Route("answers/update")]
        public WebApiResult<bool> UpdateChecklistAnswers(IEnumerable<RigOapChecklistQuestionAnswer> answers)
        {
            return TryCatch<UpdateChecklistAnswerRequest, bool>(new UpdateChecklistAnswerRequest(answers));
        }

        [HttpPost]
        [Route("{id}/assessors")]
        public WebApiResult<RigOapChecklist> AddAssessor(Guid id, RigOapChecklistAssessor assessor)
        {
            return TryCatch<AddAssessorRequest, RigOapChecklist>(new AddAssessorRequest(id, assessor));
        }

        [HttpPost]
        [Route("validate")]
        public WebApiResult<RigChecklistValidationResult> ValidateChecklist(Guid rigChecklistId)
        {
            return TryCatch<ValidateChecklistRequest, RigChecklistValidationResult>(new ValidateChecklistRequest(rigChecklistId));
        }

        [HttpPost]
        [Route("assessors/{id}/delete")]
        public WebApiResult<bool> DeleteAssessor(Guid id)
        {
            return TryCatch<DeleteAssessorRequest, bool>(new DeleteAssessorRequest(id));
        }
    }
}
