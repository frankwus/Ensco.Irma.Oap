using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup
{
    public class DeleteChecklistGroupRequest : IRequest<bool>
    { 
        public DeleteChecklistGroupRequest(int checklistGroupId)
        {
            ChecklistGroupId = checklistGroupId;
        }

        public int ChecklistGroupId {get; set;}
    }
}