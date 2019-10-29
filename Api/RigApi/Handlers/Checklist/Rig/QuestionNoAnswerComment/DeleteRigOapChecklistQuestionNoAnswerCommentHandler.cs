

using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class DeleteRigOapChecklistQuestionNoAnswerCommentHandler : IRequestHandler<DeleteRigOapChecklistQuestionNoAnswerCommentRequest, bool>
    {
        private IRigOapChecklistQuestionNoAnswerCommentService RigOapChecklistQuestionNoAnswerCommentService { get; set; }

        public DeleteRigOapChecklistQuestionNoAnswerCommentHandler(IRigOapChecklistQuestionNoAnswerCommentService rigOapChecklistQuestionNoAnswerCommentService)
        {
            RigOapChecklistQuestionNoAnswerCommentService = rigOapChecklistQuestionNoAnswerCommentService;
        }

        Task<bool> IRequestHandler<DeleteRigOapChecklistQuestionNoAnswerCommentRequest, bool>.Handle(DeleteRigOapChecklistQuestionNoAnswerCommentRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var rigOapChecklistQuestionNoAnswerComment = RigOapChecklistQuestionNoAnswerCommentService.Get(request.CommentId);

                RigOapChecklistQuestionNoAnswerCommentService.Delete(rigOapChecklistQuestionNoAnswerComment);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}