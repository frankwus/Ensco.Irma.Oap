using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class GetChecklistRequest : IRequest<OapChecklist>
    { 
        public GetChecklistRequest(int checklistId)
        {
            ChecklistId = checklistId;
        }

        public int ChecklistId {get; set;}
    }
}