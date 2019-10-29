using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class AddRigOapChecklistRequest : IRequest<RigOapChecklist>
    {
        public AddRigOapChecklistRequest(RigOapChecklist checklist)
        {
            Checklist = checklist;
        }

        public RigOapChecklist Checklist { get;  }
    }
}