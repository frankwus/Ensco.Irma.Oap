using System;
using System.Collections.Generic;
using System.Web.Http;

using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Api.Common.Models;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement;

    [RoutePrefix("oapchecklists/assetdatamanagement")]
    public class OapChecklistAssetDataManagementController : OapApiController
    {
        public OapChecklistAssetDataManagementController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapAssetDataManagement>> GetAll()
        {
           return TryCatch<GetAllChecklistAssetDataManagementRequest, IEnumerable<OapAssetDataManagement>>(new GetAllChecklistAssetDataManagementRequest());
            
        }

        [HttpGet]
        [Route("all/{groupId}")]
        public WebApiResult<IEnumerable<OapAssetDataManagement>> GetAllByGroup(int groupId)
        {
            return TryCatch<GetAllByChecklistGroupAssetDataManagementRequest, IEnumerable<OapAssetDataManagement>>(new GetAllByChecklistGroupAssetDataManagementRequest(groupId));

        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapAssetDataManagement> AddAssetDataManagement([FromBody] OapAssetDataManagement list)
        {
            return TryCatch<AddChecklistAssetDataManagementRequest, OapAssetDataManagement>(new AddChecklistAssetDataManagementRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateAssetDataManagement([FromBody] OapAssetDataManagement list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistAssetDataManagementRequest, bool>(new UpdateChecklistAssetDataManagementRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteAssetDataManagement(int id)
        {
            return TryCatch<DeleteChecklistAssetDataManagementRequest, bool>(new DeleteChecklistAssetDataManagementRequest(id));
        }
    }
}
