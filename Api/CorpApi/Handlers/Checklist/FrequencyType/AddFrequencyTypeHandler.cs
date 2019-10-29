using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.FrequencyType;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.FrequencyType
{
    public class AddFrequencyTypeHandler : IRequestHandler<AddFrequencyTypeRequest, OapFrequencyType>
    {
        private IOapFrequencyTypeService FrequencyTypeService { get; set; }

        public AddFrequencyTypeHandler(IOapFrequencyTypeService frequencyTypeService)
        {
            FrequencyTypeService = frequencyTypeService;
        }

        Task<OapFrequencyType> IRequestHandler<AddFrequencyTypeRequest, OapFrequencyType>.Handle(AddFrequencyTypeRequest request, CancellationToken cancellationToken)
        {
            var existingFrequencyType = FrequencyTypeService.GetByName(request.FrequencyType.Name);
            if (existingFrequencyType  != null)
            {
                return Task.FromResult(existingFrequencyType);
            }

            int newFrequencyTypeId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.FrequencyType.StartDateTime.IsDefaultMin() || request.FrequencyType.StartDateTime.IsDefaultMax())
                {
                    request.FrequencyType.StartDateTime = DateTime.Now;
                }

                if (request.FrequencyType.EndDateTime.IsDefaultMin())
                {
                    request.FrequencyType.EndDateTime = DateTime.MaxValue;
                }

                newFrequencyTypeId = FrequencyTypeService.Add(request.FrequencyType); 
                
                ts.Complete();
            }
            return Task.FromResult(FrequencyTypeService.Get(newFrequencyTypeId));
        }

         
    }
}