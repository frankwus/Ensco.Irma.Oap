using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup
{
    public class GetChecklistGroupRequest : IRequest<OapChecklistGroup>
    { 
        public GetChecklistGroupRequest(int checklistGroupId)
        {
            ChecklistGroupId = checklistGroupId;
        }

        public int ChecklistGroupId {get; set;}
    }
}