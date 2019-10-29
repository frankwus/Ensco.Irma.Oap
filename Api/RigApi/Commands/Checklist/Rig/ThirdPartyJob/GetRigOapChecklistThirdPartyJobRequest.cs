using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob
{
    public class GetRigOapChecklistThirdPartyJobRequest : IRequest<RigOapChecklistThirdPartyJob>
    { 
        public GetRigOapChecklistThirdPartyJobRequest(Guid rigOapChecklistThirdPartyJobId)
        {
            RigOapChecklistThirdPartyJobId = rigOapChecklistThirdPartyJobId;
        }

        public Guid RigOapChecklistThirdPartyJobId { get; set; }
    }
}