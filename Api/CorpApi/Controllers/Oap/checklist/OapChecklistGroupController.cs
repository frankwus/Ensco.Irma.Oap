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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup;

    [RoutePrefix("oapchecklistgroup")]
    public class OapChecklistGroupController : OapApiController
    {
        public OapChecklistGroupController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklistGroup> Get(int id)
        {
            return TryCatch<GetChecklistGroupRequest, OapChecklistGroup>(new GetChecklistGroupRequest(id));
        }
         
        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistGroup>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllChecklistGroupRequest, IEnumerable<OapChecklistGroup>>(new GetAllChecklistGroupRequest(model.StartDate, model.EndDate));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistGroup> AddChecklistGroup([FromBody] OapChecklistGroup list)
        {
            return TryCatch<AddChecklistGroupRequest, OapChecklistGroup>(new AddChecklistGroupRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateChecklistGroup([FromBody] OapChecklistGroup list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistGroupRequest, bool>(new UpdateChecklistGroupRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteChecklistGroup(int id)
        {
            return TryCatch<DeleteChecklistGroupRequest, bool>(new DeleteChecklistGroupRequest(id));
        }
    }
}
