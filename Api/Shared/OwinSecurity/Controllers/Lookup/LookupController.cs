using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Controllers.Lookup
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using System.Web.Http;
    using MediatR;
    using Ensco.Irma.Models.Domain.IRMA;
    using Ensco.Irma.Oap.Api.Common.Commands.Lookup;

    [RoutePrefix("lookup")]
    public class LookupController : OapApiController
    {
        public LookupController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }
 

        [HttpGet]
        [Route("criticality/all")]
        public WebApiResult<IEnumerable<Criticality>> GetAllCriticality()
        {
            return TryCatch<GetAllCriticalityRequest, IEnumerable<Criticality>>(new GetAllCriticalityRequest());
        }
    }
}
