using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.System
{
    public class AddSystemRequest : IRequest<OapSystem>
    {
        public AddSystemRequest(OapSystem system)
        {
            System = system;
        }

        public OapSystem System { get; }
    }
}