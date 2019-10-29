using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class ValidateChecklistHandler : IRequestHandler<ValidateChecklistRequest, RigChecklistValidationResult>
    {
        private readonly IRigOapChecklistService service;

        public ValidateChecklistHandler(IRigOapChecklistService service)
        {
            this.service = service;
        }

        public Task<RigChecklistValidationResult> Handle(ValidateChecklistRequest request, CancellationToken cancellationToken)
        {
            var result = service.ValidateChecklist(request.RigOapChecklistId);
            return Task.FromResult(result);
        }
    }
}