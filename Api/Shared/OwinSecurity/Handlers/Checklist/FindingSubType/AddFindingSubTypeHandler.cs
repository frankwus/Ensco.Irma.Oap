
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.FindingSubType
{
    using Ensco.Irma.Extensions;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Interfaces.Services.Oap;

    public class AddFindingSubTypeHandler : IRequestHandler<AddFindingSubTypeRequest, FindingSubType>
    {
        private IFindingSubTypeService FindingSubTypeService { get; set; }

        public AddFindingSubTypeHandler(IFindingSubTypeService findingService)
        {
            FindingSubTypeService = findingService;
        }

        Task<FindingSubType> IRequestHandler<AddFindingSubTypeRequest, FindingSubType>.Handle(AddFindingSubTypeRequest request, CancellationToken cancellationToken)
        {
            var existingFindingSubType = FindingSubTypeService.Get(request.FindingSubType.Id);
            if (existingFindingSubType  != null)
            {
                return Task.FromResult(existingFindingSubType);
            }

            int newFindingSubTypeId = 0;
            using (var ts = new TransactionScope())
            {
                newFindingSubTypeId = FindingSubTypeService.Add(request.FindingSubType); 
                
                ts.Complete();
            }
            return Task.FromResult(FindingSubTypeService.Get(newFindingSubTypeId));
        }
    }
}