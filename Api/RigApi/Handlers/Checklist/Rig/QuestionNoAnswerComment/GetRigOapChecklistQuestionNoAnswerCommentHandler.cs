
using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetRigOapChecklistQuestionNoAnswerCommentHandler : IRequestHandler<GetRigOapChecklistQuestionNoAnswerCommentRequest, RigOapChecklistQuestionNoAnswerComment>
    {
        private IRigOapChecklistQuestionNoAnswerCommentService RigOapChecklistQuestionNoAnswerCommentService { get; set; }

        public GetRigOapChecklistQuestionNoAnswerCommentHandler(IRigOapChecklistQuestionNoAnswerCommentService rigOapChecklistQuestionNoAnswerCommentService)
        {
            RigOapChecklistQuestionNoAnswerCommentService = rigOapChecklistQuestionNoAnswerCommentService;
        }

        Task<RigOapChecklistQuestionNoAnswerComment> IRequestHandler<GetRigOapChecklistQuestionNoAnswerCommentRequest, RigOapChecklistQuestionNoAnswerComment>.Handle(GetRigOapChecklistQuestionNoAnswerCommentRequest request, CancellationToken cancellationToken)
        {
            var cl =  RigOapChecklistQuestionNoAnswerCommentService.Get(request.RigOapChecklistQuestionNoAnswerCommentId);

            //if (!string.IsNullOrEmpty(cl.FileName))
            //{
            //    cl.FileStream = cl.FileName.Get();
            //}
            return Task.FromResult(cl);
        }
    }
}