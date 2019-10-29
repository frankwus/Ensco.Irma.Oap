using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding
{
    using System;

    public class DeleteOapChecklistQuestionFindingRequest : IRequest<bool>
    { 
        public DeleteOapChecklistQuestionFindingRequest(Guid findingId)
        {
            FindingId = findingId;
        }

        public Guid FindingId { get; set;}
    }
}