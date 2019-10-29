using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn
{
    public class UpdateChecklistLayoutColumnRequest : IRequest<bool>
    {
        public UpdateChecklistLayoutColumnRequest(OapChecklistLayoutColumn layoutColumn)
        {
            ChecklistLayoutColumn = layoutColumn;
        }

        public OapChecklistLayoutColumn ChecklistLayoutColumn { get;  }
    }
}