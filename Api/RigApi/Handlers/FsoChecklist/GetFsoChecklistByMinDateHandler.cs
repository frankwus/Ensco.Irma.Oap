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
    public class GetFsoChecklistByMinDateHandler : IRequestHandler<GetFsoChecklistByMinDateRequest, IEnumerable<RigOapChecklist>>
    {
        private IRigOapChecklistService Service { get; set; }

        public GetFsoChecklistByMinDateHandler(IRigOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        public Task<IEnumerable<RigOapChecklist>> Handle(GetFsoChecklistByMinDateRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetFsoChecklistByMindate(request.MinDate, request.OapChecklistId);
            return Task.FromResult(cl);
        }
    }
}