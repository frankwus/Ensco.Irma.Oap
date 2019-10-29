using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ProtocolFormType
{
    public class AddProtocolFormTypeHandler : IRequestHandler<AddProtocolFormTypeRequest, OapProtocolFormType>
    {
        private IOapProtocolFormTypeService ProtocolFormTypeService { get; set; }

        public AddProtocolFormTypeHandler(IOapProtocolFormTypeService protocolFormTypeService)
        {
            ProtocolFormTypeService = protocolFormTypeService;
        }

        Task<OapProtocolFormType> IRequestHandler<AddProtocolFormTypeRequest, OapProtocolFormType>.Handle(AddProtocolFormTypeRequest request, CancellationToken cancellationToken)
        {
            var existingProtocolFormType = ProtocolFormTypeService.GetByName(request.ProtocolFormType.Name);
            if (existingProtocolFormType  != null)
            {
                return Task.FromResult(existingProtocolFormType);
            }

            int newProtocolFormTypeId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.ProtocolFormType.StartDateTime.IsDefaultMin() || request.ProtocolFormType.StartDateTime.IsDefaultMax())
                {
                    request.ProtocolFormType.StartDateTime = DateTime.Now;
                }

                if (request.ProtocolFormType.EndDateTime.IsDefaultMin())
                {
                    request.ProtocolFormType.EndDateTime = DateTime.MaxValue;
                }

                newProtocolFormTypeId = ProtocolFormTypeService.Add(request.ProtocolFormType); 
                
                ts.Complete();
            }
            return Task.FromResult(ProtocolFormTypeService.Get(newProtocolFormTypeId));
        }

         
    }
}