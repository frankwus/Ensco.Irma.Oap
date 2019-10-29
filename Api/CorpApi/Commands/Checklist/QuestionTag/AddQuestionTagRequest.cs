using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag
{
    public class AddQuestionTagRequest : IRequest<OapChecklistQuestionTag>
    {
        public AddQuestionTagRequest(OapChecklistQuestionTag questionTag)
        {
            QuestionTag = questionTag;
        }

        public OapChecklistQuestionTag QuestionTag { get;  }
    }
}