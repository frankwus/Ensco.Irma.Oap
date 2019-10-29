using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType;

    [RoutePrefix("findingtype")]
    public class FindingTypeController : OapApiController
    {
        public FindingTypeController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<FindingType> Get(int id)
        {
            return TryCatch<GetFindingTypeRequest, FindingType>(new GetFindingTypeRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<FindingType>> GetAll()
        {
            return TryCatch<GetAllFindingTypeRequest, IEnumerable<FindingType>>(new GetAllFindingTypeRequest());
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<FindingType> AddFindingType([FromBody] FindingType list)
        {
            return TryCatch<AddFindingTypeRequest, FindingType>(new AddFindingTypeRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateFindingType([FromBody] FindingType list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateFindingTypeRequest, bool>(new UpdateFindingTypeRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteFindingType(int id)
        {
            return TryCatch<DeleteFindingTypeRequest, bool>(new DeleteFindingTypeRequest(id));
        }
    }
}
