using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class AddRigOapChecklistQuestionCommentHandler : IRequestHandler<AddRigOapChecklistQuestionCommentRequest, RigOapChecklistQuestionComment>
    {
        private IRigOapChecklistQuestionCommentService RigOapChecklistQuestionCommentService { get; set; }


        public AddRigOapChecklistQuestionCommentHandler(IRigOapChecklistQuestionCommentService rigOapChecklistQuestionCommentService)
        {
            RigOapChecklistQuestionCommentService = rigOapChecklistQuestionCommentService;
        }

        Task<RigOapChecklistQuestionComment> IRequestHandler<AddRigOapChecklistQuestionCommentRequest, RigOapChecklistQuestionComment>.Handle(AddRigOapChecklistQuestionCommentRequest request, CancellationToken cancellationToken)
        {
            Guid rigChecklistQuestionCommentId = Guid.Empty;

            using (var ts = new TransactionScope())
            {
                rigChecklistQuestionCommentId = RigOapChecklistQuestionCommentService.Add(request.Comment);

                ts.Complete();
            }

            var rigoapChecklistQuestionComment = RigOapChecklistQuestionCommentService.Get(rigChecklistQuestionCommentId);

            return Task.FromResult(rigoapChecklistQuestionComment);
        }


        
    }
}