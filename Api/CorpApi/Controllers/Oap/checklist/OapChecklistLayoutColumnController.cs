using System;
using System.Collections.Generic;
using System.Web.Http;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.ActionResults;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn;

    [RoutePrefix("oapchecklists/layoutcolumns")]
    public class OapChecklistLayoutColumnController : OapApiController
    {
        public OapChecklistLayoutColumnController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklistLayoutColumn> Get(int id)
        {
            return TryCatch<GetChecklistLayoutColumnRequest, OapChecklistLayoutColumn>(new GetChecklistLayoutColumnRequest(id));
        }

        [HttpPost]
        [Route("layout/{layoutId}")]
        public WebApiResult<IEnumerable<OapChecklistLayoutColumn>> GetAll(int layoutId)
        {
            return TryCatch<GetAllChecklistLayoutColumnRequest, IEnumerable<OapChecklistLayoutColumn>>(new GetAllChecklistLayoutColumnRequest(layoutId));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistLayoutColumn> AddChecklistLayoutColumn([FromBody] OapChecklistLayoutColumn list)
        {
            return TryCatch<AddChecklistLayoutColumnRequest, OapChecklistLayoutColumn>(new AddChecklistLayoutColumnRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateChecklistLayoutColumn([FromBody] OapChecklistLayoutColumn list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistLayoutColumnRequest, bool>(new UpdateChecklistLayoutColumnRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteChecklistLayoutColumn(int id)
        {
            return TryCatch<DeleteChecklistLayoutColumnRequest, bool>(new DeleteChecklistLayoutColumnRequest(id));
        }
    }
}
