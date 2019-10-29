using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap
{
    public class GetQuestionTagMapRequest : IRequest<OapChecklistQuestionTagMap>
    { 
        public GetQuestionTagMapRequest(int questionTagMapId)
        {
            QuestionTagMapId = questionTagMapId;
        }

        public int QuestionTagMapId { get; set;}
    }
}