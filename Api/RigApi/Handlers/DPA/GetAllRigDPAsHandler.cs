using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap.DPA;
using Ensco.Irma.Oap.Api.Rig.Commands.DPA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.DPA
{
    public class GetAllRigDPAsHandler : IRequestHandler<GetAllRigDPAsRequest, IEnumerable<Irma.Models.Domain.Oap.DPA>>
    {        
        private readonly IOapDPAService service;

        public GetAllRigDPAsHandler(IOapDPAService service)
        {            
            this.service = service;
        }

        public Task<IEnumerable<Irma.Models.Domain.Oap.DPA>> Handle(GetAllRigDPAsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(service.GetAllRigDPAs(request.RigId));            
        }
    }
}