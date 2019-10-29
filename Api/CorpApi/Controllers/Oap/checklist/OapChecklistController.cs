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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist;
    using Ensco.Irma.Oap.Common.Api.Controllers;

    [RoutePrefix("oapchecklists")] 
    public class OapChecklistController : OapApiController
    {

        public OapChecklistController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }
 
        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklist> Get(int id)
        {
            return TryCatch<GetChecklistRequest,OapChecklist>(new GetChecklistRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklist>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllChecklistRequest,IEnumerable<OapChecklist>>(new GetAllChecklistRequest(model.StartDate, model.EndDate)); 
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklist> AddOapChecklist([FromBody] OapChecklist list)
        {
            return TryCatch<AddChecklistRequest, OapChecklist>(new AddChecklistRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateOapChecklist([FromBody] OapChecklist list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistRequest, bool>(new UpdateChecklistRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteOapChecklist( int id)
        {
            return TryCatch<DeleteChecklistRequest, bool>(new DeleteChecklistRequest(id));
        }
    }
}
