using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Hierarchy
{
    public class AddHierarchyRequest : IRequest<OapHierarchy>
    {
        public AddHierarchyRequest(OapHierarchy hierarchy)
        {
            Hierarchy = hierarchy;
        }

        public OapHierarchy Hierarchy { get;  }
    }
}