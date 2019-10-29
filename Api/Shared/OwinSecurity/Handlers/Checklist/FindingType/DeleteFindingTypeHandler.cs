using Ensco.Irma.Interfaces.Services.Oap;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.FindingType
{
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType;

    public class DeleteFindingTypeHandler : IRequestHandler<DeleteFindingTypeRequest, bool>
    {
        private IFindingTypeService FindingTypeService { get; set; }

        public DeleteFindingTypeHandler(IFindingTypeService frequencyTypeService)
        {
            FindingTypeService = frequencyTypeService;
        }

        Task<bool> IRequestHandler<DeleteFindingTypeRequest, bool>.Handle(DeleteFindingTypeRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var FindingType = FindingTypeService.Get(request.FindingTypeId);
                 
                FindingTypeService.Delete(FindingType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}