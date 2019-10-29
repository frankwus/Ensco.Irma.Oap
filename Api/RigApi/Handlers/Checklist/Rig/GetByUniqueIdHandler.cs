using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetByUniqueIdHandler : IRequestHandler<GetByUniqueIdRequest, RigOapChecklist>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public GetByUniqueIdHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        Task<RigOapChecklist> IRequestHandler<GetByUniqueIdRequest, RigOapChecklist>.Handle(GetByUniqueIdRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistService.GetByUniqueId(request.RigOapChecklistUniqueId);
            return Task.FromResult(cl);
        }
    }
}