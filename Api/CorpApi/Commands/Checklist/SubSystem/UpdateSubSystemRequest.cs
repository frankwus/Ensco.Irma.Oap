using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SubSystem
{
    public class UpdateSubSystemRequest : IRequest<bool>
    {
        public UpdateSubSystemRequest(OapSubSystem subSystem)
        {
            SubSystem = subSystem;
        }

        public OapSubSystem SubSystem { get; }
    }
}