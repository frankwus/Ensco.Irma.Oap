using MediatR;
using System;
using Ensco.Irma.Models.Domain.Oap.Audit;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.WorkFlow
{
    public class StartOapAuditWorkFlowRequest:IRequest<bool>
    {


        public StartOapAuditWorkFlowRequest(Guid rigChecklistOapId, int ownerId, OapAudit audit)
        {
            RigChecklistId = rigChecklistOapId;
            OwnerId = ownerId;
            Audit = audit;
        }

        public Guid RigChecklistId { get; }

        public int OwnerId { get; }

        public OapAudit Audit { get; }

    }
}