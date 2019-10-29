
using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetRigOapChecklistQuestionNoAnswerCommentByQuestionHandler : IRequestHandler<GetRigOapChecklistQuestionNoAnswerCommentByQuestionRequest, RigOapChecklistQuestionNoAnswerComment>
    {
        private IRigOapChecklistQuestionNoAnswerCommentService RigOapChecklistQuestionNoAnswerCommentService { get; set; }

        public GetRigOapChecklistQuestionNoAnswerCommentByQuestionHandler(IRigOapChecklistQuestionNoAnswerCommentService rigOapChecklistQuestionNoAnswerCommentService)
        {
            RigOapChecklistQuestionNoAnswerCommentService = rigOapChecklistQuestionNoAnswerCommentService;
        }

        Task<RigOapChecklistQuestionNoAnswerComment> IRequestHandler<GetRigOapChecklistQuestionNoAnswerCommentByQuestionRequest, RigOapChecklistQuestionNoAnswerComment>.Handle(GetRigOapChecklistQuestionNoAnswerCommentByQuestionRequest request, CancellationToken cancellationToken)
        {
            //var c = RigOapChecklistQuestionNoAnswerCommentService.GetByQuestion(request.RigOapChecklistQuestionId);

            ////if (!string.IsNullOrEmpty(c.FileName))
            ////{
            ////    c.FileStream = c.FileName.Get();
            ////}

            //return Task.FromResult(c);
            return null;
        }
    }
}