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
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency;

    [RoutePrefix("oapfrequency")]
    public class OapFrequencyController : OapApiController
    {
        public OapFrequencyController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapFrequency> Get(int id)
        {
            return TryCatch<GetFrequencyRequest, OapFrequency>(new GetFrequencyRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapFrequency>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllFrequencyRequest, IEnumerable<OapFrequency>>(new GetAllFrequencyRequest(model.StartDate, model.EndDate));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapFrequency> AddFrequency([FromBody] OapFrequency list)
        {
            return TryCatch<AddFrequencyRequest, OapFrequency>(new AddFrequencyRequest(list));
        }

        [HttpPut]
        [Route("update")]
        public WebApiResult<bool> UpdateFrequency([FromBody] OapFrequency list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateFrequencyRequest, bool>(new UpdateFrequencyRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteFrequency(int id)
        {
            return TryCatch<DeleteFrequencyRequest, bool>(new DeleteFrequencyRequest(id));
        }
    }
}
