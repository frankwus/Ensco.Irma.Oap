using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob
{
    public class GetAllRigOapChecklistThirdPartyJobRequest : IRequest<IEnumerable<RigOapChecklistThirdPartyJob>>
    { 
        public GetAllRigOapChecklistThirdPartyJobRequest()
        { 
        }
         
    }
}