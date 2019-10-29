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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup;

    [RoutePrefix("oapchecklistsubgroup")]
    public class OapChecklistSubGroupController : OapApiController
    {
        public OapChecklistSubGroupController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklistSubGroup> Get(int id)
        {
            return TryCatch<GetChecklistSubGroupRequest, OapChecklistSubGroup>(new GetChecklistSubGroupRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistSubGroup>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllChecklistSubGroupRequest, IEnumerable<OapChecklistSubGroup>>(new GetAllChecklistSubGroupRequest(model.StartDate, model.EndDate));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistSubGroup> AddChecklistSubGroup([FromBody] OapChecklistSubGroup list)
        {
            return TryCatch<AddChecklistSubGroupRequest, OapChecklistSubGroup>(new AddChecklistSubGroupRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateChecklistSubGroup([FromBody] OapChecklistSubGroup list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistSubGroupRequest, bool>(new UpdateChecklistSubGroupRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteChecklistSubGroup(int id)
        {
            return TryCatch<DeleteChecklistSubGroupRequest, bool>(new DeleteChecklistSubGroupRequest(id));
        }
    }
}
