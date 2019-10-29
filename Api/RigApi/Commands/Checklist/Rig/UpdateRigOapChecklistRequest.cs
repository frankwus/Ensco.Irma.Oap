using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class UpdateRigOapChecklistRequest : IRequest<RigOapChecklist>
    {
        public UpdateRigOapChecklistRequest(RigOapChecklist checklist)
        {
            Checklist = checklist;
        }

        public RigOapChecklist Checklist { get;  }
    }
}