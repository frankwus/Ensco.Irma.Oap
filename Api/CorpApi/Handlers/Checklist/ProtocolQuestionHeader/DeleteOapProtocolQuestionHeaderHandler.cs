using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ProtocolQuestionHeader
{
    public class DeleteOapProtocolQuestionHeaderHandler : IRequestHandler<DeleteOapProtocolQuestionHeaderRequest, bool>
    {
        private IOapProtocolQuestionHeaderService ProtocolQuestionHeaderService { get; set; }

        public DeleteOapProtocolQuestionHeaderHandler(IOapProtocolQuestionHeaderService protocolQuestionHeaderService)
        {
            ProtocolQuestionHeaderService = protocolQuestionHeaderService;
        }

        Task<bool> IRequestHandler<DeleteOapProtocolQuestionHeaderRequest, bool>.Handle(DeleteOapProtocolQuestionHeaderRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ProtocolQuestionHeader = ProtocolQuestionHeaderService.Get(request.QuestionHeaderId);
                 
                ProtocolQuestionHeaderService.Delete(ProtocolQuestionHeader);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}