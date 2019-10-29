using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn
{
    public class GetChecklistLayoutColumnRequest : IRequest<OapChecklistLayoutColumn>
    { 
        public GetChecklistLayoutColumnRequest(int layoutColumnId)
        {
            ChecklistLayoutColumnId = layoutColumnId;
        }

        public int ChecklistLayoutColumnId {get; set;}
    }
}