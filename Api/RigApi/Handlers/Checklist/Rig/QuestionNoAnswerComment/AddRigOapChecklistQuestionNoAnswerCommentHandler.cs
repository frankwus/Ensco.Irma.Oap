using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class AddRigOapChecklistQuestionNoAnswerCommentHandler : IRequestHandler<AddRigOapChecklistQuestionNoAnswerCommentRequest, RigOapChecklistQuestionNoAnswerComment>
    {
        private IRigOapChecklistQuestionNoAnswerCommentService RigOapChecklistQuestionNoAnswerCommentService { get; set; }


        public AddRigOapChecklistQuestionNoAnswerCommentHandler(IRigOapChecklistQuestionNoAnswerCommentService rigOapChecklistQuestionNoAnswerCommentService)
        {
            RigOapChecklistQuestionNoAnswerCommentService = rigOapChecklistQuestionNoAnswerCommentService;
        }

        Task<RigOapChecklistQuestionNoAnswerComment> IRequestHandler<AddRigOapChecklistQuestionNoAnswerCommentRequest, RigOapChecklistQuestionNoAnswerComment>.Handle(AddRigOapChecklistQuestionNoAnswerCommentRequest request, CancellationToken cancellationToken)
        {
            Guid rigChecklistQuestionNoAnswerCommentId = Guid.Empty;

            using (var ts = new TransactionScope())
            {
                rigChecklistQuestionNoAnswerCommentId = RigOapChecklistQuestionNoAnswerCommentService.Add(request.Comment);

                ts.Complete();
            }

            var rigoapChecklistQuestionNoAnswerComment = RigOapChecklistQuestionNoAnswerCommentService.Get(rigChecklistQuestionNoAnswerCommentId);

            return Task.FromResult(rigoapChecklistQuestionNoAnswerComment);
        }
    }
}