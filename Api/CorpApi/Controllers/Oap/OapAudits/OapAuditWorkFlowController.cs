using System;
using System.Collections.Generic;
using System.Web.Http;
using MediatR;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.ActionResults;
using Ensco.Irma.Oap.Api.Common.Models;
using Ensco.Irma.Oap.Common.Api.Controllers;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.WorkFlow;
using Ensco.Irma.Oap.Api.Corp.Models;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap.OapAudits
{
    [RoutePrefix("oapaudits/workflow")]
    public class OapAuditWorkFlowController:OapApiController
    {
        public OapAuditWorkFlowController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }


        [HttpPost]
        [Route("start")]
        public WebApiResult<bool> StartWorkflow(StartOapAuditWorkFlow startWFModel)
        {
            return TryCatch<StartOapAuditWorkFlowRequest, bool>(new StartOapAuditWorkFlowRequest(startWFModel.Checklist, startWFModel.Owner, startWFModel.Audit));
        }

        [HttpPost]
        [Route("process")]
        public WebApiResult<bool> ProcessWorkflow(ProcessOapAuditWorkFlow processModel)
        {
            return TryCatch<ProcessOapAuditWorkFlowRequest, bool>(new ProcessOapAuditWorkFlowRequest(processModel.Checklist, processModel.User, processModel.Transition, processModel.Comment, processModel.Order, processModel.Audit));
        }
    }
}