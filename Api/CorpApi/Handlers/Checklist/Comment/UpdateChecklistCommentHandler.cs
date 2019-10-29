using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Comment
{
    using Ensco.Irma.Extensions;

    public class UpdateChecklistCommentHandler : IRequestHandler<UpdateChecklistCommentRequest, bool>
    {
        private IOapChecklistCommentService ChecklistCommentService { get; set; }

        private IMapper Mapper { get; set;  }

        public UpdateChecklistCommentHandler(IOapChecklistCommentService checklistCommentService, IMapper mapper)
        {
            ChecklistCommentService = checklistCommentService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistCommentRequest, bool>.Handle(UpdateChecklistCommentRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistComment = ChecklistCommentService.Get(request.ChecklistComment.Id);

            if (existingChecklistComment == null)
            {
                throw new ApplicationException($"UpdateChecklistCommentHandler: ChecklistComment with Id {request.ChecklistComment.Id} does not exist.");
            }
             
            //AutoMapper to Map the fields 
            Mapper.Map(request.ChecklistComment, existingChecklistComment);
             
            using (var ts = new TransactionScope())
            {
                var updatedChecklistComment = ChecklistCommentService.Update(existingChecklistComment);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}