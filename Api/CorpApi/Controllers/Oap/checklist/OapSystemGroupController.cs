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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SystemGroup;

    [RoutePrefix("systemgroup")]
    public class OapSystemGroupController : OapApiController
    {
        public OapSystemGroupController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapSystemGroup>> GetAll()
        {
            return TryCatch<GetAllSystemGroupRequest, IEnumerable<OapSystemGroup>>(new GetAllSystemGroupRequest());

        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapSystemGroup> AddSystemGroup([FromBody] OapSystemGroup list)
        {
            return TryCatch<AddSystemGroupRequest, OapSystemGroup>(new AddSystemGroupRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateSystemGroup([FromBody] OapSystemGroup group)
        {
            if (group == null)
            {
                var result = new WebApiResult<bool>();
                result.SetError($"Argument {{group}} is null");
            }

            return TryCatch<UpdateSystemGroupRequest, bool>(new UpdateSystemGroupRequest(group));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteSystemGroup(int id)
        {
            return TryCatch<DeleteSystemGroupRequest, bool>(new DeleteSystemGroupRequest(id));
        }
    }
}
