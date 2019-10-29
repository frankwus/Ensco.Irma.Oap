using MediatR;
using System;
using Ensco.Irma.Models.Domain.Oap.Audit;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.WorkFlow
{
    public class ProcessOapAuditWorkFlowRequest:IRequest<bool>
    {

        public ProcessOapAuditWorkFlowRequest(Guid rigChecklistOapId, int userId, string transition, string comment, int order, OapAudit audit)
        {
            RigChecklistId = rigChecklistOapId;
            UserId = userId;
            Transition = transition;
            Comment = comment;
            Order = order;
            Audit = audit;
        }

        public Guid RigChecklistId { get; }

        public int UserId { get; }

        public string Transition { get; }

        public string Comment { get; }
        public int Order { get; }

        public OapAudit Audit { get; }
    }
}