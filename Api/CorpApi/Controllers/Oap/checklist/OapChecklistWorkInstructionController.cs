using System;
using System.Collections.Generic;
using System.Web.Http;

using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Api.Common.Models;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistWorkInstruction;

    [RoutePrefix("oapchecklists/workinstructions")]
    public class OapChecklistWorkInstructionController : OapApiController
    {
        public OapChecklistWorkInstructionController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistWorkInstruction>> GetAll()
        {
            return TryCatch<GetAllChecklistWorkInstructionRequest, IEnumerable<OapChecklistWorkInstruction>>(new GetAllChecklistWorkInstructionRequest());

        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistWorkInstruction> AddChecklistWorkInstruction([FromBody] OapChecklistWorkInstruction list)
        {
            return TryCatch<AddChecklistWorkInstructionRequest, OapChecklistWorkInstruction>(new AddChecklistWorkInstructionRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateChecklistWorkInstruction([FromBody] OapChecklistWorkInstruction list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistWorkInstructionRequest, bool>(new UpdateChecklistWorkInstructionRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteChecklistWorkInstruction(int id)
        {
            return TryCatch<DeleteChecklistWorkInstructionRequest, bool>(new DeleteChecklistWorkInstructionRequest(id));
        }
    }
}
