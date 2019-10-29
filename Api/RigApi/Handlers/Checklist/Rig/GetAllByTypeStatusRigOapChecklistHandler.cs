using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
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
    public class GetAllByTypeStatusRigOapChecklistHandler : IRequestHandler<GetAllByTypeStatusRigOapChecklistRequest, IEnumerable<RigOapChecklist>>
    {
        private readonly IRigOapChecklistService rigOapChecklistService;

        public GetAllByTypeStatusRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            this.rigOapChecklistService = rigOapChecklistService;
        }
        public Task<IEnumerable<RigOapChecklist>> Handle(GetAllByTypeStatusRigOapChecklistRequest request, CancellationToken cancellationToken)
        {
            var checklists = rigOapChecklistService.GetByTypeStatus(request.TypeName, request.Status);
            return Task.FromResult(checklists);
        }
    }
}