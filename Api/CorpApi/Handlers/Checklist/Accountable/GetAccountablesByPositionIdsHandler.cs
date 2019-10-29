using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Accountable;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Accountable
{
    public class GetAccountablesByPositionIdsHandler : IRequestHandler<GetAccountablesByPositionIdsRequest, IEnumerable<OapAccountable>>
    {
        private readonly IOapAccountableService service;

        public GetAccountablesByPositionIdsHandler(IOapAccountableService service)
        {
            this.service = service;
        }
        public Task<IEnumerable<OapAccountable>> Handle(GetAccountablesByPositionIdsRequest request, CancellationToken cancellationToken)
        {
            var accountables = service.GetAllByPositionIds(request.Ids);
            return Task.FromResult(accountables);
        }
    }
}