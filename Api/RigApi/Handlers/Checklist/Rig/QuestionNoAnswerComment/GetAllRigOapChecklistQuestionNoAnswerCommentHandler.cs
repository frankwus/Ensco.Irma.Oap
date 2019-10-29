
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
    public class GetAllRigOapChecklistQuestionNoAnswerCommentHandler : IRequestHandler<GetAllRigOapChecklistQuestionNoAnswerCommentRequest, IEnumerable<RigOapChecklistQuestionNoAnswerComment>>
    {
        private IRigOapChecklistQuestionNoAnswerCommentService RigOapChecklistQuestionNoAnswerCommentService { get; set; }

        public GetAllRigOapChecklistQuestionNoAnswerCommentHandler(IRigOapChecklistQuestionNoAnswerCommentService rigOapChecklistQuestionNoAnswerCommentService)
        {
            RigOapChecklistQuestionNoAnswerCommentService = rigOapChecklistQuestionNoAnswerCommentService;
        }

        Task<IEnumerable<RigOapChecklistQuestionNoAnswerComment>> IRequestHandler<GetAllRigOapChecklistQuestionNoAnswerCommentRequest, IEnumerable<RigOapChecklistQuestionNoAnswerComment>>.Handle(GetAllRigOapChecklistQuestionNoAnswerCommentRequest request, CancellationToken cancellationToken)
        {
            var cl =  RigOapChecklistQuestionNoAnswerCommentService.GetAll();

            //foreach(var c in cl)
            //{
            //    if (!string.IsNullOrEmpty(c.FileName))
            //    {
            //        c.FileStream = c.FileName.Get();
            //    }
            //}
            return Task.FromResult(cl);
        }
    }
}