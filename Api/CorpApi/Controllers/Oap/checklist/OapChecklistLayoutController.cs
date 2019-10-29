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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout;

    [RoutePrefix("oapchecklists/layout")]
    public class OapChecklistLayoutController : OapApiController
    {
        public OapChecklistLayoutController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklistLayout> Get(int id)
        {
            return TryCatch<GetChecklistLayoutRequest, OapChecklistLayout>(new GetChecklistLayoutRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistLayout>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllChecklistLayoutRequest, IEnumerable<OapChecklistLayout>>(new GetAllChecklistLayoutRequest());
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistLayout> AddChecklistLayout([FromBody] OapChecklistLayout list)
        {
            return TryCatch<AddChecklistLayoutRequest, OapChecklistLayout>(new AddChecklistLayoutRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateChecklistLayout([FromBody] OapChecklistLayout list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistLayoutRequest, bool>(new UpdateChecklistLayoutRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteChecklistLayout(int id)
        {
            return TryCatch<DeleteChecklistLayoutRequest, bool>(new DeleteChecklistLayoutRequest(id));
        }
    }
}
