using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SystemGroup;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.SystemGroup
{
    public class GetAllSystemGroupHandler : IRequestHandler<GetAllSystemGroupRequest, IEnumerable<OapSystemGroup>>
    {
        private IOapSystemGroupService SystemGroupService { get; set; }

        public GetAllSystemGroupHandler(IOapSystemGroupService systemGroupService)
        {
            SystemGroupService = systemGroupService;
        }

        Task<IEnumerable<OapSystemGroup>> IRequestHandler<GetAllSystemGroupRequest, IEnumerable<OapSystemGroup>>.Handle(GetAllSystemGroupRequest request, CancellationToken cancellationToken)
        {
            var list = SystemGroupService.GetAll();
            return Task.FromResult(list);
        }

    }
}