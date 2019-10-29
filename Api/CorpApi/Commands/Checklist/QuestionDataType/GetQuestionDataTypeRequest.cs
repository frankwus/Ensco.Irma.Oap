using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionDataType
{
    public class GetQuestionDataTypeRequest : IRequest<OapChecklistQuestionDataType>
    { 
        public GetQuestionDataTypeRequest(int questionDataTypeId)
        {
            QuestionDataTypeId = questionDataTypeId;
        }

        public int QuestionDataTypeId {get; set;}
    }
}