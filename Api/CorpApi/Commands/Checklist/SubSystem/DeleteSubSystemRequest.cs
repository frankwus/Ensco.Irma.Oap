using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SubSystem
{
    public class DeleteSubSystemRequest : IRequest<bool>
    {
        public DeleteSubSystemRequest(int subSystemId)
        {
            SubSystemId = subSystemId;
        }

        public int SubSystemId { get; }
    }
}