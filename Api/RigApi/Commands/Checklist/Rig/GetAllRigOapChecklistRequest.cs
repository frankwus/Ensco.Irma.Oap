using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetAllRigOapChecklistRequest : IRequest<IEnumerable<RigOapChecklist>>
    { 
        public GetAllRigOapChecklistRequest(string status, DateTime? startDate = null)
        {
            Start = startDate;
            Status = status;
        }

        public DateTime? Start { get; set; }
        public string Status { get; }
    }
}