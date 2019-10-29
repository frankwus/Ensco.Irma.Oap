
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Corp.Api.Handlers.Checklist.FindingType
{
    using Ensco.Irma.Extensions;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Interfaces.Services.Oap;

    public class AddFindingTypeHandler : IRequestHandler<AddFindingTypeRequest, FindingType>
    {
        private IFindingTypeService FindingTypeService { get; set; }

        public AddFindingTypeHandler(IFindingTypeService findingService)
        {
            FindingTypeService = findingService;
        }

        Task<FindingType> IRequestHandler<AddFindingTypeRequest, FindingType>.Handle(AddFindingTypeRequest request, CancellationToken cancellationToken)
        {
            var existingFindingType = FindingTypeService.Get(request.FindingType.Id);
            if (existingFindingType  != null)
            {
                return Task.FromResult(existingFindingType);
            }

            int newFindingTypeId = 0;
            using (var ts = new TransactionScope())
            {
                newFindingTypeId = FindingTypeService.Add(request.FindingType); 
                
                ts.Complete();
            }
            return Task.FromResult(FindingTypeService.Get(newFindingTypeId));
        }
    }
}