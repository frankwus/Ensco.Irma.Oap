
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.People
{
    using Ensco.Irma.Models.Domain.Security;

    public class GetAllPeopleRequest : IRequest<IEnumerable<Person>>
    { 
        public GetAllPeopleRequest()
        { 
        }
    }
}