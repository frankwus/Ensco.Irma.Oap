using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding
{
    using Ensco.Irma.Models.Domain.Oap.Checklist;

    public class GetOapChecklistQuestionFindingRequest : IRequest<RigOapChecklistQuestionFinding>
    { 
        public GetOapChecklistQuestionFindingRequest(Guid findingId)
        {
            FindingId = findingId;
        }

        public Guid FindingId {get; set;}
    }
}