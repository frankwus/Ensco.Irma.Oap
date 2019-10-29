using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist
{
    public class GetChecklistByTitleHandler : IRequestHandler<GetChecklistByTitleRequest, OapChecklist>
    {
        private IOapChecklistService Service { get; set; }

        public GetChecklistByTitleHandler(IOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        Task<OapChecklist> IRequestHandler<GetChecklistByTitleRequest, OapChecklist>.Handle(GetChecklistByTitleRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetByTitle(request.Title);
            return Task.FromResult(cl);
        }
    }
}