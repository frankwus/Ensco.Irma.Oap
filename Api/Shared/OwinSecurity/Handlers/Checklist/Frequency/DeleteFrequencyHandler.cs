using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Frequency
{
    public class DeleteFrequencyHandler : IRequestHandler<DeleteFrequencyRequest, bool>
    {
        private IOapFrequencyService FrequencyService { get; set; }

        public DeleteFrequencyHandler(IOapFrequencyService frequencyService)
        {
            FrequencyService = frequencyService;
        }

        Task<bool> IRequestHandler<DeleteFrequencyRequest, bool>.Handle(DeleteFrequencyRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var Frequency = FrequencyService.Get(request.FrequencyId);
                 
                FrequencyService.Delete(Frequency);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}