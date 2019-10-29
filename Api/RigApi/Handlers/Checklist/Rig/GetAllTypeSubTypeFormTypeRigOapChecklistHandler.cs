using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetAllTypeSubTypeFormTypeRigOapChecklistHandler : IRequestHandler<GetAllTypeSubTypeFormTypeRigOapChecklistRequest, IEnumerable<RigOapChecklist>>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public GetAllTypeSubTypeFormTypeRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        public Task<IEnumerable<RigOapChecklist>> Handle(GetAllTypeSubTypeFormTypeRigOapChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistService.GetByTypeSubTypeFormType(request.TypeName, request.SubTypeName, request.FormType, request.Status);
            return Task.FromResult(cl);
        }

    }
}