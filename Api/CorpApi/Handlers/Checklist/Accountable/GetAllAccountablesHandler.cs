using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Accountable;
using Ensco.Irma.Services.Oap;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Accountable
{
    public class GetAllAccountablesHandler : IRequestHandler<GetAllAccountablesRequest, IEnumerable<OapAccountable>>
    {
        private readonly IOapAccountableService service;

        public GetAllAccountablesHandler(IOapAccountableService service)
        {
            this.service = service;
        }

        public Task<IEnumerable<OapAccountable>> Handle(GetAllAccountablesRequest request, CancellationToken cancellationToken)
        {
            var accountables = service.GetAll();
            return Task.FromResult(accountables);
        }
    }
}