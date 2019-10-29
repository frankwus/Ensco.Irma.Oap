using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.FrequencyType;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.FrequencyType
{
    public class UpdateFrequencyTypeHandler : IRequestHandler<UpdateFrequencyTypeRequest, bool>
    {
        private IOapFrequencyTypeService FrequencyTypeService { get; set; }
         

        private IMapper Mapper { get; set;  }

        public UpdateFrequencyTypeHandler(IOapFrequencyTypeService frequencyTypeService, IMapper mapper)
        {
            FrequencyTypeService = frequencyTypeService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateFrequencyTypeRequest, bool>.Handle(UpdateFrequencyTypeRequest request, CancellationToken cancellationToken)
        {
            var existingFrequencyType = FrequencyTypeService.Get(request.FrequencyType.Id);

            if (existingFrequencyType == null)
            {
                throw new ApplicationException($"UpdateFrequencyTypeHandler: FrequencyType with Id {request.FrequencyType.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.FrequencyType, existingFrequencyType);

            using (var ts = new TransactionScope())
            {
                var updatedFrequencyType = FrequencyTypeService.Update(existingFrequencyType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}