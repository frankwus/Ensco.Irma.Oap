using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment
{
    public class GetRigOapChecklistQuestionCommentRequest : IRequest<RigOapChecklistQuestionComment>
    { 
        public GetRigOapChecklistQuestionCommentRequest(Guid rigOapChecklistQuestionCommentId)
        {
            RigOapChecklistQuestionCommentId = rigOapChecklistQuestionCommentId;
        }

        public Guid RigOapChecklistQuestionCommentId { get; set; }
    }
}