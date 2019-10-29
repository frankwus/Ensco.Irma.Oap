using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ProtocolFormType
{
    public class UpdateProtocolFormTypeHandler : IRequestHandler<UpdateProtocolFormTypeRequest, bool>
    {
        private IOapProtocolFormTypeService ProtocolFormTypeService { get; set; }
         

        private IMapper Mapper { get; set;  }

        public UpdateProtocolFormTypeHandler(IOapProtocolFormTypeService protocolFormTypeService, IMapper mapper)
        {
            ProtocolFormTypeService = protocolFormTypeService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateProtocolFormTypeRequest, bool>.Handle(UpdateProtocolFormTypeRequest request, CancellationToken cancellationToken)
        {
            var existingProtocolFormType = ProtocolFormTypeService.Get(request.ProtocolFormType.Id);

            if (existingProtocolFormType == null)
            {
                throw new ApplicationException($"UpdateProtocolFormTypeHandler: ProtocolFormType with Id {request.ProtocolFormType.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.ProtocolFormType, existingProtocolFormType);

            using (var ts = new TransactionScope())
            {
                var updatedProtocolFormType = ProtocolFormTypeService.Update(existingProtocolFormType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}