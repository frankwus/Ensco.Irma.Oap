using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.FsoChecklist
{
    public class GetFsoChecklistByMinDateRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetFsoChecklistByMinDateRequest(DateTime minDate, int oapChecklistId)
        {
            OapChecklistId = oapChecklistId;
            MinDate = minDate;
        }

        public int OapChecklistId { get; }
        public DateTime MinDate { get; set; }
    }
}