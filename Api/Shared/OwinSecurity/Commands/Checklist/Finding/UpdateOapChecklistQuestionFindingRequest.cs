using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding
{
    using Ensco.Irma.Models.Domain.Oap.Checklist;

    public class UpdateOapChecklistQuestionFindingRequest : IRequest<bool>
    {
        public UpdateOapChecklistQuestionFindingRequest(RigOapChecklistQuestionFinding finding)
        {
            Finding = finding;
        }

        public RigOapChecklistQuestionFinding Finding { get;  }
    }
}