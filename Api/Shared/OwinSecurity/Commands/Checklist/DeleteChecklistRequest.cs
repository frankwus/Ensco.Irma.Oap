using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class DeleteChecklistRequest : IRequest<bool>
    { 
        public DeleteChecklistRequest(int checklistId)
        {
            ChecklistId = checklistId;
        }

        public int ChecklistId {get; set;}
    }
}