using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist.Lifesaver;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetLifesaverComplianceHandler : IRequestHandler<GetLifesaverComplianceRequest, LifesaverCompliance>
    {
        private readonly ILifesaverService service;

        public GetLifesaverComplianceHandler(ILifesaverService service)
        {
            this.service = service;
        }
        public Task<LifesaverCompliance> Handle(GetLifesaverComplianceRequest request, CancellationToken cancellationToken)
        {
            var result = service.GetComplianceStatus();
            return Task.FromResult(result);
        }
    }
}