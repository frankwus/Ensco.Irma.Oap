
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding
{
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using System;

    public class GetAllOapChecklistFindingsForChecklistRequest : IRequest<IEnumerable<RigOapChecklistQuestionFinding>>
    {
        public GetAllOapChecklistFindingsForChecklistRequest(Guid rigChecklistId)
        {
            RigChecklistId = rigChecklistId;
        }

        public Guid RigChecklistId { get; }
    }
}