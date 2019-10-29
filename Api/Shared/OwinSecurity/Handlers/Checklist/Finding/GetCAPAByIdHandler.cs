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
    public class GetCAPAByIdHandler : IRequestHandler<GetCAPAByIdRequest, IrmaCapa>
    {
        public IIrmaCAPAService service;
        public GetCAPAByIdHandler(IIrmaCAPAService service)
        {
            this.service = service;
        }

        Task<IrmaCapa> IRequestHandler<GetCAPAByIdRequest, IrmaCapa>.Handle(GetCAPAByIdRequest request, CancellationToken cancellationToken)
        {
            var cl = service.GetCAPAById(request.CapaId);
            return Task.FromResult(cl);
        }
    }
}
