using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout
{
    public class UpdateChecklistLayoutRequest : IRequest<bool>
    {
        public UpdateChecklistLayoutRequest(OapChecklistLayout layout)
        {
            ChecklistLayout = layout;
        }

        public OapChecklistLayout ChecklistLayout { get;  }
    }
}