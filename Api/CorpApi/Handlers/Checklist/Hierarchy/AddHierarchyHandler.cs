using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Hierarchy;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Hierarchy
{
    public class AddHierarchyHandler : IRequestHandler<AddHierarchyRequest, OapHierarchy>
    {
        private IOapHierarchyService HierarchyService { get; set; }

        public AddHierarchyHandler(IOapHierarchyService hierarchyService)
        {
            HierarchyService = hierarchyService;
        }

        Task<OapHierarchy> IRequestHandler<AddHierarchyRequest, OapHierarchy>.Handle(AddHierarchyRequest request, CancellationToken cancellationToken)
        {
            var existingHierarchy = HierarchyService.GetByName(request.Hierarchy.Name);
            if (existingHierarchy  != null)
            {
                return Task.FromResult(existingHierarchy);
            }

            int newHierarchyId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.Hierarchy.StartDateTime.IsDefaultMin() || request.Hierarchy.StartDateTime.IsDefaultMax())
                {
                    request.Hierarchy.StartDateTime = DateTime.Now;
                }

                if (request.Hierarchy.EndDateTime.IsDefaultMin())
                {
                    request.Hierarchy.EndDateTime = DateTime.MaxValue;
                }

                newHierarchyId = HierarchyService.Add(request.Hierarchy); 
                
                ts.Complete();
            }
            return Task.FromResult(HierarchyService.Get(newHierarchyId));
        }

         
    }
}