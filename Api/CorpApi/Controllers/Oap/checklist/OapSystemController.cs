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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.System;

    [RoutePrefix("system")]
    public class OapSystemController : OapApiController
    {
        public OapSystemController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapSystem>> GetAll()
        {
            return TryCatch<GetAllSystemRequest, IEnumerable<OapSystem>>(new GetAllSystemRequest());

        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapSystem> AddSystem([FromBody] OapSystem list)
        {
            return TryCatch<AddSystemRequest, OapSystem>(new AddSystemRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateSystem([FromBody] OapSystem list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateSystemRequest, bool>(new UpdateSystemRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteSystem(int id)
        {
            return TryCatch<DeleteSystemRequest, bool>(new DeleteSystemRequest(id));
        }
    }
}
