using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout
{
    public class DeleteChecklistLayoutRequest : IRequest<bool>
    { 
        public DeleteChecklistLayoutRequest(int layoutId)
        {
            ChecklistLayoutId = layoutId;
        }

        public int ChecklistLayoutId { get; set;}
    }
}