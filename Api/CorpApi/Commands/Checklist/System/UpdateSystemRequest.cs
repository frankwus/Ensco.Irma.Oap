using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.System
{
    public class UpdateSystemRequest : IRequest<bool>
    {
        public UpdateSystemRequest(OapSystem system)
        {
            System = system;
        }

        public OapSystem System { get; }
    }
}