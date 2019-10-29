using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question
{
    public class DeleteChecklistQuestionRequest : IRequest<bool>
    { 
        public DeleteChecklistQuestionRequest(int questionId)
        {
            QuestionId = questionId;
        }

        public int QuestionId { get; set; }
    }
}