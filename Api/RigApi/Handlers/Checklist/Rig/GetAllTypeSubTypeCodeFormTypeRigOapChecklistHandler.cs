using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetAllTypeSubTypeCodeFormTypeRigOapChecklistHandler : IRequestHandler<GetAllTypeSubTypeCodeFormTypeRigOapChecklistRequest, IEnumerable<RigOapChecklist>>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public GetAllTypeSubTypeCodeFormTypeRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        public Task<IEnumerable<RigOapChecklist>> Handle(GetAllTypeSubTypeCodeFormTypeRigOapChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistService.GetByTypeSubTypeCodeFormType(request.TypeCode, request.SubTypeCode, request.FormType, request.Status);
            return Task.FromResult(cl);
        }

    }
}