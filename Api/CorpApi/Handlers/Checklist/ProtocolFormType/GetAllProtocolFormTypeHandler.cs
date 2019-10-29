using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ProtocolFormType
{
    public class GetAllProtocolFormTypeHandler : IRequestHandler<GetAllProtocolFormTypeRequest, IEnumerable<OapProtocolFormType>>
    {
        private IOapProtocolFormTypeService Service { get; set; }

        public GetAllProtocolFormTypeHandler(IOapProtocolFormTypeService protocolFormTypeService)
        {
            Service = protocolFormTypeService;
        }

        Task<IEnumerable<OapProtocolFormType>> IRequestHandler<GetAllProtocolFormTypeRequest, IEnumerable<OapProtocolFormType>>.Handle(GetAllProtocolFormTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll(request.StartDate, request.EndDate);
            return Task.FromResult(cl);
        }
    }
}