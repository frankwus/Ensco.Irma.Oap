using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Frequency
{
    public class UpdateFrequencyHandler : IRequestHandler<UpdateFrequencyRequest, bool>
    {
        private IOapFrequencyService FrequencyService { get; set; }
         

        private IMapper Mapper { get; set;  }

        public UpdateFrequencyHandler(IOapFrequencyService frequencyService, IMapper mapper)
        {
            FrequencyService = frequencyService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateFrequencyRequest, bool>.Handle(UpdateFrequencyRequest request, CancellationToken cancellationToken)
        {
            var existingFrequency = FrequencyService.Get(request.Frequency.Id);

            if (existingFrequency == null)
            {
                throw new ApplicationException($"UpdateFrequencyHandler: Frequency with Id {request.Frequency.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.Frequency, existingFrequency);

            using (var ts = new TransactionScope())
            {
                var updatedFrequency = FrequencyService.Update(existingFrequency);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}