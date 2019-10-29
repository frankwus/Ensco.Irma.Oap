using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Hierarchy;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Hierarchy
{
    public class DeleteHierarchyHandler : IRequestHandler<DeleteHierarchyRequest, bool>
    {
        private IOapHierarchyService HierarchyService { get; set; }

        public DeleteHierarchyHandler(IOapHierarchyService hierarchyService)
        {
            HierarchyService = hierarchyService;
        }

        Task<bool> IRequestHandler<DeleteHierarchyRequest, bool>.Handle(DeleteHierarchyRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var hierarchy = HierarchyService.Get(request.HierarchyId);
                 
                HierarchyService.Delete(hierarchy);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}