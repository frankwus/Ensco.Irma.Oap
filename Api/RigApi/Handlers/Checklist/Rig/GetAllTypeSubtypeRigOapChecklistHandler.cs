using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetAllTypeSubTypeRigOapChecklistHandler : IRequestHandler<GetAllTypeSubTypeRigOapChecklistRequest, IEnumerable<RigOapChecklist>>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public GetAllTypeSubTypeRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        public Task<IEnumerable<RigOapChecklist>> Handle(GetAllTypeSubTypeRigOapChecklistRequest request, CancellationToken cancellationToken)
        {             
            var cl = RigOapChecklistService.GetByTypeSubType(request.TypeName, request.SubTypeName, request.Status);
            return Task.FromResult(cl);
        }
    }
}