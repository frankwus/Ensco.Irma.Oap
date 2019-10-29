using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class AddAssessorRequest : IRequest<RigOapChecklist>
    {
        public AddAssessorRequest(Guid rigOapChecklistId, RigOapChecklistAssessor assessor)
        {
            RigOapChecklistId = rigOapChecklistId;
            Assessor = assessor;
        }

        public Guid RigOapChecklistId { get; }
        public RigOapChecklistAssessor Assessor { get; }
    }
}