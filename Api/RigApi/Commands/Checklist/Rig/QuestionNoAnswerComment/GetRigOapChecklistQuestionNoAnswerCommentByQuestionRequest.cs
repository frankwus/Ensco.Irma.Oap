using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment
{
    public class GetRigOapChecklistQuestionNoAnswerCommentByQuestionRequest : IRequest<RigOapChecklistQuestionNoAnswerComment>
    {
        public GetRigOapChecklistQuestionNoAnswerCommentByQuestionRequest(Guid rigOapChecklistQuestionId)
        {
            RigOapChecklistQuestionId = rigOapChecklistQuestionId;
        }

        public Guid RigOapChecklistQuestionId { get;}
    }
}