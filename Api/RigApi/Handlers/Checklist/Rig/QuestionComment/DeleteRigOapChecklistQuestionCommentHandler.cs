using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class DeleteRigOapChecklistQuestionCommentHandler : IRequestHandler<DeleteRigOapChecklistQuestionCommentRequest, bool>
    {
        private IRigOapChecklistQuestionCommentService RigOapChecklistQuestionCommentService { get; set; }

        public DeleteRigOapChecklistQuestionCommentHandler(IRigOapChecklistQuestionCommentService rigOapChecklistQuestionCommentService)
        {
            RigOapChecklistQuestionCommentService = rigOapChecklistQuestionCommentService;
        }

        Task<bool> IRequestHandler<DeleteRigOapChecklistQuestionCommentRequest, bool>.Handle(DeleteRigOapChecklistQuestionCommentRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var rigOapChecklistQuestionComment = RigOapChecklistQuestionCommentService.Get(request.CommentId);

                RigOapChecklistQuestionCommentService.Delete(rigOapChecklistQuestionComment);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}