using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.FindingSubType
{
    public class DeleteFindingSubTypeHandler : IRequestHandler<DeleteFindingSubTypeRequest, bool>
    {
        private IFindingSubTypeService FindingSubTypeService { get; set; }

        public DeleteFindingSubTypeHandler(IFindingSubTypeService frequencyTypeService)
        {
            FindingSubTypeService = frequencyTypeService;
        }

        Task<bool> IRequestHandler<DeleteFindingSubTypeRequest, bool>.Handle(DeleteFindingSubTypeRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var FindingSubType = FindingSubTypeService.Get(request.FindingSubTypeId);
                 
                FindingSubTypeService.Delete(FindingSubType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}