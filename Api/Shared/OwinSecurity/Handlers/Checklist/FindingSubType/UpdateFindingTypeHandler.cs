using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.FindingSubType
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType;

    public class UpdateFindingSubTypeHandler : IRequestHandler<UpdateFindingSubTypeRequest, bool>
    {
        private IFindingSubTypeService FindingSubTypeService { get; set; }
         
        private IMapper Mapper { get; set;  }

        public UpdateFindingSubTypeHandler(IFindingSubTypeService findingSubTypeService, IMapper mapper)
        {
            FindingSubTypeService = findingSubTypeService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateFindingSubTypeRequest, bool>.Handle(UpdateFindingSubTypeRequest request, CancellationToken cancellationToken)
        {
            var existingFindingSubType = FindingSubTypeService.Get(request.FindingSubType.Id);

            if (existingFindingSubType == null)
            {
                throw new ApplicationException($"UpdateFindingSubTypeHandler: FindingSubType with Id {request.FindingSubType.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.FindingSubType, existingFindingSubType);

            using (var ts = new TransactionScope())
            {
                var updatedFindingSubType = FindingSubTypeService.Update(existingFindingSubType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}