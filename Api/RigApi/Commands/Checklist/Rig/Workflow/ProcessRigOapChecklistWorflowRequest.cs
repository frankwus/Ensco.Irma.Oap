using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Workflow
{
    public class ProcessRigOapChecklistWorflowRequest : IRequest<bool>
    {
        public ProcessRigOapChecklistWorflowRequest(Guid rigChecklistOapId, int userId, string transition, string comment, int order)
        {
            RigChecklistId = rigChecklistOapId;
            UserId = userId;
            Transition = transition;
            Comment = comment;
            Order = order;
        }

        public Guid RigChecklistId { get;  }

        public int UserId { get; }

        public string Transition { get; }

        public string Comment { get; }
        public int Order { get; }
    }
}