using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetRigOapChecklistHandler : IRequestHandler<GetRigOapChecklistRequest, RigOapChecklist>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public GetRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        Task<RigOapChecklist> IRequestHandler<GetRigOapChecklistRequest, RigOapChecklist>.Handle(GetRigOapChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistService.Get(request.RigOapChecklistId);
            return Task.FromResult(cl);
        }
    }
}