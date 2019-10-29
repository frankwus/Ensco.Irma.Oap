using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Reviewer;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Reviewer
{
    using Ensco.Irma.Extensions;

    public class UpdateChecklistReviewerHandler : IRequestHandler<UpdateChecklistReviewerRequest, bool>
    {
        private IOapChecklistReviewerService ChecklistReviewerService { get; set; }

        private IMapper Mapper { get; set;  }

        public UpdateChecklistReviewerHandler(IOapChecklistReviewerService checklistReviewerService, IMapper mapper)
        {
            ChecklistReviewerService = checklistReviewerService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistReviewerRequest, bool>.Handle(UpdateChecklistReviewerRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistReviewer = ChecklistReviewerService.Get(request.ChecklistReviewer.Id);

            if (existingChecklistReviewer == null)
            {
                throw new ApplicationException($"UpdateChecklistReviewerHandler: ChecklistReviewer with Id {request.ChecklistReviewer.Id} does not exist.");
            }
             
            //AutoMapper to Map the fields 
            Mapper.Map(request.ChecklistReviewer, existingChecklistReviewer);
             
            using (var ts = new TransactionScope())
            {
                var updatedChecklistReviewer = ChecklistReviewerService.Update(existingChecklistReviewer);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}