using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.System
{
    public class DeleteSystemRequest : IRequest<bool>
    {
        public DeleteSystemRequest(int systemId)
        {
            SystemId = systemId;
        }

        public int SystemId { get; }
    }
}