using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetAllRigOapChecklistQuestionCommentHandler : IRequestHandler<GetAllRigOapChecklistQuestionCommentRequest, IEnumerable<RigOapChecklistQuestionComment>>
    {
        private IRigOapChecklistQuestionCommentService RigOapChecklistQuestionCommentService { get; set; }

        public GetAllRigOapChecklistQuestionCommentHandler(IRigOapChecklistQuestionCommentService rigOapChecklistQuestionCommentService)
        {
            RigOapChecklistQuestionCommentService = rigOapChecklistQuestionCommentService;
        }

        Task<IEnumerable<RigOapChecklistQuestionComment>> IRequestHandler<GetAllRigOapChecklistQuestionCommentRequest, IEnumerable<RigOapChecklistQuestionComment>>.Handle(GetAllRigOapChecklistQuestionCommentRequest request, CancellationToken cancellationToken)
        {
            var cl =  RigOapChecklistQuestionCommentService.GetAll();
            return Task.FromResult(cl);
        }
    }
}