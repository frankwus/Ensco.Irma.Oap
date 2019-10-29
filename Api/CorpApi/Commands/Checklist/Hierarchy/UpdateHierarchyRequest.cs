using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Hierarchy
{
    public class UpdateHierarchyRequest : IRequest<bool>
    {
        public UpdateHierarchyRequest(OapHierarchy hierarchy)
        {
            Hierarchy = hierarchy;
        }

        public OapHierarchy Hierarchy { get;  }
    }
}