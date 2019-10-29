using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob
{
    public class UpdateRigOapChecklistThirdPartyJobRequest : IRequest<RigOapChecklistThirdPartyJob>
    {
        public UpdateRigOapChecklistThirdPartyJobRequest(RigOapChecklistThirdPartyJob checklistThirdPartyJob)
        {
            RigChecklistThirdPartyJob = checklistThirdPartyJob;
        }

        public RigOapChecklistThirdPartyJob RigChecklistThirdPartyJob { get;  }
    }
}