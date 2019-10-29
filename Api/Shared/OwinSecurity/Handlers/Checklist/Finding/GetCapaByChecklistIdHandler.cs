using Ensco.Irma.Interfaces.Services.Irma;
using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.Finding
{
    public class GetCapaByChecklistIdHandler : IRequestHandler<GetCAPAsByChecklistIdRequest, IEnumerable<IrmaCapa>>
    {
        IIrmaCAPAService capaService;
        public GetCapaByChecklistIdHandler(IIrmaCAPAService capaService)
        {
            this.capaService = capaService;
        }
        Task<IEnumerable<IrmaCapa>> IRequestHandler<GetCAPAsByChecklistIdRequest, IEnumerable<IrmaCapa>>.Handle(GetCAPAsByChecklistIdRequest request, CancellationToken cancellationToken)
        {
            var cl = capaService.GetCAPAsByChecklistId(request.ChecklistId);
            return Task.FromResult(cl);
        }
    }
}
