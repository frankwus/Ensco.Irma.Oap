using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn
{
    public class DeleteChecklistLayoutColumnRequest : IRequest<bool>
    { 
        public DeleteChecklistLayoutColumnRequest(int layoutColumnId)
        {
            ChecklistLayoutColumnId = layoutColumnId;
        }

        public int ChecklistLayoutColumnId { get; set;}
    }
}