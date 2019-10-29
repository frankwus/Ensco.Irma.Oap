using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Oap.Api.Common.ActionResults;
using Ensco.Irma.Oap.Api.Rig.Commands.DPA;
using Ensco.Irma.Oap.Common.Api.Controllers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ensco.Irma.Oap.Api.Rig.Controllers.Oap
{
    [RoutePrefix("dpa")]
    public class DPAController : OapApiController
    {
        public DPAController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [Route("{rigId}/all")]
        public WebApiResult<IEnumerable<DPA>> GetAllRigDPAs(int rigId)
        {
            return TryCatch<GetAllRigDPAsRequest, IEnumerable<DPA>>(new GetAllRigDPAsRequest(rigId));
        }
    }
}
