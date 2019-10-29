using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup
{
    public class AddChecklistSubGroupRequest : IRequest<OapChecklistSubGroup>
    {
        public AddChecklistSubGroupRequest(OapChecklistSubGroup checklistSubGroup)
        {
            ChecklistSubGroup = checklistSubGroup;
        }

        public OapChecklistSubGroup ChecklistSubGroup { get;  }
    }
}