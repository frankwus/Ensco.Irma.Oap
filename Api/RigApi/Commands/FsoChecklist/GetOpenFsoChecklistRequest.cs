using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.FsoChecklist
{
    public class GetOpenFsoChecklistRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetOpenFsoChecklistRequest(int fsoChecklistId)
        {
            FsoChecklistId = fsoChecklistId;
        }

        public int FsoChecklistId { get; }
    }
}