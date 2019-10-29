using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetRigOapChecklistRequest : IRequest<RigOapChecklist>
    { 
        public GetRigOapChecklistRequest(Guid rigOapChecklistId)
        {
            RigOapChecklistId = rigOapChecklistId;
        }

        public Guid RigOapChecklistId { get; set; }
    }
}