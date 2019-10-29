using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ProtocolQuestionHeader
{
    using Ensco.Irma.Extensions;

    public class GetAllOapProtocolQuestionHeaderHandler : IRequestHandler<GetAllOapProtocolQuestionHeaderRequest, IEnumerable<OapProtocolQuestionHeader>>
    {
        private IOapProtocolQuestionHeaderService Service { get; set; }

        public GetAllOapProtocolQuestionHeaderHandler(IOapProtocolQuestionHeaderService protocolQuestionHeaderService)
        {
            Service = protocolQuestionHeaderService;
        }

        Task<IEnumerable<OapProtocolQuestionHeader>> IRequestHandler<GetAllOapProtocolQuestionHeaderRequest, IEnumerable<OapProtocolQuestionHeader>>.Handle(GetAllOapProtocolQuestionHeaderRequest request, CancellationToken cancellationToken)
        {
            var list = Service.GetAll(request.StartDate, request.EndDate);

            return Task.FromResult(list);
        }
    }
}