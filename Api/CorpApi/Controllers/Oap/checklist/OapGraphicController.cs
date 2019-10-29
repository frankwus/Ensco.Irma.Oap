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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Graphic;

    [RoutePrefix("oapgraphic")]
    public class OapGraphicController : OapApiController
    {
        public OapGraphicController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapGraphic> Get(int id)
        {
            return TryCatch<GetGraphicRequest, OapGraphic>(new GetGraphicRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapGraphic>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllGraphicRequest, IEnumerable<OapGraphic>>(new GetAllGraphicRequest(model.StartDate, model.EndDate));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapGraphic> AddGraphic([FromBody] OapGraphic list)
        {
            return TryCatch<AddGraphicRequest, OapGraphic>(new AddGraphicRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateGraphic([FromBody] OapGraphic list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateGraphicRequest, bool>(new UpdateGraphicRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteGraphic(int id)
        {
            return TryCatch<DeleteGraphicRequest, bool>(new DeleteGraphicRequest(id));
        }
    }
}
