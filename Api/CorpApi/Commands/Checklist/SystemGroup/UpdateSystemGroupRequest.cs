using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SystemGroup
{
    public class UpdateSystemGroupRequest : IRequest<bool>
    {
        public UpdateSystemGroupRequest(OapSystemGroup systemGroup)
        {
            SystemGroup = systemGroup;
        }

        public OapSystemGroup SystemGroup { get; }
    }
}