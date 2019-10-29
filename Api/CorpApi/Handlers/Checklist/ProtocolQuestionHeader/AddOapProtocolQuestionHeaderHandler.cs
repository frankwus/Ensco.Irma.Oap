using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ProtocolQuestionHeader
{
    using Ensco.Irma.Extensions;

    public class AddOapProtocolQuestionHeaderHandler : IRequestHandler<AddOapProtocolQuestionHeaderRequest, OapProtocolQuestionHeader>
    {
        private IOapProtocolQuestionHeaderService ProtocolQuestionHeaderService { get; set; }

        public AddOapProtocolQuestionHeaderHandler(IOapProtocolQuestionHeaderService protocolQuestionHeaderService)
        {
           ProtocolQuestionHeaderService = protocolQuestionHeaderService;
        }

        Task<OapProtocolQuestionHeader> IRequestHandler<AddOapProtocolQuestionHeaderRequest, OapProtocolQuestionHeader>.Handle(AddOapProtocolQuestionHeaderRequest request, CancellationToken cancellationToken)
        {
            if (request.Header?.OapChecklistQuestionId == null)
            {
                return Task.FromResult(new OapProtocolQuestionHeader());
            }

            var existingOapProtocolQuestionHeader = ProtocolQuestionHeaderService.GetBySection(request.Header.OapChecklistQuestionId.Value, request.Header.Section);
            if (existingOapProtocolQuestionHeader != null)
            {
                return Task.FromResult(existingOapProtocolQuestionHeader);
            }

            int newOapProtocolQuestionHeaderId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.Header.StartDateTime.IsDefaultMin() || request.Header.StartDateTime.IsDefaultMax())
                {
                    request.Header.StartDateTime = DateTime.Now;
                }

                if (request.Header.EndDateTime.IsDefaultMin())
                {
                    request.Header.EndDateTime = DateTime.MaxValue;
                }

                newOapProtocolQuestionHeaderId = ProtocolQuestionHeaderService.Add(request.Header); 
                
                ts.Complete();
            }
            return Task.FromResult(ProtocolQuestionHeaderService.Get(newOapProtocolQuestionHeaderId));
        }

         
    }
}