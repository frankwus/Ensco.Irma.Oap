using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup
{
    public class DeleteChecklistSubGroupRequest : IRequest<bool>
    { 
        public DeleteChecklistSubGroupRequest(int checklistSubGroupId)
        {
            ChecklistSubGroupId = checklistSubGroupId;
        }

        public int ChecklistSubGroupId {get; set;}
    }
}