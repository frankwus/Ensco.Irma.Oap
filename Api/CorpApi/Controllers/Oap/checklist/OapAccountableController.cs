using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Oap.Api.Common.ActionResults;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Accountable;
using Ensco.Irma.Oap.Common.Api.Controllers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap.checklist
{
    [RoutePrefix("oapaccountable")]
    public class OapAccountableController : OapApiController
    {
        public OapAccountableController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }


        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapAccountable>> GetAll()
        {
            return TryCatch<GetAllAccountablesRequest, IEnumerable<OapAccountable>>(new GetAllAccountablesRequest());
        }

        [HttpGet]
        [Route("getbypositionids")]
        public WebApiResult<IEnumerable<OapAccountable>> GetByPositionIds(params int[] ids)
        {
            return TryCatch<GetAccountablesByPositionIdsRequest, IEnumerable<OapAccountable>>(new GetAccountablesByPositionIdsRequest(ids));
        }

        //[HttpGet]
        //[Route("{userId}")]
        //public WebApiResult<IEnumerable<OapAccountable>> GetByUserId(int userId)
        //{
        //    return TryCatch<GetAccountableByUserIdRequest, IEnumerable<OapAccountable>(new GetAccountableByUserIdRequest(userId));
        //}

    }
}