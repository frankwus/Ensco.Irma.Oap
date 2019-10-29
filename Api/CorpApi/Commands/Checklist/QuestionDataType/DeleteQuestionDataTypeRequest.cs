using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionDataType
{
    public class DeleteQuestionDataTypeRequest : IRequest<bool>
    { 
        public DeleteQuestionDataTypeRequest(int questionDataTypeId)
        {
            QuestionDataTypeId = questionDataTypeId;
        }

        public int QuestionDataTypeId {get; set;}
    }
}