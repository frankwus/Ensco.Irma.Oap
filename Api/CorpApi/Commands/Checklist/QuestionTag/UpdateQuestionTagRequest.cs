using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag
{
        
    public class UpdateQuestionTagRequest : IRequest<bool>
    {
        public UpdateQuestionTagRequest(OapChecklistQuestionTag questionTag)
        {
            QuestionTag = questionTag;
        }

        public OapChecklistQuestionTag QuestionTag { get;}
    }
}