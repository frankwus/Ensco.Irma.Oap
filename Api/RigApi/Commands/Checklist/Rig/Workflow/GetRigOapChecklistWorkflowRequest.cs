using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Workflow
{
    public class GetRigOapChecklistWorkflowRequest : IRequest<RigOapChecklistWorkflow>
    { 
        public GetRigOapChecklistWorkflowRequest(Guid rigOapChecklistId)
        {
            RigOapChecklistId = rigOapChecklistId;
        }

        public Guid RigOapChecklistId { get; set; }
    }
}