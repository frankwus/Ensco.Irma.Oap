
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Finding
{
    using Ensco.Irma.Extensions;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Interfaces.Services.Oap;

    public class AddOapChecklistQuestionFindingHandler : IRequestHandler<AddOapChecklistQuestionFindingRequest, RigOapChecklistQuestionFinding>
    {
        private IRigOapChecklistQuestionFindingService FindingService { get; set; }

        public AddOapChecklistQuestionFindingHandler(IRigOapChecklistQuestionFindingService findingService)
        {
            FindingService = findingService;
        }

        Task<RigOapChecklistQuestionFinding> IRequestHandler<AddOapChecklistQuestionFindingRequest, RigOapChecklistQuestionFinding>.Handle(AddOapChecklistQuestionFindingRequest request, CancellationToken cancellationToken)
        {
            var existingFinding = FindingService.Get(request.Finding.Id);
            if (existingFinding  != null)
            {
                return Task.FromResult(existingFinding);
            }

            Guid newFindingId = Guid.Empty;
            using (var ts = new TransactionScope())
            {
                newFindingId = FindingService.Add(request.Finding); 
                
                ts.Complete();
            }
            return Task.FromResult(FindingService.Get(newFindingId));
        }
    }
}