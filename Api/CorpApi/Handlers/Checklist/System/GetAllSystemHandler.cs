using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.System;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.System
{
    public class GetAllSystemHandler : IRequestHandler<GetAllSystemRequest, IEnumerable<OapSystem>>
    {
        private IOapSystemService SystemService { get; set; }

        public GetAllSystemHandler(IOapSystemService systemService)
        {
            SystemService = systemService;
        }

        Task<IEnumerable<OapSystem>> IRequestHandler<GetAllSystemRequest, IEnumerable<OapSystem>>.Handle(GetAllSystemRequest request, CancellationToken cancellationToken)
        {
            var list = SystemService.GetAll();
            return Task.FromResult(list);
        }

    }
}