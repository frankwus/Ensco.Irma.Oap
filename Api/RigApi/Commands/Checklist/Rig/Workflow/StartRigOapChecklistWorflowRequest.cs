using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Workflow
{
    public class StartRigOapChecklistWorkflowRequest : IRequest<bool>
    {
        public StartRigOapChecklistWorkflowRequest(Guid rigChecklistOapId, int ownerId)
        {
            RigChecklistId = rigChecklistOapId;
            OwnerId = ownerId; 
        }

        public Guid RigChecklistId { get;  }

        public int OwnerId { get; }
    }
}