using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetAllInWorkflowByTypeSubTypeCodeVerifierRoleRigOapChecklistHandler : IRequestHandler<GetAllInWorkflowByTypeSubTypeCodeVerifierRoleRigOapChecklistRequest, IEnumerable<RigOapChecklist>>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public GetAllInWorkflowByTypeSubTypeCodeVerifierRoleRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        public Task<IEnumerable<RigOapChecklist>> Handle(GetAllInWorkflowByTypeSubTypeCodeVerifierRoleRigOapChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistService.GetByTypeSubTypeCode(request.TypeCode, request.SubTypeCode, request.Status);

            var checklist = (from c in cl
                             where (c.Status == request.Status) && c.VerifiedBy.Any(v => v.Role == request.VerifierRole)
                             select c);

            return Task.FromResult(checklist);
        }

    }
}
