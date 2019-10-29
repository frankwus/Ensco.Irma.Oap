using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.ProtocolQuestionHeader
{
    using Ensco.Irma.Extensions;

    public class GetOapProtocolQuestionHeaderHandler : IRequestHandler<GetOapProtocolQuestionHeaderRequest, OapProtocolQuestionHeader>
    {
        private IOapProtocolQuestionHeaderService Service { get; set; }

        public GetOapProtocolQuestionHeaderHandler(IOapProtocolQuestionHeaderService ProtocolQuestionHeaderService)
        {
            Service = ProtocolQuestionHeaderService;
        }

        Task<OapProtocolQuestionHeader> IRequestHandler<GetOapProtocolQuestionHeaderRequest, OapProtocolQuestionHeader>.Handle(GetOapProtocolQuestionHeaderRequest request, CancellationToken cancellationToken)
        {
            var c = Service.Get(request.QuestionHeaderId);             

            return Task.FromResult(c);
        }
    }
}