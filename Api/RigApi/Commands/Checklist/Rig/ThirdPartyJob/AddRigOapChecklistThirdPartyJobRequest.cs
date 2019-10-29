using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob
{
    public class AddRigOapChecklistThirdPartyJobRequest : IRequest<RigOapChecklistThirdPartyJob>
    {
        public AddRigOapChecklistThirdPartyJobRequest(RigOapChecklistThirdPartyJob thirdPartyJob)
        {
            ThirdPartyJob = thirdPartyJob;
        }

        public RigOapChecklistThirdPartyJob ThirdPartyJob { get;  }
    }
}