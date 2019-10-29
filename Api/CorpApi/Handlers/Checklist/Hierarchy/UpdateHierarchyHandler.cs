using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Hierarchy;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Hierarchy
{
    public class UpdateHierarchyHandler : IRequestHandler<UpdateHierarchyRequest, bool>
    {
        private IOapHierarchyService HierarchyService { get; set; }
         

        private IMapper Mapper { get; set;  }

        public UpdateHierarchyHandler(IOapHierarchyService hierarchyService, IMapper mapper)
        {
            HierarchyService = hierarchyService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateHierarchyRequest, bool>.Handle(UpdateHierarchyRequest request, CancellationToken cancellationToken)
        {
            var existingHierarchy = HierarchyService.Get(request.Hierarchy.Id);

            if (existingHierarchy == null)
            {
                throw new ApplicationException($"UpdateHierarchyHandler: Hierarchy with Id {request.Hierarchy.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.Hierarchy, existingHierarchy);

            using (var ts = new TransactionScope())
            {
                var updatedHierarchy = HierarchyService.Update(existingHierarchy);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}