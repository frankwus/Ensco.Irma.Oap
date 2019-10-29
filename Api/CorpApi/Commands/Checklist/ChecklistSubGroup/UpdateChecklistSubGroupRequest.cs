using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup
{
    public class UpdateChecklistSubGroupRequest : IRequest<bool>
    {
        public UpdateChecklistSubGroupRequest(OapChecklistSubGroup checklistSubGroup)
        {
            ChecklistSubGroup = checklistSubGroup;
        }

        public OapChecklistSubGroup ChecklistSubGroup { get;  }
    }
}