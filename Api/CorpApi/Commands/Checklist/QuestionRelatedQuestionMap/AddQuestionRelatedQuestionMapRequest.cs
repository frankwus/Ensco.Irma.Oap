using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionRelatedQuestionMap
{
    public class AddQuestionRelatedQuestionMapRequest : IRequest<OapCheckListQuestionRelatedQuestionMap>
    {
        public AddQuestionRelatedQuestionMapRequest(OapCheckListQuestionRelatedQuestionMap questionRelatedQuestionMap)
        {
            QuestionRelatedQuestionMap = questionRelatedQuestionMap;
        }

        public OapCheckListQuestionRelatedQuestionMap QuestionRelatedQuestionMap { get;  }
    }
}