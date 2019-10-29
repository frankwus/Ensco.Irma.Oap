using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap
{
    public class DeleteQuestionTagMapRequest : IRequest<bool>
    { 
        public DeleteQuestionTagMapRequest(int questionTagMapId)
        {
            QuestionTagMapId = questionTagMapId;
        }

        public int QuestionTagMapId { get; set;}
    }
}