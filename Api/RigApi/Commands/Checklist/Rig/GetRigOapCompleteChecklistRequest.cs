using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetRigOapCompleteChecklistRequest : IRequest<RigOapChecklist>
    { 
        public GetRigOapCompleteChecklistRequest(Guid rigOapChecklistId)
        {
            RigOapChecklistId = rigOapChecklistId;
        }

        public Guid RigOapChecklistId { get; set; }
    }
}