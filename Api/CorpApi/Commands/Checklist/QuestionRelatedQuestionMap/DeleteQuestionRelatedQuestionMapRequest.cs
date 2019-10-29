using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionRelatedQuestionMap
{
    public class DeleteQuestionRelatedQuestionMapRequest : IRequest<bool>
    { 
        public DeleteQuestionRelatedQuestionMapRequest(int questionTagMapId)
        {
            QuestionRelatedQuestionMapId = questionTagMapId;
        }

        public int QuestionRelatedQuestionMapId { get; set;}
    }
}