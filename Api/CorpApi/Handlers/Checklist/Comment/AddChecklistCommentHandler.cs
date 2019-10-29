using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Comment
{
    using Ensco.Irma.Extensions;

    public class AddChecklistCommentHandler : IRequestHandler<AddChecklistCommentRequest, OapChecklistComment>
    {
        private IOapChecklistCommentService ChecklistCommentService { get; set; }

        public AddChecklistCommentHandler(IOapChecklistCommentService checklistCommentService)
        {
            ChecklistCommentService = checklistCommentService;
        }

        Task<OapChecklistComment> IRequestHandler<AddChecklistCommentRequest, OapChecklistComment>.Handle(AddChecklistCommentRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistComment = ChecklistCommentService.Get(request.ChecklistComment.Id);
            if (existingChecklistComment  != null)
            {
                return Task.FromResult(existingChecklistComment);
            }

            int newChecklistCommentId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.ChecklistComment.StartDateTime.IsDefaultMin() || request.ChecklistComment.StartDateTime.IsDefaultMax())
                {
                    request.ChecklistComment.StartDateTime = DateTime.Now;
                }

                if (request.ChecklistComment.EndDateTime.IsDefaultMin())
                {
                    request.ChecklistComment.EndDateTime = DateTime.MaxValue;
                }

                newChecklistCommentId = ChecklistCommentService.Add(request.ChecklistComment); 
                
                ts.Complete();
            }
            return Task.FromResult(ChecklistCommentService.Get(newChecklistCommentId));
        }

         
    }
}