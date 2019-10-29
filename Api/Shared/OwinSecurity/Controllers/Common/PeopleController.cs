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
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Models.Domain.Security;
    using Ensco.Irma.Oap.Api.Common.Commands.Common.People;

    [RoutePrefix("people")]
    public class PeopleController : OapApiController
    {
        public PeopleController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<Person> Get(int id)
        {
            return TryCatch<GetPersonRequest, Person>(new GetPersonRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<Person>> GetAll()
        {
            return TryCatch<GetAllPeopleRequest, IEnumerable<Person>>(new GetAllPeopleRequest());
        }
    }
}
