using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding
{

    using Ensco.Irma.Models.Domain.Oap.Checklist; 

    public class AddOapChecklistQuestionFindingRequest : IRequest<RigOapChecklistQuestionFinding>
    {
        public AddOapChecklistQuestionFindingRequest(RigOapChecklistQuestionFinding finding)
        {
            Finding = finding;
        }

        public RigOapChecklistQuestionFinding Finding { get;  }
    }
}