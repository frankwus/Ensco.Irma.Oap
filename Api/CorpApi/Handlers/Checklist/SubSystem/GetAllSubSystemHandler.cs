using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SubSystem;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.SubSystem
{
    public class GetAllSubSystemHandler : IRequestHandler<GetAllSubSystemRequest, IEnumerable<OapSubSystem>>
    {
        private IOapSubSystemService SubSystemService { get; set; }

        public GetAllSubSystemHandler(IOapSubSystemService subSystemService)
        {
            SubSystemService = subSystemService;
        }

        Task<IEnumerable<OapSubSystem>> IRequestHandler<GetAllSubSystemRequest, IEnumerable<OapSubSystem>>.Handle(GetAllSubSystemRequest request, CancellationToken cancellationToken)
        {
            var list = SubSystemService.GetAll();
            return Task.FromResult(list);
        }

    }
}