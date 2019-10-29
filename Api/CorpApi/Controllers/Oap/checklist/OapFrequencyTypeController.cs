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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.FrequencyType;

    [RoutePrefix("oapfrequencytype")]
    public class OapFrequencyTypeController : OapApiController
    {
        public OapFrequencyTypeController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapFrequencyType> Get(int id)
        {
            return TryCatch<GetFrequencyTypeRequest, OapFrequencyType>(new GetFrequencyTypeRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapFrequencyType>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllFrequencyTypeRequest, IEnumerable<OapFrequencyType>>(new GetAllFrequencyTypeRequest(model.StartDate, model.EndDate));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapFrequencyType> AddFrequencyType([FromBody] OapFrequencyType list)
        {
            return TryCatch<AddFrequencyTypeRequest, OapFrequencyType>(new AddFrequencyTypeRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateFrequencyType([FromBody] OapFrequencyType list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateFrequencyTypeRequest, bool>(new UpdateFrequencyTypeRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteFrequencyType(int id)
        {
            return TryCatch<DeleteFrequencyTypeRequest, bool>(new DeleteFrequencyTypeRequest(id));
        }
    }
}
