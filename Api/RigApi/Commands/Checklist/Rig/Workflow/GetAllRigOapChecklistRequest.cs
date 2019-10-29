using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Workflow
{
    public class GetAllRigOapChecklistWorkflowRequest : IRequest<IEnumerable<RigOapChecklistWorkflow>>
    { 
        public GetAllRigOapChecklistWorkflowRequest(DateTime startDate,DateTime endDate)
        {
            Start = startDate;
            End = endDate;
        }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}