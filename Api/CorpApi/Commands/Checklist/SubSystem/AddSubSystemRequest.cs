using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SubSystem
{
    public class AddSubSystemRequest : IRequest<OapSubSystem>
    {
        public AddSubSystemRequest(OapSubSystem subSystem)
        {
            SubSystem = subSystem;
        }

        public OapSubSystem SubSystem { get; }
    }
}