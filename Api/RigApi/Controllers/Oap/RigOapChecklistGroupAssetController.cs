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
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Asset;

    [RoutePrefix("roapchecklists/asset")]
    public class RigOapChecklistGroupAssetController : OapApiController
    {
        public RigOapChecklistGroupAssetController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<RigOapChecklistGroupAsset> Get(Guid id)
        {
            return TryCatch<GetRigOapChecklistGroupAssetRequest, RigOapChecklistGroupAsset>(new GetRigOapChecklistGroupAssetRequest(id));
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<RigOapChecklistGroupAsset>> GetAll()
        {
            return TryCatch<GetAllRigOapChecklistGroupAssetRequest, IEnumerable<RigOapChecklistGroupAsset>>(new GetAllRigOapChecklistGroupAssetRequest());
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<RigOapChecklistGroupAsset> UpdateRigChecklistAsset(RigOapChecklistGroupAsset rigOapChecklistAsset)
        {
            return TryCatch<UpdateRigOapChecklistGroupAssetRequest, RigOapChecklistGroupAsset>(new UpdateRigOapChecklistGroupAssetRequest(rigOapChecklistAsset));
        }

        [HttpPost]
        [Route("delete")]
        public WebApiResult<bool> DeleteRigChecklistAsset(Guid id)
        {
            return TryCatch<DeleteRigOapChecklistGroupAssetRequest, bool>(new DeleteRigOapChecklistGroupAssetRequest(id));
        }
    }
}


