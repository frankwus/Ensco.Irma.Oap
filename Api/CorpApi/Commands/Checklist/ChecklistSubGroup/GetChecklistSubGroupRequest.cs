using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup
{
    public class GetChecklistSubGroupRequest : IRequest<OapChecklistSubGroup>
    { 
        public GetChecklistSubGroupRequest(int checklistSubGroupId)
        {
            ChecklistSubGroupId = checklistSubGroupId;
        }

        public int ChecklistSubGroupId {get; set;}
    }
}