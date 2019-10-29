using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.FrequencyType;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.FrequencyType
{
    public class DeleteFrequencyTypeHandler : IRequestHandler<DeleteFrequencyTypeRequest, bool>
    {
        private IOapFrequencyTypeService FrequencyTypeService { get; set; }

        public DeleteFrequencyTypeHandler(IOapFrequencyTypeService frequencyTypeService)
        {
            FrequencyTypeService = frequencyTypeService;
        }

        Task<bool> IRequestHandler<DeleteFrequencyTypeRequest, bool>.Handle(DeleteFrequencyTypeRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var FrequencyType = FrequencyTypeService.Get(request.FrequencyTypeId);
                 
                FrequencyTypeService.Delete(FrequencyType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}