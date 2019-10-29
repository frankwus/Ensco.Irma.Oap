using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question
{
    public class GetChecklistQuestionRequest : IRequest<OapChecklistQuestion>
    { 
        public GetChecklistQuestionRequest(int questionId)
        {
            QuestionId = questionId;
        }


        public int QuestionId { get; }
    }
}