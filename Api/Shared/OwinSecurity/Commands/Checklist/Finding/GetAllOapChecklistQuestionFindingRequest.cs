
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding
{
    using Ensco.Irma.Models.Domain.Oap.Checklist;

    public class GetAllOapChecklistQuestionFindingRequest : IRequest<IEnumerable<RigOapChecklistQuestionFinding>>
    { 
        public GetAllOapChecklistQuestionFindingRequest()
        { 
        }
    }
}