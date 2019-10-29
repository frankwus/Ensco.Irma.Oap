using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.ProtocolFormType
{
    public class GetProtocolFormTypeHandler : IRequestHandler<GetProtocolFormTypeRequest, OapProtocolFormType>
    {
        private IOapProtocolFormTypeService Service { get; set; }

        public GetProtocolFormTypeHandler(IOapProtocolFormTypeService protocolFormTypeService)
        {
            Service = protocolFormTypeService;
        }

        Task<OapProtocolFormType> IRequestHandler<GetProtocolFormTypeRequest, OapProtocolFormType>.Handle(GetProtocolFormTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.ProtocolFormTypeId);
            return Task.FromResult(cl);
        }
    }
}