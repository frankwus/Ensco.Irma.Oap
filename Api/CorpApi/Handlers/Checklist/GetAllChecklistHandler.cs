using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist
{
    public class GetAllChecklistHandler : IRequestHandler<GetAllChecklistRequest, IEnumerable<OapChecklist>>
    {
        private IOapChecklistService Service { get; set; }

        public GetAllChecklistHandler(IOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        Task<IEnumerable<OapChecklist>> IRequestHandler<GetAllChecklistRequest, IEnumerable<OapChecklist>>.Handle(GetAllChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll(request.StartDate, request.EndDate);
            return Task.FromResult(cl);
        }
    }
}