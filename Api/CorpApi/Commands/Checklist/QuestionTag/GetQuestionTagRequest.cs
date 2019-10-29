using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag
{
    public class GetQuestionTagRequest : IRequest<OapChecklistQuestionTag>
    { 
        public GetQuestionTagRequest(int questionTagId)
        {
            QuestionTagId = questionTagId;
        }

        public int QuestionTagId { get; set;}
    }
}