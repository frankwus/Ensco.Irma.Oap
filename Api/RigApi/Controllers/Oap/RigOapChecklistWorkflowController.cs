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
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Workflow;
    using Ensco.Irma.Oap.Api.Rig.Models;

    [RoutePrefix("roapchecklists/workflow")] 
    public class RigOapChecklistWorkflowController : OapApiController
    {
        public RigOapChecklistWorkflowController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<RigOapChecklistWorkflow> Get(Guid id)
        {
            return TryCatch<GetRigOapChecklistWorkflowRequest, RigOapChecklistWorkflow>(new GetRigOapChecklistWorkflowRequest(id));
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<RigOapChecklistWorkflow>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllRigOapChecklistWorkflowRequest, IEnumerable<RigOapChecklistWorkflow>>(new GetAllRigOapChecklistWorkflowRequest(model.StartDate, model.EndDate));
        }

        [HttpPost]
        [Route("start")]
        public WebApiResult<bool> StartWorkflow(StartWorkFlow startWFModel)
        {
            return TryCatch<StartRigOapChecklistWorkflowRequest, bool>(new StartRigOapChecklistWorkflowRequest(startWFModel.Checklist, startWFModel.Owner));
        }

        [HttpPost]
        [Route("process")]
        public WebApiResult<bool> ProcessWorkflow(ProcessWorkFlow processModel)
        {
            return TryCatch<ProcessRigOapChecklistWorflowRequest, bool>(new ProcessRigOapChecklistWorflowRequest(processModel.Checklist, processModel.User, processModel.Transition, processModel.Comment, processModel.Order));
        }
    }
}
