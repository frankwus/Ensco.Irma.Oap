using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist
{
    public class UpdateChecklistRequest : IRequest<bool>
    {
        public UpdateChecklistRequest(OapChecklist checklist)
        {
            Checklist = checklist;
        }

        public OapChecklist Checklist { get;  }
    }
}