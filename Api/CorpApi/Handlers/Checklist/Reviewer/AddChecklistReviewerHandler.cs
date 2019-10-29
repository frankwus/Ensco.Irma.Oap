using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Reviewer;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Reviewer
{
    using Ensco.Irma.Extensions;

    public class AddChecklistReviewerHandler : IRequestHandler<AddChecklistReviewerRequest, OapChecklistReviewer>
    {
        private IOapChecklistReviewerService ChecklistReviewerService { get; set; }

        public AddChecklistReviewerHandler(IOapChecklistReviewerService checklistReviewerService)
        {
            ChecklistReviewerService = checklistReviewerService;
        }

        Task<OapChecklistReviewer> IRequestHandler<AddChecklistReviewerRequest, OapChecklistReviewer>.Handle(AddChecklistReviewerRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistReviewer = ChecklistReviewerService.Get(request.ChecklistReviewer.Id);
            if (existingChecklistReviewer  != null)
            {
                return Task.FromResult(existingChecklistReviewer);
            }

            int newChecklistReviewerId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.ChecklistReviewer.StartDateTime.IsDefaultMin() || request.ChecklistReviewer.StartDateTime.IsDefaultMax())
                {
                    request.ChecklistReviewer.StartDateTime = DateTime.Now;
                }

                if (request.ChecklistReviewer.EndDateTime.IsDefaultMin())
                {
                    request.ChecklistReviewer.EndDateTime = DateTime.MaxValue;
                }

                newChecklistReviewerId = ChecklistReviewerService.Add(request.ChecklistReviewer); 
                
                ts.Complete();
            }
            return Task.FromResult(ChecklistReviewerService.Get(newChecklistReviewerId));
        }

         
    }
}