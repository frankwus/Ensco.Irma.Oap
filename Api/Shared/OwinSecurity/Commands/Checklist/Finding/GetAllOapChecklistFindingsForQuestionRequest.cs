
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding
{
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using System;

    public class GetAllOapChecklistFindingsForQuestionRequest : IRequest<IEnumerable<RigOapChecklistQuestionFinding>>
    {
        public GetAllOapChecklistFindingsForQuestionRequest(Guid rigQuestionId)
        {
            RigQuestionId = rigQuestionId;
        }

        public Guid RigQuestionId { get; }
    }
}