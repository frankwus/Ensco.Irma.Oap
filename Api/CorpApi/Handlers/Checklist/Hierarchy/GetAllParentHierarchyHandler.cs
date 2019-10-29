using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Hierarchy;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Hierarchy
{
    public class GetAllParentHierarchyHandler : IRequestHandler<GetAllParentHierarchyRequest, IEnumerable<OapHierarchy>>
    {
        private IOapHierarchyService Service { get; set; }

        public GetAllParentHierarchyHandler(IOapHierarchyService HierarchyService)
        {
            Service = HierarchyService;
        }

        Task<IEnumerable<OapHierarchy>> IRequestHandler<GetAllParentHierarchyRequest, IEnumerable<OapHierarchy>>.Handle(GetAllParentHierarchyRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAllParentHierarchy(request.StartDate, request.EndDate);
            return Task.FromResult(cl);
        }
    }
}