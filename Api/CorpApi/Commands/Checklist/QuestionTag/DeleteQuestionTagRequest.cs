using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag
{
    public class DeleteQuestionTagRequest : IRequest<bool>
    { 
        public DeleteQuestionTagRequest(int questionTagId)
        {
            QuestionTagId = questionTagId;
        }

        public int QuestionTagId { get; set;}
    }
}