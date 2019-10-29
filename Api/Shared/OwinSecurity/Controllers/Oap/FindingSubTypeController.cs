using System;
using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType;

    [RoutePrefix("findingsubtype")]
    public class FindingSubTypeController : OapApiController
    {
        public FindingSubTypeController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<FindingSubType> Get(int id)
        {
            return TryCatch<GetFindingSubTypeRequest, FindingSubType>(new GetFindingSubTypeRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<FindingSubType>> GetAll()
        {
            return TryCatch<GetAllFindingSubTypeRequest, IEnumerable<FindingSubType>>(new GetAllFindingSubTypeRequest());
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<FindingSubType> AddFindingSubType([FromBody] FindingSubType list)
        {
            return TryCatch<AddFindingSubTypeRequest, FindingSubType>(new AddFindingSubTypeRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateFindingSubType([FromBody] FindingSubType list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateFindingSubTypeRequest, bool>(new UpdateFindingSubTypeRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteFindingSubType(int id)
        {
            return TryCatch<DeleteFindingSubTypeRequest, bool>(new DeleteFindingSubTypeRequest(id));
        }
    }
}
