using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ProtocolFormType
{
    public class DeleteProtocolFormTypeHandler : IRequestHandler<DeleteProtocolFormTypeRequest, bool>
    {
        private IOapProtocolFormTypeService ProtocolFormTypeService { get; set; }

        public DeleteProtocolFormTypeHandler(IOapProtocolFormTypeService protocolFormTypeService)
        {
            ProtocolFormTypeService = protocolFormTypeService;
        }

        Task<bool> IRequestHandler<DeleteProtocolFormTypeRequest, bool>.Handle(DeleteProtocolFormTypeRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ProtocolFormType = ProtocolFormTypeService.Get(request.ProtocolFormTypeId);
                 
                ProtocolFormTypeService.Delete(ProtocolFormType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}