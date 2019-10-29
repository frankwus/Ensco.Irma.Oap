using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup
{
    public class AddChecklistGroupRequest : IRequest<OapChecklistGroup>
    {
        public AddChecklistGroupRequest(OapChecklistGroup checklistGroup)
        {
            ChecklistGroup = checklistGroup;
        }

        public OapChecklistGroup ChecklistGroup { get;  }
    }
}