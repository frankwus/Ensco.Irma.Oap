using System;
using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction;

    [RoutePrefix("roapchecklists/workinstruction")]
    public class RigOapChecklistWorkInstructionController : OapApiController
    {
        public RigOapChecklistWorkInstructionController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<RigOapChecklistWorkInstruction> Get(Guid id)
        {
            return TryCatch<GetRigOapChecklistWorkInstructionRequest, RigOapChecklistWorkInstruction>(new GetRigOapChecklistWorkInstructionRequest(id));
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<RigOapChecklistWorkInstruction>> GetAll()
        {
            return TryCatch<GetAllRigOapChecklistWorkInstructionRequest, IEnumerable<RigOapChecklistWorkInstruction>>(new GetAllRigOapChecklistWorkInstructionRequest());
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<RigOapChecklistWorkInstruction> UpdateRigChecklistWorkInstruction(RigOapChecklistWorkInstruction rigOapChecklistWorkInstruction)
        {
            return TryCatch<UpdateRigOapChecklistWorkInstructionRequest, RigOapChecklistWorkInstruction>(new UpdateRigOapChecklistWorkInstructionRequest(rigOapChecklistWorkInstruction));
        }

        [HttpPost]
        [Route("delete")]
        public WebApiResult<bool> DeleteRigChecklistWorkInstruction(Guid id)
        {
            return TryCatch<DeleteRigOapChecklistWorkInstructionRequest, bool>(new DeleteRigOapChecklistWorkInstructionRequest(id));
        }
    }
}


