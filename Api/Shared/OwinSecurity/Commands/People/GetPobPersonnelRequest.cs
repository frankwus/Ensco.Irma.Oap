
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.People
{
    using Ensco.Irma.Models.Domain.IRMA;
    using Ensco.Irma.Models.Domain.Security;

    public class GetPobPersonnelRequest : IRequest<int?>
    { 
        public GetPobPersonnelRequest(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}