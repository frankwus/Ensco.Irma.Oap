using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.FsoChecklist;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist
{
    public class GetOpenFsoChecklistHandler : IRequestHandler<GetOpenFsoChecklistRequest, IEnumerable<RigOapChecklist>>
    {
        private IRigOapChecklistService Service { get; set; }

        public GetOpenFsoChecklistHandler(IRigOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        public Task<IEnumerable<RigOapChecklist>> Handle(GetOpenFsoChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetOpenFsoChecklists(request.FsoChecklistId);
            return Task.FromResult(cl);
        }
    }
}