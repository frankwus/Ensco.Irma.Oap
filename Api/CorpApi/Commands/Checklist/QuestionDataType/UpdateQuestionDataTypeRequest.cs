using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionDataType
{
    public class UpdateQuestionDataTypeRequest : IRequest<bool>
    {
        public UpdateQuestionDataTypeRequest(OapChecklistQuestionDataType questionDataType)
        {
            QuestionDataType = questionDataType;
        }

        public OapChecklistQuestionDataType QuestionDataType { get;  }
    }
}