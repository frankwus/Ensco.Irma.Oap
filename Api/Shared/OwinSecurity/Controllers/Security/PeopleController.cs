using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Controllers.Security
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Models.Domain.Security;
    using Ensco.Irma.Oap.Api.Common.Commands.People;
    using Ensco.Irma.Models.Domain.IRMA;

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

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<Person>> GetAll()
        {
            return TryCatch<GetAllPeopleRequest, IEnumerable<Person>>(new GetAllPeopleRequest());
        }

        [HttpGet]
        [Route("gettourid/{userId}")]
        public WebApiResult<int?> GetTourId(int userId)
        {
            return TryCatch<GetPobPersonnelRequest, int?>(new GetPobPersonnelRequest(userId));
        }
    }
}
