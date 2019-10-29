using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist
{
    public class AddChecklistRequest : IRequest<OapChecklist>
    {
        public AddChecklistRequest(OapChecklist checklist)
        {
            Checklist = checklist;
        }

        public OapChecklist Checklist { get;  }
    }
}