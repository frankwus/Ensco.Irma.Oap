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
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob;

    [RoutePrefix("roapchecklists/thirdpartyjob")]
    public class RigOapChecklistThirdPartyJobController : OapApiController
    {
        public RigOapChecklistThirdPartyJobController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<RigOapChecklistThirdPartyJob> Get(Guid id)
        {
            return TryCatch<GetRigOapChecklistThirdPartyJobRequest, RigOapChecklistThirdPartyJob>(new GetRigOapChecklistThirdPartyJobRequest(id));
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<RigOapChecklistThirdPartyJob>> GetAll()
        {
            return TryCatch<GetAllRigOapChecklistThirdPartyJobRequest, IEnumerable<RigOapChecklistThirdPartyJob>>(new GetAllRigOapChecklistThirdPartyJobRequest());
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<RigOapChecklistThirdPartyJob> UpdateRigChecklistThirdPartyJob(RigOapChecklistThirdPartyJob rigOapChecklistThirdPartyJob)
        {
            return TryCatch<UpdateRigOapChecklistThirdPartyJobRequest, RigOapChecklistThirdPartyJob>(new UpdateRigOapChecklistThirdPartyJobRequest(rigOapChecklistThirdPartyJob));
        }

        [HttpPost]
        [Route("delete")]
        public WebApiResult<bool> DeleteRigChecklistThirdPartyJob(Guid id)
        {
            return TryCatch<DeleteRigOapChecklistThirdPartyJobRequest, bool>(new DeleteRigOapChecklistThirdPartyJobRequest(id));
        }
    }
}


