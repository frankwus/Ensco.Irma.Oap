using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency;
using Ensco.Irma.Services.Oap;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Frequency
{
    public class AddFrequencyHandler : IRequestHandler<AddFrequencyRequest, OapFrequency>
    {
        private IOapFrequencyService FrequencyService { get; set; }

        public AddFrequencyHandler(IOapFrequencyService frequencyTypeService)
        {
            FrequencyService = frequencyTypeService;
        }

        Task<OapFrequency> IRequestHandler<AddFrequencyRequest, OapFrequency>.Handle(AddFrequencyRequest request, CancellationToken cancellationToken)
        {
            var existingFrequency = FrequencyService.GetByName(request.Frequency.Name);
            if (existingFrequency  != null)
            {
                return Task.FromResult(existingFrequency);
            }

            int newFrequencyId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.Frequency.StartDateTime.IsDefaultMin() || request.Frequency.StartDateTime.IsDefaultMax())
                {
                    request.Frequency.StartDateTime = DateTime.Now;
                }

                if (request.Frequency.EndDateTime.IsDefaultMin())
                {
                    request.Frequency.EndDateTime = DateTime.MaxValue;
                }

                newFrequencyId = FrequencyService.Add(request.Frequency); 
                
                ts.Complete();
            }
            return Task.FromResult(FrequencyService.Get(newFrequencyId));
        }

         
    }
}