using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.People
{
    using Ensco.Irma.Models.Domain.Security;

    public class GetPersonRequest : IRequest<Person>
    { 
        public GetPersonRequest(int personId)
        {
            PersonId = personId;
        }

        public int PersonId {get; set;}
    }
}