using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction
{
    public class GetAllRigOapChecklistWorkInstructionRequest : IRequest<IEnumerable<RigOapChecklistWorkInstruction>>
    { 
        public GetAllRigOapChecklistWorkInstructionRequest()
        { 
        }
         
    }
}