using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist
{
    public class GetChecklistHandler : IRequestHandler<GetChecklistRequest, OapChecklist>
    {
        private IOapChecklistService Service { get; set; }

        public GetChecklistHandler(IOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        Task<OapChecklist> IRequestHandler<GetChecklistRequest, OapChecklist>.Handle(GetChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.ChecklistId);
            return Task.FromResult(cl);
        }
    }
}