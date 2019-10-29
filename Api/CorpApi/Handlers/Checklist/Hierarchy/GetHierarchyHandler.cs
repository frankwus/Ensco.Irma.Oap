using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Hierarchy;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Hierarchy
{
    public class GetHierarchyHandler : IRequestHandler<GetHierarchyRequest, OapHierarchy>
    {
        private IOapHierarchyService Service { get; set; }

        public GetHierarchyHandler(IOapHierarchyService hierarchyService)
        {
            Service = hierarchyService;
        }

        Task<OapHierarchy> IRequestHandler<GetHierarchyRequest, OapHierarchy>.Handle(GetHierarchyRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.HierarchyId);
            return Task.FromResult(cl);
        }
    }
}