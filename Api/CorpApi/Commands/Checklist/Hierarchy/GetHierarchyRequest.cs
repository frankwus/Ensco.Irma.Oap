using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Hierarchy
{
    public class GetHierarchyRequest : IRequest<OapHierarchy>
    { 
        public GetHierarchyRequest(int hierarchyId)
        {
            HierarchyId = hierarchyId;
        }

        public int HierarchyId {get; set;}
    }
}