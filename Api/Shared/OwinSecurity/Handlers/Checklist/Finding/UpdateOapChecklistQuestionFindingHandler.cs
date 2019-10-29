using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Finding
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;

    public class UpdateOapChecklistQuestionFindingHandler : IRequestHandler<UpdateOapChecklistQuestionFindingRequest, bool>
    {
        private IRigOapChecklistQuestionFindingService FindingService { get; set; }
         
        private IMapper Mapper { get; set;  }

        public UpdateOapChecklistQuestionFindingHandler(IRigOapChecklistQuestionFindingService findingService, IMapper mapper)
        {
            FindingService = findingService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateOapChecklistQuestionFindingRequest, bool>.Handle(UpdateOapChecklistQuestionFindingRequest request, CancellationToken cancellationToken)
        {
            var existingFinding = FindingService.Get(request.Finding.Id);

            if (existingFinding == null)
            {
                throw new ApplicationException($"UpdateFindingHandler: Finding with Id {request.Finding.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.Finding, existingFinding);

            using (var ts = new TransactionScope())
            {
                var updatedFinding = FindingService.Update(existingFinding);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}