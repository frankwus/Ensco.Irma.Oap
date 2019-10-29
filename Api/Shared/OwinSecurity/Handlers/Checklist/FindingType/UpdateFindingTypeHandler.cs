using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Corp.Api.Handlers.Checklist.FindingType
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType;

    public class UpdateFindingTypeHandler : IRequestHandler<UpdateFindingTypeRequest, bool>
    {
        private IFindingTypeService FindingTypeService { get; set; }
         
        private IMapper Mapper { get; set;  }

        public UpdateFindingTypeHandler(IFindingTypeService findingTypeService, IMapper mapper)
        {
            FindingTypeService = findingTypeService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateFindingTypeRequest, bool>.Handle(UpdateFindingTypeRequest request, CancellationToken cancellationToken)
        {
            var existingFindingType = FindingTypeService.Get(request.FindingType.Id);

            if (existingFindingType == null)
            {
                throw new ApplicationException($"UpdateFindingTypeHandler: FindingType with Id {request.FindingType.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.FindingType, existingFindingType);

            using (var ts = new TransactionScope())
            {
                var updatedFindingType = FindingTypeService.Update(existingFindingType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}