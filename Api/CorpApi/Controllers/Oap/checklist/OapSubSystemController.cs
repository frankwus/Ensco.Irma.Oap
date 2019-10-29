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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SubSystem;

    [RoutePrefix("subsystem")]
    public class OapSubSystemController : OapApiController
    {
        public OapSubSystemController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapSubSystem>> GetAll()
        {
            return TryCatch<GetAllSubSystemRequest, IEnumerable<OapSubSystem>>(new GetAllSubSystemRequest());

        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapSubSystem> AddSubSystem([FromBody] OapSubSystem list)
        {
            return TryCatch<AddSubSystemRequest, OapSubSystem>(new AddSubSystemRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateSubSystem([FromBody] OapSubSystem list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateSubSystemRequest, bool>(new UpdateSubSystemRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteSubSystem(int id)
        {
            return TryCatch<DeleteSubSystemRequest, bool>(new DeleteSubSystemRequest(id));
        }
    }
}
