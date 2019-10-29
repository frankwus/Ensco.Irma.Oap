using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout
{
    public class GetChecklistLayoutRequest : IRequest<OapChecklistLayout>
    { 
        public GetChecklistLayoutRequest(int layoutId)
        {
            ChecklistLayoutId = layoutId;
        }

        public int ChecklistLayoutId {get; set;}
    }
}