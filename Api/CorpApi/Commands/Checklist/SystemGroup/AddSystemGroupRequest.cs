using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SystemGroup
{
    public class AddSystemGroupRequest : IRequest<OapSystemGroup>
    {
        public AddSystemGroupRequest(OapSystemGroup systemGroup)
        {
            SystemGroup = systemGroup;
        }

        public OapSystemGroup SystemGroup { get; }
    }
}