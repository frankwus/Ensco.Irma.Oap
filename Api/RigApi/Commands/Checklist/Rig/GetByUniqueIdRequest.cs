using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetByUniqueIdRequest : IRequest<RigOapChecklist>
    { 
        public GetByUniqueIdRequest(int checklistUniqueId)
        {
            RigOapChecklistUniqueId = checklistUniqueId;
        }

        public int RigOapChecklistUniqueId { get; set; }
    }
}