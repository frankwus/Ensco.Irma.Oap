using Ensco.Irma.Models.Domain.Oap;
using MediatR;
using System;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class ValidateChecklistRequest : IRequest<RigChecklistValidationResult>
    {
        public ValidateChecklistRequest(Guid rigOapChecklistId)
        {
            RigOapChecklistId = rigOapChecklistId;
        }

        public Guid RigOapChecklistId { get; }
    }
}