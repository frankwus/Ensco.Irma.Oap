using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap
{
    public class UpdateQuestionTagMapRequest : IRequest<bool>
    {
        public UpdateQuestionTagMapRequest(OapChecklistQuestionTagMap questionTagMap)
        {
            QuestionTagMap = questionTagMap;
        }

        public OapChecklistQuestionTagMap QuestionTagMap { get;  }
    }
}