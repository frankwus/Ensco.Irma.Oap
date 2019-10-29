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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.WorkInstruction;

    [RoutePrefix("workinstructions")]
    public class OapWorkInstructionController : OapApiController
    {
        public OapWorkInstructionController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapWorkInstruction>> GetAll()
        {
            return TryCatch<GetAllWorkInstructionRequest, IEnumerable<OapWorkInstruction>>(new GetAllWorkInstructionRequest());

        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapWorkInstruction> AddWorkInstruction([FromBody] OapWorkInstruction list)
        {
            return TryCatch<AddWorkInstructionRequest, OapWorkInstruction>(new AddWorkInstructionRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateWorkInstruction([FromBody] OapWorkInstruction list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateWorkInstructionRequest, bool>(new UpdateWorkInstructionRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteWorkInstruction(int id)
        {
            return TryCatch<DeleteWorkInstructionRequest, bool>(new DeleteWorkInstructionRequest(id));
        }
    }
}
