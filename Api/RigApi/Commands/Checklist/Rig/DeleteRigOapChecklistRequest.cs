using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class DeleteRigOapChecklistRequest : IRequest<bool>
    { 
        public DeleteRigOapChecklistRequest(Guid rigChecklistId)
        {
            RigChecklistId = rigChecklistId;
        }

        public Guid  RigChecklistId {get; set;}
    }
}