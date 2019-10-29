using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SystemGroup
{
    public class DeleteSystemGroupRequest : IRequest<bool>
    {
        public DeleteSystemGroupRequest(int systemGroupId)
        {
            SystemGroupId = systemGroupId;
        }

        public int SystemGroupId { get; }
    }
}