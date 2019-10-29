using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob
{
    public class DeleteRigOapChecklistThirdPartyJobRequest : IRequest<bool>
    { 
        public DeleteRigOapChecklistThirdPartyJobRequest(Guid thirdPartyJobId)
        {
            ThirdPartyJobId = thirdPartyJobId;
        }

        public Guid ThirdPartyJobId { get; set;}
    }
}