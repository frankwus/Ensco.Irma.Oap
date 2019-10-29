using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ProtocolQuestionHeader
{
    using Ensco.Irma.Extensions;

    public class UpdateOapProtocolQuestionHeaderHandler : IRequestHandler<UpdateOapProtocolQuestionHeaderRequest, bool>
    {
        private IOapProtocolQuestionHeaderService ProtocolQuestionHeaderService { get; set; }

        private IMapper Mapper { get; set;  }

        public UpdateOapProtocolQuestionHeaderHandler(IOapProtocolQuestionHeaderService protocolQuestionHeaderService, IMapper mapper)
        {
            ProtocolQuestionHeaderService = protocolQuestionHeaderService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateOapProtocolQuestionHeaderRequest, bool>.Handle(UpdateOapProtocolQuestionHeaderRequest request, CancellationToken cancellationToken)
        {
            var existingOapProtocolQuestionHeader = ProtocolQuestionHeaderService.Get(request.QuestionHeader.Id);

            if (existingOapProtocolQuestionHeader == null)
            {
                throw new ApplicationException($"UpdateOapProtocolQuestionHeaderHandler: OapProtocolQuestionHeader with Id {request.QuestionHeader.Id} does not exist.");
            }
             
            //AutoMapper to Map the fields 
            Mapper.Map(request.QuestionHeader, existingOapProtocolQuestionHeader);
             
            using (var ts = new TransactionScope())
            {
                var updatedOapProtocolQuestionHeader = ProtocolQuestionHeaderService.Update(existingOapProtocolQuestionHeader);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}