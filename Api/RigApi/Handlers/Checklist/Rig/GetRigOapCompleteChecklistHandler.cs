using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
    using MediatR;

    public class GetRigOapCompleteChecklistHandler : IRequestHandler<GetRigOapCompleteChecklistRequest, RigOapChecklist>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public GetRigOapCompleteChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        Task<RigOapChecklist> IRequestHandler<GetRigOapCompleteChecklistRequest, RigOapChecklist>.Handle(GetRigOapCompleteChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistService.GetCompleteChecklist(request.RigOapChecklistId); 

            return Task.FromResult(cl);
        }
    }
}