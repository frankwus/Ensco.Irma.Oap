using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment
{
    public class GetRigOapChecklistQuestionNoAnswerCommentRequest : IRequest<RigOapChecklistQuestionNoAnswerComment>
    { 
        public GetRigOapChecklistQuestionNoAnswerCommentRequest(Guid rigOapChecklistQuestionNoAnswerCommentId)
        {
            RigOapChecklistQuestionNoAnswerCommentId = rigOapChecklistQuestionNoAnswerCommentId;
        }

        public Guid RigOapChecklistQuestionNoAnswerCommentId { get; set; }
    }
}